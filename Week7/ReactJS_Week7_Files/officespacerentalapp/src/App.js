// src/App.js
import React from 'react';
import './App.css';

function App() {
  // Page title
  const pageTitle = 'Office Space Rental, At Affordable prices';

  // Use the local image from public/office.jpg
  const imageSrc = process.env.PUBLIC_URL + '/office.jpg';

  // List of office objects
  const offices = [
    { Name: 'DBS',        Rent: 50000, Address: 'Chennai' },
  ];

  return (
    <div className="App" style={{ maxWidth: 600, margin: '0 auto', padding: '2rem' }}>
      {/* Heading */}
      <h1>{pageTitle}</h1>

      {/* Fallback local image */}
      <img
        src={imageSrc}
        width="100%"
        alt="Office Space"
      />

      {/* Render each office card */}
      {offices.map((office, idx) => {
        const rentClass = office.Rent < 60000 ? 'textRed' : 'textGreen';

        return (
          <div key={idx} className="office-card">
            <h2>Name: {office.Name}</h2>
            <p className={rentClass}>Rent: Rs. {office.Rent}</p>
            <p>Address: {office.Address}</p>
          </div>
        );
      })}
    </div>
  );
}

export default App;
