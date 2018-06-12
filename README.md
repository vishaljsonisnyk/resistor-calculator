# resistor-calculator
#### A Simple Angular 6 (client) and ASP.Net Web Api 2 (server) project to calculate the resistance of resistors.
This simple app use Electric color code rings to calculate the resistance for the resistors. A user can pick one or all four color bands for a resistor to check the calculated resistance. As user picks up a respective color band, and image represents what he picked and how resistor will be color coded for further use.

For more details please check this wiki link: https://en.wikipedia.org/wiki/Electronic_color_code

#### Notes:
1. **Used tools:** Visual Studio 2017 (.NET fw 4.6.1), Visual Code
2. **Used package manager:** Nuget Package manager, npm
3. **Used enviornments:** .NET 4.6.1, Node v8.11.2, npm v6.0.0
4. **Serverside Projects:** ResistorRating.Api, ResistorRating.Library
5. **Unit Test Project:** ResistorRating.Test
6. **Frontend Project/Folder:** ResistorRating.Web

Please use mentioned website for the live demo: http://resistorcalc-web.azurewebsites.net/index.html

#### How to setup this project in local machine?
###### Notes for developers:
###### Server side notes:
1. Clone or download this repositoary in your local machine.
2. Make sure you have all above mentioned/tools already set-up in your local machine.
3. Open ResistorRatingCalculator.sln file, which should open visual studio.
4. First time opening of a project and loading it may take some time, it Nuget Package manager will try to resolve all the dependencies automatically. If it fails, go to Tools -> Nuget Package Manager -> Manage packages for solution -> Resolve packages.
5. Just for the confirmation, run all tests asociated in ResistorRating.Test project. They all shall pass.
6. Get the ResistorRating.Api project's properties. Select a Web tab in properties. Copy Project Url for later use. Default should be: http://localhost:51487/
7. If not, please set ResistorRating.Api as solution's start up project and Start Debugging the solution. (click F5)

###### Client side notes:
1. Go to downloaded directory for this repo.
2. Right click on ResistorRating.Web folder and  select "Open with visual code"
3. Open integrated terminal, run this command: `npm install`
4. Go to this folder in visual code: .\src\app\services\datacontext
5. Open lookup-repo.service.ts and resistor-calc-repo.service.ts files and change the _restBaseApi variable path to local ResistorRating.Api's target path. For example http://localhost:51487/api (Line# 10)
6. Save both the files and we are all set to run our client side app too.
7. Go to Visual code's integrated terminal again and run this command: `ng serve -o`

Above command will build an angular app and open your browser and load the Resistor Rating Calculator app. You can play with the app and test it, change it at your own will.
