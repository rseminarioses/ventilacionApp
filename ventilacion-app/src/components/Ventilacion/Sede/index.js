import React from 'react'
import { useForm } from '../../../hooks/useForm'
import { Grid } from '@material-ui/core'
import SedeForm from './SedeForm';

const getFreshModelObject = () => ({  
  sedeId: 0,  
  nombre: "",  
})

export default function Sede() {  

  const {
    values,
    setValues,
    errors,
    setErrors,
    handleInputChange,
    resetFormControls
  } = useForm(getFreshModelObject);

  return (
    <Grid >
      <Grid item xs={12}>
        <SedeForm
          {...{
            values,
            setValues,
            errors,
            setErrors,
            handleInputChange,
            resetFormControls
          }}
        />        
      </Grid>      
    </Grid>
  )
}