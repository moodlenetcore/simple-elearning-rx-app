import { COURSE_INITIAL_STATE } from './CourseConstants';

function CourseReducer(state = COURSE_INITIAL_STATE, action) {
  switch (action.type) {
    case 'INFO': {
      return state;
    }

    default:
      return state;
  }
}

export default CourseReducer;
