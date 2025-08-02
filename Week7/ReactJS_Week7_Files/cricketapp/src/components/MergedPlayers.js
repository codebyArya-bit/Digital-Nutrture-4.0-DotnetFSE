import React from 'react';

// a) Two separate format arrays
const T20Players = ['Rohit', 'Hardik', 'Bumrah', 'Pandya'];
const RanjiTrophyPlayers = ['Pujara', 'Rahane', 'Iyer', 'Washington'];

// b) merge via ES6 spread
const allPlayers = [...T20Players, ...RanjiTrophyPlayers];

export default function MergedPlayers() {
  return (
    <div>
      <h2>All Players (T20 + Ranji)</h2>
      <ul>
        {allPlayers.map((name, idx) => (
          <li key={idx}>{name}</li>
        ))}
      </ul>
    </div>
  );
}
