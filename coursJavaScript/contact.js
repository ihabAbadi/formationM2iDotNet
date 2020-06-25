const prompt = require("prompt-sync")()
let contacts = []
//On Demande à l'utilisateur de saisir une liste de contacts, chaque contact posséde un nom, prénom, telephone,
//On arrete la saisie quand l'utilisateur saisie -1
let choix
do {
    menu()
    choix = parseInt(prompt("Votre choix : "))
    switch(choix){
        case 1:
            ajouterContact()
            break;
        case 2:
            break;
        case 3:
            console.log(contacts)
            break;
    }
}while(choix != 0)

function menu() {
    console.log("1--Ajouter un contact")
    console.log('2-- Rechercher un contact par nom')
    console.log('3-- Afficher tableau des contacts')
    console.log("0-- Quitter")
}

function ajouterContact() {
    let contact = []
    let nom = prompt("Merci de saisir le nom du contact : ")
    let prenom = prompt("Merci de saisir le prénom du contact : ")
    let telephone = prompt("Merci de saisir le téléphone du contact : ")
    contact.push(nom, prenom, telephone)
    contacts.push(contact)
}