import React, { Component } from "react"

// export class Slide extends Component {
//     constructor(props) {
//         super(props)
//     }

//     render() {
//         return (
//             <div style={this.props.style} className={(this.props.index == this.props.indexActivation) ? 'slide-active slide text-center' : 'slide-noactive slide'}>
//                 <h1>{this.props.title}</h1>
//                 <div>{this.props.content}</div>
//             </div>
//         )
//     }
// }

export const Slide = (props) => {
    return (
        <div style={props.style} className={(props.index == props.indexActivation) ? 'slide-active slide text-center' : 'slide-noactive slide'}>
            <h1>{props.title}</h1>
            <div>{props.content}</div>
        </div>
    )
} 