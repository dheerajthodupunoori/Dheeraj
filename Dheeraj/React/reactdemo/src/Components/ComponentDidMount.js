import React , { Component } from 'react';

class ComponentDidMountDemo extends Component
{

    constructor()
    {
        super();
        this.state = {
            name : 'Dheeraj'
        }
    }

    componentDidMount()
    {
        console.log("Component Did mount called after render method");
        // this.setState({
        //     name:"newNamedfsdfsfs"
        // })
    }

    handelInputChange = (event) =>
    {
        this.setState({
            name : event.target.value
        })
    }

    render()
    {
        console.log("Render Method called");
        return(
        <div>
            <input type="text" value = { this.state.name } onChange = { this.handelInputChange }/>
        </div>
        )
    }
}

export default ComponentDidMountDemo