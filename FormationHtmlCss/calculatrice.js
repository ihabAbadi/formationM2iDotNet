const standard = document.querySelector('.standard')
const header = document.querySelector('header')
let firstNumber = true
standard.addEventListener('click', function(e) {
    const valueButton = e.target.innerText
    if(!isNaN(valueButton)) {
        if(firstNumber) {
            header.innerText = valueButton
            firstNumber = false
        }
        else {
            header.innerText += valueButton
        }
    }
    else {
        firstNumber = true
    }
})