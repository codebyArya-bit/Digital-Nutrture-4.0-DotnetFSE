// src/components/ScoreBelow70.js
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
]
export default function ScoreBelow70() {
  const lowScorers = players.filter(p => p.score < 70);
  return (
    <div>
      <h3>Scores Below 70</h3>
      <ul>
        {lowScorers.map((p, i) => (
          <li key={i}>
            Mr. {p.name} <span>{p.score}</span>
          </li>
        ))}
      </ul>
    </div>
  );
}
