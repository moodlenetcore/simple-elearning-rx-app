import React from 'react';
import { render } from 'react-dom';
import { Provider } from 'react-redux';
import { browserHistory, Router, Route, IndexRoute } from 'react-router';

import configureStore from './store/configureStore';

import App from './components/App/AppContainer';
import CourseCategory from './components/CourseCategory/CourseCategoryContainer';

const store = configureStore();

render((
  <Provider store={store}>
    <Router history={browserHistory}>
      <Route path="/" component={App}>
        <IndexRoute component={CourseCategory} />
        <Route path="/test" component={CourseCategory} />
      </Route>
    </Router>
  </Provider>
), document.getElementById('root'));
