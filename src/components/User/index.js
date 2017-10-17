import {combineReducers} from 'redux';
import {reducer as formReducer} from 'redux-form';
import usersReducer from './UserReducer';
import selectedUserReducer from './UserSelectedReducer';
import apiReducer from './apiReducer';

export default combineReducers({
    usersReducer,
    selectedUserReducer,
    apiReducer,
    form: formReducer    
});