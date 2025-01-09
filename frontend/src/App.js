import React, { useEffect } from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Home from './components/home/home';
import './App.css';

function App() {
  useEffect(() => {
    localStorage.removeItem('token'); 
  }, []);
  return (
    <BrowserRouter>
      <div className="App">
        <Routes>
       
          <Route path="/" element={<Home />} />

        </Routes>
      </div>
    </BrowserRouter>
  );
  
}

export default App;
