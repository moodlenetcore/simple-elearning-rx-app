import React, { PropTypes } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router';

export class AdministratorContainer extends React.Component {
  constructor(props) {
    super(props);
  }

  componentDidMount() {

  }

  render() {
    return (
      <div>
        <div style={{ textAlign: 'center' }}>
          <h1>Adnimistrator</h1>
        </div>

        {this.props.children}
      </div>
    );
  }
}

AdministratorContainer.PropTypes = {
  children: PropTypes.object.isRequired,
};


export default AdministratorContainer;
