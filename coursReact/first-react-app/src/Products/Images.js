import React, { Component } from "react"

export class Images extends Component {
    constructor(props) {
        super(props)
    }

    render() {
        return (
            <div>
                <img src={this.props.uri} />
            </div>
        )
    }
}