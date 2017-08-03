import { createStore, applyMiddleware, compose } from 'redux';
import thunk from 'redux-thunk';
import rootReducer from '../reducer';

export default function configureStore(initialState) {
  // ======================================================
  // Middleware Configuration
  // ======================================================
  const middleware = [thunk];

  // ======================================================
  // Store Enhancers
  // ======================================================
  const enhancers = [];
  let composeEnhancers = compose;

  if (__DEV__) {
    if (typeof window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ === 'function') {
      composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__;
    }
  }

  // ======================================================
  // Store Instantiation and HMR Setup
  // ======================================================
  return createStore(
    rootReducer,
    initialState,
    composeEnhancers(
      applyMiddleware(...middleware),
      ...enhancers,
    ));
}

