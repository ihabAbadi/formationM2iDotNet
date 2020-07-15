import React, { Component } from "react"
import { BrowserRouter, Switch, Route } from "react-router-dom"
import Header from "./Header"
import Home from "./Home"
import FormAnnonce from "./Annonce/FormAnnonce"
import DetailAnnonce from "./Annonce/DetailAnnonce"
import faker from "faker"
import { ColorContext } from "./ColorContext"
export class Navigation extends Component {
    constructor(props) {
        super(props)
        console.log(faker.name.findName())
        this.state = {
            style : {
                color : 'black',
                backgroundColor : 'white'
            }
        }
    }
    changeStyle = (e) => {
        let tmpStyle
        if(e.target.value == 'dark') {
            tmpStyle = {
                color : 'white',
                backgroundColor : 'black'
            }
        }else if(e.target.value == 'light') {
            tmpStyle = {
                color : 'black',
                backgroundColor : 'white'
            }
        }
        this.setState({
            style : tmpStyle
        })
    }
    render() {
        return (
            <BrowserRouter>
                <ColorContext.Provider value={this.state.style}>
                    <select onChange={this.changeStyle}><option>dark</option><option>light</option></select>
                    <Header></Header>
                    <Switch>
                        <Route render={() => <Home></Home>} path='/' exact>

                        </Route>
                        <Route render={() => <Home favoris={true}></Home>} path='/favoris' >

                        </Route>
                        <Route path='/FormAnnonce'>
                            <FormAnnonce maxImage='4'></FormAnnonce>
                        </Route>
                        {/* <Route path='/DetailAnnonce'>
                        <DetailAnnonce></DetailAnnonce>
                    </Route> */}
                        <Route path='/DetailAnnonce/:title'>
                            <DetailAnnonce></DetailAnnonce>
                        </Route>
                    </Switch>
                </ColorContext.Provider>
            </BrowserRouter>
        )
    }
}