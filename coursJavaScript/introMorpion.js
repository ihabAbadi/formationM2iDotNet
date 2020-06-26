const taille = 4
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
    }
})
