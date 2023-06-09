import axios from 'axios';
import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom';
import { Layout, Space, Input, Button, Avatar, Col, Row, Modal } from 'antd'
import HeaderComponent from 'src/component/header'
const defaultImg = require('srcImg/竞赛.png')

const { Content } = Layout
const { TextArea } = Input
const CompetitionDetail: React.FC = () => {
  const baseUrl = 'http://localhost:8090/api';
  const { pid, pname } = useParams();
  const [isAwardOpen, setIsAwardOpen] = useState(false);
  const [isTeamOpen, setIsTeamOpen] = useState(false);

  const [teamDefault, setTeamDefault] = useState('1.团队名称：\n2.团队成员：\n3.团队信息：')
  const [awardDefault, setAwardDefault] = useState('1.指导教师：\n2.获奖年份：\n3.比赛名称(包括届数)： \n4.赛道：\n5.赛区：\n6.奖项：')
  
   // Show
  const [awardList, setAwardList]: any = useState([]);
  const [groupList, setGroupList]: any = useState([]);
  useEffect(() =>{
    const awardApi = baseUrl + '/CompetitionInfo/Award/' + pid;
    axios.get(awardApi)
    .then(res =>{
      console.log(res.data);
      setAwardList(res.data);
    })
    .catch(error =>{
      console.error(error);
    })

    const groupApi = baseUrl + '/CompetitionInfo/Group/' + pid;
    axios.get(groupApi)
    .then(res =>{
      console.log(res.data);
      setGroupList(res.data);
    })
    .catch(error =>{
      console.error(error);
    })
  },[])
  // Change
  const [teamName, setTeamName] = useState('');
  const [participants, setParticipants] = useState('');
  const [textTeam, setTextTeam] = useState('');
  const teamChange = (e: any) => {
    console.log(e.target.value);    

    const tmp = e.target.value;
    setTeamDefault(tmp);
    const lines = tmp.split("\n");
    lines.forEach((line:string) =>{
      console.log(line);
      const [key,value] = line.split("：");
      // console.log(key)
      // console.log(value)
      switch(key){
        case('1.团队名称'):
          setTeamName(value);
          break;
        case('2.团队成员'):
          setParticipants(value);
          break;
        case('3.团队信息'):
          setTextTeam(value);
          break;
        default:
          setTextTeam(textTeam + value)
          break;
      }
    })   
     
  };

  const [myTeacher, setMyTeacher] = useState('');
  const [myYear, setMyYear] = useState('');
  const [mySession, setMySession] = useState('');
  const [myTrack, setMyTrack] = useState('');
  const [myRegion, setMyRegion] = useState('');
  const [myAward, setMyAward] = useState('');
  const awardChange = (e: any) => {
    console.log(e.target.value);    

    const tmp = e.target.value;
    setAwardDefault(tmp);
    const lines = tmp.split("\n");
    lines.forEach((line:string) =>{
      console.log(line);
      const [key,value] = line.split("：");
      switch(key){
        case('1.指导教师'):
          setMyTeacher(value);
          break;
        case('2.获奖年份'):
          setMyYear(value);
          break;
        case('3.比赛名称(包括届数)'):
          setMySession(value);
          break;
        case('4.赛道'):
          setMyTrack(value);
          break;
        case('5.赛区'):
          setMyRegion(value);
          break;
        case('6.奖项'):
          setMyAward(value);
          break;
        default:
          setMyAward(myAward + value)
          break;
      }
    })   
  };
  // Show
  const showAward = () => {
    setIsAwardOpen(true);
  };
  const showTeam = () => {
    setIsTeamOpen(true);
  };

  // Submit
  const handleAwardOk = () => {
    setIsAwardOpen(false);
    // 把贴的获奖信息存入数据库
    const postAward = {
      competitionId:"",
      teacherId:myTeacher,
      competitionTypeId:pid,
      year:myYear,
      session:mySession,
      track:myTrack,
      region:myRegion,
      award:myAward
    }
    const postAwardApi = baseUrl + '/CompetitionInfo/Award'
    // axios.post(postAwardApi,requestConfig)
    axios.post(postAwardApi,postAward)
    .then(res =>{
      console.log(res)
    }).catch(error =>{console.error(error)})
  };

  const handleAwardCancel = () => {
    setIsAwardOpen(false);
  };

  const handleTeamOk = () => {
    setIsTeamOpen(false);
    // 把贴的团队信息存入数据库
    console.log(pid)
    console.log(teamName)
    console.log(participants)
    console.log(textTeam)
    const postTeamApi = baseUrl + '/CompetitionInfo/Group?'
                        + 'CompTypeId=' + pid
                        + '&groupName=' + teamName
                        + '&participants=' + participants
                        + '&text=' + textTeam
    axios.post(postTeamApi)
    .then(res =>{
      console.log(res.data)
    }).catch(error =>{console.error(error)})
  };

  const handleTeamCancel = () => {
    setIsTeamOpen(false);
  };

  return (
    <Space direction="vertical" style={{ width: '100%' }} size={[0, 48]}>
      <Layout>
        <HeaderComponent />
        <Content className='content' style={{overflowY: 'scroll'}}>
          <Row gutter={16} className='mb24'>
            <Col span={8}>
              <Avatar shape="square" size={200} src={require(`srcImg/${pid}.jpg`)} />
              <p></p>
              <p style = {{fontSize:'18px'}}>{pname}</p>
           </Col>           
            <Col span={8}>
              <p style = {{fontSize:'20px'}}>获奖信息</p>
              <Button style={{width: '120px'}} onClick={showAward}>我也获奖</Button>  
              <p></p>
              {/* 此处插入该竞赛下所有往年获奖信息 */}
              <div>
                <ul>
                  {
                    awardList.map((l:any,index:number) =>(
                      <li key = {index}>{l.year} {l.session} {l.track} {l.region} {l.award} （指导教师：{l.teacherId}）</li>
                    ))
                  }
                </ul>
              </div>
            </Col>       
          </Row>
          <Row gutter={16}>
            <Col span={8} offset={8}>
              <div className='mb24'>
              <p style = {{fontSize:'20px'}}>团队信息</p> 
                <Button style={{width: '120px'}} onClick={showTeam}>我要发起团队</Button>
              </div>
              <div>
              
              {groupList.map((l:any, index:number) => (
                <div className='mb24' key={index}>
                  <p>团队{index + 1}</p>
                  <p>团队名称：{l.groupName}</p>
                  <p>团队成员：{l.participants}</p>
                  <p>团队详情：{l.text}</p>
                </div>
              ))}
              </div>
            </Col>
          </Row>
          <Modal title="请输入获奖信息" open={isAwardOpen} onOk={handleAwardOk} onCancel={handleAwardCancel} okText={'提交'} cancelText={'取消'}>
            <TextArea
              value = {awardDefault}
              onChange={awardChange}
              showCount
              maxLength={200}
              style={{ height: 120, marginBottom: 24 }}
              placeholder="请输入获奖信息"
            />
          </Modal>
          <Modal title="请输入团队信息" open={isTeamOpen} onOk={handleTeamOk} onCancel={handleTeamCancel} okText={'提交'} cancelText={'取消'}>
            <TextArea
              value={teamDefault}
              onChange={teamChange}
              showCount
              maxLength={200}
              style={{ height: 120, marginBottom: 24 }}
              placeholder="请输入团队信息"
            />
          </Modal>
        </Content>
      </Layout>
    </Space>
  )
}

export default CompetitionDetail
