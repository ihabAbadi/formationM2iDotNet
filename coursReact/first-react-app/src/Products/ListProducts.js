import React, { Component } from "react"
import { Product } from "./Product"

export class ListProduct extends Component {
    constructor(props) {
        super(props)
    }

    render() {
        return(
            <div>
                <h1>Liste des produits</h1>
                <Product title="produit 1" content="content produit 1" price="10" image="https://img.phonandroid.com/2020/06/concept-iphone-douze.jpg"></Product>
                <Product title="produit 2" content="content produit 2" price="1000" image="https://img.phonandroid.com/2020/06/concept-iphone-douze.jpg"></Product>
            </div>
        )
    }
}