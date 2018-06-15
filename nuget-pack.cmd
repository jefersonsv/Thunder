REM https://docs.microsoft.com/pt-br/dotnet/core/tools/custom-templates
rd /s /q .\src\Thunder\bin
rd /s /q .\src\Thunder\obj
del /f /s /q *.nupkg
nuget pack .\src\Thunder\Thunder.Web.Framework.nuspec
nuget push *.nupkg -Source https://api.nuget.org/v3/index.json
del /f /s /q *.nupkg
nuget pack .\src\Thunder\Thunder.Web.Framework.Template.nuspec
nuget push *.nupkg -Source https://api.nuget.org/v3/index.json