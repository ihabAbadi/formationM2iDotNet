const standard = document.querySelector('.standard')
const header = document.querySelector('header')
let firstNumber = true
let operationCours = undefined
let nombre
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
        switch(valueButton) {
            case "+":
                if(operationCours == undefined) {
                    nombre = parseFloat(header.innerText)
                }
                else {
                    switch(operationCours) {
                        case "+":
                            nombre = nombre + parseFloat(header.innerText)
                            header.innerText = nombre
                            break;
                    }
                }
                operationCours = "+"
                break;
        }
    }
})