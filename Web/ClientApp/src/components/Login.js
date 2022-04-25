import React from 'react'
import { useSelector, useDispatch } from 'react-redux'
import { loginAsync } from '../features/user/userSlice'

import { Formik, Form, Field, ErrorMessage } from 'formik';
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
export function Login() {
  const count = useSelector((state) => state.ship.value)
  const dispatch = useDispatch()

  return (
    <div className='ship-form' style={{ display: 'flex', flexDirection: 'column', justifyContent: 'center', margin: 'auto', textAlign: 'center' }}>
      <h1 style={{ marginTop: '10px', marginBottom: '30px' }}>Ship Login</h1>
      <Formik
        style={{ marginTop: '10px', marginBottom: '30px' }}
        initialValues={{ username: '', password: '' }}
        validate={values => {
          const errors = {};
          if (!values.username) {
            errors.username = 'Required';
          }
          if (!values.password) {
            errors.password = 'Required';
          }
          return errors;
        }}
        onSubmit={(values, { setSubmitting }) => {
          dispatch(loginAsync(JSON.stringify({ user: { ...values } })));
        
            setSubmitting(false);
        }}
      >
        {({ isSubmitting }) => (
          <Form style={{display:'flex',flexDirection:'column',width:'75%' ,margin:'auto'}}>
            <Field type="text" name="username" />
            <ErrorMessage name="username" component="div" />
            <Field type="password" name="password" />
            <ErrorMessage name="password" component="div" />
            <button type="submit" disabled={isSubmitting}>
              Submit
            </button>
          </Form>
        )}
      </Formik>
      <h3 style={{ color: 'gray', fontWeight: 'lighter' }}>test:test can be used for demo purposes</h3>
      <ToastContainer autoClose={2000} />
    </div>
    
  )
}
