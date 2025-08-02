// src/App.js
import React, { useState } from 'react';
import CurrencyConverter from './components/CurrencyConverter';
import './App.css';  // you can add your own styling here

function App() {
  // 1) counter state
  const [count, setCount] = useState(0);

  // 2) basic increment & decrement
  const incrementCount = () => setCount(c => c + 1);
  const decrementCount = () => setCount(c => c - 1);

  // 3) “extra” handler: say hello
  const sayHello = () => alert('Hello Member!');

  // 4) handler that calls two methods
  const handleIncrement = () => {
    incrementCount();
    sayHello();
  };

  // 5) Say Welcome with argument
  const saySomething = msg => alert(msg);

  // 6) “Click on me” press handler
  const handlePress = () => alert('I was clicked');

  return (
    <div style={{ padding: '2rem' }}>
      {/* --- Counter Display & Buttons --- */}
      <h1>{count}</h1>
      <button onClick={handleIncrement}>Increment</button>{' '}
      <button onClick={decrementCount}>Decrement</button>{' '}
      <button onClick={() => saySomething('welcome')}>Say welcome</button>{' '}
      <button onClick={handlePress}>Click on me</button>

      {/* --- Currency Converter Component --- */}
      <CurrencyConverter />
    </div>
  );
}

export default App;
