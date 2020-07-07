import React, { Component } from "react"
import {JobService} from "./../services/JobService"
export class Confirmation extends Component {
    
    constructor(props) {
        super(props)
        console.log(JobService.data)
    }

    render() {
        
        return(
            <div className="container">
                <div className="row">First Name : {JobService.dataContact.firstName}</div>
                <div className="row">Last Name : {JobService.dataContact.lastName}</div>
                <div className="row">Birth Day: {JobService.dataContact.birthDay}</div>
                <div className="row">Email: {JobService.dataContact.email}</div>
                <div className="row">Phone Number: {JobService.dataContact.phoneNumber}</div>
                <div className="row">Linkedin: {JobService.dataContact.linkedin}</div>
                <div className="row">Location: {JobService.dataContact.location}</div>
                <div className="row">Industry Like: {JobService.dataContact.industryLike}</div>
            </div>
        )
    }
}