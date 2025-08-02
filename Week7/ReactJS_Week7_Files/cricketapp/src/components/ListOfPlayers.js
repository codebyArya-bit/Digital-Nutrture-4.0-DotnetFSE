// src/components/ListOfPlayers.js
import React from 'react';

const players = [
  { name: 'Sachin',  score: 85 },
  { name: 'Dravid',  score: 68 },
  { name: 'John',    score: 78 },
  { name: 'Mathews', score: 88 },
  { name: 'Rahul',   score: 62 },
  { name: 'Rohit',   score: 75 },
  { name: 'Ann',     score: 82 },
  { name: 'Dhoni',   score: 92 },
  { name: 'Michael', score: 90 },
  { name: 'Jade',    score: 86 },
  { name: 'Raina',   score: 73 },
];

const ListOfPlayers = () => {
  const lowScorers = players.filter(player => player.score < 70);
  return (
    <div>
      <h2>All Players</h2>
      <ul>
        {players.map((player, idx) => (
          <li key={idx}>
            Mr. {player.name} <span>{player.score}</span>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default ListOfPlayers;
