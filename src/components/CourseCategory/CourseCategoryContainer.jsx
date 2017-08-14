import React, { PropTypes } from 'react';
import { Link } from 'react-router';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';

import { Button } from 'semantic-ui-react';

import MiddleWare from './CourseCategoryMiddleware';

class CourseCategoryContainer extends React.Component {
  constructor(props) {
    super(props);
  }

  componentDidMount() {
    this.props.loadCourseCategory();
  }

  render() {
    return (
      <div>
        <Button >Primary</Button>
        <Button >Secondary</Button>
      </div>
    );
  }
}

export function mapStateToProps(state) {
  const courseCategoryState = state.administrator.courseCategoryPage;
  return {
    data: courseCategoryState,
  };
}

export function mapDispatchToProps(dispatch) {
  return {
    loadCourseCategory: () => dispatch(MiddleWare.loadCourseCategory()),
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(CourseCategoryContainer);

