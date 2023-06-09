import React, { useState, useEffect } from 'react'
import { useParams } from 'react-router-dom';
// import React, { useState } from 'react'
import axios from 'axios'
import { Layout, Space, Input, Button, Avatar, Col, Row, Rate, Radio, Form, Modal, List } from 'antd'
import HeaderComponent from 'src/component/header'
import { LikeOutlined, MessageOutlined } from '@ant-design/icons'
import type { RadioChangeEvent } from 'antd';
import 'srcCss/info.less'
import internal from 'stream';
const defaultImg = require('srcImg/default.png')

const { Content } = Layout
const { TextArea } = Input


const IconText = ({ icon, text }: { icon: React.FC; text: string }) => (
  <Space>
    {React.createElement(icon)}
    {text}
  </Space>
);

const TeacherDetail: React.FC = () => {
  const [form] = Form.useForm();
  const [isModalOpen, setIsModalOpen] = useState(false);
  // 要与占位符名称一致
  const { pname, ptitle } = useParams();

  const types = [
    ['给分情况', '授课质量', '课后任务', '课下交流'],
    ['学术水平', '经费支持', '资源人脉', '个人性格'],
    ['带队经验', '资源人脉', '经费支持', '教学能力'],
  ]

  const [stars,setStars] = useState([0,0,0,0]);
  const [text, setText] = useState('');
  const showModal = () => {
    // 打开该框，进行星级评价和文字评价
    setIsModalOpen(true);
    setStars([0,0,0,0]);
    setText('');
    setCommitApi('');
  };
  const commitStar = (val:number,index:number) =>{
    console.log(val);
    console.log(index);
    const tmp = [...stars];
    tmp[index] = val;
    setStars(tmp);
    console.log(stars);
  }
  const handleText = (e:any) => {
    console.log(e.target.value);
    setText(e.target.value);
  }
  const [commitApi, setCommitApi] = useState('');
  const handleOk = () => {
    setIsModalOpen(false);
    // 这里把用户的星级和文字评论信息用post传到数据库。
    const userId = 'Administrator';
    const baseUrl = 'http://localhost:8090/api/TeacherInfo/'
    console.log(stars);
    // 设置星级提交Api
    switch(value){
      case 0:
        setCommitApi(baseUrl + 'teachstars/' 
                             + '?teacherId=' + teacherId
                             + '&userId=' + userId
                             + '&scoreStar=' + stars[0]
                             + '&teachingStar=' + stars[1]
                             + '&taskStar=' + stars[2]
                             + '&commStar=' + stars[3]);
        break;
      case 1:
        setCommitApi(baseUrl + 'compstars/' 
                             + '?teacherId=' + teacherId
                             + '&userId=' + userId
                             + '&expStar=' + stars[0]
                             + '&fundsStar=' + stars[1]
                             + '&resStar=' + stars[2]
                             + '&teachingStar=' + stars[3]);
        break;
      case 2:
        setCommitApi(baseUrl + 'RSRCHstars/' 
                             + '?teacherId=' + teacherId
                             + '&userId=' + userId
                             + '&acStar=' + stars[0]
                             + '&fundsStar=' + stars[1]
                             + '&resStar=' + stars[2]
                             + '&charStar=' + stars[3]);
        break;
      default:
        break;
    }
    // 设置文字内容提交api
    const commitTextApi = baseUrl + 'comment'
                          + '?teacherId=' + teacherId
                          + '&userId=' + userId
                          + '&commentType=' + value
                          + '&content=' +  text;
    axios.post(commitTextApi)
    .then(res =>{
      console.log(res.data);
    })
    .catch(error => {
      console.error(error);
    })
  };
  // commitApi改变后，触发提交星级
  useEffect(() =>{
    if(commitApi != '')
    {
      console.log(commitApi)
      axios.post(commitApi)
      .then(res => {
        console.log(res.data);
      })
      .catch(error => {
        console.error(error);
      })
    }    
  },[commitApi])

  const handleCancel = () => {
    setIsModalOpen(false);
  };

  const [value, setValue] = useState(0); // 教学/竞赛/科研

  const [rates, setRates] = useState(types[value]);

  const handleTypeChange = (e: RadioChangeEvent) => {
    //console.log(e.target.value);//0 1 2分别代表教学/竞赛/科研
    setValue(e.target.value);
    setRates(types[Number(e.target.value)]) // 将对应的四个维度的名称传给Rates
  };
  const [teacherId, setTeacherId] = useState('')
  const [gender, setGender] = useState('')
  const [email, setEmail] = useState('')
  const [resFields, setResFields] = useState('')
  const [dblpLink, setDblpLink] = useState('')

  const [teachStars, setTeachStars] = useState(0);
  const [compStars, setCompStars] = useState(0);
  const [researchStars, setResearchStars] = useState(0);
  useEffect(() => {
    const baseUrl = 'http://localhost:8090/api';
    const infoApi = baseUrl + '/TeachersSearch?'
                    + "name=" + pname 
                    + "&title=" + ptitle
    axios.get(infoApi)
    .then(res =>{
      //console.log(res.data)
      //setTeacher(res.data)
      setTeacherId(res.data[0].teacherId);
      setGender(res.data[0].gender);
      setEmail(res.data[0].email);
      setResFields(res.data[0].resFields);
      setDblpLink(res.data[0].dblpLink);      
    })
    .catch(error => {
      console.error(error);
    });
  }, []); 

  useEffect(()=>{
    // 根据老师Id，拿到老师的星级数据
    if(teacherId == '') return;
    console.log(teacherId)
    const baseUrl = 'http://localhost:8090/api';
    const teachApi = baseUrl + '/TeacherInfo/teachstars?teacherId=' + teacherId;
    axios.get(teachApi)
    .then(res =>{
      console.log(res.data);
      setTeachStars(Math.round(res.data.totalStar));
    })
    .catch(error =>{
      console.error(error);
    })

    const compApi = baseUrl + '/TeacherInfo/compstars?teacherId=' + teacherId;
    axios.get(compApi)
    .then(res =>{
      console.log(res.data);
      setCompStars(Math.round(res.data.totalStar));
    })
    .catch(error =>{
      console.error(error);
    })

    const researchApi = baseUrl + '/TeacherInfo/RSRCHStars?teacherId=' + teacherId;
    axios.get(researchApi)
    .then(res =>{
      console.log(res.data);
      setResearchStars(Math.round(res.data.totalStar));
    })
    .catch(error =>{
      console.error(error);
    })
    // 在上面，只展示老师三个维度的分别的totalStar
  },[teacherId])
  
  // 排序
  const [sortingType, setSortingType] = useState('comments time')
  const handleSorting = (e:any) =>{
    console.log(e.target.value);
    switch(e.target.value){
      case 'a':
        setSortingType('comments time');
        break;
      case 'b':
        setSortingType('comments like');
        break;
      default:
        break;
    }
  }
  
  // 请求评论数据
  type Comment = {
    commentId: string,
    teacherId: string,
    userId: string,
    time: string,
    commentType: string,
    content: string,
    likeNum: number
  }
  const [comments, setComments] = useState<Comment[]>([]);
  useEffect(() => {
    if(teacherId == '') return;
    // 请求评论数据
    // commentType，直接用0、1、2表示教学/竞赛/科研
    const baseUrl = 'http://localhost:8090/api';
    const commentApi = (`${baseUrl}/TeacherInfo/${sortingType}?teacherId=${teacherId}&commentType=${value}`);
    axios.get(commentApi)
    .then(res => {
      console.log(res.data);
      setComments(res.data);
    })
    .catch(error => {
      console.error(error);
    })
  },[value, sortingType, teacherId])
  
  // 重置comments中被点赞的那个对象
  const resetComments = (index:number, newItem:Comment) => {
    const tmp = [...comments];
    tmp[index] = newItem;
    setComments(tmp); // 这样重新set，页面才会重新渲染
  } 
  // 点赞（把整个对象给返回了）
  const handleLike = (item:any,index:number) =>{
    const baseUrl = 'http://localhost:8090/api';
    console.log(item);
    // 调用接口，给这个对象+1
    const likeApi = baseUrl + '/TeacherInfo/like?commentId=' + item.commentId;
    axios.put(likeApi)
    .then(res => {
      console.log(res);
      resetComments(index,res.data);
    })
    .catch(error =>{
      console.error(error);
    })
  }
  return (
    <Space direction="vertical" style={{ width: '100%' }} size={[0, 48]}>
      <Layout>
        <HeaderComponent />
        <Content className='content' style={{overflowY: 'scroll'}}>
          <Row gutter={16} className='mb24'>
            <Col span={8}>
              {/* <Avatar shape="square" size={240} src={defaultImg} /> */}
              <Avatar shape="square" style={{ width: 240, height: 340 }} size={240} src={require('../../img/' + pname + '.jpg')}/>
              <p></p>
              <p style = {{fontSize:'18px'}}>{pname} </p>
              <p style = {{fontSize:'18px'}}>武汉大学计算机学院 {ptitle}</p>
              <p></p>
            </Col>
            <Col span={8}>
              <div className="detail-info">                
                <div className="info-item">
                <p style = {{fontSize:'18px'}}>基本信息</p>
                    <p></p>
                    <ul>
                    <li>性别：{gender}</li>
                    <p></p>
                    <li>邮箱：{email}</li>
                    <p></p>
                    <li>研究领域：{resFields}</li>
                  </ul>      
              </div>
                <div className="info-item">                
                <p style = {{fontSize:'18px'}}>科研信息</p>
                  <ul>
                    <p></p>
                    <li>DBLP个人主页：<a href={dblpLink}>{dblpLink}</a></li>
                    <p></p>
                  </ul>
                </div>
                <div className="info-item">
                <p style = {{fontSize:'18px'}}>竞赛信息</p>
                  <ul>
                    <p></p>
                    <li>暂无</li>
                    <p></p>
                  </ul>
                </div>
                <div className="info-item">
                <p style = {{fontSize:'18px'}}>评价星级</p>
                  <p style = {{fontSize:'15px'}}>教学星级：<Rate value = {teachStars} disabled/></p>
                  <p style = {{fontSize:'15px'}}>竞赛星级：<Rate value = {compStars} disabled/></p>
                  <p style = {{fontSize:'15px'}}>科研星级：<Rate value = {researchStars} disabled/></p>
                </div>
              </div>
            </Col>
          </Row>
          <Row gutter={16} className='mb24'>
            <Col span={8} offset={8}>
              {/* onChange很重要，是决定哪个维度的 */}
              <Radio.Group optionType="button" onChange={handleTypeChange} value={value}>
                <Space>
                  <Radio value={0}>教学</Radio>
                  <Radio value={1}>竞赛</Radio>
                  <Radio value={2}>科研</Radio>
                </Space>
              </Radio.Group>
            </Col>
          </Row>
          <Row gutter={16} className='mb24'>
            <Col span={8} offset={8}>
            <Form
              form={form}
              layout={'inline'}
            >
              <Form.Item name="filter" label="排序">
                <Radio.Group onChange={handleSorting}>
                  <Radio value="a">时间</Radio>
                  <Radio value="b">点赞</Radio>
                </Radio.Group>
              </Form.Item>
              <Form.Item name="button">
                <Button style={{width: '120px'}} onClick={showModal}>我来评价</Button>
              </Form.Item>
            </Form>
            </Col>
          </Row>
          <Row gutter={16}>
            <Col span={8} offset={8}>
            <List
              itemLayout="vertical"
              size="small"
              // 要在点击排序依据的时候，setData
              dataSource={comments} // 数据源
              // dataSource={data}
              renderItem={(item: any,index:number) => (
                <List.Item
                  // key={item.title}
                  key = {item.userId}
                  actions={[
                    <div onClick={() => handleLike(item,index)}>
                    <IconText icon={LikeOutlined} text={item.likeNum.toString()} key="list-vertical-like-o"/>,
                    </div>  
                  ]}
                >
                  <List.Item.Meta
                    title={item.userId}
                  />
                    <p>{item.content}</p>                
                    <p style={{ textAlign: 'right' }}>{item.time}</p>
                </List.Item>
              )}
            />
            </Col>
          </Row>
          <Modal title="请输入评价" open={isModalOpen} onOk={handleOk} onCancel={handleCancel} okText={'提交'} cancelText={'取消'}>
            <div className="detail-evaluate">
              {rates.map((item:any, index:number) => (
                <div className='rate-item' key={item}>
                  <div className='rate-item__title'>
                    {item}
                  </div>
                  <Rate onChange={rating => commitStar(rating,index)}/>
                </div>
              ))}
              <TextArea
                showCount
                maxLength={200}
                onChange = {handleText}
                style={{ height: 120, marginBottom: 24 }}
                placeholder="请输入评价"
              />
            </div>
          </Modal>
        </Content>
      </Layout>
    </Space>
  )
}

export default TeacherDetail
