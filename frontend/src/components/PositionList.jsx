import { useEffect, useState } from 'react';
import './PositionList.css';

export default function PositionList({ reloadTrigger }) {
  const [positions, setPositions] = useState([]);

  useEffect(() => {
    fetch('https://localhost:7022/api/positions')
      .then(res => res.json())
      .then(setPositions);
  }, [reloadTrigger]); // reload when flag changes

  return (
    <div className="position-list">
      <h2>Current Positions</h2>
      <table>
        <thead>
          <tr><th>Security</th><th>Net Quantity</th></tr>
        </thead>
        <tbody>
          {positions.map(pos => (
            <tr key={pos.securityCode}>
              <td>{pos.securityCode}</td>
              <td>{pos.netQuantity}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}