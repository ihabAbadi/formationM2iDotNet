import React, { Component } from "react"
import { DataService } from "../service/DataService"

class DetailAnnonce extends Component {
    constructor(props) {
        super(props)
        this.state = {
            annonce: DataService.annonce
        }
    }

    renderImages = () => {
        let images = []
        for (let i of this.state.annonce.images) {
            images.push(<img src={i} className='col' />)
        }
        return images
    }
    render() {
        return (
            <section className='container'>
                <div className="row m-1">
                    <h1 className="col">{this.state.annonce.title}</h1>
                </div>
                <div className='row m-1'>
                    {this.renderImages()}
                </div>
                <div className='row m-1'>
                    <div className='col'>
                        {this.state.annonce.description}
                    </div>
                </div>
            </section>
        )
    }
}

export default DetailAnnonce