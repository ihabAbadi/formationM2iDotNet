const taille = 3
const grid = document.querySelector(".grid")

for(let i=1; i <= taille; i++) {
    for(let j=1; j <= taille ; j++) {
        grid.innerHTML+='<div class="col-'+parseInt(12/taille)+' case" data-x="'+i+'" data-y="'+j+'"></div>'
    }
}
let isFirstPlayer = true
grid.addEventListener('click', function(e) {
    if(e.target.innerText == "") {
        e.target.innerText = (isFirstPlayer) ? 'X' : 'O'
        isFirstPlayer = !isFirstPlayer
        if(testWin()){
            alert("Vous avez gagné")
        }
    }
})

function testWin() {
    let win = false
    for(let i=1; i <= taille; i++) {
        const elementLigne = document.querySelectorAll('div[data-x="'+i+'"]')
        let sameValue = true
        for(let k=0; k < elementLigne.length-1; k++) {
            if( elementLigne[k].innerText== "" || elementLigne[k].innerText != elementLigne[k+1].innerText) {
                sameValue = false
                break;
            }
        }
        if(sameValue) {
            win = true
            break
        }
    }
    return win
}