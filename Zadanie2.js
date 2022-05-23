var mysql = require('mysql');
const express = require('express');
var app = express();
const bodyparser = require('body-parser')

app.use(bodyparser.json)

var mysqlConnection = mysql.createConnection({
    host:'localhost',
    user:'root',
    password:'Nathan_musoko123',
    database:'StudentsInfo'
});
mysqlConnection.connect((err)=>{
    if (err)
    console.log("Db is not connected");
    else
    console.log("db is  connected");
});

app.listen(3000,()=>console.log('Express Server is running at 3000'));
app.get('/StudentsInfo' , (res , req) =>({
    mysqlConnection.query('SELECT * FROM Students' , (err , rows , fields)=>{
        if(!err)
        console.log(rows);
        else 
        console.log(err);
    });
}));
