import React, { Component } from "react"
import {DataService} from "./../service/DataService"
import {withRouter} from "react-router-dom"
class Annonce extends Component {
    constructor(props) {
        super(props)
    }

    redirectTo = () => {
        DataService.annonce = this.props.annonce
        this.props.history.push('/DetailAnnonce')
    }   

    render() {
        return(
            <div className="row m-1">
                <img className="col-3" src={this.props.annonce.images[0]}/>
                <div className='col-9'>
                    <div className='row m-1'>
                        <h2 className='col'>
                            {this.props.annonce.title}
                        </h2>
                    </div>
                    <div className='row m-1'>
                        <div className='col'>
                            {this.props.annonce.description.substr(1,200)}
                        </div>
                    </div>
                    <div className="row m-1">
                        <button onClick={this.redirectTo} className='col btn btn-primary'>Detail</button>
                    </div>
                </div>
            </div>
        )
    }
}

export default withRouter(Annonce)