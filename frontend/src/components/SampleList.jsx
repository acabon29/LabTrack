
const SampleList = ({ samples }) => {
  return (
    <section className="panel">
      <div className="panel-header">
        <p className="panel-kicker">Liste</p>
      </div>

      <div className="sample-list">
        {samples.map((sample) => (
          <article className="sample-card" key={sample.id}>
            <div className="sample-card-row">
              <span className="sample-label">Reference</span>
              <strong>{sample.reference}</strong>
            </div>

            <div className="sample-card-row">
              <span className="sample-label">ClientName</span>
              <strong>{sample.clientName}</strong>
            </div>

            <div className="sample-card-row">
              <span className="sample-label">ReceivedAt</span>
              <span>{sample.receivedAt}</span>
            </div>

            <div className="sample-card-row">
              <span className="sample-label">Status</span>
              <span className="status-pill">{sample.status}</span>
            </div>
          </article>
        ))}
      </div>
    </section>
  );
}

export default SampleList;