import { Box, Container, Heading, Section } from "react-bulma-components";
import Bikes from "./Bikes";

function App() {
  return (
    <div className="App">
      <Section>
        <Container>
          <Heading>GraphQL Client</Heading>
          <Heading subtitle>
            Kovan Task App
          </Heading>
          <Box>
            <Bikes />
          </Box>
        </Container>
      </Section>
    </div>
  );
}

export default App;
