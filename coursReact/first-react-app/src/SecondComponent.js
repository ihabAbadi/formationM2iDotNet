import React, {Component} from "react"
export class SecondComponent extends Component {
    constructor(props) {
        super(props)
    }
    render() {
        return(
            <div>
                <h1>This is the second component with prop1 {this.props.prop1}</h1>
            </div>
        )
    }
}