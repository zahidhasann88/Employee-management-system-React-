import React from "react";
import { Button, Card, Form } from "react-bootstrap";

const SignUp = () => {
  return (
    <div className="container text-center">
      <h1>Create Employee Account</h1>
      <Form style={{
          textAlign: "left",
      }}>
            <Form.Group className="mb-3" controlId="formBasicEmail">
              <Form.Label className="text-left">Email address</Form.Label>
              <Form.Control type="email" placeholder="Enter email" />
            </Form.Group>

            <Form.Group className="mb-3" controlId="formBasicPassword">
              <Form.Label>Password</Form.Label>
              <Form.Control type="password" placeholder="Password" />
            </Form.Group>
            <Button variant="primary" type="submit">
              SignUp
            </Button>
          </Form>
    </div>
  );
};

export default SignUp;
