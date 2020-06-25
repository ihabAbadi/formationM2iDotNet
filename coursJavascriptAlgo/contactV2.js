const prompt = require("prompt-sync")()
let contacts = []
//On Demande à l'utilisateur de saisir une liste de contacts, chaque contact posséde un nom, prénom, telephone,
//On arrete la saisie quand l'utilisateur saisie 0
let choix
do {
    menu()
    choix = parseInt(prompt("Votre choix : "))
    switch(choix){
        case 1:
            ajouterContact()
            break;
        case 2:
            rechercherContactParNom()
            break;
        case 3:
            console.log(contacts)
            break;
    }
}while(choix != 0)

function menu() {
    console.log("1-- Ajouter un contact")
    console.log('2-- Rechercher un contact par nom')
    console.log('3-- Afficher tableau des contacts')
    console.log("0-- Quitter")
}

function ajouterContact() {
    let contact = {
        nom : '',
        prenom : '',
        telephone : ''
    }
    contact['nom'] = prompt("Merci de saisir le nom du contact : ")
    contact['prenom'] = prompt("Merci de saisir le prénom du contact : ")
    contact['telephone'] = prompt("Merci de saisir le téléphone du contact : ")
    // contact.push(nom, prenom, telephone)
    contacts.push(contact)
}

function rechercherContactParNom() {
    let nomRecherche = prompt("Merci de saisir le nom : ")
    for(let i=0; i< contacts.length; i++) {
        if(contacts[i]['nom'] == nomRecherche) {
            console.log("Nom : "+contacts[i]['nom']+" Prénom : "+contacts[i]["prenom"]+" Téléphone : "+contacts[i]["telephone"])
        }
    }
}

// let tab = ['toto', 'tata', true]
// let obj = {
//     'cle1':'valeurCle1',
//     'cle2':'valeurCle2',
//     'cle3':false
// }
//Les clés sont des chaines de caractères
//Les valeurs peuvent être de n'importe quel type (number, boolean, tableau, objet...)
// // console.log(tab)
// // for(let i=0; i<tab.length;i++) {
// //     console.log(tab[i])
// // }
// //console.log(obj)
// //une autre version de la boucle for
// for(let cle in obj){
//     console.log(cle +" : "+obj[cle])
// }