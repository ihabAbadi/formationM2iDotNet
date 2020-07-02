import  React, { Component }  from 'react'

export class Address extends Component {
    constructor(props) {
        super(props)
    }

    render() {
        return(
            <div>
                <div>Rue : {this.props.rue}</div>
                <div>Ville : {this.props.ville}</div>
                <div>Pays : {this.props.pays}</div>
            </div>
        )
    }
}