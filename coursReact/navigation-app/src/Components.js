import React, { Component } from "react"

export class ComponentA extends Component {

    render() {
        return(
            <div>
                <h1>Je suis le component A</h1>
            </div>
        )
    }
}

export class ComponentB extends Component {

    render() {
        return(
            <div>
                <h1>Je suis le component B</h1>
            </div>
        )
    }
}

export class Home extends Component {
    render() {
        return(
            <div>
                <h1>Je suis la page d'accueil</h1>
            </div>
        )
    }
}