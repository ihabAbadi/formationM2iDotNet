import React, { Component } from "react"

export class FormContact extends Component {

    constructor(props) {
        super(props)
        this.state = {
            contact :undefined
        }
    }

    addContact = () => {
        if(this.state.contact != undefined) {
            this.props.addContact(this.state.contact)
        }
    }
    render() {
        return (
            <div className="container">
                <div className="row justify-content-center">
                    <input type="text" onChange={(e) => {
                        this.setState({
                            contact: e.target.value
                        })
                    }} placeholder="Name of contact" className="form-control col" />
                </div>
                <div className="row justify-content-center">
                    <button onClick={this.addContact} className="form-control btn btn-primary">Add Contact</button>
                </div>
            </div>
        )
    }
}