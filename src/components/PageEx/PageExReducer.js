import { fromJS } from 'immutable';

import { removeArrayItem } from 'helpers/immutableHelper';
import * as ActionTypes from './PageExActionTypes';
import { PAGE_EX_INITIAL_STATE } from './PageExConstants';

export default function PageExReducer(state = PAGE_EX_INITIAL_STATE, action) {
  switch (action.type) {
    case ActionTypes.PAGE_EX_REMOVE_ITEM: {
      const newState = Object.assign({}, state);
      newState.courseCategories = removeArrayItem(newState.courseCategories, action.index);
      return newState;
    }

    default:
      return state;
  }
}
