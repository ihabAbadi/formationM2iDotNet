import React from 'react';
import logo from './logo.svg';
import './App.css';
import {BrowserRouter, Link, Switch, Route} from "react-router-dom"
import {ListProduct} from "./Products/ListProducts"
import {ListToDos} from "./ToDoList/ListToDos"
import {ListContacts} from "./contacts/ListContacts"
import { Home } from './MultiStepForm/Home';
function App() {
  return (
    <div>
      <Home></Home>
    </div>
  );
}

export default App;
// <BrowserRouter>
    //   <header className="row">
    //       <Link className="col" to='/products'>Gestion de produits</Link>
    //       <Link className="col" to='/todos'>Getion de todos List</Link>
    //       <Link className="col" to='/contacts'>Getion de contacts</Link>
    //   </header>
    //   <Switch>
    //     <Route path='/products'>
    //       <ListProduct></ListProduct>
    //     </Route>
    //     <Route path='/todos'>
    //       <ListToDos></ListToDos>
    //     </Route>
    //     <Route path='/contacts'>
    //       <ListContacts></ListContacts>
    //     </Route>
    //   </Switch>
    // </BrowserRouter>