import React, { PropTypes } from 'react';
import { Table } from 'semantic-ui-react';

function CourseCategoryRow(props) {
  return (
    <Table.Row>
      <Table.Cell>{props.name}</Table.Cell>
      <Table.Cell>2</Table.Cell>
    </Table.Row>
  );
}

CourseCategoryRow.propTypes = {
  name: PropTypes.string.isRequired,
};

export default CourseCategoryRow;
