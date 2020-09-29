import React, { Component, useState } from "react"
import { FormContact } from "./FormContact"
import { Contact } from "./Contact"
import { Table, Input, InputNumber, Popconfirm, Form } from 'antd';
import axios from "axios"

export class ListContacts extends Component {
    constructor(props) {
        super(props)
        this.state = {
            contacts: [],
            idContactEditing: undefined,
            contact : {
                nom : '',
                prenom : ''
            }
        }
    }
    componentDidMount() {
        this.getData()
    }

    deleteEmail = (contactId, emailId) => {
        axios.delete("http://localhost:64783/v1/contact/" + contactId + "/email/" + emailId).then(res => {
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

    edit = (record) => {
        console.log(record)
        this.setState({
            idContactEditing: record.id
        })
    }

    updateCellValue = (index, value) => {
        let tmpContact = {...this.state.contact}
        tmpContact[index] = value
        this.setState({
            contact : tmpContact
        })
    }

    saveContact = (id) => {
        const contact = {...this.state.contact}
        axios.put("http://localhost:64783/v1/contact/" + id,contact).then((res) => {
            if(res.data.message == "succeed"){
                this.setState({
                    idContactEditing : undefined
                })
                this.getData()
            }
        })
    }
    render() {

        const columns = [
            {
                title: 'Nom',
                dataIndex: 'nom',
                editable: true,
            },
            {
                title: 'Prénom',
                dataIndex: 'prenom',
                editable: true,
            },
            {
                title: "Opération",
                render: (_, record) => {
                    return (
                        (this.state.idContactEditing == record.id) ? <a onClick={() =>this.saveContact(record.id)}> Enregistrer</a> : 
                        <a onClick={() => this.edit(record)}>Modifier</a>
                    )
                },
                editable: false,
            }
        ]

        const mergedColumns = columns.map((col) => {
            if (!col.editable) {
                return col;
            }

            return {
                ...col,
                onCell: (record) => ({
                    record,
                    inputType: col.dataIndex === 'age' ? 'number' : 'text',
                    dataIndex: col.dataIndex,
                    title: col.title,
                    updateContactCell : this.updateCellValue,
                    editing: this.state.idContactEditing == record.id,
                }),
            };
        });
        
        return (
            
            <div>
                <FormContact addContact={this.addContact}></FormContact>
                {/* <section className="container">
                    {this.state.contacts.map((c) => {
                        return (
                            <Contact deleteEmail={this.deleteEmail} deleteContact={this.deleteContact} contact={c}></Contact>
                        )
                    })}
                </section> */}
                
                <Table components={{
                    body: {
                        cell: Contact,
                    },
                }} bordered dataSource={this.state.contacts}
                    columns={mergedColumns}
                    rowClassName="editable-row" />
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