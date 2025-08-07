# Ball 3D Tournament System

A comprehensive web-based tournament management system designed for Ball 3D gaming competitions. This application allows users to create and manage single-elimination tournaments, form teams, register for competitions, and track game results in real-time.

## ✨ Features

### 🏆 Tournament Management
- **Single Elimination Tournaments**: Create bracket-style tournaments with automatic fixture generation
- **Tournament Lifecycle**: Support for upcoming, active, and completed tournaments
- **Real-time Bracket Updates**: Dynamic bracket progression as games are completed
- **Multi-Stadium Support**: Various stadium options (Classic, Small, Real Football, Small Pong)
- **Game Server Integration**: Support for different server types (EU Dedicated, USA Dedicated, Hosted Server)

### 👥 Team Management
- **Team Creation**: Users can create and manage their own teams
- **Team Invitations**: Generate unique invite links for team recruitment
- **Player Management**: Add/remove players from teams
- **Team Registration**: Register teams for tournaments with admin confirmation

### 🎮 Game Management
- **Score Tracking**: Record and confirm match results
- **Result Verification**: Dual confirmation system requiring both teams to verify scores
- **Game History**: Complete match history and statistics
- **Protest System**: Built-in dispute resolution for contested results

### 👤 User System
- **Role-based Access**: Admin and Member roles with different permissions
- **User Authentication**: Secure login system with ASP.NET Core Identity
- **Profile Management**: User account management and team affiliations

## 🛠️ Technologies Used

### Backend
- **Framework**: ASP.NET Core 3.1
- **Architecture**: Clean Architecture with separate layers
- **Database**: Entity Framework Core with SQL Server
- **Authentication**: ASP.NET Core Identity

### Frontend
- **Framework**: ASP.NET Core MVC with Razor Views
- **UI Components**: Bootstrap for responsive design
- **Areas**: Separate areas for Admin and Member functionality

### Database
- **ORM**: Entity Framework Core
- **Database**: SQL Server
- **Migrations**: Code-first approach with automatic migrations
- **Seeding**: Default data initialization for game servers and stadiums


## 🚀 Getting Started

### Prerequisites
- .NET Core 3.1 SDK or later
- SQL Server (LocalDB or full instance)
- Visual Studio 2019+ or VS Code

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/sercanbayrambey/SB.Ball3DTournamentSystem.git
   cd SB.Ball3DTournamentSystem
   ```

2. **Set up the database**
   ```bash
   cd SB.Ball3DTournamentSys.Web
   dotnet ef database update
   ```

3. **Run the application**
   ```bash
   dotnet run
   ```

4. **Access the application**
   - Open your browser and navigate to `https://localhost:5001`
   - Default admin credentials: `compo` / `123456`

### Default Data
The system automatically seeds with:
- **Game Servers**: EU Dedicated, USA Dedicated, Hosted Server
- **Stadiums**: Classic, Small, Real Football, Small Pong
- **Admin User**: Username `compo`, Password `123456`

## 📱 Usage

### For Tournament Organizers (Admins)
1. **Create Tournaments**: Set up new tournaments with game settings
2. **Manage Registrations**: Confirm team registrations
3. **Start Tournaments**: Generate brackets and begin competitions
4. **Monitor Progress**: Track game results and resolve disputes

### For Players (Members)
1. **Create Teams**: Form teams and invite other players
2. **Register for Tournaments**: Join available tournaments
3. **Report Results**: Submit match scores for verification
4. **Track Progress**: View tournament brackets and match history

## 🎯 Key Components

### Tournament Features
- **Bracket Generation**: Automatic single-elimination bracket creation
- **Bye System**: Handles non-power-of-2 participant counts
- **Score Limits**: Configurable winning conditions
- **Overtime Support**: Optional overtime rules

### Security Features
- **Authentication**: Secure user login system
- **Authorization**: Role-based access control
- **Data Validation**: Comprehensive input validation
- **Anti-forgery Tokens**: CSRF protection

## 📸 Screenshots

![Tournament List](https://user-images.githubusercontent.com/45638332/97360721-9bf80c00-18af-11eb-84d7-97799207a0b3.png)
![Tournament Bracket](https://user-images.githubusercontent.com/45638332/97360752-a6b2a100-18af-11eb-895d-ecdd5f1d45cc.png)
![Team Management](https://user-images.githubusercontent.com/45638332/97360791-b631ea00-18af-11eb-91a5-8363fb0a3d92.png)
![Game Results](https://user-images.githubusercontent.com/45638332/97361019-0a3cce80-18b0-11eb-95a3-f1500bc9baf3.png)
![Tournament Registration](https://user-images.githubusercontent.com/45638332/97361063-1759bd80-18b0-11eb-8220-c65e084a323d.png)

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👨‍💻 Author

**Sercan Bayrambey**
- GitHub: [@sercanbayrambey](https://github.com/sercanbayrambey)


