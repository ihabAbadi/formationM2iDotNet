import React, { Component } from "react"
import { SecondComponent } from "./SecondComponent"
// export const FirstComponent = () => {
//     return(
//         <div>
//             <h1>Our First Component</h1>
//             <div>
//                 This is our first react component
//             </div>
//             <SecondComponent ></SecondComponent>
//         </div>
//     )
// }

export class FirstComponent extends Component {

    render() {
        return (
            <div>
                <h1>Our First Component</h1>
                <div>
                    This is our first react component
                </div>
                <SecondComponent prop1="value of prop1"></SecondComponent>
                <SecondComponent prop1="value of prop1 for the secondComponent number two"></SecondComponent>
            </div>
        )
    }
}