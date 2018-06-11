package main

import (
	"github.com/kataras/iris"

	//"github.com/kataras/iris/middleware/logger"
	//"github.com/kataras/iris/middleware/recover"
)

func main() {
	app := iris.New()
	// Optionally, add two built'n handlers
	// that can recover from any http-relative panics
	// and log the requests to the terminal.
	
	// same as app.Handle("GET", "/ping", [...])
	// Method:   GET
	// Resource: http://localhost:8080/ping
	app.Get("/hello", func(ctx iris.Context) {
		ctx.WriteString("Hello from /hello")
	})

	// http://localhost:8080/hello
	app.Run(iris.Addr(":5002"), iris.WithoutServerError(iris.ErrServerClosed))
}
