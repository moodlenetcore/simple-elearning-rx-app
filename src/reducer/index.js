import {combineReducers} from 'redux';
import {reducer as formReducer} from 'redux-form';
import usersReducer from './usersReducer';
import selectedUserReducer from './selectedUserReducer';
import authorReducer from './authorReducer';
import apiReducer from './apiReducer';

export default combineReducers({
    usersReducer,
    selectedUserReducer,
    authorReducer,
    apiReducer,
    form: formReducer    
});