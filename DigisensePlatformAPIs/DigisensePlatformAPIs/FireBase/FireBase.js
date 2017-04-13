
var http = require('http');
var express = require('express');
var bodyParser = require('body-parser');

var cities = [{ name: 'Delhi', country: 'India' }, { name: 'New York', country: 'USA' }, { name: 'London', country: 'England' }];
var firebase = require("firebase");
var app = express();

app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());

app.get('/api/cities', function (request, response) {
    response.json([{ "foo": "bar", "name": "Mr Zaid Khan", "country": "India" }, { "foo": "Fa", "name": "Mr Fa  Khan", "country": "UK" }, { "foo": "KK", "name": "Mr NAAA", "country": "CA" }, { "foo": "bar", "name": "Mr YT", "country": "AUS" }]);
});

app.get('/api/cities/:name', function (request, response) {
    for (var index = 0; index < cities.length; index++) {
        if (cities[index].name === request.params.name) {
            response.send(cities[index]);
            return;
        }
    }
});

app.post('/api/cities', function (request, response) {
    var city = request.body;
    console.log(city);
    for (var index = 0; index < cities.length; index++) {
        if (cities[index].name === city.name) {
            response.status(409).send({ error: "City already exists" });
            return;
        }
    }

    cities.push(city);
    response.send(cities);
});

app.put('/api/cities/:name', function (request, response) {
    var city = request.body;
    console.log(city);
    for (var index = 0; index < cities.length; index++) {
        if (cities[index].name === request.params.name) {
            cities[index].country = city.country;
            response.send(cities);
            return;
        }
    }

    response.status(404).send({ error: 'City not found' });
});

app.listen(3000, function () {
    console.log("Listening on port 3000...");
});