import React, { useState, useEffect } from 'react'
import Form from '../../../layouts/Form'
import { Grid } from '@material-ui/core'
import { Input, Select, Button } from "../../../controls";
import { createAPIEndpoint, ENDPOINTS } from '../../../api'

export default function RegistroForm(props) {

  const { values, setValues, errors, setErrors,
    handleInputChange, resetFormControls } = props;  

  const [sedeList, setSedeList] = useState([]);
  const [habitacionList, setHabitacionList] = useState([]);
  const [orificioVentilacionList, setOrificioVentilacionList] = useState([]);

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

  useEffect(() => {
    createAPIEndpoint(ENDPOINTS.ORIFICIO_VENTILACION).fetchAll()
      .then(res => {
        let orificioVentilacionList = res.data.map(item => ({
          id: item.orificioVentilacionId,
          nombre: item.nombre
        }));
        orificioVentilacionList = [{ id: 0, nombre: 'Seleccione' }].concat(orificioVentilacionList);
        setOrificioVentilacionList(orificioVentilacionList);
      })
      .catch(err => console.log(err))
  }, [])

  return (
    <>
      <Form>
        <Grid container spacing={2}>
          <Grid item xs={4}>
            <Input
              label="Ingrese Fecha"
              name="fecha"
            />
            <Select
              label="Sede"
              name="SedeId"
              onChange={handleInputChange}
              options={sedeList}
            />
            <Select
              label="Habitacion"
              name="HabitacionId"
              onChange={handleInputChange}
              options={habitacionList}
            />
          </Grid>
          <Grid item xs={4}>
            <Select
              label="Orificio Ventilacion"
              name="orificioVentilacionId"
              onChange={handleInputChange}
              options={orificioVentilacionList}
            />
            <Input
              label="Ingrese Valor"
              name="fecha"
            />
            <Button              
              type='submit'
            >
              Agregar
            </Button>
          </Grid>
        </Grid>
      </Form>
    </>
  )
}