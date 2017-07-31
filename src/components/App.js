import React from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import createBrowserHistory from 'history/createBrowserHistory';
import PageNotFound from './common/PageNotFound';
import Home from './landing/Home';
import HeaderNavContainer from './landing/HeaderNavContainer';
import About from './About';

import UserListContainer from './user/UserListContainer';
import AddOrEditUserContainer from './user/AddOrEditUserContainer';

//import App from 'components/App/AppContainer';
//import CourseCategory from 'components/CourseCategory/CourseCategoryContainer';
//import PageExContainer from 'components/PageEx/PageExContainer';

const history = createBrowserHistory();

const App = () => {
  return (
    <div>
      <Router history={history}>
        <div>
          <HeaderNavContainer />
          <Switch>
            <Route exact path ="/" component={Home}></Route>
            <Route path="/users" component={UserListContainer}></Route>
            <Route exact path="/user" component={AddOrEditUserContainer}></Route>
            <Route path="/user/:id" component={AddOrEditUserContainer}></Route>
            <Route path="/about" component={About}></Route>
            <Route component={PageNotFound}></Route>
          </Switch>
        </div>
      </Router>
    </div>
  );
};

export default App;