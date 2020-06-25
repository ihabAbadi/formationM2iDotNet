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
let row, col ,winner
let endGame = false
let isFirstPlayer = true
let morpionGrid = [[".",".","."], [".",".","."], [".",".","."]]
let ligne = ""
let tmpValue
while(!endGame) {
    console.log("joueur N° : "+ ((isFirstPlayer) ? "1" : "2") + " joue")
    row = parseInt(prompt("Merci de saisir le numéro de la ligne : "))
    col = parseInt(prompt("Merci de saisir le numéro de la col : "))
    while( row < 1 || row > 3 || col < 1 || col > 3  || morpionGrid[row-1][col-1] != ".") {
        console.log("Erreur de position merci de recommencer ")
        row = parseInt(prompt("Merci de saisir le numéro de la ligne : "))
        col = parseInt(prompt("Merci de saisir le numéro de la col : "))
    }
    morpionGrid[row-1][col-1] = (isFirstPlayer) ? "X" : "O"
    isFirstPlayer = !isFirstPlayer
    for(let i=0; i < morpionGrid.length; i++) {
        ligne = ""
        for(let j=0; j < morpionGrid[i].length; j++) {
            ligne += "|"+morpionGrid[i][j]+"|"
        }
        console.log(ligne)
    }

    for(let i = 0; i < morpionGrid.length; i++){
        tmpValue = []
        for(let j=0; j < morpionGrid[i].length; j++) {
            tmpValue.push(morpionGrid[i][j])
        }
        isSame = true
        for(let k = 0; k < tmpValue.length; k++) {
            if(tmpValue[k] != 'X') {
                isSame = false
            }
        }
        if(isSame) {
            winner = 'joueur 1'
            endGame = true
        }
        isSame = true
        for(let k = 0; k < tmpValue.length; k++) {
            if(tmpValue[k] != 'O') {
                isSame = false
            }
        }
        if(isSame) {
            winner = 'joueur 2'
            endGame = true
        }
    }
}

console.log("The winner is : "+winner)