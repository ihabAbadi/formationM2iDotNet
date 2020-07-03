import React from 'react';
import logo from './logo.svg';
import './App.css';
import { FirstComponent } from './FirstComponent';
import { Person } from './Person';
import { ListProduct } from './Products/ListProducts';

function App() {
  const p1 = {
    nom : 'toto',
    prenom : 'tata',
    tel : '0101010101',
    address : {
      street : 'lille',
      city :'lille',
      country : 'France'
    }
  }
  return (
    <div className="App">
      {/* <Person nom="titi" prenom="minet" rue="warner" ville="bros" pays="usa" tel="555-010101"></Person>
      <Person nom="toto" prenom="tata" rue="lille" ville="lille" pays="france" tel="01-010101"></Person> */}
      {/* <Person personne={p1}></Person>
      <Person personne={p1}></Person> */}
      <ListProduct></ListProduct>
    </div>
  );
}

export default App;
