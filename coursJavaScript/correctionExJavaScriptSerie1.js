//Correction Ex1 
//const allInput = document.querySelectorAll('input')
// const result = document.querySelector("#result")
// const btn = document.querySelector("button")

// btn.addEventListener('click', function() {
//     let somme = 0
//     for(let i=0; i < allInput.length; i++) {
//         somme += parseFloat(allInput[i].value)
//     }
//     result.innerText = "Le resultat est de "+ somme
// })

const input = document.querySelector('input')
const result = document.querySelector("#result")

input.addEventListener('keyup', function(e) {
    let age = parseInt(e.target.value)
    if(age > 0 && age < 130) {
        result.innerHTML = "Age correct"
    }
    else {
        result.innerHTML = "Age incorrect, merci de ressayer"
    }
})