import React from "react";
import App from "./App";
import Announce from './pages/announce/Announce';
import Home from './pages/home/Home';


import { BrowserRouter, Route } from "react-router-dom";
import NavBar from "./components/navbar";

const Routes = () => (
  <BrowserRouter>
    <Route path="/" exact component={Home} />
    <Route path="/main" component={NavBar} />
    <Route path="/announce" component={Announce} />
  </BrowserRouter>
);

export default Routes;
