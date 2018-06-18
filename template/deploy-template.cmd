REM https://docs.microsoft.com/pt-br/dotnet/core/tools/custom-templates
del /f /s /q *.nupkg
nuget pack .\Thunder.Web.Framework.Template.nuspec
nuget push *.nupkg -Source https://api.nuget.org/v3/index.json
del /f /s /q *.nupkg