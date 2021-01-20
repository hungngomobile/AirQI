import React, { useEffect } from "react";
import { Card, Form, Row, Col, Button } from "react-bootstrap";
import { connect } from "react-redux";
import Polygon from "./polygon";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faShapes } from "@fortawesome/free-solid-svg-icons";
import { useForm } from "react-hook-form";

export const Sla = (props: any) => {
  const { register, handleSubmit, errors } = useForm();

  const onSubmit = (data: any) => {
    console.log(data.name);
    console.log(data.max);
    console.log(JSON.stringify(props.items || " "));

    const { dispatch, history } = props;
  };

  useEffect(() => {
    console.log(props.items);
  }, [props.items]);

  return (
    <Card className="mb-3">
      <Card.Body>
        <Card.Title>
          <FontAwesomeIcon icon={faShapes} className="mr-2" /> Edit
        </Card.Title>
        <small className="ml-4 pl-2">Edit SLA</small>

        <Card.Text className="mt-5">
          <Polygon />
          <Form onSubmit={handleSubmit(onSubmit)} className="mt-5">
            <Row>
              <Col>
                <Form.Label>
                  <b>Title</b>
                  <small className="ml-2">( Enter the SLA' name)</small>
                </Form.Label>
                <Form.Control
                  placeholder="Enter name"
                  size="sm"
                  name="name"
                  ref={register({ required: true })}
                />
              </Col>

              <Col>
                <Form.Label>
                  <b className="mr-2">Markers</b>

                  <small>(Max value)</small>
                </Form.Label>
                <Form.Control
                  type="number"
                  name="max"
                  min="0"
                  max="100"
                  size="sm"
                  placeholder="0"
                  ref={register({ required: true })}
                />
              </Col>
            </Row>
            <Row>
              <Col>
                {errors.name && (
                  <small className="text-danger"> This is required</small>
                )}
              </Col>
              <Col>
                {" "}
                {errors.max && (
                  <small className="text-danger"> This is required</small>
                )}
              </Col>
            </Row>
            <Row className="mb-5">
              <Col>
                <Form.Label></Form.Label>
                <Button variant="dark" size="sm" type="submit">
                  Save
                </Button>
              </Col>
              <Col></Col>
            </Row>
          </Form>
        </Card.Text>
      </Card.Body>
    </Card>
  );
};

function mapStateToProps(state: any) {
  const { items } = state.features;
  return {
    items,
  };
}

export default connect(mapStateToProps)(Sla);
