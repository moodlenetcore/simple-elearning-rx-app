import React, { PropTypes } from 'react';
import { Link } from 'react-router';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';

import { Button } from 'semantic-ui-react';

class CourseCategoryContainer extends React.Component {
  render() {
    return (
       <div>
    <Button >Primary</Button>
    <Button >Secondary</Button>
  </div>
    );
  }
}

export default CourseCategoryContainer;

