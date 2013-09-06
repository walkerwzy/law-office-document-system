using System;
using System.Collections.Generic;

namespace Helper
{
	/// <summary>
	/// HelperString
	/// </summary>
	public class HelperString
	{
		private HelperString(){}

		public static string GetStringWithBR(string str)
		{
			if( str == string.Empty) return "&nbsp;";
			return str.Replace("\r\n","<BR>");
		}

		public static string GetStringWithBR1(string str)
		{
			if( str == string.Empty) return " ";
			return str.Replace("\r\n","<BR>");
		}
		
		public static string GetMoneyString(double money)
		{
			string tempText = money.ToString("###,###,##0");
			if (tempText != string.Empty)
			{
				return tempText;
			}
			else
			{
				return "0";
			}
		}

        /// <summary>
        /// 返回金額中文,GBK爲zh-cn爲簡體中文,zh-tw爲繁體中文
        /// </summary>
        /// <param name="jein"></param>
        /// <param name="GBK"></param>
        /// <returns></returns>
        public static string MoneyToCN(double jein,string GBK)
        {
            string suzi = string.Empty;
            string q = string.Empty;

            if (GBK.ToLower() == "zh-cn")
            {
                suzi = "零壹贰叁肆伍陆柒捌玖";
                q = "分角元拾佰仟万拾";
            }
            else if (GBK.ToLower() == "zh-tw")
            {
                suzi = "零壹貳參肆伍陸柒捌玖";
                q = "分角元拾佰仟萬拾";
            }

            string jeout = "";
            System.Int32 zs = Convert.ToInt32(jein * 100);
            int wei, i = 0;
            while (zs / 10 != 0)
            {
                wei = zs % 10;
                zs = zs / 10;
                jeout = suzi.Substring(wei, 1) + q.Substring(i, 1) + jeout;
                i = i + 1;
            }
            wei = zs % 10;
            jeout = suzi.Substring(wei, 1) + q.Substring(i, 1) + jeout;
            return jeout;
        }  

        public static string GetFormateMoney<T>(T money)
        {
            string tempstr = string.Empty;
            try
            {
                tempstr=Convert.ToDouble(money).ToString("###,###,##0");
            }
            catch
            {
                tempstr = "0";
            }
            return tempstr;
        }

        public static string CanceFormateMoney(string money)
        {
            string tempstr = string.Empty;
            try
            {
                tempstr = money.Replace(",", string.Empty);
            }
            catch
            {
                tempstr = "0";
            }
            return tempstr;
        }

		public static string GetLongMoneyString(double money)
		{
			string tempText = money.ToString("###,##0.##");
			if (tempText != string.Empty)
			{
				return tempText;
			}
			else
			{
				return "0";
			}
		}

		public static string GetUserName(string firstName,string lastName)
		{
			return firstName+" "+lastName;
		}

		public static string cutString(string sourceStr,int length)
		{
		    sourceStr = sourceStr.Trim();
			if(sourceStr.Length<=length)
				return sourceStr;
			else
			{
				return sourceStr.Substring(0,length)+"...";
			}
		}

		public static string cutStringWithNoBR(string sourceStr,int length)
		{
			int br = sourceStr.IndexOf("\r\n");
			if(br != -1 ) sourceStr = sourceStr.Substring(0,br);
			return cutString(sourceStr,length);
		}

		public static string RemoveBlank(string sourceStr)
		{
			return sourceStr.Replace("&nbsp;","");
		}

		public static string GetHrefString(string www)
		{
			string href = string.Empty;
			if(www.IndexOf("http") == -1) href = "http://"+www;
			string str = string.Format("<a href='{0}' target='_blank'>{1}</a>",href,www);
			return str;
		}

		public static string GetMailString(string mail)
		{
			string str = string.Format("<a href='mailto:{0}'>{1}</a>",mail,mail);
			return str;
		}

		public static string DeleteLastChar(string sourceStr)
		{
			if(sourceStr.Length > 0)
			{
				return sourceStr.Substring(0,sourceStr.Length-1);
			}
			return string.Empty;
		}

        public static string FormatSeqNo(int number, string seqno)
        {
            string result = string.Empty;
            string num = string.Empty;
            int t = number - seqno.Length;
            if (t > 0)
            {
                for (int i = 0; i < t; i++)
                {
                    num += "0";
                }
            }

            result = num + seqno;
            return result;
        }

        public static string SeqNoIdentity(string seq_no)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(seq_no))
            {
                int t = Convert.ToInt32(seq_no);
                t = t + 1;

                result = FormatSeqNo(seq_no.Length, t.ToString());
            }
            return result;
        }

        //通用弹出错误然后跳转的脚本字符串，
        public static string getAlertJumpString(string msg, string url)
        {
                return "<script type='text/javascript'>alert('" + msg + "');location.href='" + url + "'</script>";
        }
    }
}
