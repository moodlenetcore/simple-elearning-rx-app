import { combineReducers } from 'redux';

import AppReducer from 'components/App/AppReducer';
import CourseCategoryReducer from 'components/CourseCategory/CourseCategoryReducer';
import PageExReducer from 'components/PageEx/PageExReducer';

export const rootReducer = combineReducers({
  app: AppReducer,
  courseCategory: CourseCategoryReducer,
  pageEx: PageExReducer,
});

export default rootReducer;
