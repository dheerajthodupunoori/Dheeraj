import React , { Component } from 'react';
import ReactDOM from 'react-dom';
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

describe("when setting up testing" , () =>
{
    let result;
    beforeAll(()=>
    {
        result = <Sum a={2} b={2}/>;
        console.log(result);
    });

    it("returns a value" , () => {
            expect(result).not.toBeNull();
    });
});
