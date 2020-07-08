import React, { Component } from "react"
import {DataService} from "./service/DataService"
import Annonces from "./Annonce/Annonces"
import Search from "./Search"
class Home extends Component {
    constructor(props) {
        super(props)
        this.state = {
            annonces: DataService.annonces
        }
    }

    search = (text) => {
        let tmpAnnonces
        if(text == '' || text == undefined) {
            tmpAnnonces = DataService.annonces
        }
        else {
            tmpAnnonces =  DataService.annonces.filter(a=> (a.title.includes(text) || a.description.includes(text)))
        }
        this.setState({
            annonces: tmpAnnonces
        })
    }
    render() {
        return(
            <main >
                <Search textSearch='Rechercher une annonce...' search={this.search}/>
                <Annonces annonces={this.state.annonces}></Annonces>
            </main>
        )
    }
}

export default Home