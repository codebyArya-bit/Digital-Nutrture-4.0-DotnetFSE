import React from 'react';

// a) our “raw” list of 11 players
const players = [
  'Sachin',
  'Dravid',
  'Ganguly',
  'Sehwag',
  'Dhoni',
  'Pathan',
  'Yuvraj',
  'Kohli',
  'Rohit',
  'Jadeja',
  'Ashwin'
];

// b) destructure into odd‐index vs even‐index teams
const [oddTeam, evenTeam] = [
  players.filter((_, i) => i % 2 === 0),  // indices 0,2,4…
  players.filter((_, i) => i % 2 !== 0)   // indices 1,3,5…
];

export default function IndianPlayers() {
  return (
    <div>
      <h2>Odd Team</h2>
      <ul>
        {oddTeam.map((name, idx) => (
          <li key={idx}>{name}</li>
        ))}
      </ul>

      <h2>Even Team</h2>
      <ul>
        {evenTeam.map((name, idx) => (
          <li key={idx}>{name}</li>
        ))}
      </ul>
    </div>
  );
}
