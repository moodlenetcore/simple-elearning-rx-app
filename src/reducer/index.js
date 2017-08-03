import {combineReducers} from 'redux';
import {reducer as formReducer} from 'redux-form';
import usersReducer from './usersReducer';
import selectedUserReducer from './selectedUserReducer';
import apiReducer from './apiReducer';

export default combineReducers({
    usersReducer,
    selectedUserReducer,
    apiReducer,
    form: formReducer    
});