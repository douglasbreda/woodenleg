import React from "react";
import "./App.css";
import "bootstrap/dist/css/bootstrap.css";
import "./components/navbar"
import Routes from './routes';
import Footer from './components/footer'

function App() {
  return (
    <div className="App">  
      <Routes />
    </div>
  );
}

export default App;
