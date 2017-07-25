import React, { PropTypes } from 'react';
import { Table, Button } from 'semantic-ui-react';

function CourseCategoryRow(props) {
  const boundOnRemoveItem = () => {
    props.onRemoveItem(props.index);
  };
  return (
    <Table.Row>
      <Table.Cell>{props.name}</Table.Cell>
      <Table.Cell>
        <Button color="red" onClick={boundOnRemoveItem}>Delete</Button>
      </Table.Cell>
    </Table.Row>
  );
}

CourseCategoryRow.propTypes = {
  name: PropTypes.string.isRequired,
  onRemoveItem: PropTypes.func.isRequired,
};

export default CourseCategoryRow;
