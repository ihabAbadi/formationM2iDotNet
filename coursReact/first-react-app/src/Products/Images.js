import React, { Component } from "react"

export class Images extends Component {
    constructor(props) {
        super(props)
    }

    render() {
        return (
            <div>
                {this.props.uri.map((image) => {
                    return (<img src={image} />)
                })}
            </div>
        )
    }
}