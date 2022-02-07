import React, { useState, useEffect } from 'react'
import Form from "../../../layouts/Form";
import { Grid } from '@material-ui/core';
import { Input, Button, Select } from "../../../controls";
import { createAPIEndpoint, ENDPOINTS } from "../../../api";
import Notification from "../../../layouts/Notification";

export default function OrificioForm(props) {

  const { values, errors, setErrors, handleInputChange, resetFormControls } = props;
  const [notify, setNotify] = useState({ isOpen: false })
  const [habitacionList, setHabitacionList] = useState([]);

  useEffect(() => {
    createAPIEndpoint(ENDPOINTS.HABITACION).fetchAll()
      .then(res => {
        let habitacionList = res.data.map(item => ({
          id: item.habitacionId,
          nombre: item.nombre
        }));
        habitacionList = [{ id: 0, nombre: 'Seleccione' }].concat(habitacionList);
        setHabitacionList(habitacionList);
      })
      .catch(err => console.log(err))
  }, [])

  const validateForm = () => {
    let temp = {};
    temp.habitacionId = values.sedeId != 0 ? "" : "Este campo es requerido";
    temp.nombre = values.nombre ? "" : "Este campo es requerido";
    temp.ancho = values.ancho ? "" : "Este campo es requerido";
    temp.alto = values.alto ? "" : "Este campo es requerido";    
    setErrors({ ...temp });
    return Object.values(temp).every(x => x === "");
  }

  const submitOrificio = e => {
    e.preventDefault();
    if (validateForm()) {
      createAPIEndpoint(ENDPOINTS.ORIFICIO_VENTILACION).create(values)
        .then(res => {
          resetFormControls();
          setNotify({ isOpen: true, message: 'Nueva Orificio Creado' });
        })
        .catch(err => console.log(err));
    }
  }

  return (
    <>
      <Form onSubmit={submitOrificio}>
        <Grid container>
          <Grid item xs={12}>
            <Select
              label="Habitacion"
              name="habitacionId"
              value={values.habitacionId}
              onChange={handleInputChange}
              options={habitacionList}
              error={errors.habitacionId}
            />
          </Grid>
          <Grid item xs={12}>
            <Input
              label="Nombre Orificio"
              name="nombre"
              value={values.nombre}
              onChange={handleInputChange}
              {...(errors.nombre && { error: true, helperText: errors.nombre })}
            />
          </Grid>
          <Grid item xs={12}>
            <Input
              label="Ubicacion"
              name="ubicacion"
              value={values.ubicacion}
              onChange={handleInputChange}
              {...(errors.ubicacion && { error: true, helperText: errors.ubicacion })}
            />
          </Grid>
          <Grid item xs={4}>
            <Input
              label="Ancho"
              name="ancho"
              value={values.ancho}
              onChange={handleInputChange}
              {...(errors.ancho && { error: true, helperText: errors.ancho })}
            />
          </Grid>
          <Grid item xs={4}>
            <Input
              label="Alto"
              name="alto"
              value={values.alto}
              onChange={handleInputChange}
              {...(errors.alto && { error: true, helperText: errors.alto })}
            />
          </Grid>
          <Grid item xs={12}>
            <Button              
              type="submit">
              Agregar Orificio
            </Button>
          </Grid>
        </Grid>
      </Form>
      <Notification
        {...{ notify, setNotify }} />
    </>
  )
}