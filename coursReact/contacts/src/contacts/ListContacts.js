import React, { Component, useState } from "react"
import { FormContact } from "./FormContact"
import { Contact } from "./Contact"
import axios from "axios"

export class ListContacts extends Component {
    constructor(props) {
        super(props)
        this.state = {
            contacts: []
        }
    }
    componentDidMount() {
        this.getData()
    }

    deleteEmail = (contactId, emailId) => {
        axios.delete("http://localhost:64783/v1/contact/" + contactId + "/email/"+emailId).then(res => {
            if (res.data.message == "succeed") {
                this.getData()
            }
        })
    }
    addContact = (contact) => {
        axios.post("http://localhost:64783/v1/contact", { ...contact }).then(res => {
            if (res.data.message == "succeed") {
                let tmpContacts = [...this.state.contacts, res.data.contact]
                this.setState({
                    contacts: tmpContacts
                })
            }
            else {
                alert("erreur")
            }
        })

    }
    getData = () => {
        axios.get("http://localhost:64783/v1/contact").then((res) => {
            this.setState({
                contacts: res.data
            })
        })
    }
    deleteContact = (id) => {
        axios.delete("http://localhost:64783/v1/contact/" + id).then(res => {
            if (res.data.message == "succeed") {
                this.getData()
            }
        })
    }
    render() {
        return (
            <div>
                <FormContact addContact={this.addContact}></FormContact>
                <section className="container">
                    {this.state.contacts.map((c) => {
                        return (
                            <Contact deleteEmail={this.deleteEmail} deleteContact={this.deleteContact} contact={c}></Contact>
                        )
                    })}
                </section>
            </div>
        )
    }
}

// export const ListContacts = (props) => {

//     const [contacts, setContacts] = useState([])

//     const deleteContact = (contact) => {
//         let tmpContacts = []
//         for(let c of contacts) {
//             if(c != contact) {
//                 tmpContacts.push(c)
//             }
//         }
//         setContacts(tmpContacts)
//     }

//     const addContact = (contact) => {
//         let tmpContacts = [...contacts, contact]
//         setContacts(tmpContacts)
//     }
//     return (
//         <div>
//             <FormContact addContact={addContact}></FormContact>
//             <section className="container">
//                 {contacts.map((c) => {
//                     return (
//                         <Contact deleteContact={deleteContact} name={c}></Contact>
//                     )
//                 })}
//             </section>
//         </div>
//     )
// }