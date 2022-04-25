import { createAsyncThunk,createSlice } from '@reduxjs/toolkit'
import { toast } from "react-toastify";
const initialState = {
  user: {},
  isLoggedIn:false
}


export const loginAsync = createAsyncThunk(
    'user/loginAsync',
    async (userJSON, thunkAPI) => {
      const response = await fetch('users/authenticate',{headers:{'content-type':'application/json'},method:"POST", body:userJSON})
      if(response.ok){
        let user= await response.json();
        const { token } = user;
        localStorage.setItem("jwtToken", token);
        return user;
      }
      else{
        throw new Error("Bad response from server");
      }
    }
  )
  
export const userSlice = createSlice({
  name: 'user',
  initialState,
  reducers: {
    
  },
  extraReducers: (builder) => {
    // Add reducers for additional action types here, and handle loading state as needed
    builder.addCase(loginAsync.fulfilled, (state, action) => {
      // Add user to the state array
      state.user=action.payload;
      state.isLoggedIn=true;
    });
    builder.addCase(loginAsync.rejected, (state, action) => {
      // Add user to the state array
      toast.warn("Couldn't logged in!");
      state.isLoggedIn=false;
    });
  },
})

// Action creators are generated for each case reducer function
export default userSlice.reducer