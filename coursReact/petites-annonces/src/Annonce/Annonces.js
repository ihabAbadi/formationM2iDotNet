import React, { Component } from "react"
import Annonce from "./Annonce"
class Annonces extends Component {
    constructor(props) {
        super(props)
    }
    render() {
        return(
            <div className="container">
                {this.props.annonces.map((element)=>{
                    return(
                        <Annonce annonce={element}></Annonce>
                    )
                })}
            </div>
        )
    }
}

export default Annonces