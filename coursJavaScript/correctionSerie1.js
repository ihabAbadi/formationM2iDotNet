const prompt = require('prompt-sync')()
//Correction Ex1 
// 
// const MAX_PRICE = 1000
// let randomPrice = Math.ceil((Math.random() * (MAX_PRICE-1)))
// let price
// let numberOfTry = 0
// do {
//     price = parseInt(prompt("Merci de saisir un prix : "))
//     numberOfTry++
//     if(price > randomPrice) {
//         console.log("moin")
//     }
//     else if(price < randomPrice) {
//         console.log("plus")
//     }
// }while(randomPrice != price)
// console.log("Bravo vous avez gagné avec "+ numberOfTry +" essai")
//Correction Ex2
// const wordTab = ["google", "microsoft", "facebook", "amazon", "apple"]
// const randomIndex = Math.floor(Math.random() * (wordTab.length-1))
// const wordToFind = wordTab[randomIndex]
// let mask = ""
// let tmpMask = ""
// let maxTry = 10
// let userChar
// for(let i=0; i < wordToFind.length; i++) {
//     mask += "*"
// }
// do {
//     console.log(mask)
//     userChar = prompt("Merci de saisir un caractère : ")
//     let found = false
//     tmpMask = ""
//     for(let i=0; i < wordToFind.length; i++) {
//         if(wordToFind[i] == userChar && mask[i] == "*"){
//             found = true
//             tmpMask += wordToFind[i]
//         }
//         else {
//             tmpMask += mask[i]
//         }
//     }
//     mask = tmpMask
//     if(found) {
//         console.log("char founded")
//     }else {
//         console.log("char not founded")
//         maxTry--
//     }
    
// }while(maxTry > 0 && mask != wordToFind)
// if(maxTry == 0) {
//     console.log("Perdu")
// }else {
//     console.log("Bravo vous avez trouvé "+ wordToFind)
// }

//exercice 3

let choix
let notes = []
do {
    console.log("1- Stocker les notes des élèves dans un tableau")
    console.log("2-	Afficher la liste des notes")
    console.log("3-	Modifier une note")
    console.log("4-	Afficher la moyenne de la classe")
    console.log("5-	Afficher la note la plus élevée")
    console.log("6-	Afficher la note la plus base")
    console.log("0-	Quitter le programme")
    choix = parseInt(prompt("Merci d'indiquer votre choix : "))
    switch(choix) {
        case 1:
            let note
            do {
                note = parseFloat(prompt("Merci de saisir une note ou -1 pour arreter la saisie : "))
                if(note != -1)
                    notes.push(note)
            }while(note != -1)
            break;
        case 2:
            console.log("--------Liste des notes----------")
            for(let i=0; i < notes.length; i++) {
                console.log("Note N° " +(i+1)+ " : "+notes[i])
            }
            break;
        case 3:
            let indexNote
            indexNote = parseInt(prompt("Numéro de la note à modifier : ")) - 1
            if(indexNote >= 0 && indexNote < notes.length) {
                notes[indexNote] = parseFloat(prompt("Saisir la nouvelle note : "))
            } 
            else {
                console.log("Note inconnue")
            }
            break;
        case 4:
            let moyenne, somme = 0
            for(let i=0; i < notes.length; i++) {
                somme += notes[i]
            }
            moyenne = somme/notes.length
            console.log("La moyenne est de : "+moyenne)
            break;
        case 5:
            let max = notes[0]
            for(let i=1; i < notes.length; i++) {
                if(notes[i] > max) {
                    max = notes[i]
                }
            }
            console.log("La note la plus élevée est "+ max)
            break;
        case 6:
            let min = notes[0]
            for(let i=1; i < notes.length; i++) {
                if(notes[i] < min) {
                    min = notes[i]
                }
            }
            console.log("La note la plus base est "+ min)
            break;
    }
}while(choix != 0)