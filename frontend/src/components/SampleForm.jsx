import { useState } from 'react'

const initialFormState = {
  reference: '',
  clientName: '',
}

const SampleForm = ({ onSubmit }) => {
  const [formValues, setFormValues] = useState(initialFormState);

  const handleChange = (event) => {
    const { name, value } = event.target;
    setFormValues((currentValues) => ({
      ...currentValues,
      [name]: value,
    }))
  };

  const handleSubmit = (event) => {
    event.preventDefault()

    if (!formValues.reference.trim() || !formValues.clientName.trim()) {
      return ;
    }

    onSubmit({
      reference: formValues.reference.trim(),
      clientName: formValues.clientName.trim(),
    });

    setFormValues(initialFormState);
  }

  return (
    <section className="panel">
      <div className="panel-header">
        <p className="panel-kicker">Nouveau sample</p>
      </div>

      <form className="sample-form" onSubmit={handleSubmit}>
        <label className="field">
          <span>Reference</span>
          <input
            name="reference"
            type="text"
            value={formValues.reference}
            onChange={handleChange}
          />
        </label>

        <label className="field">
          <span>ClientName</span>
          <input
            name="clientName"
            type="text"
            value={formValues.clientName}
            onChange={handleChange}
          />
        </label>

        <button className="primary-button" type="submit">
          Ajouter le sample
        </button>
      </form>
    </section>
  );
}

export default SampleForm