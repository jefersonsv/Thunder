REM https://docs.microsoft.com/en-us/dotnet/core/tools/custom-templates
REM https://github.com/dotnet/dotnet-template-samples
del /f /s /q *.nupkg
nuget pack .\Thunder.Web.Framework.Template.nuspec
nuget push *.nupkg -Source https://api.nuget.org/v3/index.json
del /f /s /q *.nupkg