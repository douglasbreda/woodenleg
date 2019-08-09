import React from "react";
import App from "./App";
import Home from './pages/home';

import { BrowserRouter, Route } from "react-router-dom";
import NavBar from "./components/navbar";

const Routes = () => (
  <BrowserRouter>
    <Route path="/" exact component={Home} />
    <Route path="/main" component={NavBar} />
  </BrowserRouter>
);

export default Routes;
