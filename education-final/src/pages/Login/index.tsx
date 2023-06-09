import React,{useState,useEffect} from 'react'
import { NavLink, useNavigate } from 'react-router-dom'
import { Button, Form, Input } from 'antd';
// import Identity from 'src/component/Identity'
import 'srcCss/log.less'
import axios from 'axios'

const Login: React.FC = () => {
  const baseUrl = 'http://localhost:8090/api';
  const [form] = Form.useForm();
  const navigate = useNavigate()
  const [loginError, setLoginError] = useState('')
  const [requestBody, setRequestBody] = useState({userId:'',nickName:'',email:'',password:'',userType:false})

  const goHome = () => {
    navigate('/home')
  }

  const onFinish = (value: any) => {
    console.log(value)
    const loginApi = baseUrl + '/LogOn'
                    + '?input=' + value.userInput
                    + '&password=' + value.password;
    console.log(loginApi)
    axios.get(loginApi)
        .then(response => {
          console.log(response.data);
          const tmp = response.data
          setRequestBody({userId:tmp.userId,nickName:tmp.nickName,email:tmp.email,password:tmp.password,userType:tmp.userType})
          const sessionApi = baseUrl + '/Session'
          axios.post(sessionApi,requestBody/*,{withCredentials: true}*/)
          .then(resSession =>{
            console.log(resSession)
          }).catch(error =>{console.error(error)})
          goHome()
        })
        .catch(error => {
          console.error(error);
          console.log(error.response.data);
          setLoginError(error.response.data);
        });    
  }

  return (
    <div className="log-wrapper">
      <div className='log-box'>
        <div className="log-title">点评珈</div>
        <div className="log-tip">
          没有账号？<NavLink to='/register'>点此注册</NavLink>
        </div>
        <Form
          layout={'vertical'}
          form={form}
          style={{ maxWidth: 600 }}
          onFinish={onFinish}
        >
          <Form.Item label="用户名或邮箱" name="userInput" rules={[{ required: true, message: '请输入用户名或邮箱！' }]}>
            <Input placeholder="请输入用户名或邮箱" />
          </Form.Item>
          <Form.Item label="密码" name="password" rules={[{ required: true, message: '请输入密码！' }]}>
            <Input.Password placeholder="请输入密码" />
          </Form.Item>
          <Form.Item>
            <Button type="primary" block htmlType="submit">登录</Button>
            <p>{loginError}</p>
          </Form.Item>
        </Form>
      </div>
    </div>
  )
}

export default Login
