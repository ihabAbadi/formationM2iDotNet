const express = require('express')
const cors = require('cors')
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

app.use((req,res,next) => {
    res.header('Access-Control-Allow-Origin', '*')
    res.header('Access-Control-Allow-Methods', 'GET, POST, OPTIONS')
    next()
})

app.get('/',(req,res) => {
    res.json({msg:'bonjour tout le monde'})
})

app.get('/personne',(req,res) => {
    res.json(data)
})

app.get('/annonces', (req, res) => {
    
    res.json(annonces)
})

app.listen(80,function(){
    console.log("une nouvelle connexion")
})