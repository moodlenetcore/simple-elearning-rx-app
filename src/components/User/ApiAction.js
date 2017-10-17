import * as ActionTypes from './UserActionTypes';

export const ApiCallBeginAction = () => ({
    type: ActionTypes.API_CALL_BEGIN
});

export const ApiCallErrorAction = () => ({
    type: ActionTypes.API_CALL_ERROR
});