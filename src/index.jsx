import React from 'react';
import { render } from 'react-dom';
import { Provider } from 'react-redux';
import { browserHistory, Router, Route, IndexRoute } from 'react-router';

import configureStore from 'store/configureStore';

import App from 'components/App/AppContainer';
import CourseCategory from 'components/CourseCategory/CourseCategoryContainer';
import PageExContainer from 'components/PageEx/PageExContainer';

const store = configureStore();

render((
  <Provider store={store}>
    <Router history={browserHistory}>
      <Route path="/" component={App}>
        <IndexRoute component={PageExContainer} />
        <Route path="/page-ex" component={PageExContainer}>
          <Route path="/page-ex/:id" component={PageExContainer} />
        </Route>
      </Route>
    </Router>
  </Provider>
), document.getElementById('root'));
