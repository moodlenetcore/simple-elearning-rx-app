import React, { Component } from 'react';

const CourseList = ({ courseItems }) => {
  const items = courseItems.map((item, i) => (
    <li data-id={item.id}>{item.name}</li>
  ))

  return (
    <ul>{items}</ul>
  )
}

export default CourseList