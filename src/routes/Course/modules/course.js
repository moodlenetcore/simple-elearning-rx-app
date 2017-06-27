// ------------------------------------
// Constants
// ------------------------------------
export const COURSE_LIST = 'COURSE_LIST'

// ------------------------------------
// Actions
// ------------------------------------
export function list () {
  return {
    type    : COURSE_LIST,
    payload : courses
  }
}


export const actions = {
  list
}

// ------------------------------------
// Action Handlers
// ------------------------------------
const ACTION_HANDLERS = {
  [COURSE_LIST]    : (state, action) => ({
    ...state,
    items: action.payload
  })
}

// ------------------------------------
// Reducer
// ------------------------------------
export const courses = [
  {_id: "1", name: "ReactJS" },
  {_id: "2", name: "Angular" },
  {_id: "3", name: "JQuery" },
  {_id: "4", name: "DotNetCore" },
];
export default function courseReducer (state = initialState, action) {
  const handler = ACTION_HANDLERS[action.type]

  return handler ? handler(state, action) : state
}
