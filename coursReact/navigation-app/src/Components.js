import React, { Component } from "react"
import {withRouter} from "react-router-dom"

export class ComponentA extends Component {

    render() {
        return(
            <div>
                <h1>Je suis le component A</h1>
            </div>
        )
    }
}

class ComponentB extends Component {
    constructor(props) {
        super(props)
    }
    render() {
        return(
            <div>
                <h1>Je suis le component B</h1>
                <button onClick={()=> {
                    this.props.history.push('/a')
                }}>Redirection vers A</button>
            </div>
        )
    }
}
export default withRouter(ComponentB)
export class Home extends Component {
    render() {
        return(
            <div>
                <h1>Je suis la page d'accueil</h1>
            </div>
        )
    }
}