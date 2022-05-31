import { gql, useQuery } from "@apollo/client";
import { Columns, Table } from "react-bulma-components";

const BIKE_DETAIL_QUERY = gql`
  query GET_NOTES($id: String!) {
    bikeById(id: $id) {
      bikeId
      android
      ios
      lat
      lon
      totalBookings
      isDisabled
      isReserved
      vehicleType
    }
  }
`;

export default function BikeDetail({ id }) {
  const { data, loading, error } = useQuery(BIKE_DETAIL_QUERY, {
    variables: { id: id },
  });

  if (loading) return <div>Loading</div>;

  if (error) {
    return (
      <>
        <div>{error.message}</div>
      </>
    );
  }

  if (!data || !data.bikeById) {
    return (
      <>
        <div>Data can not load.</div>
      </>
    );
  }

  return (
    <>
      <Columns>
        <Columns.Column>
          <Table width={"100%"}>
            <tbody>
              <tr>
                <td>BikeId</td>
                <td>{data.bikeById.bikeId}</td>
              </tr>
              <tr>
                <td>Android</td>
                <td>
                  <a href={data.bikeById.android}>{data.bikeById.android}</a>
                </td>
              </tr>
              <tr>
                <td>Ios</td>
                <td>
                  <a href={data.bikeById.ios}>{data.bikeById.ios}</a>
                </td>
              </tr>
              <tr>
                <td>Lat</td>
                <td>{data.bikeById.ios}</td>
              </tr>
              <tr>
                <td>Lon</td>
                <td>{data.bikeById.lon}</td>
              </tr>
              <tr>
                <td>Disabled</td>
                <td>{data.bikeById.isDisabled}</td>
              </tr>
              <tr>
                <td>Reserved</td>
                <td>{data.bikeById.isReserved}</td>
              </tr>
              <tr>
                <td>Type</td>
                <td>{data.bikeById.vehicleType}</td>
              </tr>
              <tr>
                <td>Total Bookings</td>
                <td>{data.bikeById.totalBookings}</td>
              </tr>
            </tbody>
          </Table>
        </Columns.Column>
      </Columns>
    </>
  );
}
