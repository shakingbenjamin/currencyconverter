import React from 'react';
import logo from './logo.svg';
import './App.css';
import CurrencyConverter from './CurrencyConverter';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
<CurrencyConverter></CurrencyConverter>
      </header>
    </div>
  );
}

export default App;
