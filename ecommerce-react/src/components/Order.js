import React, { Component } from "react"
import { testToken } from "../services/ApiService"


export class Order extends Component {
    constructor(props) {
        super(props)

    }

   
    render() {
        return (
            <div className="container">
                <div className="row justify-content-center align-item-center">
                    <div className="col-5">
                        <div className="row m-1">
                            <h1>Commande</h1>
                        </div>

                    </div>
                </div>
            </div>
        )
    }
}