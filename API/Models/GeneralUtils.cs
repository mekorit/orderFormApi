using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public static class GeneralUtils
    {
        /// <summary>
        /// method for reading a value from a resource file
        /// (.resx file)
        /// </summary>
        /// <param name="file">file to read from</param>
        /// <param name="key">key to get the value for</param>
        /// <returns>a string value</returns>
     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Reverse(string str)
        {
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        /// <summary>
        /// Splits string by spaces and if any part contains digits, it won't be reversed.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ReverseOnlyHebrew(string str)
        {
            string[] arr = str.Split(' ');
            List<string> res = new List<string>();

            foreach (string s in arr)
            {
                if (ContatinsDigits(s))
                {
                    res.Add(s);
                }
                else
                {
                    res.Add(Reverse(s));
                }
            }

            res.Reverse();
            return String.Join(" ", res.ToArray());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="(object)value"></param>
        /// <returns>DDl value</returns>

        public static string GetValueForDDL(object value)
        {
            string res = string.Empty;

            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                res = "0";
            }
            else
            {
                long resultVal;
                bool isLong = long.TryParse(value.ToString(), out resultVal);
                if (isLong)
                {
                    res = resultVal.ToString();
                }
                else
                {
                    res = "0";
                }
            }
            return res;
        }

        /// <summary>
        /// Get the order ascendent or descendent
        /// </summary>
        /// <param name="(object)value"></param>
        /// <returns>string</returns>
        public static int GetOrder(object value)
        {
            var resVal = 0;

            if (value != null && value.ToString() == "desc")
            {
                resVal = 1;
            }
            return resVal;
        }

        /// <summary>
        ///  Get the long value from String
        /// </summary>
        /// <param name="(object)value"></param>
        /// <returns>double</returns>
        public static string ThGetOrder(this object value)
        {
            string result = "ASC";
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                result = "ASC";
            }
            else
            {
                if (value.ToString().Trim().ToLower().Equals("desc") || value.ToString().Trim().Equals("0"))
                {
                    result = "DESC";
                }
                else
                {
                    result = "ASC";
                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="(object)value"></param>
        /// <returns>DDl value</returns>
        public static string ThGetValueForDDL(this object value)
        {
            string res = string.Empty;

            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                res = "0";
            }
            else
            {
                long resultVal;
                bool isLong = long.TryParse(value.ToString(), out resultVal);
                if (isLong)
                {
                    res = resultVal.ToString();
                }
                else
                {
                    res = "0";
                }
            }
            return res;
        }

        public static bool ContatinsDigits(string str)
        {
            char[] arr = str.ToCharArray();
            foreach (char c in arr)
            {
                if (Char.IsDigit(c))
                    return true;
            }
            return false;
        }

        public static Guid? ThGetGuidOrNull(this object value)
        {

            Guid? result = (Guid?)null;

            if (value != null || !string.IsNullOrEmpty(value.ToString()))
            {
                try
                {
                    result = new Guid(value.ToString());
                }
                catch
                {
                    result = (Guid?)null;
                    throw;
                }
            }
            else
            {
                result = (Guid?)null;
            }
            return result;
        }



        #region  Grid/Display mode

        /// <summary>
        /// Display empty string if count is 0
        /// </summary>
        /// <param name="(object)value"></param>
        /// <returns></returns>
        public static string DisplayCount(object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return string.Empty;
            }
            else
            {
                if (GetInt(value) == 0)
                {
                    return string.Empty;
                }
                else
                {
                    return value.ToString();
                }

            }
        }

        /// <summary>
        /// Sends the string and return teh true/false for canremove attribute
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string CanRemove(object value)
        {
            var count = DisplayCount(value);
            var retValue = "";

            if (string.IsNullOrEmpty(count))
            {
                retValue = "true";
            }
            else
            {
                retValue = "false";
            }

            return retValue;
        }

        /// <summary>
        /// Sends the string and return teh true/false for buttons attribute
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ThShowButton(this object value)
        {
            var count = DisplayCount(value);
            var retValue = "";

            if (string.IsNullOrEmpty(count))
            {
                retValue = "false";
            }
            else
            {
                retValue = "true";
            }

            return retValue;
        }

        /// <summary>
        /// Sends the string and return teh true/false for canremove attribute
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ThCanRemove(this object value)
        {
            var count = DisplayCount(value);
            var retValue = "";

            if (string.IsNullOrEmpty(count))
            {
                retValue = "true";
            }
            else
            {
                retValue = "false";
            }

            return retValue;
        }

        /// <summary>
        /// Display empty string if count is 0
        /// </summary>
        /// <param name="(object)value"></param>
        /// <returns></returns>
        public static string ThDisplayCount(this object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return string.Empty;
            }
            else
            {
                if (GetInt(value) == 0)
                {
                    return string.Empty;
                }
                else
                {
                    return value.ToString();
                }

            }
        }

        /// <summary>
        /// Sends the string and return teh true/false for canremove attribute
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ThArrayCanRemove(this object[] value)
        {
            var retValue = "";

            foreach (var item in value)
            {
                var count = DisplayCount(item);

                if (!string.IsNullOrEmpty(count))
                {
                    retValue = "false";
                    break;
                }
                else
                {
                    retValue = "true";
                }
            }
            return retValue;
        }

        #endregion

        #region Double

        /// <summary>
        ///  Get the long value from String
        /// </summary>
        /// <param name="(object)value"></param>
        /// <returns>double</returns>
        public static double ThGetDouble(this object value)
        {
            double result = 0;
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                result = 0;
            }
            else
            {
                double res;
                bool isLong = double.TryParse(value.ToString(), out res);
                if (isLong)
                {
                    result = res;
                }
                else
                {
                    result = 0;
                }
            }
            return result;
        }

        /// <summary>
        ///  Get the double value from object
        /// </summary>
        /// <param name="(object)value"></param>
        /// <returns>double?</returns>
        public static double? ThGetDoubleOrNull(this object value)
        {
            double? result = 0;
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                result = (double?)null;
            }
            else
            {
                double res;
                bool isLong = double.TryParse(value.ToString(), out res);
                if (isLong)
                {
                    result = res;
                }
                else
                {
                    result = (double?)null;
                }
            }
            return result;
        }

        public static object ThGetDoubleOrDBNull(this object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return DBNull.Value;
            }
            else
            {
                double res;
                bool isLong = double.TryParse(value.ToString(), out res);
                if (isLong)
                {
                    return res;
                }
                else
                {
                    return DBNull.Value;
                }
            }
        }
        #endregion

        #region Long

        /// <summary>
        ///  Get the long value from String
        /// </summary>
        /// <param name="(object)value"></param>
        /// <returns>int</returns>
        public static long GetLong(object value)
        {

            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return 0;
            }
            else
            {
                long res;
                bool isLong = long.TryParse(value.ToString(), out res);
                if (isLong)
                {
                    return res;
                }
                else
                {
                    return 0;
                }
            }
        }
        /// <summary>
        ///  Get the long value from String
        /// </summary>
        /// <param name="(object)value"></param>
        /// <returns>long</returns>
        public static long ThGetLong(this object value)
        {

            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return 0;
            }
            else
            {
                long res;
                bool isLong = long.TryParse(value.ToString(), out res);
                if (isLong)
                {
                    return res;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        ///  Get the long value from String
        /// </summary>
        /// <param name="(object)value"></param>
        /// <returns>long?</returns>
        public static long? ThGetLongOrNull(this object value)
        {
            long? result = 0;
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                result = (long?)null;
            }
            else
            {
                long res;
                bool isLong = long.TryParse(value.ToString(), out res);
                if (isLong)
                {
                    result = res;
                }
                else
                {
                    result = (long?)null;
                }
            }
            return result;
        }

        public static object ThGetLongOrDBNull(this object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return DBNull.Value;
            }
            else
            {
                long res;
                bool isLong = long.TryParse(value.ToString(), out res);
                if (isLong)
                {
                    return res;
                }
                else
                {
                    return DBNull.Value;
                }
            }
        }

        #endregion

        #region Byte

        /// <summary>
        ///  Get the byte value from String
        /// </summary>
        /// <param name="(object)value"></param>
        /// <returns>int</returns>
        public static byte GetByte(object value)
        {

            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return 0;
            }
            else
            {
                byte res;
                bool isByte = byte.TryParse(value.ToString(), out res);
                if (isByte)
                {
                    return res;
                }
                else
                {
                    return 0;
                }
            }
        }
        /// <summary>
        ///  Get the byte value from String
        /// </summary>
        /// <param name="(object)value"></param>
        /// <returns>byte</returns>
        public static byte ThGetByte(this object value)
        {

            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return 0;
            }
            else
            {
                byte res;
                bool isByte = byte.TryParse(value.ToString(), out res);
                if (isByte)
                {
                    return res;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        ///  Get the byte value from String
        /// </summary>
        /// <param name="(object)value"></param>
        /// <returns>byte?</returns>
        public static byte? ThGetByteOrNull(this object value)
        {
            byte? result = 0;
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                result = (byte?)null;
            }
            else
            {
                byte res;
                bool isByte = byte.TryParse(value.ToString(), out res);
                if (isByte)
                {
                    result = res;
                }
                else
                {
                    result = (byte?)null;
                }
            }
            return result;
        }

        #endregion

        #region Decimal

        /// <summary>
        /// 
        /// </summary>
        /// <param name="(object)value"></param>
        /// <returns>decimal</returns>
        public static decimal ThGetDecimal(this object value)
        {
            decimal result = 0.0M;

            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                result = 0.0M;
            }
            else
            {
                decimal res;
                bool isInt = decimal.TryParse(value.ToString(), out res);
                if (isInt)
                {
                    result = res;
                }
                else
                {
                    result = 0.0M;
                }
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="(object)value"></param>
        /// <returns>decimal?</returns>
        public static decimal? ThGetDecimalOrNull(this object value)
        {
            decimal? result = 0.0M;

            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                result = (decimal?)null;
            }
            else
            {
                decimal res;
                bool isInt = decimal.TryParse(value.ToString(), out res);
                if (isInt)
                {
                    result = res;
                }
                else
                {
                    result = (decimal?)null;
                }
            }

            return result;
        }

        #endregion

        #region Date

        public static DateTime? ToDateTime(object strDate)
        {
            CultureInfo enAU = new CultureInfo("en-AU");
            string[] formats = {   "d/M/yyyy hh:mm tt",
                                   "d/M/yyyy hh tt",
                                   "d/M/yyyy h:mm",
                                   "d/M/yyyy h:mm",
                                   "dd/MM/yyyy hh:mm",
                                   "dd/M/yyyy hh:mm",
                                   "dd/M/yyyy",
                                   "dd/MM/yyyy",
                                   "dd/MM/yyyy ",
                                   "d/M/yyyy h:mm:ss.fff tt",
                                   "d/M/yyyy h:mm tt",
                                   "dd/MM/yyyy HH:mm",
                                   "dd/MM/yyyy HH:mm:ss",
                                   "dd/MM/yyyy H:mm:ss",
                                   "dd/MM/yyyy hh:mm:ss.fff",
                                   "d/M/yyyy h:mm:ss.fff",
                                   "dd/MM/yyyy HH:mm:ss.fff",
                                   "dd/MM/yyyy hh:mm:ss tt",
                                   "yyyy-MM-dd HH:mm:ss.fff",
                                   "yyyy-dd-MM HH:mm:ss.fff" ,
                                   "M/d/yyyy h:mm:ss.fff tt",
                                   "M/d/yyyy h:mm tt",
                                   "MM/dd/yyyy hh:mm:ss.fff tt",
                                   "MM/dd/yyyy hh:mm:ss tt",
                                   "M/d/yyyy h:mm:ss.fff",
                                   "M/d/yyyy hh:mm tt", "M/d/yyyy hh tt",
                                   "M/d/yyyy h:mm", "M/d/yyyy h:mm",
                                   "MM/dd/yyyy hh:mm",
                                   "M/dd/yyyy hh:mm" ,

                                   "MM/dd/yyyy HH:mm:ss",

                                   "MM/dd/yyyy HH:mm:ss.fff",

                                   "MM/dd/yyyy",

                                   "MM/dd/yyyy h:mm:ss tt",
                                   "M/dd/yyyy h:mm:ss tt",
                                   "yyyy/MM/dd",
                                   "M/d/yyyy HH:mm:ss.fff",
                                   "M/d/yyyy HH:mm:ss.tt",
                                   "M/d/yyyy HH:mm:ss"
                               };

            DateTime date = new DateTime();
            DateTime? result = (DateTime?)null;
            //System.Globalization.CultureInfo.InvariantCulture
            if (DateTime.TryParseExact(strDate.ToString(), formats, enAU, DateTimeStyles.None, out date))
            {
                result = date;
            }
            else
            {
                result = (DateTime?)null;
            }
            return result;
            // return DateTime.ParseExact(strDate.ToString(), @"ddd dd MMM h:mm tt yyyy", System.Globalization.CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="This" datetime></param>
        /// <returns>string</returns>
        public static string ThToSqlDateString(this DateTime This)
        {
            return string.Format("CAST('{0}-{1}-{2} {3}:{4}:{5}' AS DATETIME)", This.Year, This.Month, This.Day, This.Hour, This.Minute, This.Second);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="This" datetime></param>
        /// <returns>string</returns>
        public static object ThToSqlDateStringOrNull(this object This)
        {
            object result;
            var date = This.ThGetDateOrNull();
            if (date != null)
            {
                DateTime tempDate = (DateTime)date;
                result = string.Format("CAST('{0}-{1}-{2} {3}:{4}:{5}' AS DATETIME)", tempDate.Year, tempDate.Month, tempDate.Day, tempDate.Hour, tempDate.Minute, tempDate.Second);
            }
            else
            {
                result = DBNull.Value;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="This" datetime></param>
        /// <returns>string</returns>
        public static string ThToSqlValidationDateString(this DateTime This)
        {
            return string.Format("{0}-{1}-{2} {3}:{4}:{5}", This.Year, This.Month, This.Day, This.Hour, This.Minute, This.Second);
        }
        public static object ThToSqlValidationDateOrDBNull(this object This)
        {
            object result;
            var date = This.ThGetDateOrNull();
            if (date != null)
            {
                DateTime tempDate = (DateTime)date;
                result = string.Format("{0}-{1}-{2} {3}:{4}:{5}", tempDate.Year, tempDate.Month, tempDate.Day, tempDate.Hour, tempDate.Minute, tempDate.Second);
            }
            else
            {
                result = DBNull.Value;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="(string)date"></param>
        /// <returns>DateTime?</returns>
        public static DateTime? GetDateOrNull(object date)
        {
            DateTime? result = (DateTime?)null;
            if (date == null || string.IsNullOrEmpty(date.ToString()))
            {
                result = (DateTime?)null;
            }
            else
            {
                try
                {
                    result = GeneralUtils.ToDateTime(date);
                }
                catch (Exception)
                {
                    result = (DateTime?)null;
                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="(object)date"></param>
        /// <returns>DateTime</returns>
        public static DateTime GetDateOrNow(object date)
        {
            DateTime result;
            if (date == null || string.IsNullOrEmpty(date.ToString()))
            {
                result = DateTime.Now;
            }
            else
            {
                try
                {
                    var res = GeneralUtils.ToDateTime(date);
                    result = res != null ? (DateTime)res : DateTime.Now;
                }
                catch (Exception)
                {
                    result = DateTime.Now;
                }
            }
            return result;
        }

        /// <summary>
        /// Gets the months between 2 dates
        /// </summary>
        /// <param name="(DateTime)firstDate, (DateTime)secondDate, "></param>
        /// <returns>double minutes</returns>
        public static IEnumerable<DateTime> MonthsBetween(DateTime startDate, DateTime endDate)
        {
            var result = Enumerable.Range(0, (endDate.Year - startDate.Year) * 12 + (endDate.Month - startDate.Month + 1))
                             .Select(m => new DateTime(startDate.Year, startDate.Month, 1).AddMonths(m));
            return result;
        }

        /// <summary>
        /// Gets the minutes between 2 dates
        /// </summary>
        /// <param name="(DateTime)firstDate, (DateTime)secondDate, "></param>
        /// <returns>double minutes</returns>
        public static double GetMinutesBetweenDates(DateTime firstDate, DateTime secondDate)
        {
            return (secondDate - firstDate).TotalMinutes;
        }

        /// <summary>
        /// Gets the days between 2 dates
        /// </summary>
        /// <param name="(DateTime)firstDate, (DateTime)secondDate, "></param>
        /// <returns>int days</returns>
        public static int GetDaysBetweenDates(DateTime firstDate, DateTime secondDate)
        {
            return secondDate.Subtract(firstDate).Days;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="(object)date"></param>
        /// <returns>{yyyyMMdd}</returns>
        public static string DisplayDateYYYYMMDD(this object val)
        {
            string result = string.Empty;

            if (val == null || string.IsNullOrEmpty(val.ToString()))
            {
                result = string.Empty;
            }
            else
            {
                DateTime date = new DateTime();
                var res = GeneralUtils.ToDateTime(date);
                date = res != null ? (DateTime)res : DateTime.Now;

                return date.ToString("yyyyMMdd");
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="(object)date"></param>
        /// <returns></returns>
        public static string ThDisplayDate(this object val)
        {
            string result = string.Empty;

            if (val == null || string.IsNullOrEmpty(val.ToString()))
            {
                result = string.Empty;
            }
            else
            {
                DateTime date = new DateTime();
                var res = GeneralUtils.ToDateTime(val);
                result = res != null ? ((DateTime)res).ToString("dd/MM/yyyy") : string.Empty;
                return result;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="(string)date"></param>
        /// <returns>DateTime?</returns>
        public static DateTime? ThGetDateOrNull(this object date)
        {
            DateTime? result = (DateTime?)null;
            if (date == null || string.IsNullOrEmpty(date.ToString()))
            {
                result = (DateTime?)null;
            }
            else
            {
                try
                {
                    var res = GeneralUtils.ToDateTime(date);
                    result = res != null ? (DateTime)res : DateTime.Now;
                }
                catch (Exception)
                {
                    result = (DateTime?)null;
                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="(object)date"></param>
        /// <returns>DateTime</returns>
        public static DateTime ThGetDateOrNow(this object date)
        {
            DateTime result;
            if (date == null || string.IsNullOrEmpty(date.ToString()))
            {
                result = DateTime.Now;
            }
            else
            {
                try
                {
                    var res = GeneralUtils.ToDateTime(date);
                    result = res != null ? (DateTime)res : DateTime.Now;
                }
                catch (Exception)
                {
                    result = DateTime.Now;
                }
            }
            return result;
        }
        public static object ThGetDateOrDBNUll(this object date)
        {
            object result;
            if (date == null || string.IsNullOrEmpty(date.ToString()))
            {
                result = DBNull.Value;
            }
            else
            {
                try
                {
                    var res = GeneralUtils.ToDateTime(date);
                    result = res != null ? (object)(DateTime)res : DBNull.Value;
                }
                catch (Exception)
                {
                    result = DBNull.Value;
                }
            }
            return result;
        }
        public static DateTime ThGetDate(this object date)
        {
            DateTime result;
            if (date == null || string.IsNullOrEmpty(date.ToString()))
            {
                result = DateTime.Now;
            }
            else
            {
                result = (DateTime)date;
            }
            return result;
        }
        public static object ToSqlDateOutTime(this object value)
        {
            object result;
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                result = DBNull.Value;
            }
            else
            {
                result = GeneralUtils.ToDateTime(value);
            }
            return result;
        }
        //public static DateTime ThGetDateOrNullChageDateFormat(this object date)
        //{
        //    if (date == null || string.IsNullOrEmpty(date.ToString()))
        //    {
        //        DateTime s = DateTime.Now;
        //        return s;
        //    }
        //    else
        //    {
        //        try
        //        {
        //            string[] words = date.ToString().Split('/');
        //            date = words[1] + '/' + words[0] + '/' + words[2]; //need for local host
        //            DateTime d = Convert.ToDateTime(date);
        //            return d;
        //        }
        //        catch(Exception e)
        //        {
        //            return Convert.ToDateTime(e);
        //        }

        //    }
        //}

        public static object ToSqlDate(this object value)
        {
            object result = DBNull.Value;

            if (value != null && !string.IsNullOrEmpty(value.ToString()))
            {
                result = GeneralUtils.ToDateTime(value);
                if (result == null) result = DBNull.Value;
            }
            return result;
        }

        #endregion


     

        #region GlobalResources

       

        public static object DisplayLikeHour(this object value)
        {
            string result = string.Empty;

            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                result = string.Empty;
            }
            else
            {
                double Timediff = value.ThGetDouble();
                if (Timediff == 0) return string.Empty;

                int Hour = (int)Timediff;
                double Minute = Timediff % 1;
                Minute = Math.Round(Minute * 60);
                Minute /= 100;
                result = string.Format("{0:0.00}", (Hour + Minute)).ToString().Replace(".", ":");
            }
            return result;
        }
        public static object DoZero(this object value)
        {
            string result = value.ThGetTrimedString();
            if (value == null || string.IsNullOrEmpty(value.ToString()) || value.ThGetDouble() == 0)
            {
                result = string.Empty;
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="(object)value"></param>
        /// <param name="(string)strVal"></param>
        /// <returns>string or global resource value</returns>
        public static string GetGlobalResourceOrString(object value, string strVal)
        {
            string result = string.Empty;

            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                result = strVal;
            }
            else
            {
                result = value.ToString().Trim();
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="(object)value"></param>
        /// <returns>this string or global resource value</returns>
        public static string GetGlobalResourceOrThisString(this string strVal, object value)
        {
            string result = string.Empty;

            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                result = strVal;
            }
            else
            {
                result = value.ToString().Trim();
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="(object)value"></param>
        /// <returns>this global resource value or string</returns>
        public static string ThGetThisGlobalResourceOrString(this object value, string strValue)
        {
            string result = string.Empty;

            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                result = strValue;
            }
            else
            {
                result = value.ToString().Trim();
            }
            return result;
        }

        #endregion

        #region String

        /// <summary>
        /// Removes all leading and trailing occurances of the specified String (toRemove) from the current String (baseString)
        /// </summary>
        /// <param name="baseString">current object </param>
        /// <param name="toRemove">string to remove</param>
        /// <returns>String</returns>
        public static string RemoveStartsEndsWith(string baseString, string toRemove)
        {
            baseString = baseString.Trim();
            if (baseString.EndsWith(toRemove))
            {
                baseString = baseString.Substring(0, baseString.Length - toRemove.Length);
            }

            if (baseString.StartsWith(toRemove))
            {
                baseString = baseString.Substring(toRemove.Length);
            }

            return baseString;
        }

        /// <summary>
        /// trim strings
        /// </summary>
        /// <param name="(object)value"></param>
        /// <returns>trimed string value</returns>
        public static string GetTrimedString(object value)
        {
            string result = string.Empty;

            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                result = string.Empty;
            }
            else
            {
                result = value.ToString().Trim();
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="toLength"></param>
        /// <returns></returns>
        public static string CutString(string value, int toLength)
        {
            if (value.Length > toLength)
            {
                string cuttedString = value.Substring(0, toLength);
                return string.Concat(cuttedString, "...");
            }

            return value;
        }

        /// <summary>
        /// trim strings
        /// </summary>
        /// <param name="this (object)value"></param>
        /// <returns>trimed string value</returns>
        public static string ThGetTrimedString(this object value)
        {

            string result = string.Empty;

            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                result = string.Empty;
            }
            else
            {
                result = value.ToString().Trim();
            }
            return result;
        }
        public static string ThGetEncodeString(this object value)
        {
            string result = string.Empty;
            string str = value.ThGetTrimedString();
            int i = 0;
            while (i < str.Length)
            {
                if (((int)str[i]) < 97 & !(((int)str[i]) > 47 & ((int)str[i]) < 59) & ((int)str[i]) != 32 & ((int)str[i]) != 58)
                {
                    string escape = Uri.HexEscape(str[i]);
                    result += escape;
                }
                else
                {
                    result += str[i];
                }
                i++;

            }
            return result;
        }
        public static string ThGetDecodeString(this object value)
        {
            string str = value.ThGetTrimedString();
            string result = string.Empty;
            int index = 0;
            while (index < str.Length)
                result += Uri.HexUnescape(str, ref index);
            return result;

        }
        /// <summary>
        /// 
        /// /// <summary>
        /// strings with '
        /// </summary>
        /// <param name="this (object)value"></param>
        /// <returns>string value with '</returns>
        public static string ThGetStringForSql(this object value)
        {
            string result = string.Empty;

            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                result = string.Empty;
            }
            else
            {
                result = value.ToString().Trim().Replace("'", "''");
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="toLength"></param>
        /// <returns></returns>
        public static string CutStrStart(this string value, int toLength)
        {
            if (value.Length > toLength)
            {
                var start = value.Length - toLength - 1;
                string cuttedString = value.Substring(start, toLength);
                return string.Concat("...", cuttedString);
            }

            return value;
        }

        public static bool ThIsNullOrEmpty(this string s)
        {
            return s == null || s.Trim() == string.Empty;
        }

        public static string TrimStart(this string This, char s)
        {
            return This.TrimStart(new char[] { s });
        }

        public static string TrimEnd(this string This, char s)
        {
            return This.TrimEnd(new char[] { s });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="toLength"></param>
        /// <returns></returns>
        public static string CutStr(this string value, int toLength)
        {
            if (value.Length > toLength)
            {
                string cuttedString = value.Substring(0, toLength);
                return string.Concat(cuttedString, "...");
            }

            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="This" datetime></param>
        /// <returns>string</returns>
        public static string ThToSqlDateFormat(this DateTime This)
        {
            return string.Format("{0}-{1}-{2} {3}:{4}:{5}.{6}", This.Year, This.ToString("MM"), This.ToString("dd"), This.ToString("HH"), This.ToString("mm"), This.ToString("ss"), This.ToString("fff"));
        }

        public static object ThGetSortColumnCorrectFormat(this object value)
        {
            object result;

            DateTime date;

            if (!DateTime.TryParseExact(value.ToString(), "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                result = value;
            }
            else
            {
                result = date.ThToSqlDateFormat();
            }

            return result;
        }

        #endregion

        #region Int

        /// <summary>
        /// 
        /// </summary>
        /// <param name="(string)value"></param>
        /// <returns>int?</returns>
        public static int GetInt(object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return 0;
            }
            else
            {
                int res;
                bool isInt = int.TryParse(value.ToString(), out res);
                if (isInt)
                {
                    return res;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="(string)value"></param>
        /// <returns>int?</returns>
        public static int? GetIntOrNull(object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return (int?)null;
            }
            else
            {
                int res;
                bool isInt = int.TryParse(value.ToString(), out res);
                if (isInt)
                {
                    return res;
                }
                else
                {
                    return (int?)null;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="(object)value"></param>
        /// <returns>int value</returns>
        public static int ThGetIntFromBool(this object value)
        {
            int result = 0;

            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                result = 0;
            }
            else
            {
                if (Convert.ToBoolean(value))
                {
                    result = 1;
                }
                else
                {
                    result = 0;
                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="(object)value"></param>
        /// <returns>Int value</returns>
        public static int GetIntFromCheckBox(object value)
        {
            int result = 0;

            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                result = 0;
            }
            else
            {
                if (value.ToString() == "checked")
                {
                    result = 1;
                }
                else
                {
                    result = 0;
                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="(object)value"></param>
        /// <returns>Int value</returns>
        public static int ThGetIntFromCheckBox(this object value)
        {
            int result = 0;

            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                result = 0;
            }
            else
            {
                if (value.ToString() == "checked")
                {
                    result = 1;
                }
                else
                {
                    result = 0;
                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="(string)value"></param>
        /// <returns>int?</returns>
        public static int ThGetInt(this object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return 0;
            }
            else
            {
                int res;
                bool isInt = int.TryParse(value.ToString(), out res);
                if (isInt)
                {
                    return res;
                }
                else
                {
                    return 0;
                }
            }
        }
        public static object ThGetIntToNull(this object value)
        {
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return null;
            }
            else if (value.ThGetInt() == 0)
            {
                return null;
            }
            else
            {
                return value;
            }
        }

        public static object ThGetIntToDBNull(this object value)
        {
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return DBNull.Value;
            }
            else if (value.ThGetInt() == 0)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }

        public static string ThGetReplaceDateOrNull(this object value)
        {
            //MTNS.Core.SendMail.Send("esterg@comax.co.il", value.ToString(), " GeneralUtils begin ");
            try
            {
                string year = DateTime.Parse(value.ThGetTrimedString().ToString()).Year.ToString();
                string month = DateTime.Parse(value.ThGetTrimedString().ToString()).Month.ToString();
                string day = DateTime.Parse(value.ThGetTrimedString().ToString()).Day.ToString();
                //MTNS.Core.SendMail.Send("esterg@comax.co.il", year+" "+ month+ " " + day, " GeneralUtils end");
                return month + '-' + day + '-' + year;
            }

            catch
            {
                // MTNS.Core.SendMail.Send("esterg@comax.co.il", value.ToString(), " GeneralUtils catch ");
                return null;
            }

        }

        //public static DateTime? ThGetReplaceDateOrNulls(this object value)
        //{
        //    try
        //    {
        //        object result;
        //        string year = DateTime.Parse(value.ThGetTrimedString().ToString()).Year.ToString();
        //        string month = DateTime.Parse(value.ThGetTrimedString().ToString()).Month.ToString();
        //        string day = DateTime.Parse(value.ThGetTrimedString().ToString()).Day.ToString();
        //        return  string.Format("{0}-{1}-{2} {3}:{4}:{5}", year, month, day, "00", "00", "00");
        //    }
        //          }
        //    catch
        //    {
        //        return (DateTime?)null;
        //    }

        //}



        public static object ThGetIntOrDBNull(this object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return DBNull.Value;
            }
            else
            {
                int res;
                bool isInt = int.TryParse(value.ToString(), out res);
                if (isInt)
                {
                    return res;
                }
                else
                {
                    return DBNull.Value;
                }
            }
        }

        public static object ThGetZeroOrDBNull(this object value)
        {
            if (value.ThGetInt() == 0)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="(string)value"></param>
        /// <returns>int?</returns>
        public static int? ThGetIntOrNull(this object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return (int?)null;
            }
            else
            {
                int res;
                bool isInt = int.TryParse(value.ToString(), out res);
                if (isInt)
                {
                    return res;
                }
                else
                {
                    return (int?)null;
                }
            }
        }

        #endregion

        #region Bool

        /// <summary>
        /// 
        /// </summary>
        /// <param name="(object)value"></param>
        /// <returns>Bool? value</returns>
        public static bool? GetBoolOrNull(object value)
        {
            bool? result = null;

            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                result = null;
            }
            else
            {
                if (value.ToString() == "1" || value.ToString().ToLower() == "true" || value.ToString() == "checked")
                {
                    result = true;
                }
                else if (value.ToString() == "0" || value.ToString().ToLower() == "false")
                {
                    result = false;
                }
                else
                {
                    result = null;
                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="(object)value"></param>
        /// <returns>bool value</returns>
        public static bool GetBool(object value)
        {
            bool result = false;

            if (value == null || value == DBNull.Value || string.IsNullOrEmpty(value.ToString()))
            {
                result = false;
            }
            else
            {
                if (value.ToString().ToLower() == "true" || value.ToString() == "1" || value.ToString() == "checked")
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="(object)value"></param>
        /// <returns>Bool? value</returns>
        public static bool? ThGetBoolOrNull(this object value)
        {
            bool? result = null;

            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                result = null;
            }
            else
            {
                if (value.ToString() == "1" || value.ToString().ToLower() == "true" || value.ToString() == "checked")
                {
                    result = true;
                }
                else if (value.ToString() == "0" || value.ToString().ToLower() == "false")
                {
                    result = false;
                }
                else
                {
                    result = null;
                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="(object)value"></param>
        /// <returns>Bool value</returns>
        public static bool ThGetBool(this object value)
        {
            bool result = false;

            if (value == null || value == DBNull.Value || string.IsNullOrEmpty(value.ToString()))
            {
                result = false;
            }
            else
            {
                if (value.ToString().ToLower() == "true" || value.ToString() == "1" || value.ToString() == "checked" || value.ToString() == "on")
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }

        #endregion


        #region Short

        /// <summary>
        ///  Get the short value from String
        /// </summary>
        /// <param name="(object)value"></param>
        /// <returns>int</returns>
        public static short GetShort(object value)
        {

            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return 0;
            }
            else
            {
                short res;
                bool isShort = short.TryParse(value.ToString(), out res);
                if (isShort)
                {
                    return res;
                }
                else
                {
                    return 0;
                }
            }
        }
        /// <summary>
        ///  Get the short value from String
        /// </summary>
        /// <param name="(object)value"></param>
        /// <returns>short</returns>
        public static short ThGetShort(this object value)
        {

            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return 0;
            }
            else
            {
                short res;
                bool isShort = short.TryParse(value.ToString(), out res);
                if (isShort)
                {
                    return res;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        ///  Get the short value from String
        /// </summary>
        /// <param name="(object)value"></param>
        /// <returns>short?</returns>
        public static short? ThGetShortOrNull(this object value)
        {
            short? result = 0;
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                result = (short?)null;
            }
            else
            {
                short res;
                bool isShort = short.TryParse(value.ToString(), out res);
                if (isShort)
                {
                    result = res;
                }
                else
                {
                    result = (short?)null;
                }
            }
            return result;
        }

        #endregion

    
        //לבדוק שחוזר רק מצבים תקינים לצורך אבטחה
        public static string ChkMode(this object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return string.Empty;
            }
            else
            {
                string mode = value.ToString();
                if (mode == "add" || mode == "update" || mode == "delete" || mode == "copy")
                    return mode;
                else
                    return string.Empty;
            }
        }

        //לבדוק שמגיע רק נתונים תקינים לצורך אבטחה
        public static string ChkeditView(this object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return string.Empty;
            }
            else
            {
                string view = value.ToString();
                if (view == "inline")
                    return view.ToString();
                else
                    return string.Empty;
            }
        }
        //קבלת שנת לימודים לפי חודש שנה
        public static int GetStudyYear(int Year = 0, int Month = 0)
        {
            if (Year == 0) Year = DateTime.Today.Year;
            if (Month == 0) Month = DateTime.Today.Month;
            int StudyYear = Year;
            if (Month > 8) StudyYear++;
            return StudyYear;
        }

        //קבלת שנה עברית
        public static string GetHebrewYear(DateTime anyDate)
        {
            // Create the hebrew culture to use hebrew (Jewish) calendar 
            CultureInfo jewishCulture = CultureInfo.CreateSpecificCulture("he-IL");
            jewishCulture.DateTimeFormat.Calendar = new HebrewCalendar();

            string Year = anyDate.ToString("yyyy", jewishCulture);
            return Year;
        }
        //קבלת שנה עברית עפ שנה לועזית
        public static string GetHebrewYearByYear(int Year)
        {
            // Create the hebrew culture to use hebrew (Jewish) calendar 
            CultureInfo jewishCulture = CultureInfo.CreateSpecificCulture("he-IL");
            jewishCulture.DateTimeFormat.Calendar = new HebrewCalendar();
            DateTime Date = new DateTime(Year, 1, 1);
            string sYear = Date.ToString("yyyy", jewishCulture);
            return sYear;
        }

        //קבלת שנה לועזית עפ שנה עברית
        public static int GetYearByHebrewYear(string HebrewYear)
        {
            Dictionary<string, int> yearsConvert = new Dictionary<string, int>();
            yearsConvert["תשע\"ג"] = 2013;
            yearsConvert["תשע\"ד"] = 2014;
            yearsConvert["תשע\"ה"] = 2015;
            yearsConvert["תשע\"ו"] = 2016;
            yearsConvert["תשע\"ז"] = 2017;
            yearsConvert["תשע\"ח"] = 2018;
            yearsConvert["תשע\"ט"] = 2019;
            yearsConvert["תש\"פ"] = 2020;
            yearsConvert["תשפ\"א"] = 2021;
            yearsConvert["תשפ\"א"] = 2021;
            yearsConvert["תשפ\"ב"] = 2022;
            yearsConvert["תשפ\"ג"] = 2023;
            yearsConvert["תשפ\"ד"] = 2024;
            yearsConvert["תשפ\"ה"] = 2025;
            yearsConvert["תשפ\"ו"] = 2026;
            yearsConvert["תשפ\"ז"] = 2027;
            yearsConvert["תשפ\"ח"] = 2028;
            yearsConvert["תשפ\"ט"] = 2029;

            return yearsConvert[HebrewYear];
        }

     
        public static DateTime GetDateOfDayInTheWeekOfDate(this DateTime from, DayOfWeek dayOfWeek)
        {
            int start = (int)from.DayOfWeek;
            int target = (int)dayOfWeek;
            return from.AddDays(target - start);
        }

        public static bool validateIdentityId(string identity)
        {
            bool res = false;
            if (identity.Length != 9)
                res = false;
            else
            {
                //var Identity = "000000000".substr(0, 9 - $field.val().length) + $field.val();
                int[] Arr = { 1, 2, 1, 2, 1, 2, 1, 2 };
                int temp = 0;
                int Sum = 0;

                for (int i = 0; i < 8; i++)
                {
                    temp = Arr[i] * (identity.Substring(i, 1).ThGetInt());
                    if (temp >= 10) temp = temp.ThGetTrimedString().Substring(0, 1).ThGetInt() + temp.ThGetTrimedString().Substring(1, 1).ThGetInt();
                    Sum += temp;
                }

                if (Sum >= 10) Sum = Sum.ThGetTrimedString().Substring(1, 1).ThGetInt();
                if (Sum != 0) Sum = 10 - Sum;
                string digit = identity.Substring(8, 1);
                if (digit.ThGetInt() > 0)
                {
                    if (digit.ThGetInt() == Sum) res = true;
                }
            }
            if (!res)
            {
                return false;
            }
            return true;
        }


        public static bool validatePhone(string phone)
        {
            string code = phone.Substring(0, 2);
            string[] codePhone2 = { "03", "04", "08", "09", "02" };
            if (codePhone2.Contains(code))
            {
                if (phone.Length == 9)
                    return true;
            }
            code = phone.Substring(0, 3);
            string[] codePhone3 = { "071", "072", "073", "074", "076", "077", "079" };
            if (codePhone3.Contains(code))
            {
                if (phone.Length == 10)
                    return true;
            }
            return false;
        }

        public static bool validateMobile(string mobile)
        {
            string code = mobile.Substring(0, 3);
            string[] codeMobile = { "050", "051", "052", "053", "054", "055", "056", "058", "059" };
            if (codeMobile.Contains(code))
            {
                if (mobile.Length == 10)
                    return true;
            }
            return false;
        }


     

    }
}
