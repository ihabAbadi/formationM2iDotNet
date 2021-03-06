import React, { Component, useState } from "react"
import { Arrow } from "./Arrow"
import { Slide } from "./Slide"
import { Indicator } from "./Indicator"

// export class Carousel extends Component {
//     constructor(props) {
//         super(props)
//         this.state = {
//             slides: [
//                 { title: 'titre Silde 1', content: 'Content slide 1' },
//                 { title: 'titre Silde 2', content: 'Content slide 2' },
//                 { title: 'titre Silde 3', content: 'Content slide 3' },
//             ],
//             indexActivation: undefined,
//             style: {

//             },
//             styleContainer: {

//             }
//         }
//     }

//     componentDidMount() {
//         this.setState({
//             indexActivation: 0,
//             styleContainer: {
//                 width: (this.state.slides.length * 830) + 'px',

//             },
//             style: {
//                 width: (810) + 'px',
//                 textAlign: 'center'
//             }
//         })
//     }
//     leftClick = () => {
//         let tmpIndex = this.state.indexActivation - 1
//         if (this.state.indexActivation == 0) {
//             tmpIndex = this.state.slides.length - 1
//         }
//         let valueTranslate = -tmpIndex * 810
//         this.setState({
//             indexActivation: tmpIndex
//         })

//         this.setState({
//             styleContainer: { ...this.state.styleContainer, transitionDuration: '1s', marginLeft: '' + valueTranslate + 'px' }
//         })
//     }

//     changeIndex = (index) => {
//         let tmpIndex = index
//         let valueTranslate = -tmpIndex * 810
//         if (this.state.indexActivation == this.state.slides.length - 1) {
//             tmpIndex = 0
//             valueTranslate = 0
//         }
//         this.setState({
//             indexActivation: tmpIndex
//         })

//         this.setState({
//             styleContainer: { ...this.state.styleContainer, transitionDuration: '1s', marginLeft: '' + valueTranslate + 'px' }
//         })
//     }
//     rightClick = () => {
//         let tmpIndex = this.state.indexActivation + 1
//         let valueTranslate = -tmpIndex * 810
//         if (this.state.indexActivation == this.state.slides.length - 1) {
//             tmpIndex = 0
//             valueTranslate = 0
//         }
//         this.setState({
//             indexActivation: tmpIndex
//         })

//         this.setState({
//             styleContainer: { ...this.state.styleContainer, transitionDuration: '1s', marginLeft: '' + valueTranslate + 'px' }
//         })
//     }
//     render() {
//         return (
//             <div className="container">
//                 <div className='row'>
//                     <Arrow type='left' click={this.leftClick} />

//                     <div className='col-9' style={{ overflowX: 'hidden' }}>
//                         <div className="container-carousel" style={this.state.styleContainer}>
//                             {this.state.slides.map((s, i) => {
//                                 return (
//                                     <Slide index={i} title={s.title} style={this.state.style} content={s.content} indexActivation={this.state.indexActivation} />
//                                 )
//                             })}
//                         </div>
//                     </div>

//                     <Arrow type='right' click={this.rightClick} />
//                 </div>
//                 <Indicator changeIndex={this.changeIndex} max={this.state.slides.length} indexActivation={this.state.indexActivation} />
//             </div>
//         )
//     }
// }


export const Carousel = (props) => {

    const [slides, setSlides] = useState([{ title: 'titre Silde 1', content: 'Content slide 1' },
    { title: 'titre Silde 2', content: 'Content slide 2' },
    { title: 'titre Silde 3', content: 'Content slide 3' },])

    const [indexActivation, setIndexActivation] = useState(0)

    const [style, setStyle] = useState({width: (810) + 'px',textAlign: 'center'})

    const [styleContainer, setStyleContainer] = useState({ width: (slides.length * 830) + 'px'})
    
    const leftClick = () => {
        let tmpIndex = indexActivation - 1
        if (indexActivation == 0) {
            tmpIndex = slides.length - 1
        }
        let valueTranslate = -tmpIndex * 810
        setIndexActivation(tmpIndex)

        setStyleContainer({ ...styleContainer, transitionDuration: '1s', marginLeft: '' + valueTranslate + 'px' })
    }

    const changeIndex = (index) => {
        let tmpIndex = index
        let valueTranslate = -tmpIndex * 810
        setIndexActivation(tmpIndex)
        setStyleContainer({ ...styleContainer, transitionDuration: '1s', marginLeft: '' + valueTranslate + 'px' })
        
    }
    const rightClick = () => {
        let tmpIndex = indexActivation + 1
        let valueTranslate = -tmpIndex * 810
        if (indexActivation == slides.length - 1) {
            tmpIndex = 0
            valueTranslate = 0
        }
        setIndexActivation(tmpIndex)
        setStyleContainer({ ...styleContainer, transitionDuration: '1s', marginLeft: '' + valueTranslate + 'px' })
        
    }
    return (
        <div className="container">
            <div className='row'>
                <Arrow type='left' click={leftClick} />

                <div className='col-9' style={{ overflowX: 'hidden' }}>
                    <div className="container-carousel" style={styleContainer}>
                        {slides.map((s, i) => {
                            return (
                                <Slide index={i} title={s.title} style={style} content={s.content} indexActivation={indexActivation} />
                            )
                        })}
                    </div>
                </div>

                <Arrow type='right' click={rightClick} />
            </div>
            <Indicator changeIndex={changeIndex} max={slides.length} indexActivation={indexActivation} />
        </div>
    )
}