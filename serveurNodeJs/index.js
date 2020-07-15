const express = require('express')
const cors = require('cors')

const bodyParser = require('body-parser')
const app = express()

const fs = require('fs')

const data = [
    {nom : 'toto', prenom : 'tata'},
    {nom : 'minet', prenom : 'titi'},
    {nom : 'toto', prenom : 'tata'},
]
// const annonces = [
//     {title : 'annonce 1', description : 'contenu annonc 1', images : []},
//     {title : 'annonce 2', description : 'contenu annonc 2', images : []},
//     {title : 'annonce 3', description : 'contenu annonc 3', images : []},
// ]

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
    const contenuFichierAnnonces = fs.readFileSync('annonces.json')
    //JSON.parse => convertir une chaine de caractère en objet json quand c'est possible
    const annonces = JSON.parse(contenuFichierAnnonces)
    annonces.push(req.body)
    //On ecrit des chaines de caractères dans notre fichier annonces.json => JSON.stringify pôur convertir un objet en chaine de caractère
    fs.writeFileSync('annonces.json', JSON.stringify(annonces))
    res.json({msg : 'annonce ajoutée'})
})

app.get('/annonces', (req, res) => {
    const contenuFichierAnnonces = fs.readFileSync('annonces.json')
    const annonces = JSON.parse(contenuFichierAnnonces)
    res.json(annonces)
})
app.get('/annonce/:title', (req, res) => {
    const title = req.params.title
    const contenuFichierAnnonces = fs.readFileSync('annonces.json')
    const annonces = JSON.parse(contenuFichierAnnonces)
    const annonce = annonces.find(element => element.title == title)
    res.json(annonce)
})
app.listen(80,function(){
    // console.log("une nouvelle connexion")
})