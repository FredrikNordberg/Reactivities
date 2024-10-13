import { useEffect, useState } from "react";
import "./App.css";
import axios from "axios";
import { Header } from "semantic-ui-react";



function App() {
  const [activities, setActivities] = useState([]);

  // Get the data from API...
  useEffect(() => {
    axios.get("http://localhost:5000/api/activities").then((response) => {
      setActivities(response.data);
    });
  }, []);

  return (
    <div>
      <Header as='h2' icon='users' content='Reactivities' />
      <ul>
        {activities.map((activity: any) => (
          <li key={activity.id}>
            {activity.title}
          </li>
        ))}
      </ul>
    </div>
  );
}

export default App;


