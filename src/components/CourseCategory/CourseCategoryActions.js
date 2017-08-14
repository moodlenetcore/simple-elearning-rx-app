import * as ActionTypes from './CourseCategoryActionTypes';

function setShowSpin(showSpin) {
  return {
    type: ActionTypes.CC_SET_SHOW_SPIN,
    showSpin,
  };
}

function getCourseCategorySuccess(data) {
  return {
    type: ActionTypes.CC_GET_COURSE_CATEGORY_SUCCESS,
    data,
  };
}

function deleteCourseCategory(index) {
  return {
    type: ActionTypes.CC_DELETE_COURSE_CATEGORY,
    index,
  };
}

export default {
  setShowSpin,
  getCourseCategorySuccess,
  deleteCourseCategory,
};
