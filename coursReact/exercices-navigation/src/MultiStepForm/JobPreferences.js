import React, { Component } from "react"
import {Link, withRouter} from "react-router-dom"
import {JobService} from "./../services/JobService"

class JobPreferences extends Component {
    constructor(props) {
        super(props)
        if(JobService.etape != 2) {
            this.props.history.push('/step2')
        }
        
    }
    changeField = (e) => {
        JobService.dataContact[e.target.name] = e.target.value
    }

    confirm = () => {     
        JobService.data.push(JobService.dataContact)
        //La métode rest est déclarée dans le Ficher service JobService, elle permet de reset l'objet dataContact dans le service 
        JobService.reset()
        JobService.etape = 0
        //L'objet history est ajouté par lafonction withRouter, il permet d'utiliser la méthode push pour naviguer entre les composants de notre BrowserRouter
        this.props.history.push('/confirm')
    }

    render() {
        return(
            <div className="container">
            <h2 className='row m-1'>Job Preferences</h2>
            <div className='row m-1'>
                <input type="text" onChange={this.changeField} defaultValue={JobService.dataContact.location} name="location" className="form-control" placeholder='Your current location' />
            </div>
            <div className='row m-1'>
                <input type="text" onChange={this.changeField} defaultValue={JobService.dataContact.industryLike} name="industryLike" className="form-control" placeholder='wich industry you like' />
            </div>
            <div className='row m-1'>
                <Link to='/step2' className='col btn form-control btn-secondary'>Previous</Link>
                <button onClick={this.confirm}  className='col btn form-control btn-primary'>Confirm your apply</button>
            </div>
        </div>)
    }
}

export default withRouter(JobPreferences)

// export const JobPreferencesBis = withRouter(JobPreferences)