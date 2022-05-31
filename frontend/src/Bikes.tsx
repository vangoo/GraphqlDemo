import {
  Button,
  Columns,
  Form,
  Heading,
  Media,
  Modal,
  Table,
} from "react-bulma-components";
import { gql, useQuery } from "@apollo/client";
import BikeDetail from "./BikeDetail";
import React, { useState } from "react";

const GET_BIKES = gql`
  query GET_NOTES($id: String, $type: String) {
    bikes(id: $id, type: $type) {
      bikeId
      vehicleType
      totalBookings
    }
  }
`;

let _bikeId: string = "";

let _type: string = "";

let _ttl: number = 1;

export default function Bikes() {
  const { data, loading, error, refetch } = useQuery(GET_BIKES);

  const [_selectedBikeId, setSelectedBikeId] = useState(0);

  if (loading) return <div>Loading</div>;

  if (error) {
    return (
      <>
        <div>{error.message}</div>
      </>
    );
  }

  function getTotalBookings() {
    return data.bikes.reduce(
      (partialSum, a) => partialSum + a.totalBookings,
      0
    );
  }

  return (
    <>
      <Columns>
        <Columns.Column>
          <Form.Field>
            <Form.Label>BikeId</Form.Label>
            <Form.Control>
              <Form.Input
                placeholder="BikeId"
                onChange={(e) => {
                  _bikeId = e.target.value;
                }}
              />
            </Form.Control>
          </Form.Field>
        </Columns.Column>

        <Columns.Column>
          <Form.Field>
            <Form.Label>Select an option</Form.Label>

            <Form.Control>
              <Form.Select
                onChange={(e) => {
                  _type = e.target.value;
                }}
              >
                <option value="All">All</option>
                <option value="Scooter">Scooter</option>
                <option value="Bike">Bike</option>
              </Form.Select>
            </Form.Control>
          </Form.Field>
        </Columns.Column>

        <Columns.Column>
          <Form.Field>
            <Form.Control>
              <Button
                color="dark"
                onClick={async () => {
                  refetch({
                    id: _bikeId,
                    type: _type,
                  });
                }}
              >
                Search
              </Button>
            </Form.Control>
          </Form.Field>
        </Columns.Column>

        <Columns.Column>
          <Form.Label>Will refresh in: {_ttl} seconds</Form.Label>
          <Form.Label>
            Total Bookings of Listed Bikes: {getTotalBookings()}
          </Form.Label>
        </Columns.Column>
      </Columns>

      <Columns>
        <Columns.Column>
          <Heading>Bike List</Heading>
          <Table width={"100%"}>
            <thead>
              <tr>
                <th>
                  <abbr title="Bike Id">Id</abbr>
                </th>
                <th>
                  <abbr title="Vehicle Type">Vehicle Type</abbr>
                </th>
                <th>
                  <abbr title="Show Detail">Detail</abbr>
                </th>
              </tr>
            </thead>
            <tbody>
              {data?.bikes?.map((bike: any) => (
                <tr>
                  <td>{bike.bikeId}</td>
                  <td>{bike.vehicleType}</td>
                  <td>
                    <button onClick={() => setSelectedBikeId(bike.bikeId)}>
                      Show
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </Table>
        </Columns.Column>
      </Columns>

      <Modal show={!!_selectedBikeId} onClose={() => setSelectedBikeId(null)}>
        <Modal.Card>
          <Modal.Card.Header>
            <Modal.Card.Title>Detail</Modal.Card.Title>
          </Modal.Card.Header>
          <Modal.Card.Body>
            <Media>
              <Media.Item>
                <Modal.Content>
                  <BikeDetail id={_selectedBikeId} />
                </Modal.Content>
              </Media.Item>
            </Media>
          </Modal.Card.Body>
        </Modal.Card>
      </Modal>
    </>
  );
}
