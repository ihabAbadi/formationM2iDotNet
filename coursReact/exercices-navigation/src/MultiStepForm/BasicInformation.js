import React, { Component } from "react"
import {Link} from "react-router-dom"
export class BasicInformation extends Component{

    render() {
        return(
            <div className="container">
                <h2 class='row m-1'>Basic information</h2>
                <div className='row m-1'>
                    <input type="text" className="form-control" placeholder='Your first name' />
                </div>
                <div className='row m-1'>
                    <input type="text" className="form-control" placeholder='Your last name' />
                </div>
                <div className='row m-1'>
                    <input type="date" className="form-control" placeholder='Your birth day' />
                </div>
                <div className='row m-1'>
                    <Link to='/step2' className='col offset-6 btn form-control btn-primary'>Next</Link>
                </div>
            </div>
        )
    }
}