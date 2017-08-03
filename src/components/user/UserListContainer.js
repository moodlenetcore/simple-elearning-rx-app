import React, {PropTypes} from 'react';
import {connect} from 'react-redux';
import {bindActionCreators} from 'redux';
import toastr from 'toastr';
import * as userAction from '../../action/UserAction';
import UserList from './UserList';

export class UserListContainer extends React.Component{
    constructor(){
        super();

        this.state = {selectedUserId: undefined};

        this.handleAddUser = this.handleAddUser.bind(this);
        this.handleEditUser = this.handleEditUser.bind(this);
        this.handleDeleteUser = this.handleDeleteUser.bind(this);
        this.handleRowSelect= this.handleRowSelect.bind(this);
    }

    componentDidMount(){
        this.props.action.getUsersAction()
            .catch(error => {
                toastr.error(error);
            });
    }

    handleAddUser(){
        this.props.history.push('/user');
    }

    handleEditUser(){
        const selectedUserId = this.state.selectedUserId;

        if (selectedUserId) {
            this.setState({selectedUserId: undefined});
            this.props.history.push(`/user/${selectedUserId}`);
        }
    }

    handleDeleteUser(){
        const selectedUserId = this.state.selectedUserId;

        if (selectedUserId) {
            this.setState({selectedUserId: undefined});
            this.props.action.deleteUserAction(selectedUserId)
                .catch(error => {
                    toastr.error(error);
                });
        }
    }

    handleRowSelect(row, isSelected){
        if (isSelected) {
            this.setState({selectedUserId: row.id});
        }
    }

    render(){
        const {users} = this.props;

        if (!users) {
            return(
                <div>Loading...</div>
            );
        }

        return(
            <div className="container-fluid">
                <div className="row mt-3">
                    <div className="col">
                        <h1>Users</h1>
                    </div>
                </div>

                <div className="row mt-3">
                    <div className="col">
                        <div className="btn-group" role="group">
                            <button
                                type="button"
                                className="btn btn-primary"
                                onClick={this.handleAddUser}
                            >
                                <i className="fa fa-plus" aria-hidden="true"/> New
                            </button>

                            <button
                                type="button"
                                className="btn btn-warning ml-2"
                                onClick={this.handleEditUser}
                            >
                                <i className="fa fa-pencil" aria-hidden="true"/> Edit
                            </button>

                            <button
                                type="button"
                                className="btn btn-danger ml-2"
                                onClick={this.handleDeleteUser}
                            >
                                <i className="fa fa-trash-o" aria-hidden="true"/> Delete
                            </button>
                        </div>
                    </div>
                </div>
                <div className="row">
                    <div className="col">
                        <UserList users={users} handleRowSelect={this.handleRowSelect}/>
                    </div>
                </div>
            </div>
        );
    }
}

const mapStateToProps = state => ({
    users: state.usersReducer.users
});

const mapDispatchToProps = dispatch => ({
    action: bindActionCreators(userAction, dispatch)
});

UserListContainer.propTypes = {
    users: PropTypes.array,
    action: PropTypes.object.isRequired,
    history: PropTypes.object.isRequired
}

export default connect(mapStateToProps, mapDispatchToProps)(UserListContainer);