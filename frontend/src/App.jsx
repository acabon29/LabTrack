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
      setSamples((currentSamples) => [...currentSamples, response.data]);
    } catch (error) {
      console.error("Erreur:", error);
    }
  }

  const handleDeleteSample = async ({ id }) => {
    try {
      const response = await axios.delete(`http://localhost:5028/api/samples/${id}`);
      console.log(response);
      if (response.status == 204) {
        let newSample = samples.slice();
        newSample.splice(samples.findIndex(sample => sample.id == id), 1);
        setSamples((currentSamples) => newSample);
      }
    } catch (error) {
      console.error("Erreur:", error);
    }
  }

  return (
    <main className="app-shell">
      <section className="content-grid">
        <SampleForm onSubmit={handleAddSample} />
        <SampleList samples={samples} onDeleteSample={handleDeleteSample} />
      </section>
    </main>
  )
}

export default App
