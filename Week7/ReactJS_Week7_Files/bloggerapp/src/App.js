// src/App.js
import React from 'react';
import './App.css';

import CourseDetails from './components/CourseDetails';
import BookDetails   from './components/BookDetails';
import BlogDetails   from './components/BlogDetails';

import { courses } from './data/courses';
import { books   } from './data/books';
import { blogs   } from './data/blogs';

function App() {
  return (
    <div className="layout-container">
      {/* Column 1 */}
      <div className="layout-column">
        <CourseDetails items={courses} />
      </div>

      {/* Green separator */}
      <div className="layout-separator" />

      {/* Column 2 */}
      <div className="layout-column">
        <BookDetails items={books} />
      </div>

      {/* Green separator */}
      <div className="layout-separator" />

      {/* Column 3 */}
      <div className="layout-column">
        <BlogDetails items={blogs} />
      </div>
    </div>
  );
}

export default App;
