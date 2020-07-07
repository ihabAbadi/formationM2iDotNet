import React, { Component } from "react"
import {Link} from "react-router-dom"
import {JobService} from "./../services/JobService"

export class ContactDetail extends Component {

    changeField = (e) => {
        JobService.dataContact[e.target.name] = e.target.value
    }

    render() {
        return(
            <div className="container">
            <h2 class='row m-1'>Contact Détail</h2>
            <div className='row m-1'>
                <input type="text" onChange={this.changeField} defaultValue={JobService.dataContact.email} name="email"  className="form-control" placeholder='Your Email' />
            </div>
            <div className='row m-1'>
                <input type="text" onChange={this.changeField} defaultValue={JobService.dataContact.phoneNumber} name="phoneNumber" className="form-control" placeholder='Your Phone number' />
            </div>
            <div className='row m-1'>
                <input type="text" onChange={this.changeField} defaultValue={JobService.dataContact.linkedin} name="linkedin" className="form-control" placeholder='Your Linkedin' />
            </div>
            <div className='row m-1'>
                <Link to='/' className='col btn form-control btn-secondary'>Previous</Link>
                <Link to='/step3' className='col btn form-control btn-primary'>Next</Link>
            </div>
        </div>
        )
    }
}