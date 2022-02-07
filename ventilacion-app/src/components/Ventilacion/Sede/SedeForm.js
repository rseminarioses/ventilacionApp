import React, { useState, useEffect } from 'react'
import Form from "../../../layouts/Form";
import { Grid } from '@material-ui/core';
import { Input, Button } from "../../../controls";
import { createAPIEndpoint, ENDPOINTS } from "../../../api";
import Notification from "../../../layouts/Notification";

export default function SedeForm(props) {

  const { values, errors, setErrors, handleInputChange, resetFormControls } = props;  
  const [notify, setNotify] = useState({ isOpen: false })

  const validateForm = () => {
    let temp = {};
    temp.nombre = values.nombre ? "" : "Este campo es requerido";
    setErrors({ ...temp });
    return Object.values(temp).every(x => x === "");
  }  

  const submitSede = e => {
    e.preventDefault();
    if (validateForm()) {
      createAPIEndpoint(ENDPOINTS.SEDE).create(values)
        .then(res => {
          resetFormControls();
          setNotify({ isOpen: true, message: 'Nueva Sede Creada.' });
        })
        .catch(err => console.log(err));
    }
  }

  return (
    <>
      <Form onSubmit={submitSede}>
        <Grid container>
          <Grid item xs={12}>
            <Input
              label="Nombre Sede"
              name="nombre"
              value={values.nombre}
              onChange={handleInputChange}
                {...(errors.nombre && { error: true, helperText: errors.nombre })}
            />
          </Grid>
          <Grid item xs={12}>
            <Button              
              type="submit">
              Agregar Sede
            </Button>
          </Grid>
        </Grid>
      </Form>
      <Notification
        {...{ notify, setNotify }} />
    </>
  )

}