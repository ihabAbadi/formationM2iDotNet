import React, { Component, useState } from "react"
import { FormContact } from "./FormContact"
import { Contact } from "./Contact"

// export class ListContacts extends Component {
//     constructor(props) {
//         super(props)
//         this.state = {
//             contacts : []
//         }
//     }
//     addContact = (contact) => {
//         let tmpContacts = [...this.state.contacts, contact]
//         this.setState({
//             contacts:tmpContacts
//         })
//     }

//     deleteContact = (contact) => {
//         let tmpContacts = []
//         for(let c of this.state.contacts) {
//             if(c != contact) {
//                 tmpContacts.push(c)
//             }
//         }
//         this.setState({
//             contacts: tmpContacts
//         })
//     }
//     render() {
//         return(
//             <div>
//                 <FormContact addContact={this.addContact}></FormContact>
//                 <section className="container">
//                     {this.state.contacts.map((c) => {
//                         return(
//                             <Contact deleteContact={this.deleteContact} name={c}></Contact>
//                         )
//                     })}
//                 </section>
//             </div>
//         )
//     }
// }

export const ListContacts = (props) => {

    const [contacts, setContacts] = useState([])

    const deleteContact = (contact) => {
        let tmpContacts = []
        for(let c of contacts) {
            if(c != contact) {
                tmpContacts.push(c)
            }
        }
        setContacts(tmpContacts)
    }

    const addContact = (contact) => {
        let tmpContacts = [...contacts, contact]
        setContacts(tmpContacts)
    }
    return (
        <div>
            <FormContact addContact={addContact}></FormContact>
            <section className="container">
                {contacts.map((c) => {
                    return (
                        <Contact deleteContact={deleteContact} name={c}></Contact>
                    )
                })}
            </section>
        </div>
    )
}