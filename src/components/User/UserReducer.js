import * as ActionTypes from './UserActionTypes';
import {USER_INITIAL_STATE} from './UserConstants';
import { fromJS } from 'immutable';
import _ from 'lodash';

const UsersReducer = (state = USER_INITIAL_STATE, action) => {
    switch(action.type) {
        case ActionTypes.GET_USERS_RESPONSE: {
            // '...' spread operator clones the state
            // lodash Object assign simply clones action.users into a new array.
            // The return object is a copy of state and overwrites the state.users with a fresh clone of action.users
            const oldState = fromJS(state);
            const newState = oldState.set('users', action.data);
            return newState.toJS();
        }


        default: { 
            return state;
        }
    }
};

export default UsersReducer;