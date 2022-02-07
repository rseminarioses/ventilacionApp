import React from 'react'
import { useForm } from '../../../hooks/useForm'
import { Grid } from '@material-ui/core'
import OrificioForm from './OrificioForm'


const getFreshModelObject = () => ({  
  orificioVentilacion: 0,
  habitacionId: 0,  
  nombre: "",
  ubicacion: "",
  ancho: "",
  alto: "",  
})

export default function Orificio() {  

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
        <OrificioForm
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