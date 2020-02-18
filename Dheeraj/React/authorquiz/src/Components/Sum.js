import React, { Component } from 'react';
import PropTypes from 'prop-types';

class Sum extends Component {

    
  render() {
    return (
      <div>
        The sum of { this.props.a} + { this.props.b } = { this.props.a + this.props.b }
        
      </div>
    )
  }
}
Sum.propTypes = {
    a:PropTypes.number.isRequired,
    b:PropTypes.number.isRequired
};
export default Sum
