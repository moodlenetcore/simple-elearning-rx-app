const logger = require('../lib/logger')

logger.info('Starting server...')
require('../../server/main').listen(12345, () => {
  logger.success('Server is running at http://localhost:12345')
})
