import React from 'react';

const flights = [
  { id: 'AI101', from: 'Delhi', to: 'Mumbai', time: '10:00 AM' },
  { id: '6E202', from: 'Bengaluru', to: 'Chennai', time: '02:00 PM' },
  { id: 'UK303', from: 'Kolkata', to: 'Hyderabad', time: '06:00 PM' },
];

export default function FlightList() {
  return (
    <div>
      <h2>Available Flights</h2>
      <ul>
        {flights.map(f => (
          <li key={f.id}>
            {f.id} – {f.from} to {f.to} at {f.time}
          </li>
        ))}
      </ul>
    </div>
  );
}
