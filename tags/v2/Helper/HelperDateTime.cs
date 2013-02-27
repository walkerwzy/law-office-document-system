using System;

namespace Helper
{
	/// <summary>
	/// HelperDateTime
	/// </summary>
	public class HelperDateTime
	{
		public static readonly DateTime INVAILD_DATETIME	= new DateTime(1900,1,1);
		public static readonly string	EMPTY				= string.Empty;

		public static readonly int		WORKINGTIMESTART	= 900;
		public static readonly int		WORKINGTIMEEND		= 1900;

		public static readonly int		BILLINGDATE			= 15;
		public static readonly int		DUEDAY				= 25;

		private HelperDateTime(){}

		#region input

		public static DateTime InputDateTime(string inputString)
		{
			try
			{
				if ((inputString != null) && (inputString != String.Empty))
				{
                    //格式化时间
                    return Convert.ToDateTime((Convert.ToDateTime(inputString).ToString("yyyy-MM-dd HH:mm:ss")));
				}
				else
				{
					return INVAILD_DATETIME;
				}
			}
			catch 
			{
				return INVAILD_DATETIME;
			}
		}

		#endregion

		#region GetDateTimeStr

		public static string GetDateTimeStr(DateTime dt)
		{
			return GetDateTimeStr(dt,null);
		}

		public static string GetDateTimeStr(DateTime dt,string format)
		{
			try
			{
				if(!dt.Equals(INVAILD_DATETIME))
				{
					if(format == null) return dt.ToString("yyyy-MM-dd");
					else return dt.ToString(format);
				}
				else
				{
					return EMPTY;
				}
			}
			catch
			{
				return EMPTY;
			}

		}

        /// <summary>
        /// 传yyyyMMdd返回yyyy-MM-dd
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static string GetFormatedDate(string datetime)
        {            
            string temp = string.Empty;

            if (!string.IsNullOrEmpty(datetime))
            {
                DateTime dt = Convert.ToDateTime(datetime.Insert(6, "-").Insert(4, "-"));
                temp = dt.ToString("yyyy-MM-dd");
            }
            return temp;
        }

        /// <summary>
        /// 传yyyy-MM-dd格式返回yyyyMMdd
        /// </summary>
        /// <param name="inputstr"></param>
        /// <returns></returns>
        public static string GetDateTimeStr(string inputstr,bool isEmpty)
        {
            if(isEmpty)
              return inputstr.IndexOf("-") > 0 ? inputstr.Replace("-", string.Empty) : "";
             else
            return inputstr.IndexOf("-") > 0 ? inputstr.Replace("-", string.Empty) : DateTime.Now.ToString("yyyyMMdd");
        }

        /// <summary>
        /// 传yyyy-MM-dd格式返回yyyy/MM/dd
        /// </summary>
        /// <param name="inputstr"></param>
        /// <returns></returns>
        public static string GetDateTaiWanTime(string inputstr)
        {
            //inputstr = Convert.ToDateTime(inputstr).ToString("yyyy-MM-dd");
            return inputstr.IndexOf("-") > 0 ? inputstr.Replace("/", string.Empty) : "1981/01/01";
        }

        /// <summary>
        /// 传yyyy/MM/dd格式返回yyyyMMdd
        /// </summary>
        /// <param name="inputstr"></param>
        /// <returns></returns>
        public static string GetDateTimeString(string inputstr)
        {
            return inputstr.IndexOf("/") > 0 ? inputstr.Replace("/", string.Empty) : "19810101";
        }



		public static string GetDateTimeStr(DateTime dt,int addDay)
		{
			return GetDateTimeStr(dt.AddDays(addDay));
		}

		public static string GetCreateDate(DateTime dt)
		{
			try
			{
				if(!dt.Equals(HelperDateTime.INVAILD_DATETIME))
				{
					return "Created at "+dt.ToString("yyyy-MM-dd HH:mm:ss");
				}
				else
				{
					return EMPTY;
				}
			}
			catch
			{
				return EMPTY;
			}
		}

		public static string GetModifyDate(DateTime dt)
		{
			try
			{
				if(!dt.Equals(HelperDateTime.INVAILD_DATETIME))
				{
					return "Updated at "+dt.ToString("yyyy-MM-dd HH:mm:ss");
				}
				else
				{
					return EMPTY;
				}
			}
			catch
			{
				return EMPTY;
			}
		}

		#endregion

		#region bll parameters control

		public static object GetSqlParameterDate(DateTime dt)
		{
			if(dt.Equals(INVAILD_DATETIME))
				return	null;
			else
				return dt;
		}

		#endregion

		#region billing firstday and last day

		public static DateTime GetBillingFirstDay(int billingDate)
		{
			if(billingDate == 0) billingDate = BILLINGDATE;
			int days = DateTime.DaysInMonth(DateTime.Now.AddMonths(-1).Year,DateTime.Now.AddMonths(-1).Month);
			string firstDay = EMPTY;
			string YEARMONTH= DateTime.Now.AddMonths(-1).ToString("yyyy-MM");
			if(billingDate<10) firstDay = YEARMONTH+"-0"+billingDate;
			else if( billingDate > days) firstDay = YEARMONTH+"-"+days;
			else firstDay = YEARMONTH+"-"+billingDate;
			try
			{
				return DateTime.Parse(firstDay).AddDays(1);
			}
			catch
			{
				return INVAILD_DATETIME;
			}
		}

		public static DateTime GetBillingFirstDay(int year,int month,int billingDate)
		{
			if(billingDate == 0) billingDate = BILLINGDATE;
            DateTime dt = new DateTime(year,month,1);
			int days = DateTime.DaysInMonth(dt.AddMonths(-1).Year,dt.AddMonths(-1).Month);
			string firstDay = EMPTY;
			string YEARMONTH= dt.AddMonths(-1).ToString("yyyy-MM");
			if(billingDate<10) firstDay = YEARMONTH+"-0"+billingDate;
			else if( billingDate > days) firstDay = YEARMONTH+"-"+days;
			else firstDay = YEARMONTH+"-"+billingDate;
			try
			{
				return DateTime.Parse(firstDay).AddDays(1);
			}
			catch
			{
				return INVAILD_DATETIME;
			}
		}

		public static DateTime GetBillingLastDay(int billingDate)
		{
			if(billingDate == 0) billingDate = BILLINGDATE;
			int days = DateTime.DaysInMonth(DateTime.Now.Year,DateTime.Now.Month);
			string lastDay = EMPTY;
			string YEARMONTH= DateTime.Now.ToString("yyyy-MM");
			if(billingDate<10)				lastDay = YEARMONTH+"-0"+billingDate;
			else if (billingDate > days)	lastDay = YEARMONTH+"-"+days;
			else							lastDay = YEARMONTH+"-"+billingDate;

			try
			{
				return DateTime.Parse(lastDay);
			}
			catch
			{
				return INVAILD_DATETIME;
			}
		}

		public static DateTime GetBillingLastDay(int year,int month, int billingDate)
		{
			if(billingDate == 0) billingDate = BILLINGDATE;
			int days = DateTime.DaysInMonth(year,month);
			string lastDay = EMPTY;
			string YEARMONTH= year+"-"+month;
			if(billingDate<10)				lastDay = YEARMONTH+"-0"+billingDate;
			else if (billingDate > days)	lastDay = YEARMONTH+"-"+days;
			else							lastDay = YEARMONTH+"-"+billingDate;

			try
			{
				return DateTime.Parse(lastDay);
			}
			catch
			{
				return INVAILD_DATETIME;
			}
		}

		public static DateTime GetDueDay(DateTime dt, int dueday)
		{
			if (dueday == -1)
				dueday = DUEDAY;
			string date = dt.Year+"-"+dt.Month+"-"+dueday;
			try
			{
				return DateTime.Parse(date);
			}
			catch
			{
				return INVAILD_DATETIME;
			}
		}
		#endregion

		#region user control

		public static string GetFormatedDate(int time)
		{
			try
			{
				string str = time.ToString();
				if(str.Length == 2) str = "0:"+str;
				else if(str.Length == 3) str = str.Substring(0,1)+":"+str.Substring(1,2);
				else if(str.Length == 4) str = str.Substring(0,2)+":"+str.Substring(2,2);
				else str= "0:0"+str;
				str = "<span style='width:35px'>"+str+"</span>";
				return str;
			}
			catch
			{
				return EMPTY;
			}
		}

		private static double GetStdTime(int Start,int Finish,bool holiday)
		{
			if(holiday) return 0;
			if(Start > WORKINGTIMEEND) return 0;
			if(Finish< WORKINGTIMESTART) return 0;
			if(WORKINGTIMESTART > Start) Start	= WORKINGTIMESTART;
			if(WORKINGTIMEEND < Finish) Finish	= WORKINGTIMEEND;
			double stdTime = GetHours(Finish)-GetHours(Start);
			if(stdTime>0) return double.Parse(stdTime.ToString("F2"));
			else return 0;
		} 

		public static double GetStdTime(int Start,int Finish,int Break,bool lastdayHol,bool todayHol, bool tomorrowHol,int chargeOT)
		{
			if(chargeOT == 0) 
			{
				// DONT charge overtime;
				double allstdTime = GetHours(Finish)-GetHours(Start)-GetHours(Break);
				if(allstdTime>0) return double.Parse(allstdTime.ToString("F2"));
			}
			double stdTime = 0;
			if(Finish<=0) 
				stdTime = GetStdTime(Start+2400,Finish+2400,lastdayHol);
			else if (Start>2400)
				stdTime = GetStdTime(Start-2400,Finish-2400,tomorrowHol);
			else if ((Start>0)&&(Finish<=2400))
				stdTime = GetStdTime(Start,Finish,todayHol);
			else if ((Start<=0)&&(Finish>2400))
			{
				stdTime+=GetStdTime(Start-2400,0,lastdayHol);
				stdTime+=GetStdTime(0,2400,todayHol);
				stdTime+=GetStdTime(0,Finish-2400,tomorrowHol);
			}
			else if (Start>0)
			{
				stdTime+=GetStdTime(Start,2400,todayHol);
				stdTime+=GetStdTime(0,Finish-2400,tomorrowHol);
			}
			else if (Finish<=2400)
			{
				stdTime+=GetStdTime(Start-2400,0,lastdayHol);
				stdTime+=GetStdTime(0,Finish,todayHol);
			}

			stdTime = stdTime-GetHours(Break);
			if(stdTime>0) return double.Parse(stdTime.ToString("F2"));
			else return 0;
		}

		public static double GetOverTime(int Start,int Finish,int Break,bool lastdayHol,bool todayHol, bool tomorrowHol,int chargeOT)
		{
			double allTime	= GetHours(Finish)-GetHours(Start)-GetHours(Break);
			double result	= allTime - GetStdTime(Start,Finish,Break,lastdayHol,todayHol,tomorrowHol,chargeOT);
			return double.Parse(result.ToString("F2"));
		}

		public static double GetHours(double time)
		{
			int hours = (int)time/100;
			double mins	= time%100/60;
			return hours+mins;
		}

		public static string showHours(double hours)
		{
			if(hours==0) return EMPTY;
			else return hours.ToString("0.00");
		}

        public static string GetFormatZeroHour(string hours)
        {
            if (hours.Length == 1)
            {
                hours = "0" + hours + ":00";
            }
            else if (hours.Length == 2)
            {
                hours = hours + ":00";
            }
            return hours;
        }
		#endregion
	}
}
