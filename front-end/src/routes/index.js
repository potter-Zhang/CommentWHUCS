import React from 'react'
import {
  HashRouter,
  Routes,
  Route,
  Navigate
} from 'react-router-dom'

import Login from 'srcPages/Login'
import Register from 'srcPages/Register'
import Home from 'srcPages/Home'
import Teacher from 'srcPages/Teacher'
import Competition from 'srcPages/Competition'
import Research from 'srcPages/Research'
import TeacherDetail from 'srcPages/TeacherDetail'
import CompetitionDetail from 'srcPages/CompetitionDetail'
// import ResearchDetail from 'srcPages/ResearchDetail'

const RoutesApp = () => (
  <HashRouter>
    <Routes>
      <Route exact path='*' element={<Navigate to='/login' replace />} />
      <Route path='login' element={<Login />} />
      <Route path='register' element={<Register />} />
      <Route path='home' element={<Home />} />
      <Route path='teacher' element={<Teacher />} />
      <Route path='competition' element={<Competition />} />
      <Route path='research' element={<Research />} />
      <Route path='teacher-detail/:pname/:ptitle' element={<TeacherDetail />} />
      <Route path='competition-detail/:pid/:pname' element={<CompetitionDetail />} />
      {/* <Route path='research-detail/:pid/:pname' element={<ResearchDetail />} /> */}
    </Routes>
  </HashRouter>
)

const App = () => (
  <RoutesApp />
)

export default App
