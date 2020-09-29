import React, { Component } from "react"

// export class Contact extends Component {

//     constructor(props) {
//         super(props)
//     }

//     render() {
//         return(
//             <div className="row">
//                 <div className="col-11">
//                     {this.props.name}
//                 </div>
//                 <div onClick={()=> {
//                     this.props.deleteContact(this.props.name)
//                 }} className="col-1">
//                     X
//                 </div>
//             </div>
//         )
//     }
// }

export const Contact = (props) => {
    const {contact} = props

    const renderEmail = () => {
        if(contact != undefined && contact.emails != undefined) {
            return contact.emails.map((email) => (
            <div className="row"><div className="col">{email.mail}</div><div onClick={() => props.deleteEmail(contact.id, email.id)}>X</div></div>
            ))
        }
    }
    return (
        <div className="row">
            <div className="col-6">
                {contact != undefined ? contact.nom + " "+ contact.prenom : ''}
            </div>
            <div className="col-5">
            {renderEmail()}
            </div>
            <div onClick={() => {
                props.deleteContact(contact.id)
            }} className="col-1">
                X
                </div>
                
        </div>
    )
}