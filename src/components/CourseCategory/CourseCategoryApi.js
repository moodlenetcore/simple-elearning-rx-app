import * as axios from 'axios';

import { BASE_COURSE_CATEGORY_API_PATH } from './CourseCategoryConstants';

class CourseCategoryApi {
  static getCourseCategories() {
    return axios.get(BASE_COURSE_CATEGORY_API_PATH);
  }

  static addCourseCategory() {
    return axios.post(BASE_COURSE_CATEGORY_API_PATH, {
      name: 'abc',
    });
  }
}

export default CourseCategoryApi;

