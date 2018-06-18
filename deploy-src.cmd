REM https://docs.microsoft.com/pt-br/dotnet/core/tools/custom-templates
rd /s /q .\src\Thunder\bin\Release
dotnet build -c Release .\src\Thunder\Thunder.csproj
nuget push .\src\Thunder\bin\Release\*.nupkg -Source https://api.nuget.org/v3/index.json
del /f /s /q .\src\Thunder\bin\Release\*.nupkg