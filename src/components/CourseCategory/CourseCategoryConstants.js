export const COURSE_CATEGORY_INITIAL_STATE = {
  loginAsAdminText: '',
  logBackInAsText: '',
  navigationLinks: [],
  navigationHelpLink: undefined,
  selectedNavigation: {
    index: 0,
    childIndex: -1,
  },
  userProfile: {},
  importExportLoadingStatus: {
    visible: false,
    text: '',
    finish: false,
  },
  importExportErrorStatus: {
    errorMessage: '',
    errorFileDocumentLink: '',
    validationErrors: [],
  },
};