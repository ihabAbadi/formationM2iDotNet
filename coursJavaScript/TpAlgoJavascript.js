const prompt = require("prompt-sync")()
let products = []
let cart = []
let endCarts = []
mainStart(console.log, prompt)
//Fonction principale
function mainStart(displayMethod, promptMethod) {
    let choix
    do {
        mainMenu(displayMethod)
        choix = parseInt(promptMethod("Votre choix : "))
        switch(choix) {
            case 1:
                mainProduct(displayMethod, promptMethod)
                break;
            case 2:
                mainCart(displayMethod, promptMethod)
                break;
            case 3:
                break;
            default:
                displayMethod("Erreur menu")
                break
        }
    }while(choix != 3)
}

//Fonction gestion produit
function mainProduct(displayMethod, promptMethod) {
    let choix
    do {
        productMenu(displayMethod)
        choix = parseInt(promptMethod("Votre choix : "))
        switch(choix) {
            case 1:
                addProduct(displayMethod, promptMethod)
                break;
            case 2:
                editProduct(displayMethod, promptMethod)
                break;
            case 3:
                deleteProduct(displayMethod, promptMethod)
                break;
            case 4:
                break;
            default:
                displayMethod("Erreur menu")
                break;
        }
    }while(choix != 4)   
}

//Fonction ajouter un produit
function addProduct(displayMethod, promptMethod) {
    //chaque  produit a un nom, prix, stock, numeroUnique
    const productTitle = promptMethod("Merci de saisir le nom du produit : ")
    const productPrice = parseFloat(promptMethod("Merci de saisir le prix du produit : "))
    const productStock = parseInt(promptMethod("Merci de saisir le stock initial : "))
    const product = {
        'title' : productTitle,
        'price' : productPrice,
        'stock' : productStock,
        'id' : (products.length == 0) ? 1 : products[products.length-1]['id'] + 1
    }
    products.push(product)
    displayMethod("Votre produit a été correctement ajouté avec le numéro : " + product["id"])
}


function editProduct(displayMethod, promptMethod) {
    let productFounded = searchProductById(promptMethod, 'product')
    if(productFounded == undefined) {
        displayMethod("Aucun produit trouvé")
    }
    else {
        productFounded["title"] = promptMethod("Merci de saisir le nouveau nom du produit : ")
        productFounded["price"] = parseFloat(promptMethod("Merci de saisir le nouveau prix du produit : "))
        productFounded["stock"] = parseInt(promptMethod("Merci de saisir le nouveau stock : "))
        displayMethod("produit modifié")
    }
}

function deleteProduct(displayMethod, promptMethod) {
    let indexProduct = searchProductById(promptMethod, 'index')
    if(indexProduct == undefined) {
        displayMethod("Aucun produit trouvé")
    }
    else {
       products.splice(indexProduct,1)
    }
}

function searchProductById(promptMethod, returnValue) {
    let productFounded, index
    const id = promptMethod("Merci de saisir l'id du produit recherché : ")
    for(let i=0; i < products.length; i++) {
        if(products[i]['id'] == id) {
            productFounded = products[i]
            index = i
            break
        }
    }
    return (returnValue == 'product') ? productFounded : index
}

function searchProductByIdWithOutPrompt(id, returnValue) {
    let productFounded, index
    for(let i=0; i < products.length; i++) {
        if(products[i]['id'] == id) {
            productFounded = products[i]
            index = i
            break
        }
    }
    return (returnValue == 'product') ? productFounded : index
}

//Fonction gestion panier
function mainCart(displayMethod, promptMethod){
    let choix
    do {
        cartMenu(displayMethod)
        choix = parseInt(promptMethod("Votre choix : "))
        switch(choix) {
            case 1:
                addProductToCart(displayMethod, promptMethod)
                break;
            case 2:
                deleteProductInCart(displayMethod, promptMethod)
                break;
            case 3:
                displayCart(displayMethod)
                break;
            case 4:
                confirmCart(displayMethod)
                displayMethod(products)
                displayMethod(endCarts)
                break;
            case 5:
                break;
            default:
                displayMethod("Erreur menu")
                break;
        }
    }while(choix != 5)  
}


function addProductToCart(displayMethod, promptMethod) {
    let productFounded = searchProductById(promptMethod, "product")
    if(productFounded == undefined) {
        displayMethod("Aucun produit avec cet id dans le magasin")
    }
    else {
        let cartSearchProduct = searchProductInCart(productFounded['id'], 'product')
        if(cartSearchProduct == undefined) {
            //Ajout du produit dans le panier s'il n'existe pas déjà
            const cartProduct = {
                'id' : productFounded['id'],
                'title' : productFounded['title'],
                'price' : productFounded['price'],
                'qty' : 1
            }
            cart.push(cartProduct)
        }
        else {
            cartSearchProduct['qty'] += 1
        }
        
    }
}

function searchProductInCart(id, returnType) {
    let cartProductFounded, index
    for(let i=0; i < cart.length; i++) {
        if(cart[i]['id'] == id) {
            cartProductFounded = cart[i]
            index = i
            break
        }
    }
    return returnType == 'product' ? cartProductFounded : index
}

function deleteProductInCart(displayMethod, promptMethod) {
    const id = promptMethod("L'id du produit à enlever du panier : ")
    let cartSearchProduct = searchProductInCart(id, 'product')
    if(cartSearchProduct == undefined) {
        displayMethod("Aucun produit avec cet id dans le panier")
    }
    else {
        if(cartSearchProduct["qty"] > 1) {
            cartSearchProduct["qty"] -= 1
        }
        else {
            let index = searchProductInCart(id, 'index')
            cart.splice(index,1)
        }
    }
}

function confirmCart(displayMethod) {
    for(let i=0; i < cart.length; i++) {
        let productStock = searchProductByIdWithOutPrompt(cart[i]["id"], 'product')
        productStock["stock"] -= cart[i]["qty"]
    }
    endCarts.push(cart)
    cart = []
    displayMethod("---Panier validé----")
}

function displayCart(displayMethod) {
    displayMethod("-------Détail panier----------")
    let total = 0
    for(let i=0; i < cart.length; i++) {
        displayMethod("Id : "+cart[i]['id'] + ", Titre : "+cart[i]['title'] + ", Prix U.T : "+cart[i]['price']+", Qty : "+cart[i]['qty']+", Total U.T : "+(cart[i]['price']*cart[i]['qty']))
        total += cart[i]['price']*cart[i]['qty']
    }
    displayMethod("Total Panier : "+ total)
}

function mainMenu(displayMethod) {
    displayMethod("1-- Gestion produit")
    displayMethod("2-- Gestion panier")
    displayMethod("3-- Quittter")
}

function productMenu(displayMethod) {
    displayMethod("1-- Ajouter un produit")
    displayMethod("2-- Modifier un produit")
    displayMethod("3-- Supprimer un produit")
    displayMethod("4-- Retour")
}

function cartMenu(displayMethod) {
    displayMethod("1-- Ajouter un produit au panier")
    displayMethod("2-- Supprimer un produit du panier")
    displayMethod("3-- Afficher le detail du panier")
    displayMethod("4-- Valider le panier")
    displayMethod("5-- Retour")
}