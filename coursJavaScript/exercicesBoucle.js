const prompt = require('prompt-sync')()
//Exercice 1
// const prompt = require('prompt-sync')()
// let nombre, i, max, position
// i = 1
// do {
//     nombre = prompt("Merci de saisir le chiffre n° "+ i + " : ")
//     nombre = parseInt(nombre)
//     if(i == 1 || max < nombre) {
//         max = nombre
//         position = i
//     }
//     i++
// }while(nombre != 0)
// console.log("Le max est " + max + " à la position : " + position)
//Exercice 2
// let nombreHabitant = parseInt(prompt("Merci de saisir le nombre d'habitant : "))
// const nombreHabitantCible = parseInt(prompt("Merci de saisir le nombre d'habitant cible : "))
// const taux = parseFloat(prompt("Merci de saisir le taux de croissement annuel : "))
// let annee = 2013

// while(nombreHabitant < nombreHabitantCible) {
//     // console.log(annee++)
//     // console.log(++annee)
//     annee++
//     console.log("h : "+ nombreHabitant + " c : "+ nombreHabitantCible + " t : " + taux)
//     nombreHabitant = nombreHabitant * (1 + taux/100)
// }
// console.log("Le nombre d'habitant cible sera atteint en "+ annee)
//Exercice 3
const n = parseInt(prompt("Merci de saisir un nombre : "))
let message =""
// for(let i = 1 ; i <= n; i++) {
//     message += " "+i+" "
//     console.log(message)
// }

for(let i = 1; i <= n; i++) {
    message = ""
    for(let j = 1; j <= i; j++) {
        message += " "+ j + " " 
    }
    console.log(message)
}