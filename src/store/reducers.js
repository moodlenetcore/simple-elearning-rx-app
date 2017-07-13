import { combineReducers } from 'redux';

import AppReducer from '../components/App/AppReducer';
import CourseCategoryReducer from '../components/CourseCategory/CourseCategoryReducer';

export const rootReducer = combineReducers({
  app: AppReducer,
  courseCategory: CourseCategoryReducer,
});

export default rootReducer;
