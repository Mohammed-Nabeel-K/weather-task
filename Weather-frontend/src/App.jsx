import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import WeatherCard from './pages/WeatherCard'
import WeatherTableWithFilter from './pages/WeatherTableWithFilter'

function App() {
  

  return (
    <>
    <WeatherCard/>
    <WeatherTableWithFilter/>
      </>
  )
}

export default App
