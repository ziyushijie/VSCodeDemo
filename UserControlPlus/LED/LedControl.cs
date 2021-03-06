﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace UserControlPlusLib
{
	public partial class LedControl : UserControl
	{
		#region 属性定义

		/// <summary>
		/// LED的颜色
		/// </summary>
		[Description("修改此值，可修改分割线的颜色"), Category("自定义属性")]
		public virtual Color LedColor
		{
			get
			{
				return this.ledButtonControl_led.LedColor;
			}

			set
			{
				this.ledButtonControl_led.LedColor=value;
			}
		}

		/// <summary>
		/// 状态
		/// </summary>
		[Description("修改此值，可修改选择的状态"), Category("自定义属性")]
		public virtual bool LedChecked
		{
			get
			{
				return this.buttonCheckControl_led.Checked;
			}

			set
			{
				this.buttonCheckControl_led.Checked=value;
			}
		}

		/// <summary>
		/// 样式
		/// </summary>
		[Description("修改此值，可修改状态的样式"), Category("自定义属性")]
		public virtual CheckStyle CheckStylePlus
		{
			get
			{
				return this.buttonCheckControl_led.CheckStylePlus;
			}

			set
			{
				this.buttonCheckControl_led.CheckStylePlus=value;
				this.Invalidate();
			}
		}

		#endregion 属性定义

		#region 委托事件

		/// <summary>
		/// 自定义事件的参数类型
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <param name="orther"></param>
		public delegate void UserClickHandle(object sender, EventArgs e);

		[Description("当点击控件时发生，调用选中当前控件逻辑"), Category("自定义事件")]
		public event UserClickHandle UserClick;

		#endregion 委托事件

		#region 构造函数

		/// <summary>
		///
		/// </summary>
		public LedControl()
		{
			InitializeComponent();

			//---设置Style支持透明背景色并且双缓冲
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			this.SetStyle(ControlStyles.ResizeRedraw, true);
			this.SetStyle(ControlStyles.Selectable, true);
			this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			this.SetStyle(ControlStyles.UserPaint, true);

			//---限定尺寸,尺寸不可更改
			this.MinimumSize=this.Size;
			this.MaximumSize=this.Size;

			//---注册事件
			this.buttonCheckControl_led.Click+=new System.EventHandler(this.buttonCheckControl_Click);
		}

		#endregion 构造函数

		#region 事件定义

		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public virtual void buttonCheckControl_Click(object sender, EventArgs e)
		{
			ButtonCheckControl bcc = (ButtonCheckControl)sender;
			switch (bcc.Name)
			{
				case "buttonCheckControl_led":
					if (this.buttonCheckControl_led.Checked)
					{
						this.ledButtonControl_led.LedColor=Color.Red;
					}
					else
					{
						this.ledButtonControl_led.LedColor=Color.Black;
					}

					//---用户事件
					if (this.UserClick!=null)
					{
						this.UserClick(sender, e);
					}
					break;

				default:
					break;
			}
		}

		#endregion 事件定义
	}
}