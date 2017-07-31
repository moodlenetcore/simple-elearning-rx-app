import * as ActionType from '../action/ActionType';
import initialState from './initialState';
import _ from 'lodash';

const usersReducer = (state = initialState.usersReducer, action) => {
    switch(action.type) {
        case ActionType.GET_USERS_RESPONSE: {
            // '...' spread operator clones the state
            // lodash Object assign simply clones action.users into a new array.
            // The return object is a copy of state and overwrites the state.users with a fresh clone of action.users
            return {
                ...state, 
                users: _.assign(action.users)
            };
        }


        default: { return state; }
    }
};

export default usersReducer;