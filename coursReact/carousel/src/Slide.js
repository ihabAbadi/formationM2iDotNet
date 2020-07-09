import React, { Component } from "react"

export class Slide extends Component {
    constructor(props) {
        super(props)
    }

    render() {
        return (
            <div className={(this.props.index == this.props.indexActivation) ? 'slide-active col-10 text-center' : 'slide-noactive'}>
                <h1>{this.props.title}</h1>
                <div>{this.props.content}</div>
            </div>
        )
    }
}