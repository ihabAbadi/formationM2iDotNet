//Création de la fonction
// function direBonjour() {
//     console.log("Bonjour tout le monde")
// }

//Créer une fonction avec un paramètre
// function direBonjour(nom, prenom) {
//     nom += "."
//     console.log("Bonjour "+nom +" "+prenom)
// }

//Création d'une fonction avec un retour

// function addition(a, b) {
//     return a+b
// }

//la portée des variables à l'intérieur d'une fonction
//let globalVar = "Je suis une variable globale"

// function testScopeVariable() {
//     globalVar = "Je suis une variable globale"
// }
// function testScopeVariable() {
//     var localVarWithExtension = "Je suis une variable globale"
//     function secondScopeFunction() {
//         localVarWithExtension = "Je suis une variable globale modifiée par la fonction"
//     }
//     secondScopeFunction()
//     console.log(localVarWithExtension)
// }
// function testScopeVariable() {
//     let localVarWithOutExtension = "Je suis une variable globale"
//     function secondScopeFunction() {
//         let localVarWithOutExtension = "Je suis une variable globale modifiée par la fonction"
//     }

//     secondScopeFunction()
//     console.log(localVarWithOutExtension)
// }

//Utilisation de la fonction
// let n = "abadi"
// let p = "ihab"
// direBonjour(n, p)
// console.log(n)
//console.log(addition(10,20))
//testScopeVariable()

//console.log(globalVar)
let test = "coucou"
functionUsedBeforeDeclaration(test)

function functionUsedBeforeDeclaration(a) {
    console.log("Je suis une fonction déclarée après l'utilisation avec le paramètre : "+a)
}