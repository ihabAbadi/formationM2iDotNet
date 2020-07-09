import React, { Component } from "react"

export class Indicator extends Component {
    constructor(props) {
        super(props)
    }

    renderBloc = () => {
        let blocs= []
        for(let i=0; i < this.props.max; i++) {
            blocs.push(<div className='col-1'><div className={this.props.indexActivation == i ? 'bloc-active' : 'bloc'}></div></div>)
        }
        return blocs
    }
    render() {
        return(
            <div className='row justify-content-center'>
                {this.renderBloc()}
            </div>
        )
    }
}