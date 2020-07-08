import React, { Component } from "react"
import {DataService} from "./service/DataService"
import Annonces from "./Annonce/Annonces"
class Home extends Component {
    constructor(props) {
        super(props)
        this.state = {
            annonces: DataService.annonces
        }
    }
    render() {
        return(
            <main >
                <Annonces annonces={this.state.annonces}></Annonces>
            </main>
        )
    }
}

export default Home