import React from 'react'
import { useForm } from '../../../hooks/useForm'
import { Grid } from '@material-ui/core'
import RegistroForm from './RegistroForm'


const getFreshModelObject = () => ({  
  sedeId: 0,
  habitacionId: 0,  
  orificioId: 0,
  fecha: "",
})

export default function Registro() {  

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
        <RegistroForm
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