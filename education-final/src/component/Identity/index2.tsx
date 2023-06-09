import React, { useState } from 'react'
import { Button, Col, Row } from 'antd';

const Identity: React.FC = () => {
  const [identity, setIdentity] = useState('student');

  const setIdentityFc = (id: string) => {
    if (id === 'student' && identity !== 'student') {
      setIdentity('student')
    } else if (id === 'teacher' && identity !== 'teacher') {
      setIdentity('teacher')
    }
  }
  return (
    <Row gutter={16}>
      <Col span={12}>
        <Button block type={identity === 'student' ? 'primary' : 'default'} onClick={() => setIdentityFc('student')}>学生</Button>
      </Col>
      <Col span={12}>
        <Button block type={identity === 'teacher' ? 'primary' : 'default'} onClick={() => setIdentityFc('teacher')}>教师</Button>
      </Col>
    </Row>
  )
}

export default Identity
