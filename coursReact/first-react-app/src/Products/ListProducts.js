import React, { Component } from "react"
import { Product } from "./Product"

export class ListProduct extends Component {
    constructor(props) {
        super(props)
        this.products= [
            {title:'produit1', content : 'contenu produit 1', price:10, images : ['https://picsum.photos/id/1002/200','https://picsum.photos/id/1005/200','https://picsum.photos/id/1010/200']},
            {title:'produit2', content : 'contenu produit 2', price:1000, images : ['https://picsum.photos/id/1003/200','https://picsum.photos/id/1006/200','https://picsum.photos/id/1011/200']},
            {title:'produit3', content : 'contenu produit 3', price:1000, images : ['https://picsum.photos/id/1004/200','https://picsum.photos/id/1012/200','https://picsum.photos/id/1008/200']},
        ]
    }

    render() {
        return(
            <div>
                <h1>Liste des produits</h1>
                {this.products.map((element) => {
                    return(
                        <Product title={element.title} content={element.content} price={element.price} images={element.images} />
                    )
                })}
            </div>
        )
    }
}