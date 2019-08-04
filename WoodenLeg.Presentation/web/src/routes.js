import React from 'react';
import App from './App';

import {BrowserRouter, Switch, Route } from 'react-router-dom';


const Routes = () => (
    <BrowserRouter>
        <Switch>
            <Route exact path="/" component={App}></Route>
        </Switch>
    </BrowserRouter>
)

export default Routes;