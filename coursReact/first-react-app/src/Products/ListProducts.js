import React, { Component } from "react"
import { Product } from "./Product"

export class ListProduct extends Component {
    constructor(props) {
        super(props)
        this.products= [
            {title:'produit1', content : 'contenu produit 1', price:10, image : 'https://img.phonandroid.com/2020/06/concept-iphone-douze.jpg'},
            {title:'produit2', content : 'contenu produit 2', price:1000, image : 'https://img.phonandroid.com/2020/06/concept-iphone-douze.jpg'},
            {title:'produit3', content : 'contenu produit 3', price:1000, image : 'https://img.phonandroid.com/2020/06/concept-iphone-douze.jpg'},
            {title:'produit3', content : 'contenu produit 3', price:1000, image : 'https://img.phonandroid.com/2020/06/concept-iphone-douze.jpg'},
        ]
    }

    render() {
        return(
            <div>
                <h1>Liste des produits</h1>
                {this.products.map((element) => {
                    return(
                        <Product title={element.title} content={element.content} price={element.price} image={element.image} />
                    )
                })}
            </div>
        )
    }
}