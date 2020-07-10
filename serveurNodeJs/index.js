const express = require('express')
const cors = require('cors')

const bodyParser = require('body-parser')
const app = express()

const data = [
    {nom : 'toto', prenom : 'tata'},
    {nom : 'minet', prenom : 'titi'},
    {nom : 'toto', prenom : 'tata'},
]
const annonces = [
    {title : 'annonce 1', description : 'contenu annonc 1', images : []},
    {title : 'annonce 2', description : 'contenu annonc 2', images : []},
    {title : 'annonce 3', description : 'contenu annonc 3', images : []},
]

//Autoriser les requetes quelque soit l'origin
app.use((req,res,next) => {
    res.header('Access-Control-Allow-Origin', '*')
    res.header('Access-Control-Allow-Methods', 'GET, POST, OPTIONS')
    res.header('Access-Control-Allow-Headers', '*')
    next()
})

//analyser et parser le body request
app.use(bodyParser.json())

app.get('/',(req,res) => {
    res.json({msg:'bonjour tout le monde'})
})

app.get('/personne',(req,res) => {
    res.json(data)
})

app.post('/addAnnonce', (req, res) => {
    console.log(req.body)
    annonces.push(req.body)
    res.json({msg : 'annonce ajoutée'})
})

app.get('/annonces', (req, res) => {
    
    res.json(annonces)
})

app.listen(80,function(){
    console.log("une nouvelle connexion")
})