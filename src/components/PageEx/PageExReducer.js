import * as ActionTypes from './PageExActionTypes';
import { PAGE_EX_INITIAL_STATE } from './PageExConstants';

export default function PageExReducer(state = PAGE_EX_INITIAL_STATE, action) {
  switch (action.type) {
    case ActionTypes.PAGE_EX_ABC: {
      return state;
    }

    default:
      return state;
  }
}
