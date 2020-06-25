const prompt = require('prompt-sync')()
let choix
let notes = []
do {
    displayMenu(console.log)
    choix = parseInt(prompt("Merci d'indiquer votre choix : "))
    switch(choix) {
        case 1:
            addNote()
            break;
        case 2:
            displayNotes(console.log)
            break;
        case 3:
            editNote(prompt, console.log)
            break;
        case 4:
            AverageNote(console.log)
            break;
        case 5:
            maxNote(console.log)
            break;
        case 6:
            minNote(console.log)
            break;
    }
}while(choix != 0)

//Fonction pour afficher le menu
function displayMenu(methodeAffichage) {
    methodeAffichage("1-    Stocker les notes des élèves dans un tableau")
    methodeAffichage("2-	Afficher la liste des notes")
    methodeAffichage("3-	Modifier une note")
    methodeAffichage("4-	Afficher la moyenne de la classe")
    methodeAffichage("5-	Afficher la note la plus élevée")
    methodeAffichage("6-	Afficher la note la plus base")
    methodeAffichage("0-	Quitter le programme")
}

function addNote() {
    let note
    do {
        note = parseFloat(prompt("Merci de saisir une note ou -1 pour arreter la saisie : "))
        if(note != -1)
        notes.push(note)
    }while(note != -1)
}

//Version sans CallBack, fonctionne uniquement en mode console
// function displayNotes() {
//     console.log("--------Liste des notes----------")
//     for(let i=0; i < notes.length; i++) {
//         console.log("Note N° " +(i+1)+ " : "+notes[i])
//     }
// }

//Version avec callBack, ou on passe la méthode d'affichage comme paramètre
function displayNotes(methodeAffichage) {
    methodeAffichage("--------Liste des notes----------")
    for(let i=0; i < notes.length; i++) {
        methodeAffichage("Note N° " +(i+1)+ " : "+notes[i])
    }
}

//Fonction Pour modifier un note
function editNote(methodeSaisie, methodeAffichage) {
    let indexNote
    indexNote = parseInt(methodeSaisie("Numéro de la note à modifier : ")) - 1
    if(indexNote >= 0 && indexNote < notes.length) {
        notes[indexNote] = parseFloat(methodeSaisie("Saisir la nouvelle note : "))
    } 
    else {
        methodeAffichage("Note inconnue")
    }
}
//Fonction qui calcule la moyenne des notes
function AverageNote(methodeAffichage) {
    let moyenne, somme = 0
    for(let i=0; i < notes.length; i++) {
        somme += notes[i]
    }
    moyenne = somme/notes.length
    methodeAffichage("La moyenne est de : "+moyenne)
}

//Fonction qui affiche la note max en utilisant la méthode d'affichage passée en paramètre
function maxNote(methodeAffichage) {
    let max = notes[0]
    for(let i=1; i < notes.length; i++) {
        if(notes[i] > max) {
            max = notes[i]
        }
    }
    methodeAffichage("La note la plus élevée est "+ max)
}

//Fonction qui affiche la note min en utilisant la méthode d'affichage passée en paramètre
function minNote(methodeAffichage) {
    let min = notes[0]
    for(let i=1; i < notes.length; i++) {
        if(notes[i] < min) {
            min = notes[i]
        }
    }
    methodeAffichage("La note la plus base est "+ min)    
}