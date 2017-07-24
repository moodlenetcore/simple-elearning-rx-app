import React, { PropTypes } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';

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
        <h1>APP</h1>
        <h4>====================</h4>
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
