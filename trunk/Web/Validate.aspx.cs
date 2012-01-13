using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

	/// <summary>
	/// Validate ��ժҪ˵����
	/// </summary>
	partial class Validate : System.Web.UI.Page
	{
		private void Page_Load(object sender, EventArgs e)
		{
			string strValidateCode = ValidateCode(4);//ȡ������ַ�����������Sessionֵ
			DrawValidateCode(strValidateCode,50,100);//��ͼ
		}
    
		//��ͼ
		private void DrawValidateCode(string strValidateCode,int intFgNoise,int intBgNoise)
		{
			if(strValidateCode == null || strValidateCode.Trim() == String.Empty)
			{
				return;
			}
			else
			{
				//����һ��λͼ�ļ� ȷ������
				Bitmap bmpImage = new Bitmap((int)Math.Ceiling((strValidateCode.Length * 12.5)), 22);
				Graphics grpGraphics = Graphics.FromImage(bmpImage);
    
				try
				{
					//�������������
					Random rndRandom = new Random();
    
					//���ͼƬ����ɫ
					grpGraphics.Clear(Color.White);
    
					//��ͼƬ�ı���������
					for(int i=0; i<intBgNoise; i++)
					{
						int int_x1 = rndRandom.Next(bmpImage.Width);
						int int_x2 = rndRandom.Next(bmpImage.Width);
						int int_y1 = rndRandom.Next(bmpImage.Height);
						int int_y2 = rndRandom.Next(bmpImage.Height);
    
						grpGraphics.DrawLine(new Pen(Color.Silver), int_x1, int_y1, int_x2, int_y2);
					}
					//�Ѳ�������������������ʽд�뻭��
					Font font = new Font("Arial", 12, (FontStyle.Bold | FontStyle.Italic));
					LinearGradientBrush brhBrush = new LinearGradientBrush(new Rectangle(0, 0, bmpImage.Width, bmpImage.Height), Color.Blue, Color.DarkRed, 1.2f, true);
					grpGraphics.DrawString(strValidateCode, font, brhBrush, 2, 2);
    
					//��ͼƬ��ǰ��������
					for(int i=0; i<intFgNoise; i++)
					{
						int int_x = rndRandom.Next(bmpImage.Width);
						int int_y = rndRandom.Next(bmpImage.Height);
    
						bmpImage.SetPixel(int_x, int_y, Color.FromArgb(rndRandom.Next()));
					}
    
					//��ͼƬ�ı߿���
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

    
		//ȡ������ַ�����������Sessionֵ
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
					chrCode = (char)('0' + (char)(intNumber % 10));//����������ż�� ȡ��
				}
				else
				{
					chrCode = (char)('A' + (char)(intNumber % 26));//�������������� ѡ���[A-Z]
				}
				strValidateCode += chrCode.ToString(); 
			}
    
			Session["Code"] = strValidateCode;//����Session["ValidateCode"]
//			Response.Cookies.Add(new HttpCookie("strValidateCode",strValidateCode));//Session,Cookie����֮����һ������֤
    
			return strValidateCode;
		}

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
