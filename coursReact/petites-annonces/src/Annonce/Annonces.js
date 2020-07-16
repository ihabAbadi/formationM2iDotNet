import React, { Component } from "react"
import Annonce from "./Annonce"
import { ColorContext } from "../ColorContext"
class Annonces extends Component {
    static contextType = ColorContext
    constructor(props) {
        super(props)
    }
    render() {
        return(
            <div className="container" style={this.context}>
                {this.props.annonces.map((element)=>{
                    return(
                        <Annonce reload={this.props.reload} annonce={element}></Annonce>
                    )
                })}
            </div>
        )
    }
}

export default Annonces