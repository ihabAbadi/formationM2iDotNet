import React, { Component } from "react"
import {DataService} from "./../service/DataService"
import {withRouter} from "react-router-dom"
// import axios from "axios"
import {ApiService} from "./../service/ApiService"
import { ColorContext } from "../ColorContext"
class FormAnnonce extends Component {
    static contextType = ColorContext
    constructor(props) {
        super(props)
        this.state = {
            annonce : {
                title : '',
                description : '',
                images : []
            },
            nombreImage : 1,
            tmpImage : undefined
        }

    }

    addImage = () => {
        if(this.state.tmpImage != undefined && this.state.nombreImage < this.props.maxImage) {
            let tmpAnnonce = {...this.state.annonce}
            tmpAnnonce.images.push(this.state.tmpImage)
            this.setState({
                annonce : tmpAnnonce,
                tmpImage : undefined,
                nombreImage : this.state.nombreImage + 1
            })
        }
    }

    changeFieldImage = (e) => {
        this.setState({
            tmpImage : e.target.value
        })
    }

    renderInputImage = () => {
        let renderImages = []
        for(let i=1; i <= this.state.nombreImage; i++){
            renderImages.push(<div className="row m-1"><input type="text" onChange={this.changeFieldImage} className="col form-control" placeholder="URL image" /></div>)
        }
        return renderImages
    }

    changeField = (e) => {
        let tmpAnnonce = {...this.state.annonce}
        tmpAnnonce[e.target.name] = e.target.value
        this.setState({
            annonce : tmpAnnonce
        })
    }

    addAnnonce = (e) => {
        e.preventDefault()
        //DataService.annonces.push(this.state.annonce)
        // axios.post('http://localhost:80/addAnnonce',this.state.annonce).then(res=> {
        //     console.log(res)
        //     this.props.history.push('/')
        // })
        ApiService.post('addAnnonce', this.state.annonce).then(res=> {
            this.props.history.push('/')
        })        
    }
    render(){
        return(
            <form className="container" onSubmit={this.addAnnonce}>
                <div className="row m-1">
                    <input onChange={this.changeField} type="text" className="col form-control" name="title" placeholder="Titre de l'annonce" />
                </div>
                <div className="row m-1">
                    <textarea onChange={this.changeField} className="col form-control" name="description" placeholder="Description de l'annonce" ></textarea>
                </div>
                <div className='row m-1'>
                    <span className='col-11'>Images Max({this.props.maxImage}) </span>
                    <span className='col-1 text-right'><i onClick={this.addImage} className="fa fa-plus-circle btn" aria-hidden="true"></i></span>
                </div>
                {this.renderInputImage()}
                <div className="row m-1">
                    <button type='submit' style={{color:this.context}} className="col btn form-control btn-success">Valider</button>
                </div>
            </form>
        )
    }
}

export default withRouter(FormAnnonce)