import React, { Component } from 'react'
import { Address } from './Address'

export class Person extends Component {
    constructor(props) {
        super(props)
    }


    render() {
        return(
            <div>
                <div>Nom {this.props.nom}</div>
                <div>Prénom {this.props.prenom}</div>
                <div>Téléphone {this.props.tel}</div>
                <Address rue={this.props.rue} ville={this.props.ville} pays={this.props.pays}></Address>
            </div>
        )
    }
}