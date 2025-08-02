// src/components/CurrencyConverter.js
import React, { useState } from 'react'
import '../App.css'   // ensure your converter-heading class is defined here

export default function CurrencyConverter() {
  const [amount, setAmount]     = useState('')
  const [currency, setCurrency] = useState('')

  // conversion rate: 1 unit of foreign currency = 80 INR
  const RATE = 80

  const handleSubmit = e => {
    e.preventDefault()
    const result = amount * RATE
    alert(`Converting to ${currency}: Amount is ${result}`)
  }

  return (
    <div style={{ marginTop: '2rem' }}>
      {/* Green headline via converter-heading class */}
      <h2 className="converter-heading">Currency Converter!!!</h2>

      <form onSubmit={handleSubmit}>
        <div>
          <label>Amount (in foreign units): </label>
          <input
            type="number"
            value={amount}
            onChange={e => setAmount(e.target.value)}
            required
          />
        </div>
        <div>
          <label>Currency Name: </label>
          <input
            type="text"
            value={currency}
            onChange={e => setCurrency(e.target.value)}
            required
          />
        </div>
        <button type="submit">Convert</button>
      </form>
    </div>
  )
}
