import React from 'react';
import logo from './logo.svg';
import './App.css';
import 'antd/dist/antd.css'
import {BrowserRouter, Switch, Route} from "react-router-dom"
import Home from './Home';
import HomeChat from './Chat/HomeChat';

function App() {
  return (
    <BrowserRouter>
      <Switch>
        <Route path="/" exact>
            <Home></Home>
        </Route>
        <Route path="/chat">
            <HomeChat></HomeChat>
        </Route>
      </Switch>
    </BrowserRouter>
  );
}

export default App;
