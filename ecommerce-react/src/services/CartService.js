export const getCart = () => {
    let cart = []
    const cartString = localStorage.getItem("cart")
    if(cartString != undefined) {
        cart = JSON.parse(cartString)
    }
    return cart
}

export const addToCart = (product, q) => {
    const cart = getCart()
    let cartProduct = cart.find(p => p.product.id == product.id)
    if(cartProduct != undefined) {
        cartProduct.qty += q 
    }
    else {
        cart.push({product:product, qty:q})
    }
    saveCart(cart)
}

export const removeFromCart = (product) => {
    let cart = getCart()
    let cartProduct = cart.find(p => p.product.id == product.id)
    if(cartProduct != undefined) {
       cart = cart.filter(p => p.product.id != cartProduct.product.id)
    }
    saveCart(cart)
}

export const updateQty = (id, q) => {
    let cart = getCart()
    let cartProduct = cart.find(p => p.product.id == id)
    if(cartProduct != undefined) {
        cartProduct.qty += q
        if(cartProduct.qty == 0) {
            cart = cart.filter(p => p.product.id != cartProduct.product.id)
        }
        saveCart(cart)
    }
}

export const clearCart = () => {
    localStorage.removeItem("cart")
}

export const totalCart = () => {
    let cart = getCart()
    let total = 0
    cart.forEach(p=> {
        total += p.qty * p.product.price
    })
    return total
}

export const saveCart = (cart) => {
    localStorage.setItem("cart", JSON.stringify(cart))
}

export const prepareOrder = () => {
    let order = {
        total : totalCart(),
        products : []
    }
    getCart().forEach(p => {
        order.products.push({
            ...p
        })
    })

    return order
}