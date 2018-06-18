# Thunder
Thunder web framework where productivity and performance go together

## Benchmark comparative
The folder ` .\benchmarks ` contains some battles of Thunder web framework against Iris (golang), Flask (python), Expressjs (nodejs)

![battle Thunder vs Iris](https://raw.githubusercontent.com/thunder/benchmarks/battle-dotnet-vs-golang.gif)

> Throughput Thunder (.NET Core): 6.31MB/s
> Throughput Iris (golang): 6.28MB/s

## How can I get it? (template mode)

1. Install the latest .NET Core SDK.
2. Run ` dotnet new -i "Thunder.Web.Framework.Template::*" ` to install the project template.
3. Run ` dotnet new thunder --help ` to see how to select the feature of the project.
4. Run ` dotnet new thunder --name "FastestServer" ` to create a project from the template.

## How can I get it? (nuget references)

1. Install the latest .NET Core SDK.
2. Create a new .NET Core console application.
3. PM> ` Install-Package Thunder.Web.Framework `.

## Simple usage
The simple usage configure a custom route **/hello** and render *.html inside all directories of **.\wwwroot**

```c#
Server.Get("/hello", context => context.Response.WriteAsync("Hello from /hello"));
Server.SetViews(".\\wwwroot");
Server.Run();
```
## To uninstall template
```
dotnet new -u "Thunder.Web.Framework.Template::*"
```