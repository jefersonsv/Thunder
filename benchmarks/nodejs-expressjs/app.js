var express = require('express');
var app = express();

app.get('/hello', function (req, res) {
  res.send('Hello from /hello');
});

app.listen(5004, function () {
  console.log('Example app listening on port 5004!');
});
