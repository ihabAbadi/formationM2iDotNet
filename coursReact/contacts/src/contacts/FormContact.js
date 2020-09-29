import React, { Component } from "react"

export class FormContact extends Component {

    constructor(props) {
        super(props)
        this.state = {
            contact :{
                nom : '',
                prenom : ''
            }
        }
    }

    updateValueContact = (e) => {
        let tmpContact = {...this.state.contact}
        tmpContact[e.target.name] = e.target.value
        this.setState({
            contact : tmpContact
        })
    }

    addContact = () => {
        if(this.state.contact != undefined) {
            this.props.addContact(this.state.contact)
            this.setState({
                contact : {
                    nom : '',
                    prenom : ''
                }
            })
        }
    }
    render() {
        return (
            <div className="container">
                <div className="row justify-content-center">
                    <input name="nom" value={this.state.contact.nom} onChange={this.updateValueContact} placeholder="Nom" className="form-control col" />
                </div>
                <div className="row justify-content-center">
                    <input name="prenom" value={this.state.contact.prenom} onChange={this.updateValueContact} placeholder="Prénom" className="form-control col" />
                </div>
                <div className="row justify-content-center">
                    <button onClick={this.addContact} className="form-control btn btn-primary">Add Contact</button>
                </div>
            </div>
        )
    }
}

// export const FormContact = (props) => {

//     const [contact, setContact] = useState(undefined)    
//     const addContact = (e) => {
//         if (contact != undefined) {
//             props.addContact(contact)
//         }
//     }
//     return (
//         <div className="container">
//             <div className="row justify-content-center">
//                 <input type="text" onChange={(e) => {
//                     setContact(e.target.value)
//                 }} placeholder="Name of contact" className="form-control col" />
//             </div>
//             <div className="row justify-content-center">
//                 <button onClick={addContact} className="form-control btn btn-primary">Add Contact</button>
//             </div>
//         </div>
//     )
// }

