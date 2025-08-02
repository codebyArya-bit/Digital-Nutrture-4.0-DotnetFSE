import React, { useState } from 'react';
import LoginButton   from './components/LoginButton';
import LogoutButton  from './components/LogoutButton';
import Greeting      from './components/Greeting';

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  const handleLoginClick  = () => setIsLoggedIn(true);
  const handleLogoutClick = () => setIsLoggedIn(false);

  return (
    <div style={{ padding: '2rem', maxWidth: 600, margin: 'auto' }}>
      {/* Heading */}
      <h1>{isLoggedIn ? 'Welcome back!' : 'Please sign up.'}</h1>

      {/* Login / Logout button */}
      {isLoggedIn
        ? <LogoutButton onClick={handleLogoutClick} />
        : <LoginButton onClick={handleLoginClick} />
      }

      <hr/>

      {/* Either the Flight List or the Booking Form */}
      <Greeting isLoggedIn={isLoggedIn} />
    </div>
  );
}

export default App;
