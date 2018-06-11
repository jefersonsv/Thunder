@ECHO OFF
ECHO Testing .NET Core Thunder
ECHO =========================
.\lib\bombardier  -c 125 -n 100000 http://localhost:5000/hello
ECHO Testing GO iris
ECHO ===============
.\lib\bombardier  -c 125 -n 100000 http://localhost:5002/hello
ECHO Testing Python Flask
ECHO ====================
.\lib\bombardier  -c 125 -n 100000 http://localhost:5003/hello
ECHO Testing Node.js Express.js
ECHO ==========================
.\lib\bombardier  -c 125 -n 100000 http://localhost:5004/hello
pause