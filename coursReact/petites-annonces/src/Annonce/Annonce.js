import React, { Component, useState } from "react"
import { DataService } from "./../service/DataService"
import { withRouter, useHistory } from "react-router-dom"
// class Annonce extends Component {
//     constructor(props) {
//         super(props)
//         this.state = {
//             isFavoris: (DataService.favorisAnnonces.find(e => e.title == this.props.annonce.title) != undefined)
//         }
//     }

//     redirectTo = () => {
//         DataService.annonce = this.props.annonce
//         this.props.history.push('/DetailAnnonce')
//     }

//     clickFavoris = () => {
//         let tmpIsFavoris = !this.state.isFavoris
//         this.setState({
//             isFavoris: tmpIsFavoris
//         })
//         if (tmpIsFavoris) {
//             DataService.favorisAnnonces.push(this.props.annonce)
//         }
//         else {
//             DataService.favorisAnnonces = DataService.favorisAnnonces.filter(element => element.title != this.props.annonce.title)
//         }
//     }

//     render() {
//         return (
//             <div className="row m-1">
//                 <img className="col-3" src={this.props.annonce.images[0]} />
//                 <div className='col-9'>
//                     <div className='row m-1'>
//                         <h2 className='col'>
//                             {this.props.annonce.title}
//                         </h2>
//                     </div>
//                     <div className='row m-1'>
//                         <div className='col'>
//                             {this.props.annonce.description.substr(1, 200)}
//                         </div>
//                     </div>
//                     <div className="row m-1">
//                         <button onClick={this.redirectTo} className='col btn btn-primary'>Detail</button>
//                     </div>
//                     <div className="row m-1">
//                         <i onClick={this.clickFavoris} className={(this.state.isFavoris) ? 'col fa fa-heart' : 'col fa fa-heart-o'} aria-hidden="true"></i>
//                     </div>
//                 </div>
//             </div>
//         )
//     }
// }


const Annonce = (props) => {
    const history = useHistory()
    const [isFavoris, setIsFavoris] = useState(false) 
    const redirectTo = () => {
        DataService.annonce = props.annonce
        history.push('/DetailAnnonce/'+props.annonce.title)
    }

    const clickFavoris = () => {
        let tmpIsFavoris = !isFavoris
        setIsFavoris(tmpIsFavoris)
        if (tmpIsFavoris) {
            DataService.favorisAnnonces.push(this.props.annonce)
        }
        else {
            DataService.favorisAnnonces = DataService.favorisAnnonces.filter(element => element.title != props.annonce.title)
        }
    }


    return (
        <div className="row m-1">
            <img className="col-3" src={props.annonce.images[0]} />
            <div className='col-9'>
                <div className='row m-1'>
                    <h2 className='col'>
                        {props.annonce.title}
                    </h2>
                </div>
                <div className='row m-1'>
                    <div className='col'>
                        {props.annonce.description.substr(1, 200)}
                    </div>
                </div>
                <div className="row m-1">
                    <button onClick={redirectTo} className='col btn btn-primary'>Detail</button>
                </div>
                <div className="row m-1">
                    <i onClick={clickFavoris} className={(isFavoris) ? 'col fa fa-heart' : 'col fa fa-heart-o'} aria-hidden="true"></i>
                </div>
            </div>
        </div>
    )
}
export default withRouter(Annonce)