const prompt = require('prompt-sync')()

startGame(prompt, console.log)

//Fonction pour démarrer le jeu
function startGame(methodeSaisie, methodeAffichage) {
    let winner
    let isFirstPlayer = true
    //génération dynamique de la grille
    let morpionGrid = generateGrid(parseInt(methodeSaisie("Merci de saisir la taille du morpion : ")))
    let joueurs = ['X', 'O']
    //tant que le jeu n'est pas fini
    while(winner == undefined) {
        isFirstPlayer = play(isFirstPlayer, morpionGrid, methodeSaisie, methodeAffichage)
        //On affiche la grille
        displayGrid(morpionGrid, methodeAffichage) 
        winner = testWinner(morpionGrid, joueurs)
    }
    
    methodeAffichage("The winner is : "+winner)
}



//Fonction de génération de grille dynamique
function generateGrid(size) {
    let grid = []
    for(let i=0; i < size;i++) {
        let tmpRow =[]
        for(let j=0; j < size; j++) {
            tmpRow.push('.')
        }
        grid.push(tmpRow)
    }
    return grid
}

function play(isFirstPlayer, grid, methodeSaisie, methodeAffichage) {
    //Affichage du joueur à jouer
    methodeAffichage("joueur N° : "+ ((isFirstPlayer) ? "X" : "O") + " joue")
    //demande de la saisie du numéro de ligne et de col
    let row = parseInt(methodeSaisie("Merci de saisir le numéro de la ligne : "))
    let col = parseInt(methodeSaisie("Merci de saisir le numéro de la col : "))
    //Si le joueur saisi une ligne et col qui sont à l'exterieur des limites ou la position d'une case déjà rempli on redemande la saisie
    while( row < 1 || row > grid.length || col < 1 || col > grid.length  || grid[row-1][col-1] != ".") {
        methodeAffichage("Erreur de position merci de recommencer ")
        row = parseInt(methodeSaisie("Merci de saisir le numéro de la ligne : "))
        col = parseInt(methodeSaisie("Merci de saisir le numéro de la col : "))
    }
    //On remplie la case en fonction du joueur (si joueur 1 par X et O pour joueur 2)
    grid[row-1][col-1] = (isFirstPlayer) ? "X" : "O"
    //On change de joueur en inversant le boolean qui indique si joueur 1 ou 2
    isFirstPlayer = !isFirstPlayer
    return isFirstPlayer
}

function displayGrid(grid, methodeAffichage) {
    let ligne = ""
    for(let i=0; i < grid.length; i++) {
        ligne = ""
        for(let j=0; j < grid[i].length; j++) {
            ligne += "|"+grid[i][j]+"|"
        }
        methodeAffichage(ligne)
    }
}

function testWinner(grid, joueurs)
{
    let tmpValue, winner, isSame
    //On verifie le gagnant sur les lignes uniquement 
    for(let i = 0; i < grid.length; i++){
        tmpValue = []
        for(let j=0; j < grid[i].length; j++) {
            tmpValue.push(grid[i][j])
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
            }
        }
    }

    //On verifie le gagnant sur les col uniquement 
    for(let i = 0; i < grid.length; i++){
        tmpValue = []
        for(let j=0; j < grid[i].length; j++) {
            tmpValue.push(grid[j][i])
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
            }
        }
    }
    //On verifie sur la première diag
    tmpValue = []
    for(let i = 0; i < grid.length; i++){
        for(let j=0; j < grid[i].length; j++) {
            if(i == j){
                tmpValue.push(grid[i][j])
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
        }
    }

    //On verifie sur la deuxième diag
    tmpValue = []
    for(let i = 0; i < grid.length; i++){
        for(let j=0; j < grid[i].length; j++) {
            if((i+1)+(j+1) == grid.length + 1 ){
                tmpValue.push(grid[i][j])
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
        }
    }

    return winner
}