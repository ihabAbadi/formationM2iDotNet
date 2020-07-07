import React, { Component } from "react"
import {Link} from "react-router-dom"
import {DataService} from "./../services/data.service"

export class BasicInformation extends Component{

    render() {
        DataService.objet.name = "new Value"
        return(
            <div className="container">
                <h2 class='row m-1'>{DataService.objet.name} Basic information</h2>
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