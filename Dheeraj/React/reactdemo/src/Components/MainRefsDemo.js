import React , { Component } from 'react';
import RefsDemo from './RefsDemo'

class MainRefsDemo extends Component{

    constructor(props)
    {
        super(props);
        this.childRef = React.createRef()
    }


    handleChildComponentFocus = () =>
    {
        this.childRef.current.focusInput()
    }
    render()
    {
        return (
            <div>
                <RefsDemo ref = {this.childRef}></RefsDemo>
               <button onClick = { this.handleChildComponentFocus }>FocusRefsDemo Input Field</button>
            </div>
        )
    }
}

export default MainRefsDemo