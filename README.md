# Thunder
Thunder web framework where productivity and performance go together

# Getting Started
```
dotnet new -i Thunder.Web.Framework
```
# Simple usage
The simple usage configure a custom route **/hello** and render *.html inside all directories of **.\wwwroot**

```c#
Server.Get("/hello", context => context.Response.WriteAsync("Hello from /hello"));
Server.SetViews(".\\wwwroot");
Server.Run();
```