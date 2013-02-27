using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

	/// <summary>
	/// Validate 的摘要说明。
	/// </summary>
	partial class Validate : System.Web.UI.Page
	{
		private void Page_Load(object sender, EventArgs e)
		{
			string strValidateCode = ValidateCode(4);//取得随机字符串，并设置Session值
			DrawValidateCode(strValidateCode,50,100);//绘图
		}
    
		//绘图
		private void DrawValidateCode(string strValidateCode,int intFgNoise,int intBgNoise)
		{
			if(strValidateCode == null || strValidateCode.Trim() == String.Empty)
			{
				return;
			}
			else
			{
				//建立一个位图文件 确立长宽
				Bitmap bmpImage = new Bitmap((int)Math.Ceiling((strValidateCode.Length * 12.5)), 22);
				Graphics grpGraphics = Graphics.FromImage(bmpImage);
    
				try
				{
					//生成随机生成器
					Random rndRandom = new Random();
    
					//清空图片背景色
					grpGraphics.Clear(Color.White);
    
					//画图片的背景噪音线
					for(int i=0; i<intBgNoise; i++)
					{
						int int_x1 = rndRandom.Next(bmpImage.Width);
						int int_x2 = rndRandom.Next(bmpImage.Width);
						int int_y1 = rndRandom.Next(bmpImage.Height);
						int int_y2 = rndRandom.Next(bmpImage.Height);
    
						grpGraphics.DrawLine(new Pen(Color.Silver), int_x1, int_y1, int_x2, int_y2);
					}
					//把产生的随机数以字体的形式写入画面
					Font font = new Font("Arial", 12, (FontStyle.Bold | FontStyle.Italic));
					LinearGradientBrush brhBrush = new LinearGradientBrush(new Rectangle(0, 0, bmpImage.Width, bmpImage.Height), Color.Blue, Color.DarkRed, 1.2f, true);
					grpGraphics.DrawString(strValidateCode, font, brhBrush, 2, 2);
    
					//画图片的前景噪音点
					for(int i=0; i<intFgNoise; i++)
					{
						int int_x = rndRandom.Next(bmpImage.Width);
						int int_y = rndRandom.Next(bmpImage.Height);
    
						bmpImage.SetPixel(int_x, int_y, Color.FromArgb(rndRandom.Next()));
					}
    
					//画图片的边框线
					grpGraphics.DrawRectangle(new Pen(Color.Silver), 0, 0, bmpImage.Width - 1, bmpImage.Height - 1);
    
					MemoryStream memsMemoryStream = new MemoryStream();
					bmpImage.Save(memsMemoryStream, ImageFormat.Gif);
					Response.ClearContent();
					Response.ContentType = "image/Gif";
					Response.BinaryWrite(memsMemoryStream.ToArray());
				}
				finally
				{
					grpGraphics.Dispose();
					bmpImage.Dispose();
				}
			}
		}

    
		//取得随机字符串，并设置Session值
		private string ValidateCode(int intLength)
		{
			int intNumber;
			char chrCode;
			string strValidateCode = String.Empty;
    
			Random rndRandom = new Random();//5^1^a^s^p^x
    
			for(int i=0;i<intLength;i++)
			{
				intNumber = rndRandom.Next();
				if(intNumber % 2 == 0)
				{
					chrCode = (char)('0' + (char)(intNumber % 10));//如果随机数是偶数 取余
				}
				else
				{
					chrCode = (char)('A' + (char)(intNumber % 26));//如果随机数是奇数 选择从[A-Z]
				}
				strValidateCode += chrCode.ToString(); 
			}
    
			Session["Code"] = strValidateCode;//设置Session["ValidateCode"]
//			Response.Cookies.Add(new HttpCookie("strValidateCode",strValidateCode));//Session,Cookie两者之中用一个来验证
    
			return strValidateCode;
		}

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
