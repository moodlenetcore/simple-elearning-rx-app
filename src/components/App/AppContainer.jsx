import React, { PropTypes } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router';

import * as appActions from './AppActions';

export class AppContainer extends React.Component {
  constructor(props) {
    super(props);

    this.testAtion = this.testAtion.bind(this);
  }

  componentDidMount() {

  }

  testAtion(value) {
    this.props.testAtion(value);
  }

  render() {
    return (
      <div>
        <div style={{ textAlign: 'center' }}>
          <h1>APP</h1>
          <h4><Link to={'/elearning-app/administrator/course-category'}>Login</Link></h4>
        </div>

        {this.props.children}
      </div>
    );
  }
}

AppContainer.PropTypes = {
  children: PropTypes.object.isRequired,
};

export function mapStateToProps(state) {
  return state;
}

export function mapDispatchToProps(dispatch) {
  return bindActionCreators(appActions, dispatch);
}

export default connect(mapStateToProps, mapDispatchToProps)(AppContainer);
