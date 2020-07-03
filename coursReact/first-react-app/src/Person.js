import React, { Component } from 'react'
import { Address } from './Address'

export class Person extends Component {
    constructor(props) {
        super(props)
    }


    render() {
        return(
            <div>
                <div>Nom {this.props.personne.nom}</div>
                <div>Prénom {this.props.personne.prenom}</div>
                <div>Téléphone {this.props.personne.tel}</div>
                {/* <Address rue={this.props.rue} ville={this.props.ville} pays={this.props.pays}></Address> */}
                <Address adresse = {this.props.personne.address} />
            </div>
        )
    }
}