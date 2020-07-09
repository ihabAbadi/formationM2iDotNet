import React, { Component } from "react"
import { Arrow } from "./Arrow"
import { Slide } from "./Slide"
import { Indicator } from "./Indicator"

export class Carousel extends Component {
    constructor(props) {
        super(props)
        this.state = {
            slides: [
                { title: 'titre Silde 1', content: 'Content slide 1' },
                { title: 'titre Silde 2', content: 'Content slide 2' },
                { title: 'titre Silde 3', content: 'Content slide 3' },
            ],
            indexActivation: undefined
        }
    }

    componentDidMount() {
        this.setState({
            indexActivation: this.state.slides.length - 1
        })
    }
    leftClick = () => {
        let tmpIndex = this.state.indexActivation - 1
        if (this.state.indexActivation == 0) {
            tmpIndex = this.state.slides.length - 1
        }
        this.setState({
            indexActivation: tmpIndex
        })
    }

    rightClick = () => {
        let tmpIndex = this.state.indexActivation + 1
        if (this.state.indexActivation == this.state.slides.length - 1) {
            tmpIndex = 0
        }
        this.setState({
            indexActivation: tmpIndex
        })
    }
    render() {
        return (
            <div className="container">
                <div className='row'>
                    <Arrow type='left' click={this.leftClick} />
                    {this.state.slides.map((s, i) => {
                        return (
                            <Slide index={i} title={s.title} content={s.content} indexActivation={this.state.indexActivation} />
                        )
                    })}
                    <Arrow type='right' click={this.rightClick} />
                </div>
                <Indicator max={this.state.slides.length} indexActivation={this.state.indexActivation} />
            </div>
        )
    }
}