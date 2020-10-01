import React, { Component } from "react";
export default class CartItem extends Component {
    render() {
    const { qty, product } = this.props.item;
    const { updateQty, removeProduct } = this.props;

        return (
            <div className="row my-2 text-capitalize text-center">
            <div className="col-10 mx-auto col-lg-2">
                <img
                src={product.images[0].url}
                style={{ width: "5rem", heigth: "5rem" }}
                className="img-fluid"
                alt=""
                />
            </div>
            <div className="col-10 mx-auto col-lg-2 ">
                <span className="d-lg-none">product :</span> {product.title}
            </div>
            <div className="col-10 mx-auto col-lg-2 ">
                <strong>
                <span className="d-lg-none">price :</span> ${product.price}
                </strong>
            </div>
            <div className="col-10 mx-auto col-lg-2 my-2 my-lg-0 ">
                <div className="d-flex justify-content-center">
                <div>
                    <span
                    className="btn btn-black mx-1"
                    onClick={() => updateQty(product.id,-1)}
                    >
                    -
                    </span>
                    <span className="btn btn-black mx-1">{qty}</span>
                    <span
                    className="btn btn-black mx-1"
                    onClick={() =>  updateQty(product.id,1)}
                    >
                    +
                    </span>
                </div>
                </div>
            </div>
            <div className="col-10 mx-auto col-lg-2 ">
                <div className=" cart-icon" onClick={() => removeProduct(product)}>
                <i className="fas fa-trash" />
                </div>
            </div>

            <div className="col-10 mx-auto col-lg-2 ">
                <strong>item total : ${product.price * qty} </strong>
            </div>
            </div>
        );
    }
}