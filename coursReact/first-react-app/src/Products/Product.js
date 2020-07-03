import React, { Component } from "react"
import { Images } from "./Images"

export class Product extends Component {
    constructor(props) {
        super(props)
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
                    <Images uri={this.props.images}></Images>
                </div>
            </div>
        )
    }
}
