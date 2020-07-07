import React, { Component } from "react"
import { JobService } from "./../services/JobService"
export class Confirmation extends Component {

    constructor(props) {
        super(props)
        this.state = {
            data: JobService.data
        }
    }

    search = (e) => {
        if(e.target.value != ''){
            this.setState({
                data : JobService.data.filter(element => (element.firstName.includes(e.target.value) || element.lastName.includes(e.target.value)))
            })
        }
        else {
            this.setState({
                data : JobService.data
            })
        }
    }

    render() {

        return (
            <div className="container">
                <div className="row m-1">
                    <input type="text" className="form-control col" onChange={this.search} />
                </div>
                <div className="row">
                    <div className="col">First Name</div>
                    <div className="col">Last Name</div>
                    <div className="col">Birth Day</div>
                    <div className="col">Email</div>
                    <div className="col">Phone Number</div>
                    <div className="col">Linkedin</div>
                    <div className="col">Location</div>
                    <div className="col">Industry Like</div>
                </div>
                {this.state.data.map((c) => {
                    return (
                        <div className="row">
                            <div className="col">{c.firstName}</div>
                            <div className="col">{c.lastName}</div>
                            <div className="col">{c.birthDay}</div>
                            <div className="col">{c.email}</div>
                            <div className="col">{c.phoneNumber}</div>
                            <div className="col">{c.linkedin}</div>
                            <div className="col">{c.location}</div>
                            <div className="col">{c.industryLike}</div>
                        </div>
                    )
                })}

            </div>
        )
    }
}