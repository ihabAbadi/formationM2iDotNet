import React from 'react';
import logo from './logo.svg';
import './App.css';
import { FirstComponent } from './FirstComponent';
import { Person } from './Person';

function App() {
  return (
    <div className="App">
      <Person nom="titi" prenom="minet" rue="warner" ville="bros" pays="usa" tel="555-010101"></Person>
      <Person nom="toto" prenom="tata" rue="lille" ville="lille" pays="france" tel="01-010101"></Person>
    </div>
  );
}

export default App;
