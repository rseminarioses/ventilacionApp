import React, { useState, useEffect } from 'react'
import Form from "../../../layouts/Form";
import { Grid } from '@material-ui/core';
import { Input, Button, Select } from "../../../controls";
import { createAPIEndpoint, ENDPOINTS } from "../../../api";
import Notification from "../../../layouts/Notification";

export default function HabitacionForm(props) {

  const { values, errors, setErrors, handleInputChange, resetFormControls } = props;
  const [notify, setNotify] = useState({ isOpen: false })
  const [sedeList, setSedeList] = useState([]);

  useEffect(() => {
    createAPIEndpoint(ENDPOINTS.SEDE).fetchAll()
      .then(res => {
        let sedeList = res.data.map(item => ({
          id: item.sedeId,
          nombre: item.nombre
        }));
        sedeList = [{ id: 0, nombre: 'Seleccione' }].concat(sedeList);
        setSedeList(sedeList);
      })
      .catch(err => console.log(err))
  }, [])

  const validateForm = () => {
    let temp = {};
    temp.sedeId = values.sedeId != 0 ? "" : "Este campo es requerido";
    temp.nombre = values.nombre ? "" : "Este campo es requerido";
    temp.ancho = values.ancho ? "" : "Este campo es requerido";
    temp.alto = values.alto ? "" : "Este campo es requerido";
    temp.largo = values.largo ? "" : "Este campo es requerido";
    setErrors({ ...temp });
    return Object.values(temp).every(x => x === "");
  }

  const submitHabitacion = e => {
    e.preventDefault();
    if (validateForm()) {
      createAPIEndpoint(ENDPOINTS.HABITACION).create(values)
        .then(res => {
          resetFormControls();
          setNotify({ isOpen: true, message: 'Nueva Habitacion Creada' });
        })
        .catch(err => console.log(err));
    }
  }

  return (
    <>
      <Form onSubmit={submitHabitacion}>
        <Grid container>
          <Grid item xs={12}>
            <Select
              label="Sede"
              name="sedeId"
              value={values.sedeId}
              onChange={handleInputChange}
              options={sedeList}
              error={errors.sedeId}
            />
          </Grid>
          <Grid item xs={12}>
            <Input
              label="Nombre Habitacion"
              name="nombre"
              value={values.nombre}
              onChange={handleInputChange}
              {...(errors.nombre && { error: true, helperText: errors.nombre })}
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
          <Grid item xs={4}>
            <Input
              label="Largo"
              name="largo"
              value={values.largo}
              onChange={handleInputChange}
              {...(errors.largo && { error: true, helperText: errors.largo })}
            />
          </Grid>
          <Grid item xs={12}>
            <Button
              
              type="submit">
              Agregar Habitacion
            </Button>
          </Grid>
        </Grid>
      </Form>
      <Notification
        {...{ notify, setNotify }} />
    </>
  )

}