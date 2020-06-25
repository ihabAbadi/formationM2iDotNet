const prompt = require('prompt-sync')()
///OUTPUT morpion
// i : 1
// j : 1
//=> | X | . | . |
//=> | . | . | . |
//=> | . | . | . |
// i : 2
// j : 3
//=> | X | . | O |
//=> | . | X | O |
//=> | . | . | O |
let size = parseInt(prompt("Merci de saisir la taille du morpion : "))
let row, col ,winner
let endGame = false
let isFirstPlayer = true
//génération dynamique de la grille
let morpionGrid = []
for(let i=0; i < size;i++) {
    let tmpRow =[]
    for(let j=0; j < size; j++) {
        tmpRow.push('.')
    }
    morpionGrid.push(tmpRow)
}
let ligne = ""
let tmpValue
let joueurs = ['X', 'O']
//tant que le jeu n'est pas fini
while(!endGame) {
    //Affichage du joueur à jouer
    console.log("joueur N° : "+ ((isFirstPlayer) ? "X" : "O") + " joue")
    //demande de la saisie du numéro de ligne et de col
    row = parseInt(prompt("Merci de saisir le numéro de la ligne : "))
    col = parseInt(prompt("Merci de saisir le numéro de la col : "))
    //Si le joueur saisi une ligne et col qui sont à l'exterieur des limites ou la position d'une case déjà rempli on redemande la saisie
    while( row < 1 || row > morpionGrid.length || col < 1 || col > morpionGrid.length  || morpionGrid[row-1][col-1] != ".") {
        console.log("Erreur de position merci de recommencer ")
        row = parseInt(prompt("Merci de saisir le numéro de la ligne : "))
        col = parseInt(prompt("Merci de saisir le numéro de la col : "))
    }
    //On remplie la case en fonction du joueur (si joueur 1 par X et O pour joueur 2)
    morpionGrid[row-1][col-1] = (isFirstPlayer) ? "X" : "O"
    //On change de joueur en inversant le boolean qui indique si joueur 1 ou 2
    isFirstPlayer = !isFirstPlayer
    //On affiche la grille
    for(let i=0; i < morpionGrid.length; i++) {
        ligne = ""
        for(let j=0; j < morpionGrid[i].length; j++) {
            ligne += "|"+morpionGrid[i][j]+"|"
        }
        console.log(ligne)
    }
    //On verifie le gagnant sur les lignes uniquement 
    for(let i = 0; i < morpionGrid.length; i++){
        tmpValue = []
        for(let j=0; j < morpionGrid[i].length; j++) {
            tmpValue.push(morpionGrid[i][j])
        }
        for(let y=0; y < joueurs.length; y++){
            isSame = true
            for(let k = 0; k < tmpValue.length; k++) {
                if(tmpValue[k] != joueurs[y]) {
                    isSame = false
                }
            }
            if(isSame) {
                winner = 'joueur '+joueurs[y]
                endGame = true
            }
        }
    }

    //On verifie le gagnant sur les col uniquement 
    for(let i = 0; i < morpionGrid.length; i++){
        tmpValue = []
        for(let j=0; j < morpionGrid[i].length; j++) {
            tmpValue.push(morpionGrid[j][i])
        }
        for(let y=0; y < joueurs.length; y++){
            isSame = true
            for(let k = 0; k < tmpValue.length; k++) {
                if(tmpValue[k] != joueurs[y]) {
                    isSame = false
                }
            }
            if(isSame) {
                winner = 'joueur '+joueurs[y]
                endGame = true
            }
        }
    }
    //On verifie sur la première diag
    tmpValue = []
    for(let i = 0; i < morpionGrid.length; i++){
        for(let j=0; j < morpionGrid[i].length; j++) {
            if(i == j){
                tmpValue.push(morpionGrid[i][j])
            }   
        }
    }
    for(let y=0; y < joueurs.length; y++){
        isSame = true
        for(let k = 0; k < tmpValue.length; k++) {
            if(tmpValue[k] != joueurs[y]) {
                isSame = false
            }
        }
        if(isSame) {
            winner = 'joueur '+joueurs[y]
            endGame = true
        }
    }

    //On verifie sur la deuxième diag
    tmpValue = []
    for(let i = 0; i < morpionGrid.length; i++){
        for(let j=0; j < morpionGrid[i].length; j++) {
            if((i+1)+(j+1) == morpionGrid.length + 1 ){
                tmpValue.push(morpionGrid[i][j])
            }   
        }
    }
    for(let y=0; y < joueurs.length; y++){
        isSame = true
        for(let k = 0; k < tmpValue.length; k++) {
            if(tmpValue[k] != joueurs[y]) {
                isSame = false
            }
        }
        if(isSame) {
            winner = 'joueur '+joueurs[y]
            endGame = true
        }
    }
}

console.log("The winner is : "+winner)