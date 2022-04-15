import React, { useState, useEffect, Fragment } from "react";
import axios from "axios";
//import { Link } from "react-router-dom";
import { Table, Button, Modal, Form } from "react-bootstrap";
//import { clear } from "@testing-library/user-event/dist/clear";

const Home = () => {
  const [show, setShow] = useState(false);

  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  const [Emp_name, setEmp_name] = useState("");
  const [Dep_name, setDep_name] = useState("");
  const [Phone_number, setPhone_number] = useState("");
  const [Email, setEmail] = useState("");
  const [Address, setAddress] = useState("");
  const [Birthdate, setBirthdate] = useState("");
  const [Remarks, setRemarks] = useState("");
  const [Employees, setEmployees] = useState([]);

  const url = "https://localhost:44324";

  const handleSubmit = (e) => {
    //alert("Employee Added Successfully");

    const data = {
      Emp_name: Emp_name,
      Dep_name: Dep_name,
      Phone_number: Phone_number,
      Email: Email,
      Address: Address,
      Birthdate: Birthdate,
      Remarks: Remarks,
    };
    axios
      .post(`${url}/api/Employees/CreateEmployee`, data)
      .then((json) => {
        clear();
      })
      .catch((err) => {
        console.log(err);
      });
  };
  const getEmployees = () => {
    axios
      .get(`${url}/api/Employees`)
      .then((json) => {
       // console.log(json.data.payload);
        setEmployees(json.data.payload);
      })
      .catch((err) => {
        console.log(err);
      });
  };

  useEffect(() => {
    getEmployees();
  });

  const handleDelete = (id) => {
    const data = {
      Id: id
    };
    axios
      .post(`${url}/api/Employees/DeleteEmployee`, data)
      .then((json) => {
        clear();
      })
      .catch((err) => {
        console.log(err);
      });

  }

  const handleEdit = (id) => {

  }
  const clear = () => {
    setEmp_name("");
    setDep_name("");
    setPhone_number("");
    setEmail("");
    setAddress("");
    setBirthdate("");
    setRemarks("");
  };
  return (
    <div className="container">
      <>
        <br></br>
        <Button variant="primary" onClick={handleShow}>
          Add Employee
        </Button>

        <Modal show={show} onHide={handleClose}>
          <Modal.Header closeButton>
            <Modal.Title>Add Employee</Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <Fragment>
              <Form>
                <Form.Group
                  className="mb-3"
                  controlId="exampleForm.ControlInput1"
                >
                  <Form.Label>Name</Form.Label>
                  <Form.Control
                    type="text"
                    placeholder="Employee Name"
                    value={Emp_name}
                    onChange={(e) => setEmp_name(e.target.value)}
                    autoFocus
                  />
                </Form.Group>
                <Form.Group
                  className="mb-3"
                  controlId="exampleForm.ControlInput1"
                >
                  <Form.Label>Department</Form.Label>
                  <Form.Control
                    type="text"
                    value={Dep_name}
                    onChange={(e) => setDep_name(e.target.value)}
                    placeholder="Employee Department Name"
                    autoFocus
                  />
                </Form.Group>
                <Form.Group
                  className="mb-3"
                  controlId="exampleForm.ControlInput1"
                >
                  <Form.Label>Phone Number</Form.Label>
                  <Form.Control
                    type="number"
                    value={Phone_number}
                    onChange={(e) => setPhone_number(e.target.value)}
                    placeholder="Employee Mobile No"
                    autoFocus
                  />
                </Form.Group>
                <Form.Group
                  className="mb-3"
                  controlId="exampleForm.ControlInput1"
                >
                  <Form.Label>Email</Form.Label>
                  <Form.Control
                    type="email"
                    value={Email}
                    onChange={(e) => setEmail(e.target.value)}
                    placeholder="Employee Email"
                    autoFocus
                  />
                </Form.Group>
                <Form.Group
                  className="mb-3"
                  controlId="exampleForm.ControlInput1"
                >
                  <Form.Label>Address</Form.Label>
                  <Form.Control
                    type="text"
                    value={Address}
                    onChange={(e) => setAddress(e.target.value)}
                    placeholder="Employee Address"
                    autoFocus
                  />
                </Form.Group>
                <Form.Group
                  className="mb-3"
                  controlId="exampleForm.ControlInput1"
                >
                  <Form.Label>Birthdate</Form.Label>
                  <Form.Control
                    type="date"
                    value={Birthdate}
                    onChange={(e) => setBirthdate(e.target.value)}
                    placeholder="Employee Birthdate"
                    autoFocus
                  />
                </Form.Group>
                <Form.Group
                  className="mb-3"
                  controlId="exampleForm.ControlInput1"
                >
                  <Form.Label>Remarks</Form.Label>
                  <Form.Control
                    type="text"
                    value={Remarks}
                    onChange={(e) => setRemarks(e.target.value)}
                    placeholder="Remarks"
                    autoFocus
                  />
                </Form.Group>
              </Form>
            </Fragment>
          </Modal.Body>
          <Modal.Footer>
            <Button variant="secondary" onClick={handleClose}>
              Close
            </Button>
            <Button variant="primary" onClick={(e) => handleSubmit(e)}>
              Submit
            </Button>
          </Modal.Footer>
        </Modal>
      </>
      <br></br>
      <Table striped bordered hover size="sm">
        <thead>
          <tr>
            <th>#</th>
            <th>Name</th>
            <th>Department Name</th>
            <th>Phone Number</th>
            <th>Email</th>
            <th>Address</th>
            <th>Birthdate</th>
            <th>Remarks</th>
            <th className="text-center">Action</th>
          </tr>
        </thead>
        <tbody>
          {
            Employees &&
            Employees.map((employee, index) => {
              return (
                <tr key={index}>
                  <td>{index + 1}</td>
                  <td>{employee.emp_name}</td>
                  <td>{employee.dep_name}</td>
                  <td>{employee.phone_number}</td>
                  <td>{employee.email}</td>
                  <td>{employee.address}</td>
                  <td>{employee.birthdate}</td>
                  <td>{employee.remarks}</td>

                  <td className="text-center">
                   
                      <Button variant="primary" onClick={() => handleEdit(employee.id)}>
                        <i
                          className="fa fa-pencil-square-o"
                          aria-hidden="true"
                        ></i>
                      </Button>

                    &nbsp;&nbsp;
                    <Button variant="primary" onClick={() => handleDelete(employee.id)}>
                      <i className="fa fa-trash-o"></i>
                    </Button>
                  </td>
                </tr>
              );
            })}
        </tbody>
      </Table>
    </div>
  );
};

export default Home;
