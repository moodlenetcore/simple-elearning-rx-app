import React from 'react'
import CourseList from '../components/CourseList'

class Course extends React.Component{
  render(){
    //const {items} = this.props;
    const items = [
      {_id: "1", name: "ReactJS" },
      {_id: "2", name: "Angular" },
      {_id: "3", name: "JQuery" },
      {_id: "4", name: "DotNetCore" },
    ];

    return (
      <div>
        <h4>Course Page</h4>
        <CourseList courseItems={items}  />
      </div>
    )
  }
}

export default Course