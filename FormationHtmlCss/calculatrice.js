const standard = document.querySelector('.standard')
const header = document.querySelector('header')
let firstNumber = true
let operationCours = undefined
let nombre
standard.addEventListener('click', function (e) {
    const valueButton = e.target.innerText
    if (!isNaN(valueButton)) {
        if (firstNumber) {
            header.innerText = valueButton
            firstNumber = false
        }
        else {
            header.innerText += valueButton
        }
    }
    else {
        firstNumber = true
        switch (valueButton) {
            case "+":
                if (operationCours == undefined) {
                    nombre = parseFloat(header.innerText)
                }
                else {
                    switch (operationCours) {
                        case "+":
                            nombre = nombre + parseFloat(header.innerText)
                            header.innerText = nombre
                            break;
                        case "-":
                            nombre = nombre - parseFloat(header.innerText)
                            header.innerText = nombre
                            break;
                        case "X":
                            nombre = nombre * parseFloat(header.innerText)
                            header.innerText = nombre
                            break;
                        case "/":
                            nombre = nombre + parseFloat(header.innerText)
                            header.innerText = nombre
                            break;
                    }
                }
                operationCours = "+"
                break;
            case "-":
                if (operationCours == undefined) {
                    nombre = parseFloat(header.innerText)
                }
                else {
                    switch (operationCours) {
                        case "+":
                            nombre = nombre + parseFloat(header.innerText)
                            header.innerText = nombre
                            break;
                        case "-":
                            nombre = nombre - parseFloat(header.innerText)
                            header.innerText = nombre
                            break;
                        case "X":
                            nombre = nombre * parseFloat(header.innerText)
                            header.innerText = nombre
                            break;
                        case "/":
                            nombre = nombre + parseFloat(header.innerText)
                            header.innerText = nombre
                            break;
                    }
                }
                operationCours = "-"
                break;
            case "X":
                if (operationCours == undefined) {
                    nombre = parseFloat(header.innerText)
                }
                else {
                    switch (operationCours) {
                        case "+":
                            nombre = nombre + parseFloat(header.innerText)
                            header.innerText = nombre
                            break;
                        case "-":
                            nombre = nombre - parseFloat(header.innerText)
                            header.innerText = nombre
                            break;
                        case "X":
                            nombre = nombre * parseFloat(header.innerText)
                            header.innerText = nombre
                            break;
                        case "/":
                            nombre = nombre + parseFloat(header.innerText)
                            header.innerText = nombre
                            break;
                    }
                }
                operationCours = "X"
                break;
            case "/":
                if (operationCours == undefined) {
                    nombre = parseFloat(header.innerText)
                }
                else {
                    switch (operationCours) {
                        case "+":
                            nombre = nombre + parseFloat(header.innerText)
                            header.innerText = nombre
                            break;
                        case "-":
                            nombre = nombre - parseFloat(header.innerText)
                            header.innerText = nombre
                            break;
                        case "X":
                            nombre = nombre * parseFloat(header.innerText)
                            header.innerText = nombre
                            break;
                        case "/":
                            nombre = nombre + parseFloat(header.innerText)
                            header.innerText = nombre
                            break;
                    }
                }
                operationCours = "/"
                break;
            case "=":
                switch (operationCours) {
                    case "+":
                        nombre = nombre + parseFloat(header.innerText)
                        header.innerText = nombre
                        break;
                    case "-":
                        nombre = nombre - parseFloat(header.innerText)
                        header.innerText = nombre
                        break;
                    case "X":
                        nombre = nombre * parseFloat(header.innerText)
                        header.innerText = nombre
                        break;
                    case "/":
                        nombre = nombre + parseFloat(header.innerText)
                        header.innerText = nombre
                        break;
                }
                operationCours = undefined
                break;
            case ",":
                if (header.innerText.indexOf('.') == -1) {
                    header.innerText += '.'
                    firstNumber = false
                }
                break;
            case "C":
                header.innerText = "0"
                operationCours = undefined
                firstNumber = true
                break;
            case "+/-":
                header.innerText = parseFloat(header.innerText) * -1
            break;
        }
    }
})