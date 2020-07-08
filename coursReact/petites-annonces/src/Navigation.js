import React, { Component } from "react"
import {BrowserRouter, Switch, Route} from "react-router-dom"
import Header from "./Header"
import Home from "./Home"
import FormAnnonce from "./Annonce/FormAnnonce"
import DetailAnnonce from "./Annonce/DetailAnnonce"
export class Navigation extends Component {

    render() {
        return(
            <BrowserRouter>
                <Header></Header>
                <Switch>
                    <Route render={() => <Home></Home>} path='/' exact>
                        
                    </Route>
                    <Route render={() => <Home favoris={true}></Home>} path='/favoris' >
                        
                    </Route>
                    <Route path='/FormAnnonce'>
                        <FormAnnonce maxImage='4'></FormAnnonce>
                    </Route>
                    <Route path='/DetailAnnonce'>
                        <DetailAnnonce></DetailAnnonce>
                    </Route>
                </Switch>
            </BrowserRouter>
        )
    }
}