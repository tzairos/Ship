import React, { Component } from 'react';
import { Layout } from './components/Layout';
import { Login } from './components/Login';
import { AuthRoute } from './components/AuthRoute';
import { Ship } from './components/Ship';
import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
       
        <AuthRoute path="/login" type="guest">
           <Login />
        </AuthRoute>
        <AuthRoute path="/" type="private">
           <Ship />
        </AuthRoute>
      </Layout>
    );
  }
}
