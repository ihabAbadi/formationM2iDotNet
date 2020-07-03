import React, { Component } from "react"

export class FormProduct extends Component {
    constructor(props) {
        super(props)
        this.state = {
            product : {
                images : []
            },
            numberImageInput : 1
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
        const inputs = []
        for(let i=1; i <= this.state.numberImageInput; i++ ){
            inputs.push(<div><input type='text' placeholder="Url Image" /></div>)
        }
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
                    <div><button onClick={()=>{
                        this.setState({
                            numberImageInput:this.state.numberImageInput+1
                        })
                    }}>Ajouter image</button></div>
                    {inputs}
                    <div>
                        <button type="submit">Valider</button>
                    </div>
                </form>
            </div>
        )
    }

}