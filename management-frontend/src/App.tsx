import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';

import { Navbar } from './components/Navbar';
import { PostMainPage } from './features/posts/PostMainPage';
import { EditPostForm } from './features/posts/EditPostForm';

function App() {
  return (
    <Router>
      <Navbar />
      <div className="App">
        <Routes>
          <Route
            path="/"
            element={<PostMainPage />}
          ></Route>
          <Route path="/editPosition/:positionId" element={<EditPostForm />} />
        </Routes>
      </div>
    </Router>
  )
}

export default App
