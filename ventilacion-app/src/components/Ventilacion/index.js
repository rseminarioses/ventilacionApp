import React from 'react'
import { Grid, Divider, Paper } from '@material-ui/core'
import Sede from './Sede'
import Habitacion from './Habitacion'
import Orificio from './Orificio'
import Registro from './Registro'

export default function Ventilacion() {

  return (
    <Grid container>
      <Paper>
        <Grid container spacing={2} >
          <Grid item xs={4}>
            <Sede />
            <Divider />
          </Grid>
          <Grid item xs={4}>
            <Habitacion />
            <Divider />
          </Grid>
          <Grid item xs={4}>
            <Orificio />            
          </Grid>
        </Grid>
        <Grid item xs={12} >
          <Divider />
          <Registro />
        </Grid>
      </Paper>
    </Grid >
  )
}