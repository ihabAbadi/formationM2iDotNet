import React, { Component } from "react"
import { Product } from "./Product"

export class ListProduct extends Component {
    constructor(props) {
        super(props)
        this.state = {
            products: [
                { title: 'produit1', content: 'contenu produit 1', price: 10, images: ['https://picsum.photos/id/1002/200', 'https://picsum.photos/id/1005/200', 'https://picsum.photos/id/1010/200'] },
                { title: 'produit2', content: 'contenu produit 2', price: 1000, images: ['https://picsum.photos/id/1003/200', 'https://picsum.photos/id/1006/200', 'https://picsum.photos/id/1011/200'] },
                { title: 'produit3', content: 'contenu produit 3', price: 1000, images: ['https://picsum.photos/id/1004/200', 'https://picsum.photos/id/1012/200', 'https://picsum.photos/id/1008/200'] },
            ],
            total: 0
        }
    }

    delete = (title) => {
        // let tmpProducts = []
        // for(let product of this.state.products){
        //     if(product.title != title) {
        //         tmpProducts.push(product)
        //     }
        // }
        // this.setState({
        //     products : tmpProducts
        // })
        this.setState({
            products: this.state.products.filter(product => product.title != title)
        })
    }
    updateTotal = (montant) => {
        let total = this.state.total + montant
        this.setState({
            total : total
        })
    }
    render() {
        return (
            <div>
                <h1>Liste des produits</h1>
                <div>Total : {this.state.total}</div>
                {this.state.products.map((element) => {
                    return (
                        <div>
                            <Product updateTotal={this.updateTotal} delete={this.delete} title={element.title} content={element.content} price={element.price} images={element.images} />
                            {/* <button onClick={() => {this.delete(element.title)}}>Supprimer</button> */}
                        </div>
                    )
                })}
            </div>
        )
    }
}