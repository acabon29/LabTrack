import { useState, useEffect } from 'react'
import './App.css'
import SampleForm from './components/SampleForm'
import SampleList from './components/SampleList'
import axios from "axios";

function App() {
  const [samples, setSamples] = useState([])

  const updateAllSamples = async ({ reference, clientName }) => {
    try {
      const response = await axios.get("http://localhost:5028/api/samples");
      console.log(response);
      setSamples(response.data);

    } catch (error) {
      console.error("Erreur:", error);
    }
  }

  useEffect(() => {
    updateAllSamples();
  }, []);

  const handleAddSample = async ({ reference, clientName }) => {
    try {
      const response = await axios.post("http://localhost:5028/api/samples", {
        reference,
        clientName,
      });
      console.log(response);
      setSamples((currentSamples) => [response.data, ...currentSamples]);

    } catch (error) {
      console.error("Erreur:", error);
    }
  }



  return (
    <main className="app-shell">
      <section className="content-grid">
        <SampleForm onSubmit={handleAddSample} />
        <SampleList samples={samples} />
      </section>
    </main>
  )
}

export default App
