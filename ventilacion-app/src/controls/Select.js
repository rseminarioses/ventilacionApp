import React from 'react'
import { FormControl, InputLabel, Select as MuiSelect, MenuItem, FormHelperText } from '@material-ui/core'
import { makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles((theme) => ({
  formControl: {
    //margin: theme.spacing(1),
    minWidth: 200,
  },
}));


export default function Select(props) {
  const { name, label, value, varient, onChange, options, error = null } = props;
  const classes = useStyles();

  return (
    <FormControl
      className={classes.formControl}
      variant={varient || 'outlined'}
      {...(error && { error: true })}>
      <InputLabel>{label}</InputLabel>
      <MuiSelect
        label={label}
        name={name}
        value={value}
        onChange={onChange} >
        {
          options.map(
            item => (<MenuItem key={item.id} value={item.id}>{item.nombre}</MenuItem>)
          )
        }
      </MuiSelect>
      {error && <FormHelperText>{error}</FormHelperText>}
    </FormControl>
  )
}