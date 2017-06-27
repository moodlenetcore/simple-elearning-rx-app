import { connect } from 'react-redux'
import { list } from '../modules/course'

import CourseList from '../components/CourseList'

const mapDispatchToProps = {
  list : () => list(),
}

const mapStateToProps = (state) => ({
})

export default connect(mapStateToProps, mapDispatchToProps)(CourseList)