import React, { Component } from "react"
import { Images } from "./Images"

export class Product extends Component {
    constructor(props) {
        super(props)
        this.state = {
            qty : 1,
            total : this.props.price * 1
        }
    }

    // clickProduit = (e) => {
    //     //alert(e.target.innerHTML)
    //     alert("je viens de cliquer sur "+this.props.title)
    // }
    more = () => {
        this.setState({
            qty : this.state.qty+1,
            total : this.props.price * (this.state.qty+1)
        })
    }
    less = () => {
        this.setState({
            qty : this.state.qty-1,
            total : this.props.price * (this.state.qty-1)
        })
    }
    render() {
        return (
            <div>
                <h2>{this.props.title}</h2>
                <div>
                    {this.props.content}
                </div>
                <div>
                    {this.props.price}
                </div>
                <div>
                    Qty : {this.state.qty}
                </div>
                <div>
                    Total : {this.state.total}
                </div>
                <div>
                    <Images uri={this.props.images}></Images>
                </div>
                <div>
                <button onClick={this.less}>moin</button><button onClick={this.more}>Plus</button>
                </div>
                {/* <div onClick={this.clickProduit}>
                    Je clique sur le produit
                </div> */}
            </div>
        )
    }
}
