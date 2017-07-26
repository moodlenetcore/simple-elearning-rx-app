import React, { PropTypes } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';

import { Container, Row, Col } from 'reactstrap';
import { Table } from 'semantic-ui-react';

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
    const {
        pageEx,
      } = this.props;

    let courseCategoriesRowItem = [];
    if (pageEx.courseCategories) {
      courseCategoriesRowItem = pageEx.courseCategories.map((item, index) => (
        <CourseCategoryRow
          index={index}
          name={item.name}
          onRemoveItem={this.removeItem}
        />
      ));
    }

    return (
      <Container>
        <Row>
          <Col md="4" className="pull-left">
            {
              pageEx.courseCategories ?
                <Table celled>
                  <Table.Header>
                    <Table.Row>
                      <Table.HeaderCell>Category Name</Table.HeaderCell>
                      <Table.HeaderCell />
                    </Table.Row>
                  </Table.Header>
                  <Table.Body>
                    {courseCategoriesRowItem}
                  </Table.Body>
                </Table> :
              null
            }
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
  const pageEx = state.pageEx;
  return {
    pageEx,
  };
}

export function mapDispatchToProps(dispatch) {
  return {
    actions: bindActionCreators(PageExActions, dispatch),
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(PageExContainer);
