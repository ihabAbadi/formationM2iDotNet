import React, { Component } from "react"
import {DataService} from "./service/DataService"
import Annonces from "./Annonce/Annonces"
import Search from "./Search"
import axios from "axios"
class Home extends Component {
    constructor(props) {
        super(props)
        this.state = {
            annonces: []
        }
    }

    componentDidMount() {
        console.log(this.props.favoris)
        // this.setState({
        //     annonces : (this.props.favoris != undefined && this.props.favoris == true) ? DataService.favorisAnnonces : DataService.annonces
        // })
        axios.get('http://localhost:80/annonces').then(response=> {
            console.log(response)
            const res = response.data
            this.setState({
                annonces : res
            })
        })
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