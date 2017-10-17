import * as ActionTypes from './UserActionTypes';
import initialState from './UserInitialState';
import _ from 'lodash';


const SelectedUserReducer = (state = initialState.selectedUserReducer, action) => {
    switch(action.type) {

        case ActionTypes.GET_USER_RESPONSE: {
            return {
                ...state,
                user: _.assign(action.user)
            };
        }


        default: { return state; }
    }
};


export default SelectedUserReducer;