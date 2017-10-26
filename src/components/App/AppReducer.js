import { APP_INITIAL_STATE } from './AppConstants';
import * as ActionTypes from './AppActionTypes';

function AppReducer(state = APP_INITIAL_STATE, action) {
  switch (action.type) {
    case ActionTypes.APP_TEST_ACTION_INFO: {
      return state;
    }

    default:
      return state;
  }
}

export default AppReducer;
