import React from 'react'
import { NavLink } from 'react-router-dom'
import HeaderComponent from 'src/component/header'
import { Layout, Space, Row, Col } from 'antd'
const defaultImg = require('srcImg/default.png')
const teachImg = require('srcImg/教学.png')
const compImg = require('srcImg/竞赛.png')
const researchImg = require('srcImg/科研.png')

const { Content } = Layout

const Home: React.FC = () => {
  return (
    <Space direction="vertical" style={{ width: '100%' }} size={[0, 48]}>
      <Layout>
        <HeaderComponent />
        <Content className='content'>
          <Row gutter={24}>
            <Col span={8}>
              <NavLink to='/teacher'><img src={teachImg} style={{ width: '100%' }} alt="教师" /></NavLink>
            </Col>
            <Col span={8}>
              <NavLink to='/competition'><img src={compImg} style={{ width: '100%' }} alt="竞赛" /></NavLink>
            </Col>
            <Col span={8}>
              <NavLink to='/research'><img src={researchImg} style={{ width: '100%' }} alt="科研" /></NavLink>
            </Col>
          </Row>
        </Content>
      </Layout>
    </Space>
  )
}

export default Home
