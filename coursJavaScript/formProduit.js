
// let errors = []

// const produits = []
// formProduit.addEventListener('keydown', function (e) {
//     e.target.classList.remove("border-danger")
// })
// formProduit.addEventListener('submit', function (e) {
//     e.preventDefault()
//     let error = false
//     errors = []
//     // document.querySelector('input[name="titre"]').classList.remove("border-danger")
//     // document.querySelector('input[name="prix"]').classList.remove("border-danger")
//     // document.querySelector('textarea').classList.remove("border-danger")
//     const titre = document.querySelector('input[name="titre"]').value
//     if (titre == "") {
//         error = true
//         errors.push("Merci d'ajouter un titre du produit")
//         document.querySelector('input[name="titre"]').classList.add("border-danger")
//     }
//     const prix = document.querySelector('input[name="prix"]').value
//     if (prix == "" || isNaN(prix)) {
//         error = true
//         errors.push("Merci d'ajouter un prix du produit")
//         document.querySelector('input[name="prix"]').classList.add("border-danger")
//     }

//     const description = document.querySelector("textarea").value
//     if (description == "") {
//         error = true
//         errors.push("Merci d'ajouter un description du produit")
//         document.querySelector("textarea").classList.add("border-danger")
//     }
//     if (!error) {
//         produits.push({
//             id: (produits[produits.length - 1] != undefined) ? (produits[produits.length - 1].id + 1) : 1,
//             titre: titre,
//             prix: prix,
//             description: description
//         })

//         let produit = ""
//         produit += "<div class='col'>"
//         produit += "<div class='row'><div class='col'>" + titre + "</div></div>"
//         produit += "<div class='row'><div class='col'>" + prix + "</div></div>"
//         produit += "<div class='row'><div class='col'>" + description + "</div></div>"
//         produit += "</div>"
//         affichage.innerHTML += produit
//         document.querySelector('input[name="prix"]').value = ""
//         document.querySelector('input[name="titre"]').value = ""
//         document.querySelector('textarea').value = ""
//     }
//     else {

//     }
// })

class GestionProduits {
    
    //Constructeur des objets de types gestion produits
    constructor(formulaire, affichageHtml) {
        
        //Attribut pour stocker les produits
        this.produits = []

        //Attribut pour le formulaire
        this.formulaire = formulaire

        //Attribut pour la zone d'affichage html
        this.affichageHtml = affichageHtml
        this.errors = []
        this.editId = undefined
    }


    //Methode pour ajouter un produit dans l'attribut produits à partir du formulaire
    validerProduit() {
        let error = false
        const titre = this.formulaire.querySelector('input[name="titre"]').value
        const prix = this.formulaire.querySelector('input[name="prix"]').value
        const description = this.formulaire.querySelector('textarea').value
        if (titre == "") {
            error = true
            //errors.push("Merci d'ajouter un titre du produit")
            this.formulaire.querySelector('input[name="titre"]').classList.add("border-danger")
        }
        if (prix == "" || isNaN(prix)) {
            error = true
            //errors.push("Merci d'ajouter un prix du produit")
            this.formulaire.querySelector('input[name="prix"]').classList.add("border-danger")
        }
        if (description == "") {
            error = true
            //errors.push("Merci d'ajouter un description du produit")
            this.formulaire.querySelector("textarea").classList.add("border-danger")
        }
        if (!error) {
            if(this.editId == undefined) {
                this.produits.push({
                    id: (this.produits[this.produits.length - 1] != undefined) ? (this.produits[this.produits.length - 1].id + 1) : 1,
                    titre: titre,
                    prix: prix,
                    description: description
                })
            } else {
                for(let produit of this.produits) {
                    if(produit.id == this.editId) {
                        produit.titre = titre
                        produit.prix = prix
                        produit.description = description
                        break
                    }
                }
                this.editId = undefined
            }
            

            this.affichageHtmlProduits()
            this.clearForm()
        }
        
    }

    //Méthode pour afficher les produits de l'attribut produits dans la zone html
    affichageHtmlProduits() {
        this.affichageHtml.innerHTML = ""
        for (let produit of this.produits) {
            let affichageProduit = "";
            affichageProduit += "<div class='col'>"
            affichageProduit += "<div class='row'><div class='col'>" + produit.titre + "</div></div>"
            affichageProduit += "<div class='row'><div class='col'>" + produit.prix + "</div></div>"
            affichageProduit += "<div class='row'><div class='col'>" + produit.description + "</div></div>"
            affichageProduit += "<div class='row'><button class='col edit btn btn-warning' data-id='"+produit.id+"'>Modifier</button></div>"
            affichageProduit += "<div class='row'><button class='col delete btn btn-danger' data-id='"+produit.id+"'>Supprimer</button></div>"
            affichageProduit += "</div>"
            this.affichageHtml.innerHTML += affichageProduit
        }
    }

    //Méthode pour vider les champs du formulaire
    clearForm() {
        this.formulaire.querySelector('input[name="titre"]').value = ""
        this.formulaire.querySelector('input[name="prix"]').value = ""
        this.formulaire.querySelector('textarea').value = ""
    }

    //Méthode pour écouter les evenements du formulaires (event submit pour valider le formulaire, supprimer les bordures rouges)
    eventListener() {
        this.formulaire.addEventListener('submit', (e) => {
            e.preventDefault()
            this.validerProduit()
        })
        this.formulaire.addEventListener('keydown', (e) => {
            e.target.classList.remove("border-danger")
        })

        this.affichageHtml.addEventListener('click', (e) => {
            if(e.target.classList.contains("delete")) {
                this.supprimerProduit(e.target.getAttribute("data-id"))
            }
            else if(e.target.classList.contains("edit")) {
                this.modifierProduit(e.target.getAttribute("data-id"))
            }
        })
    }

    //Méthode pour supprimer un produit avec son id
    supprimerProduit(id) {
        //Insctruction pour la suppression du produit
        let index = undefined
        for(let i=0; i < this.produits.length; i++) {
            if(this.produits[i].id == id) {
                index = i
                break
            }
        }
        if(index != undefined) {
            this.produits.splice(index,1)
        }
        this.affichageHtmlProduits()
    }

    //Méthode modification produit
    modifierProduit(id) {
        //Instruction pour la modification du produit
        let produitFound = undefined
        for(let produit of this.produits) {
            if(produit.id == id){
                produitFound = produit
                break
            }
        }
        if(produitFound != undefined) {
            this.formulaire.querySelector("input[name='titre']").value = produitFound.titre
            this.formulaire.querySelector("input[name='prix']").value = produitFound.prix
            this.formulaire.querySelector("textarea").value = produitFound.description
            this.editId = produitFound.id
        }
        else {
            alert("Aucun produit avec cet id")
        }
    }
}
const formProduit = document.querySelector("#formProduit")
const affichage = document.querySelector("#affichage")
const gestion = new GestionProduits(formProduit, affichage)
gestion.eventListener()