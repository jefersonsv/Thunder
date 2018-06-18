@ECHO OFF
ECHO 	Testing .NET Core Thunder
ECHO 	=========================
.\lib\bombardier  -c 125 -n 100000 http://localhost:5000/hello
ECHO 	Testing GO iris
ECHO 	===============
.\lib\bombardier  -c 125 -n 100000 http://localhost:5002/hello
pause