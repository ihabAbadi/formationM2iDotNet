let canvas = document.querySelector('canvas')
let ctx = canvas.getContext("2d")
// ctx.beginPath()
// ctx.rect(10, 100, 50, 80)
// ctx.fillStyle = "#cd2127"
// ctx.fill()
// ctx.closePath()

// ctx.beginPath()
// ctx.arc(50, 80, 15, 0, Math.PI * 2)
// //ctx.fillStyle = "blue"
// //ctx.fill()
// ctx.strokeStyle = "blue"
// ctx.stroke()
// ctx.closePath()
// //effacer la totalité du canvas
// ctx.clearRect(0, 0, canvas.width, canvas.height)

// let dx = 2
// let dy = 2
// let x = 10
// let y = 20
// let xr = 50
// let yr = 70
// var speed = 20
// let anim = () => {
//     x = x + dx
//     y = y + dy
//     // xr += dx
//     // yr += dy
//     //déplacer le cercle dans le sens inverse quand on arrive a la fin du canvas => largeur
//     if (x >= (canvas.width - 15)) {
//         dx = -dx
//     }
//     //Inverser encore le sens quand on arrive au début du canvas => largeur
//     else if (x <= 15) {
//         dx = 2
//     }
//     //hauteur
//     if (y >= (canvas.height - 15)) {
//         dy = -dy

//     }
//     //hauteur
//     else if (y <= 15) {
//         dy = 2

//     }

//     ctx.clearRect(0, 0, canvas.width, canvas.height)
//     ctx.beginPath()

//     ctx.arc(x, y, 15, 0, Math.PI * 2)
//     //ctx.fillStyle = "blue"
//     //ctx.fill()
//     ctx.strokeStyle = "blue"
//     ctx.stroke()
//     ctx.closePath()

// }

// setInterval(() => {
//     anim()
// }, speed);

// document.addEventListener('keyup',(e) => {
//     if(e.keyCode == 39) {
//         dx = 2
//     }
//     else if(e.keyCode == 37) {
//         dx = -2
//     }
//     else if(e.keyCode == 40) {
//         dy = 2
//     }
//     else if(e.keyCode == 38) {
//         dy = -2
//     }

// })
const delta = 2
let x = 10
let y = 10
let dx = 0
let dy = 0
let prop = 1
let gameOver = false
let generateRect = true
let cibleCase = {
    x : 0,
    y : 0,
}
const width = 10
const height = 10
const drawRect = (i, j) => {
    ctx.clearRect(i-(dx * prop), j-dy, width, height)
    ctx.beginPath()
    ctx.rect(i, j, width, height)
    ctx.fillStyle = "#cd2127"
    ctx.fill()
    ctx.closePath()
}

const drawRandomRect = () => {
    let randomX = Math.floor(Math.random() * (canvas.width-width))
    let randomY = Math.floor(Math.random() * (canvas.height - height))
    cibleCase.x = randomX
    cibleCase.y = randomY
    drawRect(randomX, randomY)
}
setInterval(() => {
    if (!gameOver) {
        x += dx
        y += dy
        if (x >= canvas.width - width || x <= 0 || y >= canvas.height - height || y <= 0) {
            alert("game over")
            gameOver = true
        }
        else if((x >= (cibleCase.x-width) && x <= (cibleCase.x+width)) && (y >= (cibleCase.y-height) && y <= (cibleCase.y+height))) {
            ctx.clearRect(cibleCase.x, cibleCase.y, width, height)
            prop++
            console.log("test")
            generateRect = true
        }
        else {
            drawRect(x, y)
        }
        if(generateRect) {
            drawRandomRect()
            generateRect = false
        }
    }
}, 20);
document.addEventListener('keyup', (e) => {
    if (e.keyCode == 37) {
        dy = 0
        dx = -delta
    }
    else if (e.keyCode == 39) {
        dy = 0
        dx = delta
    }
    else if (e.keyCode == 38) {
        dx = 0
        dy = -delta
    }
    else if (e.keyCode == 40) {
        dx = 0
        dy = delta
    }
})