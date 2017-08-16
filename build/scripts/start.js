const logger = require('../lib/logger')

logger.info('Starting server...')
require('../../server/main').listen(11112, () => {
  logger.success('Server is running at http://localhost:3000/elearning-app')
})
