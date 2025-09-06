import { useState } from 'react';
import TransactionForm from './components/TransactionForm';
import PositionList from './components/PositionList';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

function App() {
  const [reloadFlag, setReloadFlag] = useState(false);

  const handleReload = () => {
    setReloadFlag(prev => !prev); // toggle to trigger useEffect
  };

  return (
    <>
      <TransactionForm onSuccess={handleReload} />
      <PositionList reloadTrigger={reloadFlag} />
      <ToastContainer />
    </>
  );
}

export default App;