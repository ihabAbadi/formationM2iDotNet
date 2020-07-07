import React, { Component } from "react"
import {Link, withRouter} from "react-router-dom"
import {JobService} from "./../services/JobService"

class ContactDetail extends Component {
    constructor(props) {
        super(props)
        if(JobService.etape != 1) {
            this.props.history.push('/')
        }
    }
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
                <button onClick={() => {
                    JobService.etape = 2
                    this.props.history.push('/step3')
                }}  className='col btn form-control btn-primary'>Next</button>
            </div>
        </div>
        )
    }
}

export default withRouter(ContactDetail)