import React, { Component } from "react"
import { FormContact } from "./FormContact"
import { Contact } from "./Contact"

export class ListContacts extends Component {
    constructor(props) {
        super(props)
        this.state = {
            contacts : []
        }
    }
    addContact = (contact) => {
        let tmpContacts = [...this.state.contacts, contact]
        this.setState({
            contacts:tmpContacts
        })
    }

    deleteContact = (contact) => {
        let tmpContacts = []
        for(let c of this.state.contacts) {
            if(c != contact) {
                tmpContacts.push(c)
            }
        }
        this.setState({
            contacts: tmpContacts
        })
    }
    render() {
        return(
            <div>
                <FormContact addContact={this.addContact}></FormContact>
                <section className="container">
                    {this.state.contacts.map((c) => {
                        return(
                            <Contact deleteContact={this.deleteContact} name={c}></Contact>
                        )
                    })}
                </section>
            </div>
        )
    }
}