import React, { Component } from "react"
import {Link, withRouter} from "react-router-dom"
import {JobService} from "./../services/JobService"

class BasicInformation extends Component{
    constructor(props) {
        super(props)
    }
    changeField = (e) => {
        JobService.dataContact[e.target.name] = e.target.value
    }

    render() {
        
        return(
            <div className="container">
                <h2 class='row m-1'>Basic information</h2>
                <div className='row m-1'>
                    <input type="text" onChange={this.changeField} name="firstName" defaultValue={JobService.dataContact.firstName} className="form-control" placeholder='Your first name' />
                </div>
                <div className='row m-1'>
                    <input type="text" onChange={this.changeField} name="lastName" defaultValue={JobService.dataContact.lastName} className="form-control" placeholder='Your last name' />
                </div>
                <div className='row m-1'>
                    <input type="date" onChange={this.changeField} name="birthDay" defaultValue={JobService.dataContact.birthDay} className="form-control" placeholder='Your birth day' />
                </div>
                <div className='row m-1'>
                    <button onClick={() => {
                        JobService.etape = 1
                        this.props.history.push('/step2')
                    }} className='col offset-6 btn form-control btn-primary'>Next</button>
                </div>
            </div>
        )
    }
}

export default withRouter(BasicInformation)