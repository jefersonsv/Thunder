REM https://docs.microsoft.com/pt-br/dotnet/core/tools/custom-templates
nuget pack .\template\Startup\Thunder.Web.Framework.Template.nuspec
nuget push *.nupkg -Source https://api.nuget.org/v3/index.json
del /f /s /q *.nupkg