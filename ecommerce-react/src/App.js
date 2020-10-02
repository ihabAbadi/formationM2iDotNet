import React, { Component } from 'react';
import { Switch, Route, Redirect } from 'react-router-dom';
//import logo from './logo.svg';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';

import Navbar from './components/Navbar';
import ProductList from './components/ProductList';
import Details from './components/Details';
import Cart from './components/Cart';
import Default from './components/Default';
import Modal from './components/Modal';
import { Login } from './components/Login';
import { Order } from './components/Order';
import { testToken } from './services/ApiService';

class App extends Component {
  render() {
    return (
      <React.Fragment>
        <Navbar />
        <Switch>
          <Route exact path="/" component={ProductList}></Route>
          <Route path="/details/:id" component={Details}></Route>
          <Route path="/cart" component={Cart}></Route>
          <Route path="/cart/:id" component={Cart}></Route>
          <Route path="/login" component={Login} ></Route>
          <Route path="/order" component={Order}></Route>
          <Route component={Default}></Route>
        </Switch>
        <Modal />
      </React.Fragment>
    );
  }
}
class PrivateRoute extends Component {
  constructor(props) {
    super(props)
    this.state = {
      authenticate: false
    }
  }

  componentDidMount() {
    testToken().then((res) => {
      console.log(res)
      this.setState({
        test : true
      })
    }).catch(err => {

    })
  }
  render() {
    return (
      this.state.authenticate ? <Route {...this.state.props}></Route> : <Redirect
        to={{
          pathname: "/login"
        }}
      />
    )
  }
}
export default App;
