import React from 'react';
import logo from './logo.svg';
import './App.css';
import { BrowserRouter, Link, Switch, Route } from "react-router-dom"
import { ListProduct } from "./Products/ListProducts"
import { ListToDos } from "./ToDoList/ListToDos"
import { ListContacts } from "./contacts/ListContacts"
import { Home } from './MultiStepForm/Home';
function App() {
  return (
    <div>
      <Home></Home>
    </div>
  );
}

export default App;
