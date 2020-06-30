const formProduit = document.querySelector("#formProduit")
const affichage = document.querySelector("#affichage")
let errors = []

const produits = []
formProduit.addEventListener('keydown', function(e) {
    e.target.classList.remove("border-danger")
})
formProduit.addEventListener('submit', function(e) {
    e.preventDefault()
    let error = false
    errors = []
    // document.querySelector('input[name="titre"]').classList.remove("border-danger")
    // document.querySelector('input[name="prix"]').classList.remove("border-danger")
    // document.querySelector('textarea').classList.remove("border-danger")
    const titre = document.querySelector('input[name="titre"]').value
    if(titre == "") {
        error = true
        errors.push("Merci d'ajouter un titre du produit")
        document.querySelector('input[name="titre"]').classList.add("border-danger")
    }
    const prix = document.querySelector('input[name="prix"]').value
    if(prix == "" || isNaN(prix)) {
        error = true
        errors.push("Merci d'ajouter un prix du produit")
        document.querySelector('input[name="prix"]').classList.add("border-danger")    
    }
    
    const description = document.querySelector("textarea").value
    if(description == "") {
        error = true
        errors.push("Merci d'ajouter un description du produit")
        document.querySelector("textarea").classList.add("border-danger")
    }
    if(!error) {
        produits.push({
            titre : titre,
            prix : prix,
            description : description
        })
        affichage.innerHTML += "<div class='col'>"
        affichage.innerHTML += "<div class='row'><div class='col'>"+titre+"</div></div>"
        affichage.innerHTML += "<div class='row'><div class='col'>"+prix+"</div></div>"
        affichage.innerHTML += "<div class='row'><div class='col'>"+description+"</div></div>"
        affichage.innerHTML += "</div>"
    }
    else {

    }
})