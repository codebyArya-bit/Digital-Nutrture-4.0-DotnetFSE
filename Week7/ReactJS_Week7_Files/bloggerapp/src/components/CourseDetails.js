import React from 'react';

export default function CourseDetails({ items }) {
  return (
    <div>
      <h3>Course Details</h3>
      <ul>
        {items.map(course => (
          <li key={course.id}>
            <strong>{course.name}</strong> — {course.date}
          </li>
        ))}
      </ul>
    </div>
  );
}
