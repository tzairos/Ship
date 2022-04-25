import { createAsyncThunk, createSlice } from '@reduxjs/toolkit'
import { toast } from "react-toastify";
const initialState = {
  value: 0,
  weatherData: [],
  shipData: []
}


export const fetchWeatherAsync = createAsyncThunk(
  'ship/fetchWeatherAsync',
  async (userId, thunkAPI) => {
    let token = localStorage.getItem("jwtToken");
    const response = await fetch('weatherforecast', {
      headers: {
        Authorization: `Bearer ${token}`, 'content-type': 'application/json'
      },
    })
    return response.json()
  }
)
export const fetchShipAsync = createAsyncThunk(
  'ship/fetchShipAsync',
  async (userId, thunkAPI) => {
    let token = localStorage.getItem("jwtToken");
    if(token==null){
      return;
    }
    const response = await fetch('ship', {
      headers: {
        Authorization: `Bearer ${token}`
      }
    })
    return response.json()
  }
)
export const addShipAsync = createAsyncThunk(
  'ship/addShipAsync',
  async (shipJSON, thunkAPI) => {
    let token = localStorage.getItem("jwtToken");
    if(token==null){
      return;
    }
    const response = await fetch('ship', {
      headers: {
        Authorization: `Bearer ${token}`,
        'content-type': 'application/json'
      }, method: "POST", body: shipJSON
    })
    if (!response.ok) {
      let responseJSON = await response.json();
      throw new Error(responseJSON?.Message);
    }
  }
)
export const updateShipAsync = createAsyncThunk(
  'user/updateShipAsync',
  async (shipJSON, thunkAPI) => {
    let token = localStorage.getItem("jwtToken");
    if(token==null){
      return;
    }
    const response = await fetch('ship', {
      headers: {
        Authorization: `Bearer ${token}`,
        'content-type': 'application/json'
      }, method: "PUT", body: shipJSON
    })
    if (!response.ok) {
      let responseJSON = await response.json();
      throw new Error(responseJSON?.Message);
    }
   
  }
)
export const shipSlice = createSlice({
  name: 'ship',
  initialState,
  reducers: {
    increment: (state) => {
      state.value += 1
    },
    decrement: (state) => {
      state.value -= 1
    },
    incrementByAmount: (state, action) => {
      state.value += action.payload
    },
  },
  extraReducers: (builder) => {
    // Add reducers for additional action types here, and handle loading state as needed
    builder.addCase(fetchWeatherAsync.fulfilled, (state, action) => {
      // Add user to the state array
      state.weatherData = action.payload;
      toast.success("Success!");
    });
    builder.addCase(fetchShipAsync.fulfilled, (state, action) => {
      // Add user to the state array
      state.shipData = action.payload;
      toast.success("Success!");
    });
    builder.addCase(addShipAsync.fulfilled, (state, action) => {
      // Add user to the state array
      toast.success("Success!");

    });
    builder.addCase(addShipAsync.rejected, (state, action) => {
      // Add user to the state array
      toast.error(action.error?.message);
    });
    builder.addCase(updateShipAsync.fulfilled, (state, action) => {
      // Add user to the state array
      toast.success("Success!");
    });
    builder.addCase(updateShipAsync.rejected, (state, action) => {
      // Add user to the state array
     
      toast.error(action.error?.message);
    });
  },
})

// Action creators are generated for each case reducer function
export const { increment, decrement, incrementByAmount } = shipSlice.actions;
export default shipSlice.reducer