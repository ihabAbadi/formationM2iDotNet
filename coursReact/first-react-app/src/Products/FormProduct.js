import React, { Component } from "react"

export class FormProduct extends Component {
    constructor(props) {
        super(props)
        this.state = {
            product : {
                images : []
            }
        }
    }

    onChangeField = (e) => {
        // let p = {}
        // for(let key in this.state.product){
        //     p[key] = this.state.product[key]
        // }

        let p = {...this.state.product}
        p[e.target.name] = e.target.value
        this.setState({
            product : p
        })
    }

    submitForm = (e) => {
        e.preventDefault()
        this.props.addProduct(this.state.product)
    }
    render() {
        return(
            <div>
                <form onSubmit={this.submitForm}>
                    <div>
                        <input type="text" onChange={this.onChangeField} name="title" placeholder="Titre  du produit" />
                    </div>
                    <div>
                        <textarea name="content" onChange={this.onChangeField} placeholder="Description du produit"></textarea>
                    </div>
                    <div>
                        <input type="text" onChange={this.onChangeField} name="price" placeholder="Prix  du produit" />
                    </div>
                    <div>
                        <button type="submit">Valider</button>
                    </div>
                </form>
            </div>
        )
    }

}