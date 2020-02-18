import React, { Component } from 'react';
// import logo from './logo.svg';
import './App.css';
// import Componentdidmount from './Components/ComponentDidMount'
// import RefsDemo from './Components/RefsDemo'
// import MainRefsDemo from './Components/MainRefsDemo'
// import HttpDemo from './Components/HttpPostDemo'
import Home from './Components/Home';
import About from './Components/About';
import Contact from './Components/Contact';
import Error from './Components/Error';
import  { BrowserRouter as Router  , NavLink , Redirect } from 'react-router-dom';
import Route from 'react-router-dom/Route';

class App extends Component {

  state = {
    isLoggedIn : false
  };

  handleLogIn = () =>
  {
    console.log("Login handler triggered");
    this.setState( prevState => ({
      isLoggedIn : !prevState.isLoggedIn
    }));
  }
  render() {
    return (
      <Router>
      <div className="App">
      <ul>
      <li><NavLink to="/Home" activeStyle = { {color : 'red' } } exact>Home</NavLink></li>
      <li><NavLink to="/About" activeStyle = { {color : 'red' } } exact>About</NavLink> </li>
      <li> <NavLink to="/Contact" activeStyle = { {color : 'red' } } exact>Contact</NavLink></li>
      </ul>
      <input type="button" value={ this.state.isLoggedIn ? "Log Out" : "Log In"} onClick = { this.handleLogIn }/>
      <Route path="/Home"  render = {
        () => (
          this.state.isLoggedIn ? (<Home/>) : (<Redirect to="/About"></Redirect>)
        )
      }/>
      <Route path="/About" component = { About }/>
      <Route path="/Contact" component = { Contact }/>
      <Route  component = { Error }/>

       
      </div>
      </Router>
    );
  }
}

export default App;
