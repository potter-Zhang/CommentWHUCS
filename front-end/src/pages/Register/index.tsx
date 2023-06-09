import React,{useState,useEffect} from 'react'
import { NavLink, useNavigate } from 'react-router-dom'
import { Button, Form, Input } from 'antd';
import Identity from 'src/component/Identity'
import 'srcCss/log.less'
import axios from 'axios'

const Register: React.FC = () => {
  const baseUrl = 'http://localhost:8090/api'
  const [form] = Form.useForm();
  const navigate = useNavigate()
  const [userType, setUserType] = useState('false')
  const [myEmail, setMyEmail] = useState('')
  const [requestapi, setRequestapi] = useState('http://localhost:8090/api/LogOn/Verification?email=')
  const [inputCaptcha, setInputCaptcha] = useState('')
  const [standardCaptcha, setStandardCaptcha] = useState('')
  const [regError, setRegError] = useState('')

  const goLogin = () => {
    navigate('/login')
  }
 
  const handleUserType = (message = 'false') =>{
    setUserType(message)
  }
  const sendCaptcha = () => {
    console.log("发送验证码！")   
    const newEmail = encodeURIComponent(myEmail)
    setRequestapi(requestapi + newEmail)
  }
  useEffect(() => {
    if (requestapi != 'http://localhost:8090/api/LogOn/Verification?email=') {
      axios.get(requestapi)
        .then(response => {
          console.log(response.data);
          setStandardCaptcha(response.data);
        })
        .catch(error => {
          console.error(error);
        });
    }
  }, [requestapi]);

  const onFinish = (value: any) => {
    console.log(userType)
    console.log(value)
    const regApi = baseUrl + '/LogOn' 
                    + '?nickName=' + value.username
                    + '&email=' + value.email
                    + '&password=' + value.password
                    + '&userType=' + userType
                    + '&verificationCode=' + standardCaptcha
                    + '&inputCode=' + inputCaptcha
    console.log(regApi)
    axios.post(regApi)
        .then(response => {
          console.log(response.data);
          if(response.data == '注册成功')
            goLogin()
        })
        .catch(error => {
          console.error(error);
          console.log(error.response.data);
          setRegError(error.response.data);
        });
  }

  return (
    <div className="log-wrapper">
      <div className='log-box'>
        <div className="log-title">点评珈</div>
        <div className="log-tip">
          已有帐号?<NavLink to='/login'>点此登录</NavLink>
        </div>
        <Form
          layout={'vertical'}
          form={form}
          style={{ maxWidth: 600 }}
          onFinish={onFinish}
        >
          <Form.Item>
            <Identity sendMessage = {handleUserType}/>
          </Form.Item> 
          <Form.Item label="用户名" name="username" rules={[{ required: true, message: '请输入用户名！' }]}>
            <Input placeholder="请输入用户名" />
          </Form.Item>
          <Form.Item label="邮箱" name="email" rules={[{ required: true, message: '请输入邮箱！' }]}>
            <Input placeholder="请输入邮箱" value = {myEmail} onChange={(e) => setMyEmail(e.target.value)}/>
          </Form.Item>
          <Form.Item label="密码" name="password" rules={[{ required: true, message: '请输入密码！' }]}>
            <Input.Password placeholder="请输入密码" />
          </Form.Item>
          <Form.Item label="验证码">
            <div className='captcha-content'>
              <Form.Item
                name="captcha"
                noStyle
                rules={[{ required: true, message: '请输入验证码' }]}
              >
              <Input value = {inputCaptcha} onChange={(e) => setInputCaptcha(e.target.value)}/>
              </Form.Item>
              <Button onClick = {sendCaptcha} >获取验证码</Button>
            </div>
          </Form.Item>
          <Form.Item>
            <Button type="primary" block htmlType="submit">注册</Button>
            <p>{regError}</p>
          </Form.Item>
        </Form>
      </div>
    </div>
  )
}

export default Register
