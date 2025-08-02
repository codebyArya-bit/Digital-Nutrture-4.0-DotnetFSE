import React from 'react';
import ListOfPlayers    from './components/ListOfPlayers';    // Lab 1
import ScoreBelow70     from './components/ScoreBelow70';     // Lab 1
import IndianPlayers    from './components/IndianPlayers';    // Lab 2a
import MergedPlayers    from './components/MergedPlayers';    // Lab 2b

function App() {
  const flag = false; // ← toggle to false to see the IndianPlayers + MergedPlayers view

  if (flag) {
    return (
      <div className="App">
        <h1>All Players &amp; Low Scorers</h1>
        <ListOfPlayers />
        <hr/>
        <ScoreBelow70 />
      </div>
    );
  } else {
    return (
      <div className="App">
        <h1>Indian Team Breakdown</h1>
        <IndianPlayers />
        <hr/>
        <MergedPlayers />
      </div>
    );
  }
}

export default App;
