import React from "react";
import "../node_modules/bootstrap/dist/css/bootstrap.css";
import 'font-awesome/css/font-awesome.min.css';
import "./App.css";
import Navbar from "./components/layout/Navbar";
import Home from "./components/Pages/Home";
import EProfile from "./components/Pages/EProfile";
import {
  BrowserRouter as Router,
  Route,
  Switch,
} from "react-router-dom";
import SignUp from "./components/Pages/SignUp";

function App() {
  return (
    <Router>
      <div className="App">
        <Navbar />
        <Switch>
          <Route exact path="/" component={Home} />
          <Route exact path="/employe-profile" component={EProfile} />
          <Route exact path="/signup" component={SignUp} />
        </Switch>
      </div>
    </Router>
  );
}

export default App;
