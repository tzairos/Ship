import React, { useState } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { Redirect, Route } from "react-router";
export const AuthRoute = props => {
    const isLoggedIn = useSelector((state) => state.user.isLoggedIn)
    const { type } = props;
    if (type === "guest" && isLoggedIn) return <Redirect to="/" />;
    else if (type === "private" && !isLoggedIn) return <Redirect to="/login" />;
  
    return <Route {...props} />;
  };