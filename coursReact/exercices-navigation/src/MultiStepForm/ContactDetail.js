import React, { Component } from "react"
import {Link} from "react-router-dom"
import {DataService} from "./../services/data.service"

export class ContactDetail extends Component {

    render() {
        return(
            <div className="container">
            <h2 class='row m-1'>{DataService.objet.name}Contact Détail</h2>
            <div className='row m-1'>
                <input type="text" className="form-control" placeholder='Your Email' />
            </div>
            <div className='row m-1'>
                <input type="text" className="form-control" placeholder='Your Phone number' />
            </div>
            <div className='row m-1'>
                <input type="text" className="form-control" placeholder='Your Linkedin' />
            </div>
            <div className='row m-1'>
                <Link to='/' className='col btn form-control btn-secondary'>Previous</Link>
                <Link to='/step3' className='col btn form-control btn-primary'>Next</Link>
            </div>
        </div>
        )
    }
}