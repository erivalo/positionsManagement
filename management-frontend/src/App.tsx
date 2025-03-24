import { BrowserRouter as Router, Route, Routes } from 'react-router-dom'

import { Navbar } from './components/Navbar'
import { PostMainPage } from './features/posts/PostMainPage'
import { SinglePostPage } from './features/posts/SinglePostPage'
import { EditPostForm } from './features/posts/EditPostForm'

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
          <Route path="/positions/:positionId" element={<SinglePostPage />} />
          <Route path="/editPosition/:positionId" element={<EditPostForm />} />
        </Routes>
      </div>
    </Router>
  )
}

export default App
