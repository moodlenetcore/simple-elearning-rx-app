import _ from 'lodash';
import * as ActionTypes from './UserActionTypes';
import initialState from './UserInitialState';



const apiReducer = (state = initialState.apiReducer, action) => {
    if (action.type === ActionTypes.API_CALL_BEGIN) {
        return {
            ...state, apiCallsInProgress: state.apiCallsInProgress + 1
        };

    } else if (isApiCallFinished(action.type) || action.type === ActionTypes.API_CALL_ERROR) {
        return {
            ...state, apiCallsInProgress: state.apiCallsInProgress - 1
        };
    }

    return state;
};



function isApiCallFinished(type) {
    return _.endsWith(type, '_RESPONSE');
}




export default apiReducer;