import React from 'react';
import CartItem from './CartItem';

export default function CartList({cart, updateQty, removeProduct}) {

    
    return (
    <div className="container-fluid">
        {cart.map(item => (
        <CartItem updateQty={updateQty} removeProduct={removeProduct} key={item.id} item={item} />
        ))}
    </div>
    );
}
