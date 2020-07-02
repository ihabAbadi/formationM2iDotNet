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

const cases = []
const delta = 2
let x = 10
let y = 10
let dx = 0
let dy = 0
let prop = 0
let gameOver = false
let generateRect = true
let direction = undefined
let cibleCase = {
    x: 0,
    y: 0,
}
const width = 10
const height = 10
const drawRect = (i, j) => {
    ctx.beginPath()
    ctx.rect(i, j, width, height)
    ctx.fillStyle = "#cd2127"
    ctx.fill()
    ctx.closePath()
}

const drawRandomRect = () => {
    if (generateRect) {
        cibleCase.x = Math.floor(Math.random() * (canvas.width - width))
        cibleCase.y = Math.floor(Math.random() * (canvas.height - height))
        generateRect = false
    }
    console.log(cibleCase)
    drawRect(cibleCase.x, cibleCase.y)
}
cases.push({
    x: 0,
    y: 0,
    direction: "right"
})
setInterval(() => {
    ctx.clearRect(0, 0, canvas.width, canvas.height)
    if (!gameOver) {

        if (x >= canvas.width - width || x <= 0 || y >= canvas.height - height || y <= 0) {
            alert("game over")
            gameOver = true
        }
        else if ((x >= (cibleCase.x - width) && x <= (cibleCase.x + width)) && (y >= (cibleCase.y - height) && y <= (cibleCase.y + height))) {
            console.log("test")
            generateRect = true
            cases.push({
                x: cibleCase.x,
                y: cibleCase.y,
                direction: direction
            })
        }
        else {
            for (let c of cases) {
                switch (c.direction) {
                    case "right":
                        c.x += delta
                        break;
                    case "left":
                        c.x -= delta
                        break;
                    case "top":
                        c.y -= delta
                        break;
                    case "bottom":
                        c.y += delta
                        break;
                }
                drawRect(c.x, c.y)
                if(c.x == dx && c.y == dy) {
                    c.direction = direction
                }
                
            }
        }
        drawRandomRect()
    }
}, 20);
document.addEventListener('keyup', (e) => {
    if (e.keyCode == 37) {
        direction = "left"
    }
    else if (e.keyCode == 39) {
        direction = "right"
    }
    else if (e.keyCode == 38) {
        direction = "top"
    }
    else if (e.keyCode == 40) {
        direction = "bottom"
    }
    dx = cases[cases.length - 1].x
    dy = cases[cases.length - 1].y
})