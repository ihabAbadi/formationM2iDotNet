import React, { Component, useState, useEffect } from "react"
import { DataService } from "./service/DataService"
import Annonces from "./Annonce/Annonces"
import Search from "./Search"
// import axios from "axios"
import { ApiService } from "./service/ApiService"
// class Home extends Component {
//     constructor(props) {
//         super(props)
//         this.state = {
//             annonces: []
//         }
//     }

//     componentDidMount() {
//         console.log(this.props.favoris)
//         // this.setState({
//         //     annonces : (this.props.favoris != undefined && this.props.favoris == true) ? DataService.favorisAnnonces : DataService.annonces
//         // })
//         // axios.get('http://localhost:80/annonces').then(response=> {
//         //     console.log(response)
//         //     const res = response.data
//         //     this.setState({
//         //         annonces : res
//         //     })
//         // })
//         ApiService.get('annonces').then(response => {
//             this.setState({
//                 annonces : response.data
//             })
//         })
//     }


//     search = (text) => {
//         let tmpAnnonces
//         if(text == '' || text == undefined) {
//             tmpAnnonces = DataService.annonces
//         }
//         else {
//             tmpAnnonces =  DataService.annonces.filter(a=> (a.title.includes(text) || a.description.includes(text)))
//         }
//         this.setState({
//             annonces: tmpAnnonces
//         })
//     }
//     render() {
//         return(
//             <main >
//                 <Search textSearch='Rechercher une annonce...' search={this.search}/>
//                 <Annonces annonces={this.state.annonces}></Annonces>
//             </main>
//         )
//     }
// }

const Home = (props) => {
    const search = (text) => {
        
        let tmpAnnonces
        if (text == '' || text == undefined) {
            tmpAnnonces = DataService.annonces
        }
        else {
            tmpAnnonces = DataService.annonces.filter(a => (a.title.includes(text) || a.description.includes(text)))
        }
        setAnnonces(tmpAnnonces)
    }

    const [annonces, setAnnonces] = useState([])
    const [loading,setLoading] = useState(false)
    useEffect(() => {
        ApiService.get('annonces').then(response => {
            setAnnonces(response.data)
        })
    },[loading])

    const reload = () => {
        setLoading(!loading)
    }

    return (
        <main >
            <button onClick = {reload}>Reload</button>
            <Search textSearch='Rechercher une annonce...' search={search} />
            <Annonces reload={reload} annonces={annonces}></Annonces>
        </main>
    )
}

export default Home