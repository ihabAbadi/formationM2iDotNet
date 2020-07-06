import React, { Component } from "react"
import {BrowserRouter, Route, Switch} from "react-router-dom"
import { BasicInformation } from "./BasicInformation"
import { ContactDetail } from "./ContactDetail"
import { JobPreferences } from "./JobPreferences"
export class Home extends Component {

    constructor(props) {
        super(props)
    }

    render() {
       return( 
       <BrowserRouter>
            <h1>Create your account to Apply</h1>
            <Switch>
                <Route path='/' exact>
                    <BasicInformation></BasicInformation>
                </Route>
                <Route path='/step2'>
                    <ContactDetail></ContactDetail>
                </Route>
                <Route path='/step3'>
                    <JobPreferences></JobPreferences>
                </Route>
            </Switch>
        </BrowserRouter>
        )
    }
}