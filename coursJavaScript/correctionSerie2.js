const prompt = require("prompt-sync")()
//Exercice 3
//Récuperer la date du jour en javascript
// const dateJour = new Date(Date.now())
// console.log(dateJour.getMonth())

// const jour = parseInt(prompt("Votre jour de naissance : "))
// const mois = parseInt(prompt("Votre mois de naissance : "))
// const annee = parseInt(prompt("Votre année de naissance : "))
// if(diff(jour,mois, annee) >= 60) {
//     console.log("Vous avez la réduction sénior")
// }else {
//     console.log("Pas de réduction sénior pour vous")
// }

//console.log(seconde(14,5,13))
//console.log(divise(21,7))
const annee = prompt("Merci de saisir l'année : ")
const mois = prompt("Merci de saisir le mois : ")
console.log(nbJours(annee, mois))
function diff(jour, mois, annee) {
    //renvoie la date du jour en utilisant la fonction now() de javascript
    const dateJour = new Date(Date.now())
    let diffAnnee
    // const dateUtilisateur = new Date(annee, mois, jour)
    // const dateDiff = new Date(dateJour-dateUtilisateur)
    if(mois < dateJour.getMonth() || (mois == dateJour.getMonth() && jour < dateJour.getDate())){
        diffAnnee = dateJour.getFullYear() - annee
    }
    else {
        diffAnnee = dateJour.getFullYear() - annee - 1
    }
    return diffAnnee
}

function seconde(heure, minute, seconde) {
    return heure*3600+minute*60+seconde
}

//Exercice 1 Serie 2
function divise(a, b) {
    return a%b==0
}

function mois31(mois) {
    if((mois<=7 && mois%2!= 0) || (mois>=8 && mois%2 == 0)){
        return 1
    }else {
        return 0
    }
}

function mois30(mois) {
    if(mois == 2 || mois31(mois) == 1) {
        return 0
    }else {
        return 1
    }
}

function bissextile(annee) {
    if(annee%400==0 || (annee%4==0 && annee%100 != 100)){
        return 1
    }
    else {
        return 0
    }
}

function nbJours(annee, mois) {
    if(mois31(mois) == 1){
        return 31
    }
    else if(mois30(mois) == 1) {
        return 30
    }
    else {
        if(bissextile(annee) == 1){
            return 29
        }
        else {
            return 28
        }
    }
}