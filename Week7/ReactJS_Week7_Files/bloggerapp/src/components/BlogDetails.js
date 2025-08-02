import React from 'react';

export default function BlogDetails({ items }) {
  return (
    <div>
      <h3>Blog Details</h3>
      <ul>
        {items.map(post => (
          <li key={post.id}>
            <strong>{post.title}</strong> by {post.author}
            <p>{post.body}</p>
          </li>
        ))}
      </ul>
    </div>
  );
}
