import React from 'react';
import logo from './logo.svg';
import { BrowserRouter, Link, Switch, Route } from "react-router-dom"
import './App.css';
import { ComponentA, ComponentB, Home } from './Components';

function App() {
  return (
    <BrowserRouter>
      <header>
        <nav>
          <li><Link to='/'> Home</Link></li>
          <li><Link to='/a'> Component A</Link></li>
          <li><Link to='/b'> Component B</Link></li>
        </nav>
        <Switch>
          <Route path='/' exact>
            <Home></Home>
          </Route>
          <Route path='/a'>
            <ComponentA></ComponentA>
          </Route>
          <Route path='/b'>
            <ComponentB></ComponentB>
          </Route>
        </Switch>
      </header>
    </BrowserRouter>
  );
}

export default App;
