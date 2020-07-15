import React, { Component, useState, useEffect } from "react"
import { DataService } from "../service/DataService"
import { useParams } from "react-router-dom"
import { ApiService } from "./../service/ApiService"

// class DetailAnnonce extends Component {
//     constructor(props) {
//         super(props)
//         this.state = {
//             annonce: DataService.annonce
//         }
//     }

//     renderImages = () => {
//         let images = []
//         for (let i of this.state.annonce.images) {
//             images.push(<img src={i} className='col' />)
//         }
//         return images
//     }
//     render() {
//         return (
//             <section className='container'>
//                 <div className="row m-1">
//                     <h1 className="col">{this.state.annonce.title}</h1>
//                 </div>
//                 <div className='row m-1'>
//                     {this.renderImages()}
//                 </div>
//                 <div className='row m-1'>
//                     <div className='col'>
//                         {this.state.annonce.description}
//                     </div>
//                 </div>
//             </section>
//         )
//     }
// }

const DetailAnnonce = (props) => {
    const [annonce, setAnnonce] = useState({ title: '', description: '', images: [] })
    const {title} = useParams()
    const [load,setLoad] = useState(false)
    useEffect(()=> {
        ApiService.get('annonce/'+title).then(res=> {
            setAnnonce(res.data)
        })
    },[load])
    const renderImages = () => {
        let images = []
        for (let i of annonce.images) {
            images.push(<img src={i} className='col' />)
        }
        return images
    }
    return (
        <section className='container'>
            <div className="row m-1">
                <h1 className="col">{annonce.title}</h1>
            </div>
            <div className='row m-1'>
                {renderImages()}
            </div>
            <div className='row m-1'>
                <div className='col'>
                    {annonce.description}
                </div>
            </div>
        </section>
    )
}

export default DetailAnnonce