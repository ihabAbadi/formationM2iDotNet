class Memory {
    constructor(length, htmlGrid) {
        this.grid = []
        this.length = length
        this.init()
        this.shuffle()
        this.htmlGrid = htmlGrid
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
            this.htmlGrid.innerHTML += "<div class='mask'><div class='case'>"+this.grid[i]+"</div></div>"
        }
    }
}


const g = document.querySelector("#grid")
let m = new Memory(16,g)

m.generateHtml()
// setTimeout(function(){
//     alert("Bonjour après 2 sec")
// },2000)
g.addEventListener('click', function(e){
    
    e.target.classList.add("hideMask")
})
