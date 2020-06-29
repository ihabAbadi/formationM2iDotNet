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

function personne(nom, prenom) {
    this.nom = nom;
    this.prenom = prenom;
    this.afficher = function() {
        alert(this.nom + " "+this.prenom)
    }
}

const p1 = new personne("abadi", "ihab")
const p2 = new personne("titi", "minet")
// alert(p1.nom + " "+p1.prenom)
// alert(p2.nom + " "+p2.prenom)
// p1.afficher()
// p2.afficher()

console.log(p1)
console.log(p2)