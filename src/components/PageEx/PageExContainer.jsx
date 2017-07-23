import React, { PropTypes } from 'react';
import { connect } from 'react-redux';

class PageExContainer extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    const {
        courseCategories,
      } = this.props;

    return (
      <div className="col-md-12">
        <div className="col-md-4">
          <ul>
            {
              courseCategories.map(courseCategory =>
                (<li>
                  {courseCategory.name}
                </li>),
              )
            }
          </ul>
        </div>
        <div className="col-md-8">
          {this.props.children}
        </div>
      </div>
    );
  }
}

PageExContainer.propTypes = {
  courseCategories: PropTypes.array.isRequired,
  children: PropTypes.node,
};

export function mapStateToProps(state) {
  const pageEx = state.pageEx;
  return {
    courseCategories: pageEx.courseCategories,
  };
}

export default connect(mapStateToProps)(PageExContainer);
