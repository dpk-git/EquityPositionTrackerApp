import { useState } from 'react';
import { toast } from 'react-toastify';
import './TransactionForm.css';

export default function TransactionForm({ onSuccess }) {
  const [form, setForm] = useState({
    tradeID: '',
    version: 1,
    securityCode: '',
    quantity: 0,
    actionType: 'INSERT',
    buySell: 'BUY'
  });

  const [loading, setLoading] = useState(false);

  const handleChange = e => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleSubmit = async e => {
    e.preventDefault();
    setLoading(true);
    try {
      const res = await fetch('https://localhost:7022/api/transaction', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(form)
      });

      if (res.ok) {
        toast.success('Transaction submitted successfully!');
        setForm({ tradeID: '', version: 1, securityCode: '', quantity: 0, actionType: 'INSERT', buySell: 'BUY' });
        onSuccess(); // trigger reload
      } else {
        toast.error('Failed to submit transaction.');
      }
    } catch {
      toast.error('Server error.');
    } finally {
      setLoading(false);
    }
  };

  return (
    <form className="transaction-form" onSubmit={handleSubmit}>
      <h2>Submit Transaction</h2>
      <input name="tradeID" placeholder="Trade ID" value={form.tradeID} onChange={handleChange} required />
      <input name="version" type="number" placeholder="Version" value={form.version} onChange={handleChange} required />
      <input name="securityCode" placeholder="Security Code" value={form.securityCode} onChange={handleChange} required />
      <input name="quantity" type="number" placeholder="Quantity" value={form.quantity} onChange={handleChange} required />
      <select name="actionType" value={form.actionType} onChange={handleChange}>
        <option value="INSERT">INSERT</option>
        <option value="UPDATE">UPDATE</option>
        <option value="CANCEL">CANCEL</option>
      </select>
      <select name="buySell" value={form.buySell} onChange={handleChange}>
        <option value="BUY">BUY</option>
        <option value="SELL">SELL</option>
      </select>
      <button type="submit" disabled={loading}>
        {loading ? 'Submitting...' : 'Submit'}
      </button>
    </form>
  );
}