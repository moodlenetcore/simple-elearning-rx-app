import * as ActionTypes from './PageExActionTypes';

export function removeItem(index) {
  return {
    type: ActionTypes.PAGE_EX_REMOVE_ITEM,
    index,
  };
}

export function ABC1(index) {
  return {
    type: ActionTypes.PAGE_EX_ABC1,
    index,
  };
}
