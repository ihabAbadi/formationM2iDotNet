import React, { Component } from "react"

export class Contact extends Component {
    
    constructor(props) {
        super(props)
    }

    render() {
        return(
            <div className="row">
                <div className="col-11">
                    {this.props.name}
                </div>
                <div onClick={()=> {
                    this.props.deleteContact(this.props.name)
                }} className="col-1">
                    X
                </div>
            </div>
        )
    }
}