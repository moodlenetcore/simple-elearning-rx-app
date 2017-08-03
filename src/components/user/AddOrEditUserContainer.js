import React, { PropTypes } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import toastr from 'toastr';
import * as userAction from '../../action/UserAction';
import UserForm from './UserForm';

export class AddOrEditUserContainer extends React.Component{
    constructor(){
        super();
        this.handleSave = this.handleSave.bind(this);
        this.handleCancel = this.handleCancel.bind(this);
    }

    componentDidMount(){
        this.props.action.getUserAction(this.props.match.params.id)
            .catch(error => {
                toastr.error(error);
            });
    }

    handleSave(values){
        const user = {
            id: values.id,
            username: values.username,
            password: values.password
        }

        this.props.action.saveUserAction(user)
            .then(() => {
                toastr.success('User saved');
                this.props.history.push('users');
            }).catch(error => {
                toastr.error(error);
            });
    }

    handleCancel(event){
        event.preventDefault();
        this.props.history.replace('/users');
    }

    render(){
        const {initialValues}=this.props;
        const heading = initialValues && initialValues.id ? 'Edit' : 'Add';

        return(
            <div className="container">
                <UserForm
                    heading={heading}
                    handleSave={this.handleSave}
                    handleCancel={this.handleCancel}
                    initialValues={this.props.initialValues}
                />
            </div>
        );
    }
}

const mapStateToProps = (state, ownProps) => {
    const userId = ownProps.match.params.id;

    if (userId && state.selectedUserReducer.user && userId === state.selectedUserReducer.user.id) {
        return{
            initialValues: state.selectedUserReducer.user
        };
    }
    else {
        return {
            
        };
    }
};

const mapDispatchToProps = dispatch => ({
    action: bindActionCreators({...userAction}, dispatch)
});

AddOrEditUserContainer.propTypes = {
    action: PropTypes.object.isRequired,
    history: PropTypes.object,
    initialValues: PropTypes.object,
    match: PropTypes.object.isRequired
};

export default connect(mapStateToProps, mapDispatchToProps)(AddOrEditUserContainer);