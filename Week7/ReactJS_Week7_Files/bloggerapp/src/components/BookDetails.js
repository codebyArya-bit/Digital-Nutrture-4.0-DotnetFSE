import React from 'react';

export default function BookDetails({ items }) {
  return (
    <div>
      <h3>Book Details</h3>
      <ul>
        {items.map(book => (
          <li key={book.id}>
            <strong>{book.bname}</strong> &mdash; Rs. {book.price}
          </li>
        ))}
      </ul>
    </div>
  );
}
