import React, { Component } from "react"
import {Link} from "react-router-dom"
import {JobService} from "./../services/JobService"

export class JobPreferences extends Component {

    changeField = (e) => {
        JobService.dataContact[e.target.name] = e.target.value
    }

    render() {
        return(
            <div className="container">
            <h2 class='row m-1'>Job Preferences</h2>
            <div className='row m-1'>
                <input type="text" onChange={this.changeField} defaultValue={JobService.dataContact.location} name="location" className="form-control" placeholder='Your current location' />
            </div>
            <div className='row m-1'>
                <input type="text" onChange={this.changeField} defaultValue={JobService.dataContact.industryLike} name="industryLike" className="form-control" placeholder='wich industry you like' />
            </div>
            <div className='row m-1'>
                <Link to='/step2' className='col btn form-control btn-secondary'>Previous</Link>
                <Link to='/confirm' className='col btn form-control btn-primary'>Confirm your apply</Link>
            </div>
        </div>)
    }
}