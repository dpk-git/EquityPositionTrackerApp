import { useEffect, useState } from 'react';

export default function PositionList(props) {
  const [positions, setPositions] = useState([]);

  useEffect(() => {
    if(props.refresh === false) return;
    fetch(`https://localhost:7022/api/positions`)
      .then(res => res.json())
      .then(setPositions);
  }, [props.refresh]);

  return (
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
  );
}