import React, { useState } from 'react';

export default function BookingForm() {
  const [flightId, setFlightId] = useState('');
  const [name, setName]       = useState('');
  const [seats, setSeats]     = useState(1);

  const handleSubmit = e => {
    e.preventDefault();
    alert(`Booked ${seats} seat(s) for ${name} on flight ${flightId}`);
    setFlightId(''); setName(''); setSeats(1);
  };

  return (
    <form onSubmit={handleSubmit}>
      <h2>Book Your Ticket</h2>
      <div>
        <label>Flight ID: </label>
        <input
          type="text"
          value={flightId}
          onChange={e => setFlightId(e.target.value)}
          required
        />
      </div>
      <div>
        <label>Your Name: </label>
        <input
          type="text"
          value={name}
          onChange={e => setName(e.target.value)}
          required
        />
      </div>
      <div>
        <label>Seats: </label>
        <input
          type="number"
          min="1"
          value={seats}
          onChange={e => setSeats(e.target.value)}
          required
        />
      </div>
      <button type="submit">Book</button>
    </form>
  );
}
