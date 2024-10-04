# ProjectGameDevelopment

This is a 2D platform game developed using MonoGame and C#. Follow the instructions below to set up and run the game on your local machine.

## Prerequisites

Before you begin, ensure you have the following installed:
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) (Community edition or higher)
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [MonoGame](https://www.monogame.net/downloads/) (version 3.8.1 or later)

### Visual Studio 2022 Components

When installing or modifying Visual Studio 2022, make sure you have the following components selected in the Visual Studio Installer:

- .NET Core cross-platform development
- Mobile development with .NET
- Universal Windows Platform development
- .NET desktop development

## Setup Instructions

1. **Install Visual Studio 2022**
   If you haven't already installed Visual Studio 2022, download it from the [official website](https://visualstudio.microsoft.com/vs/). During installation, make sure to select the components listed above.

   If you already have Visual Studio 2022 installed, you can modify your installation:
   - Open the Visual Studio Installer
   - Click "Modify" next to your Visual Studio 2022 installation
   - Ensure the components listed above are selected
   - Click "Modify" to update your installation

2. **Verify .NET 8 SDK Installation**
   Open a command prompt and run:
   ```
   dotnet --version
   ```
   Ensure the output starts with 8.x.x. If not, download and install .NET 8 SDK from the official Microsoft website.

3. **Clone the Repository**
   ```
   git clone https://github.com/Lenaerts-Nestor/Project_Game_Development.git
   cd ProjectGameDevelopment
   ```

4. **Install MonoGame Templates**
   Run the following command:
   ```
   dotnet new --install MonoGame.Templates.CSharp
   ```

5. **Install Required NuGet Packages**
   Run these commands in your project directory:
   ```
   dotnet add package Apos.Gui --version 1.0.11
   dotnet add package MonoGame.Content.Builder.Task --version 3.8.1.303
   dotnet add package MonoGame.Framework.WindowsDX --version 3.8.1.303
   ```

6. **Install Visual Studio 2022 Extensions**
   - Open Visual Studio 2022
   - Go to Extensions > Manage Extensions
   - Search for and install:
     - "MonoGame Project Templates"
     - "Tiled2Unity" (for map integration)

7. **Configure Content Pipeline**
   - Right-click on the project in Solution Explorer
   - Select "Edit Project File"
   - Ensure the following line is present:
     ```xml
     <MonoGameContentBuilderExe>mgcb</MonoGameContentBuilderExe>
     ```

8. **Build the Project**
   Run this command in your project directory:
   ```
   dotnet build
   ```

9. **Run the Game**
   - Open the solution in Visual Studio 2022
   - Press F5 or select Debug > Start Debugging

## Troubleshooting

- If you're missing certain project templates or facing unexpected errors, ensure that you have all the required Visual Studio components installed as listed in the Prerequisites section.
- If you encounter any issues with dependencies, try cleaning the solution (Build > Clean Solution) and then rebuilding.
- Ensure all required content files are present in the Content folder and properly referenced in the Content.mgcb file.
- Make sure you're using .NET 8 for the project. You can check this in the project properties under the "Application" tab.
- If you have trouble running PowerShell scripts, you may need to change the execution policy:
  1. Open PowerShell as administrator
  2. Run: `Set-ExecutionPolicy RemoteSigned`
  3. Confirm the change when prompted

## Credits

This game uses various resources and was inspired by several tutorials:

- Jump mechanics: [Flatformer Blog](https://flatformer.blogspot.com/)
- Screen management: [MonoGame Extended Documentation](https://www.monogameextended.net/docs/features/screen-management/screen-management)
- Textures (sprite pack + tilemap): [GrafxKid on itch.io](https://grafxkid.itch.io/)
- Font: Custom-made
- Map and collision via Tiled: [MonoGame Extended Tiled Documentation](https://www.monogameextended.net/docs/features/tiled/tiled/)
- Additional collision concepts: [Archive of Wild Bunny Blog](https://web.archive.org/web/20191208231225/https://wildbunny.co.uk/blog/2011/12/14/how-to-make-a-2d-platform-game-part-2-collision-detection/)
- Movement, Input, Animation, Hero and Enemy mechanics, and hitbox: Based on school projects and tutorials

## Support

If you encounter any issues or have questions, please open an issue in the GitHub repository.

Enjoy the game!
