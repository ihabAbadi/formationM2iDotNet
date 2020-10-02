import React from 'react';
import {Link} from 'react-router-dom';
import { confirmOrder } from '../../services/ApiService';
import { totalCart } from '../../services/CartService';

export default function CartTotals({clearCart, history}) {

    const validOrder = () => {
        confirmOrder().then(res => {
            alert("order id "+ res.data.id)
            localStorage.removeItem("cart")
        })
    }
    return (
        <React.Fragment>
            
            <div className="container">
                <div className="row">
                <div className="col-10 mt-2 ml-sm-5 ml-md-auto col-sm-8 text-capitalize text-right">
                    <Link to="/">
                    <button
                        className="btn btn-outline-danger text-uppercase mb-3 px-5"
                        type="button"
                        onClick={() => {
                        clearCart();
                        }}
                    >
                        clear cart
                    </button>
                    </Link>
                    <Link to="/order">
                    <button
                        className="btn btn-outline-danger text-uppercase mb-3 px-5"
                        type="button"
                        onClick ={() => {
                            validOrder()
                        }}
                    >
                        confirm order
                    </button>
                    </Link>
                    <h5>
                    <span className="text-title"> total :</span>{" "}
                    <strong>$ {totalCart()} </strong>
                    </h5>
                </div>
                </div>
            </div>

        </React.Fragment>
    );
}
