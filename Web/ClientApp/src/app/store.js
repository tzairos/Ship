import { configureStore } from '@reduxjs/toolkit'
import shipReducer from '../features/ship/shipSlice'
import userReducer from '../features/user/userSlice'
export const store = configureStore({
  reducer:
  {
    ship: shipReducer,
    user: userReducer
  },
})