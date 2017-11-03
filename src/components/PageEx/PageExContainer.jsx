import React, { PropTypes } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';

import { Container, Row, Col } from 'reactstrap';
import { Table } from 'semantic-ui-react';

import 'styles/main.scss';
import CourseCategoryRow from './CourseCategoryRow';
import * as PageExActions from './PageExActions';

class PageExContainer extends React.Component {
  constructor(props) {
    super(props);
    this.removeItem = this.removeItem.bind(this);
  }

  removeItem(index) {
    this.props.actions.removeItem(index);
  }

  render() {
   

    return (
      <Container>
        <Row>
          <Col md="4" className="pull-left">
            
          </Col>
          <Col md="8" />
        </Row>
      </Container>
    );
  }
}

PageExContainer.propTypes = {
  actions: PropTypes.object.isRequired,
};

export function mapStateToProps(state) {
  return state;
}

export function mapDispatchToProps(dispatch) {
  return {
    actions: bindActionCreators(PageExActions, dispatch),
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(PageExContainer);
