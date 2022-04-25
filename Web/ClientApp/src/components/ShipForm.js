import React from 'react'
import { useSelector, useDispatch } from 'react-redux'
import { loginAsync } from '../features/user/userSlice'
import { addShipAsync,updateShipAsync } from '../features/ship/shipSlice'

import { Formik, Form, Field, ErrorMessage } from 'formik';
import { Label } from 'reactstrap';

const ShipForm = (props)=> {
  const dispatch = useDispatch();
  const {ship}=props;

  return (
    <div className='ship-form' style={{display:'flex',flexDirection:'column',justifyContent:'center', alignItems:'center'}}>
     <h1>Ship</h1>
     <Formik
      style={{display:'flex',flexDirection:'column',width:'75%' ,margin:'auto'}}
      initialValues={ship ? ship : {}}
      enableReinitialize 

       validate={values => {
         const errors = {};
         if (!values.name) {
           errors.name = 'Required';
         } 
         if (!values.code) {
            errors.code = 'Required';
          } 
          if (!values.length) {
            errors.length = 'Required';
          } 
          if (!values.width) {
            errors.width = 'Required';
          } 
         return errors;
       }}
       onSubmit={(values, { setSubmitting }) => {
         if(ship){
          dispatch(updateShipAsync(JSON.stringify({id:ship.id,ship:{...values}})));
         }
         else{
          dispatch(addShipAsync(JSON.stringify({test:'abc',ship:{...values}})));
         }
           
       
           setSubmitting(false);
       }}
     >
       {({ isSubmitting }) => (
         <Form>
           <Label for="name">Name</Label>
           <Field type="text" name="name"  />
           <ErrorMessage name="name" component="div" />
           <Label for="name">Code</Label>
           <Field type="text" name="code" />
           <ErrorMessage name="length" component="div"  />
           <Label for="name">Length</Label>
           <Field type="text" name="length" />
           <ErrorMessage name="username" component="div" />
           <Label for="name">Width</Label>
           <Field type="text" name="width"  />
           <ErrorMessage name="width" component="div" />
           <button className='btn' type="submit" disabled={isSubmitting}>
             {ship ? 'Update' : 'Add'}
           </button>
         </Form>
       )}
     </Formik>
   </div>
  )
}


export default ShipForm;