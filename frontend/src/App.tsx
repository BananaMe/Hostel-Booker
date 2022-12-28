import type { Component } from 'solid-js';

import styles from './App.module.css';
import FormHolder from './Components/FormHolder';

const App: Component = () => {
  return (
    <div class={styles.App}>
      <h1>Hostel booker Admin access</h1>
      {/* <TabHolder/> */}
      <FormHolder/>
    </div>
  );
};

export default App;
