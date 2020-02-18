import React from 'react';
import './App.css';
import './bootstrap.min.css';
// import Sum from './Components/Sum';


function Hero() {
return(
<div className="row">
<div className="jumbotron col-10 offset-1">
<h1> Author Quiz</h1>
<p>Select  the book written by the author shown</p>
</div>
</div>)
}


function Turn({author , books}){
  console.log(books);
return(
<div className="row" style={{ backgroundColor : "white" }}>
<div className="col-4 offset-1">
<image src={author.imageUrl} className="authorImage" alt="Author"/>
</div>
<div className="col-6">
{books.map((title) =><Book title={title} key={title}/>)}
</div>
</div>
)

}

function Book({title}){
  return(
    <div className="answer">
    <h4>{title}</h4>
    </div>
  )
}

function Continue(){
  return(<div/>)


}

function Footer(){
  return(<div className="row" id="footer">
<div className="col-12">
<p className="text-muted credit">All images are from public domain</p>
</div>
  </div>)
}

function AuthorQuiz({turnData}) {
 
    return (
     <div className = "container-fluid">
      <Hero/>
      <Turn {...turnData}/>
      <Continue/>
      <Footer/>
     </div>
    );
  
}

export default AuthorQuiz;
