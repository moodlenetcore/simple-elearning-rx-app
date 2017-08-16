import Actions from './CourseCategoryActions';
import CourseCategoryApi from './CourseCategoryApi';

function loadCourseCategory() {
  return (dispatch) => {
    dispatch(Actions.setShowSpin(true));
    return CourseCategoryApi.getCourseCategories()
      .then((response) => {
        console.log(response.data);
        dispatch(Actions.getCourseCategorySuccess(response.data));
        dispatch(Actions.setShowSpin(false));
      })
      .catch(() => {
        console.log('get info category failed');
      });
  };
}

export default {
  loadCourseCategory,
};
