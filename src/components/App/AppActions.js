import * as ActionTypes from './AppActionTypes';

function testAction(info) {
  console.log('asdksl');
  return {
    type: ActionTypes.APP_TEST_ACTION_INFO,
    info,
  };
}
