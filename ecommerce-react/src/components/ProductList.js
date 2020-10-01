import React, { Component } from 'react';
import Title from './Title';
import Product from './Product';
import { ProductConsumer } from '../context';
import { getProducts } from '../services/ApiService';

export default class ProductList extends Component {


    constructor(props) {
        super(props)
        this.state = {
            products: []
        }
    }
    componentDidMount() {
        getProducts().then(res => {
            this.setState({
                products : res.data
            })
        })
    }
    render() {
        return (
            <React.Fragment>
                <div className="py-5">
                    <div className="container">
                        <Title name="our" title="products" />
                        <div className="row">
                            {this.state.products.map(product => {
                                return <Product key={product.id} product={product} />
                            })
                            }
                        </div>
                    </div>
                </div>
            </React.Fragment>
        )
    }
}
