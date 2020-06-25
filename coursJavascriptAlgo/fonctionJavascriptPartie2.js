//Créer une fonction avec un stockage dans une variable
// const direBonjour = function(nom) {
//     //console.log("Bonjour tout le monde")
//     return "Bonjour "+nom
// }

// console.log(direBonjour("abadi"))

// //Fonction anonyme
// (function() {
//     console.log("je suis une fonction anonyme")
// })()
//Fonction anonyme avec des paramètres
// (function(a) {
//     console.log("je suis une fonction anonyme avec le paramètre : "+ a)
// })("test")

//Fonction de callBack <=> fonction de rappel

function calcule(a, b, methodeCalcule) {
    console.log(methodeCalcule(a,b))
}
const addition = function(a,b) {
    return a+b
}
calcule(10, 30,addition)
calcule(30,46, function(a,b) {return a-b})
calcule(10,30, function(a,b) {return a * b})