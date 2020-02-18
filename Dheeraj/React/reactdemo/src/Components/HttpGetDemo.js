import React , { Component } from 'react';
import Axios from 'axios';

class HttpGetDemo extends Component{

    constructor(props)
    {
        super(props)
        this.state = {
            //Empty Array declaration
            jsonPlaceHolderPosts : [],
            errorMessage : ""
        }
    }

//Life cycle method where we can make http request
    componentDidMount(){

        Axios.get('https://jsonplaceholder.typicode.com/posts')
            .then((response) => {
                console.log(response);
                this.setState({
                    jsonPlaceHolderPosts : response.data
                })
            })
            .catch((error) => {
                console.log(error);
                this.setState({
                    errorMessage : "Error Occured while retrieving data from JsonPlaceholder"
                })
                console.log(this.state.errorMessage);
            });

    }

    render()
    {
        // const { getData } = this.state
        return (
            <div>
                List of Posts:
                {
                  this.state.jsonPlaceHolderPosts.map(item => <li key = { item.id }>{ item.title }</li>) 
                }
                { this.state.errorMessage ? <div> { this.state.errorMessage } </div>: null }
            </div>
        )
    }
}

export default HttpGetDemo