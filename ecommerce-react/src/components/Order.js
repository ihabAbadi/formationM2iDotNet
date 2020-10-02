import React, { Component } from "react"
import { testToken } from "../services/ApiService"
import Cart from "./Cart/Cart"


export class Order extends Component {
    constructor(props) {
        super(props)

    }

    componentDidMount() {
        testToken().then((res) => {

        }).catch(err=> {
            this.props.history.push("/login")
        })
    }
    render() {
        return (
            <div className="container">
                <div className="row justify-content-center align-item-center">
                    <div className="col-5">
                        <div className="row m-1">
                            <h1>Commande</h1>
                        </div>
                        <Cart {...this.props}/>
                    </div>
                </div>
            </div>
        )
    }
}