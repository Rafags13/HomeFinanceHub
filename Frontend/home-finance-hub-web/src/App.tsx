import "./App.css";
import { Providers } from "./app/provider";
import Router from "./app/router";

function App() {
  return (
    <Providers>
      <Router />
    </Providers>
  );
}

export default App;
