import React from 'react';
import ReactDOM from 'react-dom';
import { Route, BrowserRouter as Router, Switch } from 'react-router-dom'

//Style
import './index.css';

import App from './pages/home/App';
import Login from './pages/login/login'
import Cadastro from './pages/Cadastro/Cadastro';

import reportWebVitals from './reportWebVitals';

const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={App}/> {/* Home */}
        <Route  exact path="/Login" component={Login}/> {/* Login */}
        <Route path="/cadastro" component={Cadastro} /> {/* cadastro */}
      </Switch>
    </div>
  </Router>
)

ReactDOM.render(routing,document.getElementById('root'));

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();

