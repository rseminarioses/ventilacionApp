import React from 'react'
import { useForm } from '../../../hooks/useForm'
import { Grid } from '@material-ui/core'
import HabitacionForm from './HabitacionForm'


const getFreshModelObject = () => ({  
  habitacionId: 0,
  sedeId: 0,  
  nombre: "",
  ancho: "",
  alto: "",
  largo: ""
})

export default function Habitacion() {  

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
        <HabitacionForm
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