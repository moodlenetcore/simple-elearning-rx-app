import React from 'react';
import { render } from 'react-dom';
import { Provider } from 'react-redux';
import { browserHistory, Router, Route, IndexRoute } from 'react-router';

import configureStore from 'store/configureStore';

import App from 'components/App/AppContainer';
import CourseCategory from 'components/CourseCategory/CourseCategoryContainer';
import PageExContainer from 'components/PageEx/PageExContainer';
import { BASE_ROUTE } from 'components/Common/CommonConstants';

const store = configureStore();

render((
  <Provider store={store}>
    <Router history={browserHistory}>
      <Route path={`/${BASE_ROUTE}`} component={App}>
        <IndexRoute component={PageExContainer} />
        <Route path={`/${BASE_ROUTE}/page-ex`} component={PageExContainer}>
          <Route path={`/${BASE_ROUTE}/page-ex/:id`} component={PageExContainer} />
        </Route>
      </Route>
      <Router path={`/${BASE_ROUTE}/administrator`} component={App}>
        <Router path={`/${BASE_ROUTE}/administrator/course-category`} component={CourseCategory} />
      </Router>
    </Router>
  </Provider>
), document.getElementById('root'));
