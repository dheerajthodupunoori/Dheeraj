import React , { Component } from 'react';
import Axios from 'axios';


class HttpPostDemo extends Component{

    constructor(props){
        super(props)
        this.state = {
            userId : '',
            title : '',
            body : ''
        }
    }

    handleChangeEvent = (event) => {
        this.setState({
            [event.target.name] : event.target.value
        })
    }
    handleSubmit = (event) => {
        event.preventDefault();
        console.log(this.state);
        Axios.post('https://jsonplaceholder.typicode.com/posts' , this.state)
            .then((response) => {
                console.log("Succesfully inserted data into server " , response);
            })
            .catch((error) => {
                console.log("Error occured while inserting data into server " ,error);
            });
    }
    render()
    {
        return (
            <div>
                <form onSubmit = { this.handleSubmit }>
                    <input 
                        type="text" 
                        name = "userId"
                        value = { this.state.userId } 
                        onChange = { this.handleChangeEvent }
                    />
                     <input 
                        type="text" 
                        name = "title"
                        value = { this.state.title } 
                        onChange = { this.handleChangeEvent }
                    />
                     <input 
                        type="text" 
                        name = "body"
                        value = { this.state.body } 
                        onChange = { this.handleChangeEvent }
                    />
                    <button type="submit">Submit</button>
                </form>
            </div>
        )
    }
}

export default HttpPostDemo