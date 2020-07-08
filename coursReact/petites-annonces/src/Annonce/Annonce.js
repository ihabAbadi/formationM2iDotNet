import React, { Component } from "react"

class Annonce extends Component {
    constructor(props) {
        super(props)
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
                            {this.props.annonce.description}
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}

export default Annonce