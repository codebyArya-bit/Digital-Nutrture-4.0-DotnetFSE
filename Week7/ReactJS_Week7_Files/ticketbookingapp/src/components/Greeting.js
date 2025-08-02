import React from 'react';
import FlightList   from './FlightList';
import BookingForm  from './BookingForm';

export default function Greeting({ isLoggedIn }) {
  return isLoggedIn ? <BookingForm /> : <FlightList />;
}
