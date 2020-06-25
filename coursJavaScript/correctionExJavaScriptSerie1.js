const allInput = document.querySelectorAll('input')
const result = document.querySelector("#result")
const btn = document.querySelector("button")

btn.addEventListener('click', function() {
    let somme = 0
    for(let i=0; i < allInput.length; i++) {
        somme += parseFloat(allInput[i].value)
    }
    result.innerText = "Le resultat est de "+ somme
})