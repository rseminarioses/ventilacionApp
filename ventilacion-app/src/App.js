import './App.css';
import { Container, Typography } from "@material-ui/core"
//import RegistroVentilacion from "./components/RegistroVentilacion"
import VentilacionForm from "./components/Ventilacion"

function App() {
  return (
    <Container maxWidth="md">
      <Typography variant='h3' align='center'>
        Sistema de RAH
      </Typography>
      <VentilacionForm />
    </Container>
  );
}

export default App;
