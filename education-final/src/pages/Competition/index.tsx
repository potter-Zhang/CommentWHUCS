import React, { useState, useEffect, useRef } from 'react'
import { NavLink } from 'react-router-dom'
import { Layout, Space, Input, Image, Form, Radio, Select } from 'antd'
import HeaderComponent from 'src/component/header'
import type { RadioChangeEvent } from 'antd';
import axios from 'axios'
const defaultImg = require('srcImg/竞赛.png')

const { Content } = Layout

const { Search } = Input

const { Option } = Select;

const Competition: React.FC = () => {
  const baseUrl = 'http://localhost:8090/api'
  const [list, setList]: any = useState([]);
  const [form] = Form.useForm();
  const [searchTxt, setSearchTxt] = useState('');
  const onSearch = (value: string) => {
    console.log(value);
    setSearchTxt(value);
  }
  const [firstTypeVal,setFirstTypeVal] = useState(0);
  const [firstType, setFirstType] = useState('');
  const [secondType, setSecondType] = useState('')
  const [bonusType, setBonusType] = useState('')
  const isInitialRender = useRef(true);
  useEffect(() => {
    // 确保初始渲染只执行一次。
    if (isInitialRender.current) {
      isInitialRender.current = false;
      return;
    }
    const compApi = baseUrl + '/CompetitionSearch/comptype?'
                      + "name=" + searchTxt
                      + "&firstType=" + firstType
                      + '&secondType=' + secondType
                      + '&BonusType=' + bonusType;
    console.log(compApi)
    axios.get(compApi)
    .then(response => {
      console.log(response.data);
      const competitions = response.data;
      setList(competitions)
    })
    .catch(error => {
      console.error(error);
    });
    console.log(list)
  },[searchTxt, firstType, secondType, bonusType])
  const Projects = [
    [
      '创新创业类',
      '硬件类',
      '信息安全类',
      '跨学科类',
      '程序设计类',
      '数学建模类'
    ],
    [ '创新创业类',
      '硬件类',
      '信息安全类',
      '跨学科类'
    ],
    [
      '硬件类',
      '程序设计类',
      '信息安全类',
      '数学建模类'
    ]
  ]

  const handleFirstType = (e: RadioChangeEvent) => {
    //setFirstType(e.target.value);
    switch(e.target.value){
      case 0:
        setFirstTypeVal(1)
        setFirstType('项目类')
        break;
      case 1:
        setFirstTypeVal(2)
        setFirstType('非项目类')
        break;
      default:
        break;
    }
  };

  const handleSecondType = (e: any) => {
    console.log(e);
    setSecondType(e);
  };

  const handleBonusType = (e: RadioChangeEvent) => {
    console.log(e.target.value);
    switch(e.target.value){
      case 'a':
        setBonusType('一类')
        break;
      case 'b':
        setBonusType('二类A')
        break;
       case 'c':
        setBonusType('二类B')
        break;
       case 'd':
        setBonusType('二类C')
        break;
       case 'e':
        setBonusType('二类D')
        break;
      default:
        break;
    }
  };
  return (
    <Space direction="vertical" style={{ width: '100%' }} size={[0, 48]}>
      <Layout>
        <HeaderComponent />
        <Content className='content' style={{overflowY: 'scroll'}}>
          <div className="search">
            <Search placeholder="请输入竞赛关键词" enterButton style={{ width: 500 }} onSearch={onSearch} />
          </div>
          <div className="filter">
            <Form
              form={form}
            >
              <Form.Item name="shape" label="竞赛形式">
                <Radio.Group onChange={handleFirstType}>
                  <Radio value={0}>项目类</Radio>
                  <Radio value={1}>非项目类</Radio>
                </Radio.Group>
              </Form.Item>
              <Form.Item
                name="select"
                label="项目子类"
              >
                <Select placeholder="请选择项目子类" style={{ width: '160px' }} onChange={handleSecondType}>
                  {Projects[firstTypeVal].map((i) => (
                    <Option value={i} key={i}>{i}</Option>
                  ))}
                </Select>
              </Form.Item>
              <Form.Item name="grade" label="加分等级">
                <Radio.Group onChange={handleBonusType}>
                  <Radio value="a">一类</Radio>
                  <Radio value="b">二类A</Radio>
                  <Radio value="c">二类B</Radio>
                  <Radio value="d">二类C</Radio>
                  <Radio value="e">二类D</Radio>
                </Radio.Group>
              </Form.Item>
            </Form>
          </div>
          <div className="list">
            {list.map((l:any) => (
              <NavLink to = {`/competition-detail/${l.competitionTypeId}/${l.competitionName}`} className="list-item" key={l.competitionTypeId}>
                {/* <Avatar shape="square" size={240} src={defaultImg} /> */}
                <Image src={require('../../img/' + l.competitionTypeId + '.jpg')} style={{ width: 310, height: 240 }} />
                <p>{l.competitionName}</p>
              </NavLink>
            ))}
          </div>
        </Content>
      </Layout>
    </Space>
  )
}

export default Competition
