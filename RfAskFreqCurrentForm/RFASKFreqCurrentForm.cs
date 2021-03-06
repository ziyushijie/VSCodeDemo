﻿using ClockWM8510Lib;
using COMMPortLib;
using MessageBoxPlusLib;
using RFASKFreqCurrentLib;
using System;
using System.Windows.Forms;
using UserControlPlusLib;

namespace RFASKFreqCurrentForm
{
	public partial class RFASKFreqCurrentForm : Form
	{
		#region 变量定义

		private RFASKFreqCurrent usedFreqCurrent = null;

		#endregion 变量定义
		
		#region 构造函数

		/// <summary>
		///
		/// </summary>
		public RFASKFreqCurrentForm()
		{
			InitializeComponent();

			//---限定尺寸,尺寸不可更改
			this.MinimumSize=this.Size;
			this.MaximumSize=this.Size;

			//---窗体加载事件
			this.Load+=new EventHandler(this.Form_Load);

			//---窗体关闭事件
			this.FormClosing+=new FormClosingEventHandler(this.Form_Closing);
		}

		#endregion 构造函数

		#region 初始化

		/// <summary>
		///
		/// </summary>
		/// <param name=""></param>
		public virtual void Start_Init()
		{
			//---使用的类
			if (this.usedFreqCurrent==null)
			{
				this.usedFreqCurrent=new RFASKFreqCurrent(new SerialCOMMPort(this, 115200));
			}

			//---定义端口使用的缓存区
			this.usedFreqCurrent.m_UsedPort.ReadAnWriteBufferSize(1800, 1800);
			//---通信端口初始化
			this.commPortControl_commPort.Init(this, this.usedFreqCurrent.m_UsedPort, this.richTextBoxEx_msg);
			//---函数注册
			this.RegisterEventHandle();

			//---窗体初始化
			this.FormInit(false);

			//---计算频率电流扫描的点数的个数
			//this.freqCurrentControl_freqCurrentPointOne.m_StepPointNum=(int)((this.freqCurrentControl_freqCurrentPointOne.m_StartFreq*100)/(this.freqCurrentControl_freqCurrentPointOne.m_StepFreq*100));
			//this.freqCurrentControl_freqCurrentPointTwo.m_StepPointNum=(int)((this.freqCurrentControl_freqCurrentPointTwo.m_StartFreq*100)/(this.freqCurrentControl_freqCurrentPointTwo.m_StepFreq*100));
		}

		/// <summary>
		/// 注册事件处理
		/// </summary>
		public virtual void RegisterEventHandle()
		{
			//---定时器
			this.timer_SysTick.Tick+=new EventHandler(this.timer_Tick);

			//---时钟控件的事件注册
			this.clockRateControl_clockRate.UserButtonClick+=new UserControlPlusLib.ClockRateControl.UserButtonClickHandle(this.ClockRateUserControl_ButtonClick);
			this.clockRateControl_clockRate.UserButtonCheckControlClick+=new UserControlPlusLib.ClockRateControl.UserButtonCheckControlClickHandle(this.ClockRateUserControl_ChannelClick);

			//---预设时钟控件事件注册
			this.preFreqControl_preFreq.UserButtonClick+=new UserControlPlusLib.PreFreqControl.UserButtonClickHandle(this.PreFreqControlUserControl_ButtonClick);

			//---设备类型的事件注册
			this.deviceTypeControl_deviceType.UserButtonClick+=new DeviceTypeControl.UserButtonClickHandle(this.DeviceTypeControl_ButtonClick);

			//---频率电流扫描的参数
			this.freqCurrentControl_freqCurrentPointOne.UserButtonClick+=new FreqCurrentControl.UserButtonClickHandle(this.FreqCurrentControl_ButtonClick);

			//---频率电流扫描的参数
			this.freqCurrentControl_freqCurrentPointTwo.UserButtonClick+=new FreqCurrentControl.UserButtonClickHandle(this.FreqCurrentControl_ButtonClick);

			//---监听数据
			this.button_startMonitorData.Click += new EventHandler(this.button_Click);
			//---停止监听
			this.button_stopMonitorData.Click += new EventHandler(this.button_Click);
		}

		/// <summary>
		/// 销毁事件处理
		/// </summary>
		public virtual void UnRegisterEventHandle()
		{
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="isEmable"></param>
		public virtual void FormInit(bool isEmable)
		{
			//this.deviceTypeControl_deviceType.m_Enabled=isEmable;
			//this.clockRateControl_clockRate.m_Enabled=isEmable;
			//this.preFreqControl_preFreq.m_Enabled=isEmable;
			//this.freqCurrentControl_freqCurrentPointOne.m_Enabled=isEmable;
			//this.freqCurrentControl_freqCurrentPointTwo.m_Enabled=isEmable;

			if (isEmable==false)
			{
				this.clockRateControl_clockRate.ClearChannelChecked(false);
			}
		}

		#endregion 初始化

		#region 函数重载

		/// <summary>
		/// 重写窗体关闭事件
		/// </summary>
		/// <param name="e"></param>
		//protected override void OnClosing(CancelEventArgs e)
		//{
		//    if (DialogResult.OK == MessageBoxPlus.Show(this, "你确定要关闭应用程序吗？", "关闭提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
		//    {
		//        //---为保证Application.Exit();时不再弹出提示，所以将FormClosing事件取消
		//        this.FormClosing -= new FormClosingEventHandler(this.Form_Closing);
		//        //---确认关闭事件
		//        e.Cancel = false;
		//        //---退出当前窗体
		//        this.Dispose();
		//    }
		//    else
		//    {
		//        //---取消关闭事件
		//        e.Cancel = true;
		//    }
		//}

		#endregion 函数重载

		#region 事件定义

		/// <summary>
		/// 窗体加载
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public virtual void Form_Load(object sender, EventArgs e)
		{
			this.Start_Init();
		}

		/// <summary>
		/// 窗体关闭
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public virtual void Form_Closing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason==CloseReason.MdiFormClosing)
			{
				return;
			}
			else if (e.CloseReason==CloseReason.UserClosing)
			{
				if (DialogResult.OK==MessageBoxPlus.Show(this, "你确定要关闭应用程序吗？", "关闭提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
				{
					//---为保证Application.Exit();时不再弹出提示，所以将FormClosing事件取消
					this.FormClosing-=new FormClosingEventHandler(this.Form_Closing);

					//---确认关闭事件
					e.Cancel=false;

					//---退出当前窗体
					this.Dispose();
				}
				else
				{
					//---取消关闭事件
					e.Cancel=true;
				}
			}
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public virtual void timer_Tick(object sender, EventArgs e)
		{
			//---刷新时间
			this.toolStripLabel_SysTick.Text=System.DateTime.Now.ToString();
			if (this.commPortControl_commPort.m_ButtonName=="关闭端口")
			{
				this.FormInit(true);
			}
			else if (this.deviceTypeControl_deviceType.Enabled==true)
			{
				this.FormInit(false);
			}
		}

		/// <summary>
		/// 按键点击事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public virtual void button_Click(object sender, EventArgs e)
		{
			if ((this.usedFreqCurrent == null) || (this.usedFreqCurrent.m_UsedPort == null))
			{
				return;
			}
			Button button = (Button)sender;
			switch (button.Name)
			{
				case "button_startMonitorData":
					this.usedFreqCurrent.m_UsedPort.m_DataReceivedEvent += new COMMPort.ReceivedEventHandler(this.DataReceivedHandler);
					break;
				case "button_stopMonitorData":
					if (this.usedFreqCurrent.m_UsedPort.m_DataReceivedEvent!=null)
					{
						this.usedFreqCurrent.m_UsedPort.m_DataReceivedEvent -= new COMMPort.ReceivedEventHandler(this.DataReceivedHandler);
					}
					break;
				default:
					break;
			}
		}

		#endregion 事件定义

		#region 函数定义

		/// <summary>
		/// 数据接收事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public virtual void DataReceivedHandler(object sender, EventArgs e)
		{
			if ((this.usedFreqCurrent == null) || (this.usedFreqCurrent.m_UsedPort == null))
			{
				return;
			}
			this.usedFreqCurrent.FreqCurrentDo(this.usedFreqCurrent.m_UsedPort, this.myChart_freqCurrent, this.richTextBoxEx_msg);
		}

		/// <summary>
		/// 时钟设置通道选取
		/// </summary>
		/// <param name="freq"></param>
		/// <param name="index"></param>
		public virtual void ClockRateUserControl_ButtonClick(object sender, EventArgs e, int freq, int index = 0)
		{
			if ((this.usedFreqCurrent==null)||(this.usedFreqCurrent.m_UsedPort==null))
			{
				return;
			}
			ClockWM8510 usedWM8510 = new ClockWM8510();
			usedWM8510.ClockWM8510Set(freq, index, this.usedFreqCurrent.m_UsedPort, this.richTextBoxEx_msg);
			if (index==1)
			{
				if (freq<usedWM8510.m_MinFreq)
				{
					this.clockRateControl_clockRate.m_ClockRate=usedWM8510.m_MinFreq;
					this.clockRateControl_clockRate.m_ClockRateMin=usedWM8510.m_MinFreq;
				}
			}
		}

		/// <summary>
		/// 时钟通道的选择
		/// </summary>
		/// <param name="index"></param>
		/// <param name="isChecked"></param>
		public virtual void ClockRateUserControl_ChannelClick(object sender, EventArgs e, int index, bool isChecked = false)
		{
			if ((this.usedFreqCurrent==null)||(this.usedFreqCurrent.m_UsedPort==null))
			{
				return;
			}
			ClockWM8510 usedWM8510 = new ClockWM8510();
			if (usedWM8510.ClockWM8510SetChannel(index, isChecked, this.usedFreqCurrent.m_UsedPort, this.richTextBoxEx_msg)!=0)
			{
				this.clockRateControl_clockRate.SetChannelChecked(index, !isChecked);
			}
		}

		/// <summary>
		/// 预设频率点的配置
		/// </summary>
		/// <param name="freq"></param>
		/// <param name="index"></param>
		public void PreFreqControlUserControl_ButtonClick(object sender, EventArgs e, int index, int preFreqIndex)
		{
			if ((this.usedFreqCurrent==null)||(this.usedFreqCurrent.m_UsedPort==null))
			{
				return;
			}
			ClockWM8510 usedWM8510 = new ClockWM8510();
			usedWM8510.PreFreqYSELSet(index, preFreqIndex, this.preFreqControl_preFreq, this.usedFreqCurrent.m_UsedPort, this.richTextBoxEx_msg);
		}

		/// <summary>
		/// 设备类型的配置
		/// </summary>
		/// <param name="index"></param>
		public virtual void DeviceTypeControl_ButtonClick(object sender, EventArgs e, int index)
		{
			if ((this.usedFreqCurrent==null)||(this.usedFreqCurrent.m_UsedPort==null))
			{
				return;
			}
			this.usedFreqCurrent.DeviceTypeSet(index, this.deviceTypeControl_deviceType, this.usedFreqCurrent.m_UsedPort, this.richTextBoxEx_msg);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="index"></param>
		public virtual void FreqCurrentControl_ButtonClick(object sender, EventArgs e, int index)
		{
			if ((this.usedFreqCurrent==null)||(this.usedFreqCurrent.m_UsedPort==null))
			{
				return;
			}
			FreqCurrentControl fcc = (FreqCurrentControl)sender;
			int _return = 0;
			switch (fcc.Name)
			{
				//---第一个电压点的频率电流扫描
				case "freqCurrentControl_freqCurrentPointOne":
					_return=this.usedFreqCurrent.FreqCurrentSet(index, 1, this.freqCurrentControl_freqCurrentPointOne, this.usedFreqCurrent.m_UsedPort,this.myChart_freqCurrent, this.richTextBoxEx_msg);
					break;

				//---第二个电压点的频率电流扫描
				case "freqCurrentControl_freqCurrentPointTwo":
					_return=this.usedFreqCurrent.FreqCurrentSet(index, 2, this.freqCurrentControl_freqCurrentPointTwo, this.usedFreqCurrent.m_UsedPort, this.myChart_freqCurrent, this.richTextBoxEx_msg);
					break;

				default:
					break;
			}
		}

		#endregion 函数定义
	}
}