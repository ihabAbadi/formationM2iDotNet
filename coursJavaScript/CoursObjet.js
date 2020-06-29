//Création d'objet en javascript
//En utilisant un objet anonyme

// let objet = {
//     //attributs
//     attr1 : "Value of attribut 1",
//     attr2 : "Value of attribut 2",
//     //methodes
//     diplayAttributes : function() {
//         alert("Je vais afficher les attributs")
//         alert(this.attr1 +" et " + this.attr2)
//     },

//     useObjectWithParams : function(param) {
//         alert("Je suis une méthode qui utilise le paramètre " + param)
//     }
// }

// console.log(objet.attr1)
// objet.diplayAttributes()
// objet.useObjectWithParams("paramètre 1")
// objet.useObjectWithParams("paramètre 2")

//Création d'objets avec des fonctions

//Rappel sur fonction en javascript

// const fonction = () => {
//     alert("je suis une fonction sans objet")
// }

// fonction()

// function fonctionObject() {
//     alert("je suis une fonction qui cree des objets")
// }

// fonctionObject()

// function personne(nom, prenom) {
//     this.nom = nom;
//     this.prenom = prenom;
//     this.afficher = function() {
//         alert(this.nom + " "+this.prenom)
//     }
// }

// const p1 = new personne("abadi", "ihab")
// const p2 = new personne("titi", "minet")
// alert(p1.nom + " "+p1.prenom)
// alert(p2.nom + " "+p2.prenom)
// p1.afficher()
// p2.afficher()

// console.log(p1)
// console.log(p2)

// function voiture(model, marque, immat, conso) {
//     this.model = model
//     this.marque = marque
//     this.immat = immat
//     this.reservoir = 0
//     this.conso = conso
//     this.afficher = function() {
//         console.log("Voiture model : "+ this.model + ", marque : "+this.marque + ", immat : "+this.immat+", reservoir : "+this.reservoir)
//     }
//     this.fairePlein = function(nombreLitre) {
//         this.reservoir += nombreLitre
//     }
//     this.rouler = function(nombreKm) {
//         const consoF = nombreKm * this.conso / 100
//         if(this.reservoir - consoF >= 0) {
//             console.log("Voiture roule ")
//             this.reservoir -= consoF
//         }
//         else {
//             console.log("Merci de faire le plein il vous manque : "+ (consoF - this.reservoir) + " L")
//         }
//     }
// }

//Création d'objet en utilisant des classes
// class Voiture {

//     constructor(model, marque, immat, conso) {
//         this.model = model
//         this.marque = marque
//         this.immat = immat
//         this.reservoir = 0
//         this.conso = conso
//     }
    
//     afficher() {
//         console.log("Voiture model : "+ this.model + ", marque : "+this.marque + ", immat : "+this.immat+", reservoir : "+this.reservoir)
//     }

//     fairePlein(nombreLitre) {
//         this.reservoir += nombreLitre
//     }

//     rouler(nombreKm) {
//         const consoF = nombreKm * this.conso / 100
//         if(this.reservoir - consoF >= 0) {
//             console.log("Voiture roule ")
//             this.reservoir -= consoF
//         }
//         else {
//             console.log("Merci de faire le plein il vous manque : "+ (consoF - this.reservoir) + " L")
//         }
//     }
// }
// const v1 = new Voiture("kuga" ,"Ford", "123456",9)
// v1.afficher()
// v1.fairePlein(50)
// v1.afficher()
// v1.rouler(30)
// v1.afficher()
// v1.rouler(1000)
// const v2 = new Voiture("Kia", "ceed", "233333", 7)

class Personnage {
    constructor(nom, sante, force) {
        this.nom = nom
        this.sante = sante
        this.force = force
        this.exp = 0
    }

    afficher() {
        console.log("Nom du personnage : "+ this.nom + ", sante : "+this.sante +", force : "+this.force +", exp : "+this.exp)
    }

    attaquer(cible) {
        if(cible.sante > 0) {
            cible.sante -= this.force
            this.exp += 10
            cible.afficher()
            if(cible.sante <= 0) {
                console.log("cible est morte")
            }
        }
    }
}
const p1 = new Personnage("p1", 1000, 50)
const p2 = new Personnage("p2", 1000, 160)

let firstAttack = true
while(p1.sante > 0 && p2.sante > 0 ) {
    
    if(firstAttack) {
        p1.attaquer(p2)
    }
    else {
        p2.attaquer(p1)
    }
    firstAttack = !firstAttack
}

