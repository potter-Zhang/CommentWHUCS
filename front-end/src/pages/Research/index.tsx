import React, { useState, useEffect, useRef} from 'react'
import EChartsComponent from './EchartsComponent';
// import { NavLink } from 'react-router-dom'
import { Layout, Space, Input, Avatar, Form, Cascader, Col, Row, Modal, Button, List, Select } from 'antd'
import HeaderComponent from 'src/component/header'
import axios from 'axios'

const { Content } = Layout
const { Option } = Select
const { Search } = Input
const { TextArea } = Input

interface Option {
  value: string | number;
  label: string;
  children?: Option[];
  disableCheckbox?: boolean;
}

const Research: React.FC = () => {
  const baseUrl = 'http://localhost:8090/api'
  // const {pid, pname} = useParams();
  const [list, setList]: any = useState([]);
  const [form] = Form.useForm();
  const [generalDir,setGeneralDir] = useState('');
  const handleGeneralDir = (e:string) => {
    // console.log(e);
    setGeneralDir(e);
  }
  const [isTeamOpen, setIsTeamOpen] = useState(false);

  const [team, setTeam] = useState('1.团队名称：\n2.指导老师：\n3.团队信息：')
  const [teamName, setTeamName] = useState('');
  const [teachers, setTeachers] = useState('');
  const [text, setText] = useState('');
  const [groups, setGroups] = useState<any[]>([]);
  const [typeList, setTypeList] = useState<any[]>([]);
  const [admitGroups, setAdmitGroups] = useState(0);

  const teamChange = (e: any) => {
    setTeam(e.target.value);
    const tmp = e.target.value;
    setTeam(tmp);
    const lines = tmp.split("\n");
    lines.forEach((line:string) =>{
      console.log(line);
      const [key,value] = line.split("：");
      switch(key){
        case('1.团队名称'):
          setTeamName(value);
          break;
        case('2.指导老师'):
          setTeachers(value);
          break;
        case('3.团队信息'):
          setText(value);
          break;
        default:
          setText(text + value)
          break;
      }
    })   
  };
  const getParentChildren = (parentName:any) => {
    const parentOption = options.find(option => option.label === parentName);
    if (parentOption) {
      if(parentOption.children){
        const children = parentOption.children.map(child => child.label);
        return children;
      }
      else {
        return [];
      }
    }
    return [];
  };
  const handleTypeList = ((typeList:any) => {
    let sqlList:any[] = []; // 存入数据库
    const visibleList:any[] = []; // 显示在团队信息中
    typeList.forEach((item:any) => {
      const len = item.length;
      if(len == 1){
        // 说明选择的是大类，而非子类。在数据库中存入它对应的子类信息，在团队信息中显示大类信息。
        const parentName = item[0];
        visibleList.push(parentName);
        const nextList = getParentChildren(parentName);
        sqlList = sqlList.concat(nextList);// 要进行列表拼接，不能用const类型的列表。
      }
      else
      {
        // 说明选择的是子类。在数据库和团队信息中都用第二维子类信息。
        sqlList = sqlList.concat([item[1]]);
        visibleList.push(item[1]);
      }
    })
    return [sqlList, visibleList];
  })
  const addTypes = ((mytext:string,visibleList:any) => {
    let str = mytext + '（团队方向：';
    visibleList.forEach((item:string) => {
      str = str + item + ',';
    })
    str = str.slice(0,-1) + ')';
    return str;
  })
  const handleTeamOk = () => {
    setIsTeamOpen(false);
    const [sqlList,visibleList] = handleTypeList(typeList);
    console.log(typeList)
    console.log(sqlList);
    console.log(visibleList);
    const tmpText = addTypes(text,visibleList);
    console.log(tmpText);
    const groupApi = baseUrl + '/ResearchInfo/Group?'
                      + 'userType=true'
                      + '&RSRCHTypeId=' + '300'
                      + '&groupName=' + teamName
                      + '&teachers=' + teachers
                      + '&text=' + tmpText;
    axios.post(groupApi,sqlList)
    .then(res => {
      console.log(res);
    })
    .catch(error =>{
      console.error(error);
    })
    setAdmitGroups(admitGroups + 1);
  };
  const showTeam = () => {
    setIsTeamOpen(true);
  };
  const handleTeamCancel = () => {
    setIsTeamOpen(false);
  };
  const onChange = (value: any) => {
    // console.log(value);
    setTypeList(value);
  };
  const [searchContent, setSearchContent] = useState('');
  const onSearch = (value: string) => {
    console.log(value);
    setSearchContent(value);
  }
  const researchs = [
    '人工智能和机器学习',
    '数据挖掘和信息检索',
    '计算机网络和分布式系统',
    '数据库和信息管理',
    '软件工程和编程语言',
    '计算机安全和密码学',
    '计算机图形学和视觉计算',
    '计算机体系结构和操作系统',
    '学科交叉',
  ]
  const isInitialRender = useRef(true);

  useEffect(() => {
    // 只要点了搜索，或者下面换了方向，重新发请求。
    // 确保初始渲染只执行一次。
    if (isInitialRender.current) {
      isInitialRender.current = false;
      return;
    }
    console.log(searchContent);
    console.log(generalDir);
    console.log(groups);
    const resApi = baseUrl + '/ResearchTypeSearch?'
                  + 'generalDir=' + generalDir
                  + '&searchText=' + searchContent;
    console.log(generalDir);
    console.log(searchContent);
    console.log(resApi)
    axios.get(resApi)
    .then(res =>{
      console.log(res.data);
      setList(res.data);
    })
    .catch(error => {
      console.error(error);
    })
  },[searchContent, generalDir, admitGroups])
  useEffect(() =>{
    console.log("开始查找团队！");
    let tmpGroups:any[] = [];
    const requests = list.map((item: any) => {
      console.log(item.id);
      const groupApi = baseUrl + '/ResearchInfo/Group/' + item.id;
      // axios请求是异步的。去重只能在所有都完成之后进行。
      return axios.get(groupApi)
        .then(res => {
          //console.log(res.data); // 这个小方向下的所有团队，都在res.data里面
          const tmp = res.data;   
          console.log(tmp);      
          tmpGroups = tmpGroups.concat(tmp); // concat得到新值，要赋值回去。
        })
        .catch(error =>{
          console.error(error);
        })
    })
    Promise.all(requests)
    .then(() => {
      //console.log(tmpGroups);
      // 所有请求已经完成，进行去重和赋值。
      let newGroups:any[] = [];
      tmpGroups.forEach((element:any) => {
        const isDuplicate = newGroups.some((group: any) => group.groupId === element.groupId);
        if(!isDuplicate){
          newGroups.push(element);
        }
      })
      //console.log(newGroups);
      setGroups(newGroups);
    })
  },[list])
  const options: Option[] = [
    {
      value: '人工智能和机器学习',
      label: '人工智能和机器学习',
      children: [
        {
          value: '自然语言处理和文本挖掘',
          label: '自然语言处理和文本挖掘'
        },
        {
          value: '计算机视觉和图像识别',
          label: '计算机视觉和图像识别'
        },
        {
          value: '深度学习和神经网络',
          label: '深度学习和神经网络'
        },
        {
          value: '强化学习和控制问题',
          label: '强化学习和控制问题'
        },
        {
          value: '人工智能的可解释性和公平性问题',
          label: '人工智能的可解释性和公平性问题'
        },
        {
          value: '机器学习模型的优化和泛化能力',
          label: '机器学习模型的优化和泛化能力'
        }
      ]
    },
    {
      value: '数据挖掘和信息检索',
      label: '数据挖掘和信息检索',
      children: [
        {
          value: '大数据处理与分析',
          label: '大数据处理与分析'
        },
        {
          value: '推荐系统与社交网络',
          label: '推荐系统与社交网络'
        },
        {
          value: '高维数据分析和可视化',
          label: '高维数据分析和可视化'
        },
        {
          value: '时间序列数据分析和预测',
          label: '时间序列数据分析和预测'
        },
        {
          value: '图形数据挖掘和知识图谱',
          label: '图形数据挖掘和知识图谱'
        }
      ]
    },
    {
      value: '计算机网络和分布式系统',
      label: '计算机网络和分布式系统',
      children: [
        {
          value: '云计算和边缘计算',
          label: '云计算和边缘计算'
        },
        {
          value: '无线网络和移动计算',
          label: '无线网络和移动计算'
        },
        {
          value: '网络安全和隐私保护',
          label: '网络安全和隐私保护'
        },
        {
          value: '区块链技术和数字货币',
          label: '区块链技术和数字货币'
        },
        {
          value: '物联网和传感器网络',
          label: '物联网和传感器网络'
        },
        {
          value: '分布式数据库和一致性协议',
          label: '分布式数据库和一致性协议'
        }
      ]
    },
    {
      value: '数据库和信息管理',
      label: '数据库和信息管理',
      children: [
        {
          value: '数据库系统和数据模型',
          label: '数据库系统和数据模型'
        },
        {
          value: '数据库查询和优化',
          label: '数据库查询和优化'
        },
        {
          value: '数据库索引和存储结构',
          label: '数据库索引和存储结构'
        },
        {
          value: '数据库备份和恢复',
          label: '数据库备份和恢复'
        },
        {
          value: '数据库安全和隐私保护',
          label: '数据库安全和隐私保护'
        },
        {
          value: '大数据管理和数据仓库',
          label: '大数据管理和数据仓库'
        }
      ]
    },
    {
      value: '软件工程和编程语言',
      label: '软件工程和编程语言',
      children: [
        {
          value: '软件开发方法和模型',
          label: '软件开发方法和模型'
        },
        {
          value: '软件测试和验证',
          label: '软件测试和验证'
        },
        {
          value: '软件架构和设计模式',
          label: '软件架构和设计模式'
        },
        {
          value: '代码分析和重构',
          label: '代码分析和重构'
        },
        {
          value: '混合现实和虚拟现实应用',
          label: '混合现实和虚拟现实应用'
        },
        {
          value: '前端和后端开发技术',
          label: '前端和后端开发技术'
        }
      ]
    },
    {
      value: '计算机安全和密码学',
      label: '计算机安全和密码学',
      children: [
        {
          value: '加密技术和密钥管理',
          label: '加密技术和密钥管理'
        },
        {
          value: '认证和授权机制',
          label: '认证和授权机制'
        },
        {
          value: '网络攻击和防御',
          label: '网络攻击和防御'
        },
        {
          value: '恶意软件和病毒检测',
          label: '恶意软件和病毒检测'
        },
        {
          value: '网络入侵检测和防御',
          label: '网络入侵检测和防御'
        },
        {
          value: '安全漏洞分析和修复',
          label: '安全漏洞分析和修复'
        }
      ]
    },
    {
      value: '计算机图形学和视觉计算',
      label: '计算机图形学和视觉计算',
      children: [
        {
          value: '三维图形和动画技术',
          label: '三维图形和动画技术'
        },
        {
          value: '游戏开发和物理模拟',
          label: '游戏开发和物理模拟'
        },
        {
          value: '计算机视觉和图像处理',
          label: '计算机视觉和图像处理'
        },
        {
          value: '视频编码和压缩技术',
          label: '视频编码和压缩技术'
        },
        {
          value: '视频分析和内容识别',
          label: '视频分析和内容识别'
        },
        {
          value: '虚拟现实和增强现实技术',
          label: '虚拟现实和增强现实技术'
        }
      ]
    },
    {
      value: '计算机体系结构和操作系统',
      label: '计算机体系结构和操作系统',
      children: [
        {
          value: '多核处理器和并行计算',
          label: '多核处理器和并行计算'
        },
        {
          value: '内存层次和缓存管理',
          label: '内存层次和缓存管理'
        },
        {
          value: '操作系统和分布式系统',
          label: '操作系统和分布式系统'
        },
        {
          value: '性能调优和功耗优化',
          label: '性能调优和功耗优化'
        },
        {
          value: '高性能计算和云计算',
          label: '高性能计算和云计算'
        },
        {
          value: '量子计算和量子算法',
          label: '量子计算和量子算法'
        }
      ]
    },
    {
      value: '学科交叉',
      label: '学科交叉',
      children: [
        {
          value: '生物信息学和基因组学',
          label: '生物信息学和基因组学'
        },
        {
          value: '计算机辅助药物设计和虚拟筛选',
          label: '计算机辅助药物设计和虚拟筛选'
        },
        {
          value: '生物计算和生物网络',
          label: '生物计算和生物网络'
        },
        {
          value: '系统生物学和代谢组学',
          label: '系统生物学和代谢组学'
        }
      ]
    }
  ]
  return (
    <Space direction="vertical" style={{ width: '100%' }} size={[0, 48]}>
      <Layout>
        <HeaderComponent />
        <Content className='content' style={{overflowY: 'scroll'}}>
          <div className="search">
            <Search placeholder="请输入科研关键词" enterButton style={{ width: 500 }} onSearch={onSearch} />
          </div>
          <div className="filter mb24">
            <Form
              form={form}
              layout={'inline'}
            >
              <Form.Item
                name="select"
                label="科研分类"
              >
                <Select placeholder="请选择科研分类" style={{ width: '260px' }} onChange={handleGeneralDir}>
                  {researchs.map((i) => (
                    <Option value={i} key={i}>{i}</Option>
                  ))}
                </Select>
              </Form.Item>
              <Form.Item>
                <Button style={{width: '120px'}} onClick={showTeam}>发起团队</Button>
              </Form.Item>
            </Form>
          </div>
          <Row gutter={16} className='mb24'>
            <Col span={12} >
              <div className="detail-info">
                <div className="info-item">科研团队信息：</div>
                <p></p>
                <div className="info-item">   
                  <List
                    itemLayout="vertical"
                    size="small"
                    dataSource={groups} // 数据源
                    renderItem={(item: any,index:number) => (
                      <List.Item>
                        <List.Item.Meta                   
                          title={item.groupName}
                          key = {item.groupId}    
                        />        
                        <p>指导老师：{item.teachers}</p>
                        团队信息：{item.text}
                      </List.Item>                      
                    )}
                  />
                </div>
              </div>
            </Col>
            <Col span={12} >
            <EChartsComponent />
            </Col>
          </Row>
          <Modal title="请输入团队信息" open={isTeamOpen} onOk={handleTeamOk} onCancel={handleTeamCancel} okText={'提交'} cancelText={'取消'}>
            <TextArea
              value={team}
              onChange={teamChange}
              showCount
              maxLength={200}
              style={{ height: 120, marginBottom: 24 }}
              placeholder="请输入团队信息"
            />
            <Form
              form={form}
            >
              <Form.Item
                name="select"
                label="科研分类"
              >
                <Cascader
                  placeholder="请选择科研分类"
                  style={{ width: '100%' }}
                  options={options}
                  onChange={onChange}
                  multiple
                  maxTagCount="responsive"
                />
              </Form.Item>
            </Form>
          </Modal>
        </Content>
      </Layout>
    </Space>    
  )
}

export default Research
