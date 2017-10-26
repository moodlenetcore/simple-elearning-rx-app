import { fromJS } from 'immutable';

import { COURSE_CATEGORY_INITIAL_STATE } from './CourseCategoryConstants';
import * as ActionTypes from './CourseCategoryActionTypes';

function CourseCategoryReducer(state = COURSE_CATEGORY_INITIAL_STATE, action) {
  switch (action.type) {
    case ActionTypes.CC_SET_SHOW_SPIN: {
      return state;
    }
    case ActionTypes.CC_GET_COURSE_CATEGORY_SUCCESS: {
      const oldState = fromJS(state);
      const newState = oldState.set('courseCategories', action.data);
      return newState.toJS();
    }

    default:
      return state;
  }
}

export default CourseCategoryReducer;
