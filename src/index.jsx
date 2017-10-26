import React from 'react';
import { render } from 'react-dom';
import { Provider } from 'react-redux';
import { browserHistory, Router, Route, IndexRoute } from 'react-router';

import configureStore from 'store/configureStore';

import App from 'components/App/AppContainer';
import Administrator from 'components/Administrator/AdministratorContainer';
import CourseCategory from 'components/CourseCategory/CourseCategoryContainer';
import PageEx from 'components/PageEx/PageExContainer';
import { BASE_ROUTE } from 'components/Common/CommonConstants';

import 'styles/main.scss';

const store = configureStore();

render((
  <Provider store={store}>
    <Router history={browserHistory}>
      <Route path={`/${BASE_ROUTE}`} component={App}>
        <IndexRoute component={PageEx} />
        <Route path={`/${BASE_ROUTE}/page-ex`} component={PageEx}>
          <Route path={`/${BASE_ROUTE}/page-ex/:id`} component={PageEx} />
        </Route>
      </Route>
      <Router path={`/${BASE_ROUTE}/administrator`} component={Administrator}>
        <Router path={`/${BASE_ROUTE}/administrator/course-category`} component={CourseCategory} />
      </Router>
    </Router>
  </Provider>
), document.getElementById('root'));
