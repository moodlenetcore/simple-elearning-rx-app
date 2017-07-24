import React, { PropTypes } from 'react';
import { connect } from 'react-redux';

import { Header, Table, Rating } from 'semantic-ui-react';
import { Container, Row, Col } from 'reactstrap';

import CourseCategoryRow from './CourseCategoryRow';

class PageExContainer extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    const {
        courseCategories,
      } = this.props;

    const courseCategoriesRowItem = [];
    if (courseCategories) {
      courseCategories.forEach((item, index) => {
        courseCategoriesRowItem.push(
          <CourseCategoryRow
            name={item.name}
          />,
        );
      });
    }

    return (
      <Container>
        <Row>
          <Col md="6">
            {
              courseCategories ?
                <Table celled>
                  <Table.Header>
                    <Table.Row>
                      <Table.HeaderCell>Category Name</Table.HeaderCell>
                      <Table.HeaderCell></Table.HeaderCell>
                    </Table.Row>
                  </Table.Header>
                  <Table.Body>
                    {courseCategoriesRowItem}
                  </Table.Body>
                </Table> :
              null
            }
          </Col>
          <Col md="6">
          
          </Col>
        </Row>
      </Container>
    );
  }
}

PageExContainer.propTypes = {
  courseCategories: PropTypes.array.isRequired,
  children: PropTypes.node,
};

export function mapStateToProps(state) {
  const pageEx = state.pageEx;
  return {
    courseCategories: pageEx.courseCategories,
  };
}

export default connect(mapStateToProps)(PageExContainer);
