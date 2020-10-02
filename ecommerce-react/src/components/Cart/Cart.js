import React, { Component } from 'react';
import Title from '../Title';
import CartColumns from './CartColumns';
import EmptyCart from './EmptyCart';
import { ProductConsumer } from '../../context';
import CartList from './CartList';
import CartTotals from './CartTotals';
import { getProduct } from '../../services/ApiService';
import { addToCart, clearCart, getCart, removeFromCart, updateQty } from '../../services/CartService';

export default class Cart extends Component {
    constructor(props) {
        super(props)
        this.state = {
            cart : []
        }
    }

    componentDidMount() {
        if(this.props.match.params != undefined && this.props.match.params.id != undefined) {
            getProduct(this.props.match.params.id).then(res => {
                addToCart(res.data, 1)
                this.setState({
                    cart : getCart()
                })
            })
        }
        else {
            this.setState({
                cart : getCart()
            })
        }
    }

    updateQty = (id, qty) => {
        updateQty(id,qty)
        this.setState({
            cart : getCart()
        })
    }

    removeProduct = (product) => {
        removeFromCart(product)
        this.setState({
            cart : getCart()
        })
    }

    clearCart = () => {
        clearCart()
    }
    render() {
        const { cart } = this.state;
        return (
            <section>
                {
                    (cart.length > 0) ? (
                        <React.Fragment>
                            <Title name="your" title="cart" />
                            <CartColumns />
                            <CartList updateQty={this.updateQty} removeProduct={this.removeProduct} cart={cart} />
                            <CartTotals history={this.props.history} clearCart = {this.clearCart} value={cart} />
                        </React.Fragment>
                    )
                        :
                        <EmptyCart />
                }

            </section>
        );
    }
}
