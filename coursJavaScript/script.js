// for(let i=1; i < 5; i++){
//     alert(i)
// }
//Manipulation du DOM
// const firstDiv = document.querySelector('div')
// // firstDiv.innerText = "Bonjour tout le monde"
// firstDiv.innerHTML = "<h1>Bonjour tout le monde</h1>"
// const allDiv = document.querySelectorAll('div')
// for(let i=0; i < allDiv.length; i++) {
//     allDiv[i].innerHTML = "<h1>Bonjour tout le monde</h1>"
// }

// const firstInput = document.querySelector('input')
// firstInput.value = "test"
// const monLien = document.querySelector('a')
// const href = monLien.getAttribute('href')
// alert(href)
// monLien.setAttribute('href', 'http://utopios.solutions')

// const btn = document.querySelector('button')
// btn.addEventListener('click', function() {
//     alert('On vient de cliquer sur le bouton')
// })

const div = document.querySelector("#maDiv")

div.addEventListener('click', function(e) {
    alert(e.target.innerText)
})