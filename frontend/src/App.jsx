import { useState, useEffect } from 'react'
import './App.css'
import SampleForm from './components/SampleForm'
import SampleList from './components/SampleList'
import axios from "axios";

const initialSamples = [
  {
    id: 1,
    reference: 'LAB-2026-001',
    clientName: 'Clinique Saint-Michel',
    receivedAt: '2026-04-22 09:15',
    status: 'Received',
  },
  {
    id: 2,
    reference: 'LAB-2026-002',
    clientName: 'Centre BioNord',
    receivedAt: '2026-04-22 11:40',
    status: 'In Analysis',
  },
  {
    id: 3,
    reference: 'LAB-2026-003',
    clientName: 'Cabinet Horizon',
    receivedAt: '2026-04-23 08:05',
    status: 'Completed',
  },
];

function App() {
  const [samples, setSamples] = useState(initialSamples)

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
