import { combineReducers } from 'redux';

import AppReducer from 'components/App/AppReducer';
import CourseCategoryReducer from 'components/CourseCategory/CourseCategoryReducer';
import PageExReducer from 'components/PageEx/PageExReducer';
import UserReducer from 'components/User/UserReducer';

export const rootReducer = combineReducers({
  app: combineReducers({
    index: AppReducer,
    pageEx: PageExReducer,
  }),
  administrator: combineReducers({
    courseCategoryPage: CourseCategoryReducer,
    userPage: UserReducer,
  }),
});

export default rootReducer;
