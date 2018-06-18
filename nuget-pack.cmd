REM https://docs.microsoft.com/pt-br/dotnet/core/tools/custom-templates
rd /s /q .\src\Thunder\bin
rd /s /q .\src\Thunder\obj
rd /s /q .\src\Thunder\lib
del /f /s /q *.nupkg
dotnet build .\src\Thunder\Thunder.csproj -o .\lib\netcoreapp2.1
rd /s /q .\src\Thunder\bin
rd /s /q .\src\Thunder\obj
nuget pack .\src\Thunder\Thunder.Web.Framework.nuspec
nuget push *.nupkg -Source https://api.nuget.org/v3/index.json
del /f /s /q *.nupkg