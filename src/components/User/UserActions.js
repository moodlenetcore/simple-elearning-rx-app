import * as ActionTypes from './UserActionTypes';
import UserApi from '../api/UserApi';
import { ApiCallBeginAction, ApiCallErrorAction } from './ApiAction';

export const getUsersResponse = users => ({
    type: ActionTypes.GET_USERS_RESPONSE,
    users
});

export function getUsersAction() {
    return (dispatch) => {

        dispatch(ApiCallBeginAction());

        return UserApi.getAllUsers()
            .then(users => {
                dispatch(getUsersResponse(users));
            }).catch(error => {
                throw error;
            });
    };
}

export const addNewUserResponse = () => ({
    type: ActionTypes.ADD_NEW_USER_RESPONSE
});

export const updateExistingUserResponse = () => ({
    type: ActionTypes.UPDATE_EXISTING_USER_RESPONSE
});

export function saveUserAction(userBeingAddedOrEdited) {
    return function (dispatch) {

        dispatch(ApiCallBeginAction());

        //if userId exists, it means that the user is being edited, therefore update it.
        //if userId doesn't exist, it must therefore be new user that is being added, therefore add it
        return UserApi.saveUser(userBeingAddedOrEdited)
            .then(() => {
                if (userBeingAddedOrEdited.id) {
                    dispatch(updateExistingUserResponse());
                } else {
                    dispatch(addNewUserResponse());
                }
            }).then(() => {
                dispatch(getUsersAction());
            }).catch(error => {
                dispatch(ApiCallErrorAction());
                throw (error);
            });
    };
}

export const getUserResponse = userFound => ({
    type: ActionTypes.GET_USER_RESPONSE,
    user: userFound
});

export function getUserAction(userId) {
    return (dispatch) => {

        dispatch(ApiCallBeginAction());

        return UserApi.getUser(userId)
            .then(user => {
                dispatch(getUserResponse(user));
            }).catch(error => {
                throw error;
            });
    };
}

export const deleteUserResponse = () => ({
    type: ActionTypes.DELETE_USER_RESPONSE
});

export function deleteUserAction(userId) {
    return (dispatch) => {

        dispatch(ApiCallBeginAction());

        return UserApi.deleteUser(userId)
            .then(() => {
                dispatch(deleteUserResponse());
            }).then(() => {
                dispatch(getUsersAction());
            }).catch(error => {
                throw error;
            });
    };
}