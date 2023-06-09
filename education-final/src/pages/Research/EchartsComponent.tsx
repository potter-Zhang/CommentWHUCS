
import React, { useEffect } from 'react';
import { init, EChartsOption } from 'echarts';

const EChartsComponent: React.FC = () => {
  useEffect(() => {
    // 创建图表实例
    const chart = init(document.getElementById('chart-container')!);
    // 设置选项
    const option: EChartsOption = {
        tooltip: {
            trigger: 'item'
          },
          legend: {
            top: '5%',
            left: 'right',
            orient: 'vertical' // 将图例纵向排列
          },
          grid: {
            left: '0%', // 设置左边距为10%
            right: '10%', // 设置右边距为10%
            top: '10%', // 设置上边距为10%
            bottom: '10%', // 设置下边距为10%
            containLabel: true // 将标签包含在内
          },
          color: ['#4682B4', '#87CEEB', '#00BFFF', '#1E90FF', '#4169E1', '#6495ED', '#87CEFA', '#ADD8E6', '#B0E0E6'],
          series: [
            {
              name: 'Access From',
              type: 'pie',
              radius: ['40%', '70%'],
              avoidLabelOverlap: false,
              itemStyle: {
                borderRadius: 10,
                borderColor: '#fff',
                borderWidth: 2
              },
              label: {
                show: false,
                position: 'center'
              },
              emphasis: {
                label: {
                  show: true,
                  fontSize: 30,
                  fontWeight: 'bold'
                }
              },
              labelLine: {
                show: false
              },
              data: [
                { value: 100, name: '人工智能和机器学习' },
                { value: 50, name: '数据挖掘和信息检索' },
                { value: 30, name: '计算机网络和分布式系统' },
                { value: 30, name: '数据库和信息管理' },
                { value: 40, name: '软件工程和编程语言' },
                { value: 10, name: '计算机安全和密码学' },
                { value: 10, name: '计算机图形学和视觉计算' },
                { value: 10, name: '计算机体系结构和操作系统' },
                { value: 5, name: '学科交叉' },
              ]
            }
          ]
    };
    // 渲染图表
    chart.setOption(option);

    // 在组件卸载时销毁图表实例
    return () => {
      chart.dispose();
    };
  }, []);

  return <div id="chart-container" style={{
    width: '700px', // 设置容器宽度
    height: '400px', // 设置容器高度
  }}></div>;
};

export default EChartsComponent;
