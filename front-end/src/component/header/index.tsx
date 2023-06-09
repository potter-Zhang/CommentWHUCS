import React,{useState,useEffect} from 'react'
import axios from 'axios'
import 'srcCss/info.less'
import { Layout } from 'antd'

const { Header } = Layout


const HeaderComponent: React.FC = () => {
  const getUserApi = 'http://localhost:8090/api/Session/NickName'
  const [currentUser, setCurrentUser] = useState('')
  useEffect(() => {
    // 在组件加载完成后触发事件
    getNickName();
    //console.log("查找昵称！")
  }, []);
  const getNickName = () =>{
    axios.get(getUserApi/*,{withCredentials:true}*/)
    .then(res =>{
      console.log("查找昵称成功！")
      console.log(res)
      setCurrentUser(res.data);
    })
    .catch(error => {
      console.log("查找昵称失败！")
      console.error(error);
    });    
  }
  return (
    <Header className='header'>
      <p className='title'>点评珈——WHUCS交互式一体化信息平台</p>
      <p>{currentUser}</p>
    </Header>
  )
}

export default HeaderComponent
