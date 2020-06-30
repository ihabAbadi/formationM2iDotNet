class Memory {
    constructor(length, htmlGrid) {
        this.grid = []
        this.length = length
        this.init()
        this.shuffle()
        this.htmlGrid = htmlGrid
        this.firstClick = true
        this.firstValue = undefined
    }

    init() {
        for(let i=65; i < this.length+65; i++) {
            //String.fromCharCode(i) => renvoie un char à partir de son code Ascii
            this.grid.push(String.fromCharCode(i))
            this.grid.push(String.fromCharCode(i))
        } 
    }

    shuffle() {
        for(let i=0; i < this.grid.length; i++) {
            const r = Math.floor(Math.random() * this.grid.length)
            const tmp = this.grid[i]
            this.grid[i] = this.grid[r]
            this.grid[r] = tmp
        }
    }

    generateHtml() {
        for(let i=0 ; i< this.grid.length; i++) {
            this.htmlGrid.innerHTML += "<div class='case'><div class='mask' data-value='"+this.grid[i]+"'></div><div class='valueCase'>"+this.grid[i]+"</div></div>"
        }
        this.htmlEventListener()
    }

    htmlEventListener() {
        //Utilisation d'une fonction pur (Arrow function ) au lieu d'utiliser le mot clé function pour accéder au attribut de la classe mère 
        this.htmlGrid.addEventListener('click', (e) => {
            e.target.classList.add('hideMask')
            if(!this.firstClick) {
                if(e.target.getAttribute("data-value") == this.firstValue) {
                    const allhiddenMask = document.querySelectorAll(".hideMask")
                        for(let i=0; i < allhiddenMask.length; i++) {
                            allhiddenMask[i].classList.remove('hideMask')
                            allhiddenMask[i].classList.add('found')
                        }
                }
                else {
                    setTimeout(() => {
                        const allhiddenMask = document.querySelectorAll(".hideMask")
                        for(let i=0; i < allhiddenMask.length; i++) {
                            allhiddenMask[i].classList.remove('hideMask')
                        }
                       
                    },1000)
                }             
                this.firstClick = !this.firstClick
                this.firstValue = undefined
            }
            else {
                this.firstValue = e.target.getAttribute("data-value")
                this.firstClick = !this.firstClick
            }
            
        })
        
    }
}


const g = document.querySelector("#grid")
let m = new Memory(8,g)

m.generateHtml()
// setTimeout(function(){
//     alert("Bonjour après 2 sec")
// },2000)
// g.addEventListener('click', function(e){
    
//     e.target.classList.add("hideMask")
// })
