import React, { Component } from "react"
import {Link} from "react-router-dom"

export class JobPreferences extends Component {
    render() {
        return(
            <div className="container">
            <h2 class='row m-1'>Job Preferences</h2>
            <div className='row m-1'>
                <input type="text" className="form-control" placeholder='Your current location' />
            </div>
            <div className='row m-1'>
                <input type="text" className="form-control" placeholder='wich industry you like' />
            </div>
            <div className='row m-1'>
                <Link to='/step2' className='col btn form-control btn-secondary'>Previous</Link>
                <button className='col btn form-control btn-primary'>Confirm your apply</button>
            </div>
        </div>)
    }
}