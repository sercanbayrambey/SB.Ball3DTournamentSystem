﻿using SB.Ball3DTournamentSys.Business.Interfaces;
using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SB.Ball3DTournamentSys.Business.Concrete
{
    public class FixtureManager : IFixtureService
    {
        public List<TeamEntity> Teams { get; private set; }
        public int TournamentId { get; private set; }

        private List<TournamentBracketRoundEntity> rounds;

        private List<PlayedGamesEntity> gamesToBePlayed;

        private readonly ITournamentBracketRoundService _tournamentBracketRoundService;
        private readonly IPlayedGamesService _playedGamesService;

        public FixtureManager(IPlayedGamesService playedGamesService)
        {
            _playedGamesService = playedGamesService;
        }

        public FixtureManager(List<TeamEntity> teams = null, int tournamentId = 0, ITournamentBracketRoundService tournamentBracketRoundService = null, IPlayedGamesService playedGamesService = null)
        {
            Teams = teams;
            TournamentId = tournamentId;
            _tournamentBracketRoundService = tournamentBracketRoundService;
            _playedGamesService = playedGamesService;
            gamesToBePlayed = new List<PlayedGamesEntity>();
            rounds = new List<TournamentBracketRoundEntity>();
        }


        public void GenerateFixture()
        {
            try
            {
                //Select first N Teams for first round
                if (!MathManager.isPowerOfTwo(Teams.Count))
                {
                    int playerCount = Teams.Count;
                    int smallestPowerOf2 = MathManager.FindSmallestPowerOf2AsLargeAsParam(playerCount);
                    int firstRoundPlayerCount = (2 * playerCount) - smallestPowerOf2;
                    GenerateFirstNonPowerOf2Round(firstRoundPlayerCount);
                    return;
                }



                for (int i = 0; i < Teams.Count / 2; i++)
                {
                    PlayedGamesEntity game = new PlayedGamesEntity { RoundMatchId = i, HomeTeamId = Teams[i].Id, AwayTeamId = Teams[Teams.Count - (i + 1)].Id, RoundNumber = 1 };
                    gamesToBePlayed.Add(game);
                }

                TournamentBracketRoundEntity round = new TournamentBracketRoundEntity { RoundNumber = 1, TournamentId = TournamentId };

                rounds.Add(round);
                GenerateNextRounds(Teams.Count / 2, 2, TournamentId, null);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private void GenerateFirstNonPowerOf2Round(int firstRoundPlayerCount)
        {
            List<TeamEntity> teams = Teams.Take(firstRoundPlayerCount).ToList();
            int roundMatchIdCounter = 0;

            for (int i = 0; i < firstRoundPlayerCount / 2; i++)
            {
                PlayedGamesEntity game = new PlayedGamesEntity { RoundMatchId = i, HomeTeamId = teams[i].Id, AwayTeamId = teams[teams.Count - (i + 1)].Id, RoundNumber = 1 };
                Teams[i] = null;
                Teams[teams.Count - (i + 1)] = null;
                gamesToBePlayed.Add(game);
                roundMatchIdCounter++;
            }

            // adds null oppenent to first round bye's teams
            List<TeamEntity> passedTeams = Teams.Skip(firstRoundPlayerCount).ToList();
            for (int i = 0; i < passedTeams.Count; i++)
            {
                PlayedGamesEntity game = new PlayedGamesEntity { RoundMatchId = roundMatchIdCounter, HomeTeamId = passedTeams[i].Id, AwayTeamId = null, RoundNumber = 1, IsFinished=true };
                game.IsAwayTeamConfirmedResult = true;
                game.IsHomeTeamConfirmedResult = true;
                gamesToBePlayed.Add(game);
                roundMatchIdCounter++;
            }

            TournamentBracketRoundEntity round = new TournamentBracketRoundEntity { RoundNumber = 1, TournamentId = TournamentId };
            rounds.Add(round);
            var passedTeamCount = Teams.Count - (MathManager.FindSmallestPowerOf2AsLargeAsParam(Teams.Count) / 2);
            GenerateNextRounds(MathManager.FindSmallestPowerOf2AsLargeAsParam(Teams.Count) / 2, 2, TournamentId, passedTeamCount);
        }

        public void GenerateNextRounds(int teamCount, int round, int tournamentId, int? passedTeamCount)
        {
            try
            {
                if (teamCount == 1)
                {
                    SaveEntitiesToDb();
                    return;
                }


                if (!MathManager.isPowerOfTwo(Teams.Count) && round == 2)
                {
                    //In this case, teamCount parameter represents passed team count at 1 st round
                    var teamListOn2ndRound = Teams.Where(I => I != null).ToList();
                    int firstRoundGameCount = gamesToBePlayed.Count;

                    int counter = 0;
                    for(int i =0;i<firstRoundGameCount;i++)
                    {
                        PlayedGamesEntity game = new PlayedGamesEntity();
                        game.RoundMatchId = counter;
                        game.HomeTeamId = GetPassedTeamId(gamesToBePlayed[i]) ?? null;
                        game.AwayTeamId = GetPassedTeamId(gamesToBePlayed[i + 1])?? null;
                        game.RoundNumber = round;
                        gamesToBePlayed.Add(game);
                        counter++;
                        i++;
                    }
                   
                }
                else
                {
                    for (int i = 0; i < teamCount / 2; i++)
                    {
                        PlayedGamesEntity game = new PlayedGamesEntity { RoundMatchId = i, RoundNumber = round };
                        gamesToBePlayed.Add(game);
                    }
                }


                TournamentBracketRoundEntity _round = new TournamentBracketRoundEntity { RoundNumber = round, TournamentId = tournamentId };

                rounds.Add(_round);
                GenerateNextRounds(teamCount / 2, round + 1, tournamentId, null);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void SaveEntitiesToDb()
        {
            foreach (var item in rounds)
            {
                _tournamentBracketRoundService.Add(item);
            }

            var roundId = _tournamentBracketRoundService.GetRoundIdByTournamentId(TournamentId);
            foreach (var item in gamesToBePlayed)
            {
                item.RoundId = roundId;
                _playedGamesService.Add(item);
            }
        }

        public PlayedGamesEntity FindTheNextTableForGame(PlayedGamesEntity playedGame)
        {

            playedGame.RoundNumber++;
            playedGame.RoundMatchId = FindNextRoundMatchId(playedGame);
            var playedGamesEntity = _playedGamesService.GetAllByRoundId(playedGame.RoundId);
            var newTable = playedGamesEntity.Where(I => I.RoundMatchId == playedGame.RoundMatchId && I.RoundNumber == playedGame.RoundNumber).FirstOrDefault();
            return newTable;
        }

        private int FindNextRoundMatchId(PlayedGamesEntity playedGame)
        {       
            // RoundMatchId 0 - 1 = Next match will be 0
            // RoundMatchId 2-3 = Next Match will be 1
            // RoundMatchId 4-5 = Next match will be 2

            //Algoritm: 
            //            if the RoundMatchId is 0 or 1 = next match rounId be 0
            //for others: if the RoundMatchId is even next match roundMatchId will be RoundMatchId/2
            //            if the RoundMatchId is odd next match roundMatchId will be Math.Floor(RoundMatchId/2)

            if (playedGame.RoundMatchId == 0 || playedGame.RoundMatchId == 1)
                playedGame.RoundMatchId = 0;
            else if (playedGame.RoundMatchId % 2 == 0)
                playedGame.RoundMatchId /= 2;
            else
                playedGame.RoundMatchId = (int)Math.Floor((decimal)playedGame.RoundMatchId / 2);

            return playedGame.RoundMatchId;
        }

        private int? GetPassedTeamId (PlayedGamesEntity game)
        {
            if (game.HomeTeamId != null && game.AwayTeamId == null)
                return game.HomeTeamId;
            if (game.HomeTeamId == null && game.AwayTeamId != null)
                return game.AwayTeamId;
            if (game.HomeTeamId != null && game.AwayTeamId != null)
                return null;

            return null;
        }



    }
}
