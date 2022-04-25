import React, { useState } from 'react'
import { useSelector, useDispatch } from 'react-redux'
import { fetchShipAsync } from '../features/ship/shipSlice'
import ShipForm from './ShipForm'

import { ToastContainer } from "react-toastify";

const renderShipTable = (ships,setSelectedShip,setShowForm) => {
  return (
    <table className='table table-striped' aria-labelledby="tabelLabel">
      <thead>
        <tr>
          <th>Name</th>
          <th>Code</th>
          <th>Width</th>
          <th>Height</th>
          <th></th>
        </tr>
      </thead>
      <tbody>
        {ships.map(ship =>
          <tr key={ship.code}>
            <td>{ship.name}</td>
            <td>{ship.code}</td>
            <td>{ship.width}</td>
            <td>{ship.length}</td>
            <td><button onClick={()=>{setSelectedShip(ship);setShowForm(true)}}>Update</button></td>
          </tr>
        )}
      </tbody>
    </table>
  );
}

export function Ship() {
  const count = useSelector((state) => state.ship.value)
  const weatherData = useSelector((state) => state.ship.weatherData)
  const shipData = useSelector((state) => state.ship.shipData)
  const dispatch = useDispatch()
  const [selectedShip, setSelectedShip] = useState(null);
  const [showForm, setShowForm] = useState(false);
  return (
    <div>
      <div>
        <button
          aria-label="ship"
          onClick={() => dispatch(fetchShipAsync())}
        >
          Fetch Ships
        </button>
      </div>
       <div>
        {
          shipData && renderShipTable(shipData,setSelectedShip,setShowForm)
        }
      </div>
      <div style={{'display':'flex', 'justifyContent':'end'}}>
     <button onClick={()=>{setSelectedShip(null);setShowForm(true)}}>Add</button>
      </div>
      {
        showForm &&
       <ShipForm ship={selectedShip} />
      }
 <ToastContainer autoClose={2000} />
    </div>
  )
}
