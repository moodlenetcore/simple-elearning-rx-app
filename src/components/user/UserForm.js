import React, { PropTypes } from 'react';
import { Field, reduxForm } from 'redux-form';
import FieldInput from '../common/FieldInput';
import SelectInput from '../common/SelectInput';

export const UserForm = ({ handleSubmit, pristine, reset, submitting, heading, authors, handleSave, handleCancel }) => {
	return (
		<form onSubmit={handleSubmit(handleSave)}>
			<h1>{heading}</h1>

			<Field
				type="text"
				name="username"
				label="User Name"
				placeholder="User name"
				component={FieldInput}
			/>
			<Field
				type="text"
				name="password"
				label="Password"
				placeholder="Password"
				component={FieldInput}
			/>
			<div>
				<button type="submit" disabled={submitting} className="btn btn-primary"><i className="fa fa-paper-plane=o" aria-hidden="true" />Submit</button>

				{heading === 'Add' && <button type="button" disabled={pristine || submitting} onClick={reset} className="btn btn-default btn-space">Clear Values</button>}

				<button type="button" className="btn btn-default btn-space" onClick={handleCancel}>Cancel</button>
			</div>
		</form>
	);
};

const validate = values => {
	const errors = {};

	if (!values.username) {
		errors.username = 'Required';
	}

	if (!values.password) {
		errors.password = 'Required';
	}

	return errors;
};

UserForm.propTypes={
	handleSubmit: PropTypes.func.isRequired,
	pristine: PropTypes.bool.isRequired,
	reset: PropTypes.func.isRequired,
	submitting: PropTypes.bool.isRequired,
	heading: PropTypes.string.isRequired,
	authors: PropTypes.array.isRequired,
	handleSave: PropTypes.func.isRequired,
	handleCancel: PropTypes.func.isRequired,
}

export default reduxForm({
	form: 'UserForm',
	validate
})(UserForm);