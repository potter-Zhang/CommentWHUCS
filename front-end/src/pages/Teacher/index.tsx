// import React from 'react'
import React, { useState, useEffect, useRef } from 'react'
import { NavLink } from 'react-router-dom'
import { Layout, Space, Input, Form, Avatar, Radio } from 'antd'
import HeaderComponent from 'src/component/header'
import axios from 'axios'
const defaultImg = require('srcImg/default.png')

const { Content } = Layout

const { Search } = Input

const Teacher: React.FC = () => {
  const baseUrl = 'http://localhost:8090/api'
  const [form] = Form.useForm();
  const [myList, setMyList]: any = useState([]);
  const [title, setTitle] = useState("");
  const [searchTxt, setSearchTxt] = useState('');
  const onSearch = (value: string) => {
    setSearchTxt(value);
  }
  const isInitialRender = useRef(true);
  useEffect(() => {
    if (isInitialRender.current) {
      isInitialRender.current = false;
      return;
    }
    const searchApi = baseUrl + '/TeachersSearch?'
                      + "name=" + searchTxt
                      + "&title=" + title;
    axios.get(searchApi)
    .then(response => {
      const teachers = response.data;    
      setMyList(teachers)
    })
    .catch(error => {
      console.error(error);
    });
  },[searchTxt, title])
  const handleTitle = (e:any) =>{
    console.log(e.target.value);
    const tmp = e.target.value;
    switch(tmp){
      case 'a':
        console.log('教授');
        setTitle('教授')
        break;
      case 'b':
        console.log('讲师');
        setTitle('讲师')
        break;
      case 'c':
        console.log('研究员');
        setTitle('研究员')
        break;
      case 'd':
        console.log('工程师');
        setTitle('工程师')
        break;
      case 'e':
        console.log('博士后');
        setTitle('博士后')
        break;
      default:
        console.log("没有选择职称！")
        break;
    }
  }
  return (
    <Space direction="vertical" style={{ width: '100%' }} size={[0, 48]}>
      <Layout>
        <HeaderComponent />
        <Content className='content' style={{overflowY: 'scroll'}}>
          <div className="search">
            <Search placeholder="请输入教师关键词" enterButton style={{ width: 500 }} onSearch={onSearch} />
          </div>
          <div className="filter">
            <Form
              form={form}
            >
              <Form.Item name="radio-group" label="职称">
                <Radio.Group onChange={handleTitle}>
                  <Radio value="a">教授</Radio>
                  <Radio value="b">讲师</Radio>
                  <Radio value="c">研究员</Radio>
                  <Radio value="d">工程师</Radio>
                  <Radio value="e">博士后</Radio>
                </Radio.Group>
              </Form.Item>
            </Form>
          </div>
          <div className="list">
            {myList.map((l:any) => (
              <NavLink to = {`/teacher-detail/${l.name}/${l.title}`} className="list-item" key={l.teacherId}>
                {/* <Avatar shape="square" size={240} src={defaultImg} /> */}
                <Avatar shape = "square" style={{ width: 240, height: 340 }} size={400} src={require('../../img/' + l.name + '.jpg')} />
                <p>{l.name}</p>
              </NavLink>
            ))}
          </div>
        </Content>
      </Layout>
    </Space>
  )
}

export default Teacher
