import React, { Component } from 'react';
import { ProductConsumer } from '../context';
import { Link } from 'react-router-dom';
import { ButtonContainer } from './Button';
import { getProduct } from '../services/ApiService';

export default class Details extends Component {
    constructor(props) {
        super(props)
        this.state = {
            product: {
                id: '',
                images: [],
                description: '',
                price: '',
                title: ''
            }
        }
    }

    componentDidMount() {
        getProduct(this.props.match.params.id).then(res => {
            this.setState({
                product: res.data
            })
        })
    }
    render() {
        const { id, images, description, price, title } = this.state.product;
        return (
            <div className="container py-5">
                {/* title */}
                <div className="row">
                    <div className="col-10 max-auto text-center text-slanted text-blue my-5">
                        <h1>{title}</h1>
                    </div>
                </div>
                {/* end-title */}
                {/* product info */}
                <div className="row">
                    <div className="col-10 mx-auto col-md-6 my-3">
                        {images.map((img, index) => (
                            <img src={img.url} key={index} className="img-fluid" alt="product" />
                        ))}
                    </div>
                    <div className="col-10 mx-auto col-md-6 my-3 text-capitalize">
                        <h2>Model: {title}</h2>

                        <h4 className="text-blue">
                            <strong>
                                Price: <span>$</span>
                                {price}
                            </strong>
                        </h4>
                        <p className="text-capitalize font-weight-bold mt-3 mb-0">
                            some info about product:
                        </p>
                        <p className="text-muted lead">{description}</p>
                        {/* buttons */}
                        <div>
                            <Link to="/">
                                <ButtonContainer>back to products</ButtonContainer>
                            </Link>
                            <ButtonContainer
                            >add to cart
                            </ButtonContainer>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}
