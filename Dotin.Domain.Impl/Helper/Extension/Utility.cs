namespace Dotin.HostApi.Domain.Helper.Extension
{
    using System;
    using System.Data;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    public static class Utility
    {
        #region Validation
        //آیا ایمیل است؟
        public static bool IsEmail(this string str)
        {
            return Regex.IsMatch(str, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        }
        //آیا آدرس است؟
        public static bool IsUrl(this string str)
        {
            return Regex.IsMatch(str, @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
            //return Regex.IsMatch(str, @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?");
        }
        //آیا موبایل است؟
        public static bool IsMobile(this string str)
        {
            return Regex.IsMatch(str, @"^(((\+|00)98)|0)?9[123]\d{8}$");
        }
        //آیا زمان 12 ساعته است؟
        public static bool IsTimeSpan12(this string str)
        {
            return Regex.IsMatch(str, @"^(1[012]|[1-9]):([0-5]?[0-9]) (AM|am|PM|pm)$");
        }
        //آیا زمان 12 ساعته فارسی است؟
        public static bool IsTimeSpan12P(this string str)
        {
            return Regex.IsMatch(str, @"^(1[012]|[1-9]):([0-5]?[0-9]) (ق ظ|ق.ظ|ب ظ|ب.ظ)$");
        }
        //آیا زمان 24 ساعته است؟
        //01:24
        public static bool IsTimeSpan24Hhm(this string str)
        {
            return Regex.IsMatch(str, @"^([01][0-9]|2[0-3]):([0-5]?[0-9])$");
        }
        //آیا زمان 24 ساعته است؟
        //1:24
        public static bool IsTimeSpan24Hm(this string str)
        {
            return Regex.IsMatch(str, @"^(2[0-3]|[01]?\d):([0-5]?[0-9])$");
        }
        //آیا تاریخ شمسی و ساعت است؟
        //مثال
        // 1394/01/01 01:01
        // 94/01/01 01:01
        // 94/1/01 01:01
        // 94/1/1 01:01
        // 94/1/1 1:01
        // 94/1/1 1:1
        public static bool IsPersianDateTime(this string str)
        {
            return Regex.IsMatch(str, @"^(13\d{2}|[1-9]\d)/(1[012]|0?[1-9])/([12]\d|3[01]|0?[1-9]) ([01][0-9]|2[0-3]):([0-5]?[0-9])$");
        }
        //زمان صحیح است؟
        public static bool IsTime(this string str)
        {
            return Regex.IsMatch(str, @"^([01][0-9]|2[0-3]):([0-5]?[0-9])$");
        }
        //تاریخ شمسی کامل است؟
        public static bool IsPersianDate(this string str)
        {
            return Regex.IsMatch(str, @"^(13\d{2}|[1-9]\d)/(1[012]|0?[1-9])/([12]\d|3[01]|0?[1-9])$");
        }
        //تاریخ شمسی کامل است؟
        public static bool IsPersianDate2(this string str)
        {
            return Regex.IsMatch(str, @"^(13\d{2})/(1[012]|0?[1-9])/([12]\d|3[01]|0?[1-9])$");
        }
        //آیا تاریخ ماه شمسی است؟
        public static bool IsPersianMonthDate(this string str)
        {
            return Regex.IsMatch(str, @"^(13\d{2}|[1-9]\d)/(1[012]|0?[1-9])$");
        }
        //آیا Unicode است؟
        public static bool IsUnicode(this string str)
        {
            return str.Any(ch => (int)ch > 255);
        }
        //آیا عددی است؟ (تعداد کاراکتر نا محدود)
        public static bool IsDigit(this string str)
        {
            return str.All(char.IsDigit);
        }
        //آیا Int است؟
        public static bool IsInt(this string str)
        {
            try
            { 
                Convert.ToInt32(str.Replace(",", ""));
                return true;
            }
            catch
            {
                return false;
            }
        }
        //آیا Byte است؟
        public static bool IsByte(this string str)
        {
            try
            {
                Convert.ToByte(str);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //آیا Decimal است؟
        public static bool IsDecimal(this string str)
        {
            try
            {
                Convert.ToDecimal(str.Replace('/', '.'));
                return true;
            }
            catch
            {
                return false;
            }
        }
        //آیا ساعت زمان است؟
        public static bool IsTimeSpan(this string str)
        {
            TimeSpan ts;
            return System.TimeSpan.TryParse(str, out ts);
        }
        //آیا کد ملی است؟
        public static bool IsNationalCode(this string nationalcode)
        {
            if (string.IsNullOrEmpty(nationalcode)) return false;
            if (!new Regex(@"\d{10}").IsMatch(nationalcode)) return false;
            var array = nationalcode.ToCharArray();
            var allDigitEqual = new[] { "0000000000", "1111111111", "2222222222", "3333333333", "4444444444", "5555555555", "6666666666", "7777777777", "8888888888", "9999999999" };
            if (allDigitEqual.Contains(nationalcode)) return false;
            var j = 10;
            var sum = 0;
            for (var i = 0; i < array.Length - 1; i++)
            {
                sum += Int32.Parse(array[i].ToString(CultureInfo.InvariantCulture)) * j;
                j--;
            }
            var div = sum / 11;
            var r = div * 11;
            var diff = Math.Abs(sum - r);
            if (diff <= 2)
            {
                return diff == Int32.Parse(array[9].ToString(CultureInfo.InvariantCulture));
            }
            var temp = Math.Abs(diff - 11);
            return temp == Int32.Parse(array[9].ToString(CultureInfo.InvariantCulture));
        }
        //آیا کدملی است؟ + نمایش خروجی
        public static bool IsNationalCode(this string nationalcode, out string msg)
        {
            try
            {
                var chArray = nationalcode.Trim().ToCharArray();
                var numArray = new int[chArray.Length];
                for (var i = 0; i < chArray.Length; i++)
                {
                    numArray[i] = (int)char.GetNumericValue(chArray[i]);
                }
                var num2 = numArray[9];
                switch (nationalcode.Trim())
                {
                    case "0000000000":
                    case "1111111111":
                    case "22222222222":
                    case "33333333333":
                    case "4444444444":
                    case "5555555555":
                    case "6666666666":
                    case "7777777777":
                    case "8888888888":
                    case "9999999999":
                        msg = "کد ملی وارد شده صحیح نمی باشد";
                        return false;
                }
                var num3 = ((((((((numArray[0] * 10) + (numArray[1] * 9)) + (numArray[2] * 8)) + (numArray[3] * 7)) + (numArray[4] * 6)) + (numArray[5] * 5)) + (numArray[6] * 4)) + (numArray[7] * 3)) + (numArray[8] * 2);
                var num4 = num3 - ((num3 / 11) * 11);
                if ((((num4 == 0) && (num2 == num4)) || ((num4 == 1) && (num2 == 1))) || ((num4 > 1) && (num2 == Math.Abs(num4 - 11))))
                {
                    msg = "کد ملی صحیح می باشد";
                    return true;
                }
                else
                {
                    msg = "کد ملی نامعتبر است";
                    return false;
                }
            }
            catch (Exception)
            {
                msg = "لطفا یک عدد 10 رقمی وارد کنید";
                return false;
            }
        }
        //آیا پسورد قوی است؟
        public static bool IsStrongPassword(this string str)
        {
            var isStrong = Regex.IsMatch(str, @"[\d]");
            if (isStrong) isStrong = Regex.IsMatch(str, @"[a-z]");
            if (isStrong) isStrong = Regex.IsMatch(str, @"[A-Z]");
            if (isStrong) isStrong = Regex.IsMatch(str, @"[\s~!@#\$%\^&\*\(\)\{\}\|\[\]\\:;'?,.`+=<>\/]");
            if (isStrong) isStrong = str.Length >= 6;
            return isStrong;
        }
        //آیا پسورد قوی است؟ + نمایش پیام خروجی
        public static bool IsStrongPassword(this string str, out string message)
        {
            message = "رمز عبور دارای امنیت بالایی می باشد";
            if (!Regex.IsMatch(str, @"[\d]"))
            {
                message = "رمز عبور باید شامل عدد باشد";
                return false;
            }
            if (!Regex.IsMatch(str, @"[aA-zZ]"))
            {
                message = "رمز عبور باید شامل حروف انگلیسی باشد";
                return false;
            }
            if (str.Length < 6)
            {
                message = "رمز عبور باید 6 کاراکتر به بالا باشد";
                return false;
            }
            return true;

            //message = "پسورد دارای امنیت بالایی می باشد";
            //if (!Regex.IsMatch(str, @"[\d]"))
            //{
            //    message = "رمز عبور باید شامل عدد باشد";
            //    return false;
            //}
            //if (!Regex.IsMatch(str, @"[a-z]"))
            //{
            //    message = "رمز عبور باید شامل حروف انگلیسی کوچک باشد";
            //    return false;
            //}
            //if (!Regex.IsMatch(str, @"[A-Z]"))
            //{
            //    message = "رمز عبور باید شامل حروف انگلیسی بزرگ باشد";
            //    return false;
            //}
            //if (!Regex.IsMatch(str, @"[\s~!@#\$%\^&\*\(\)\{\}\|\[\]\\:;'?,.`+=<>\/]"))
            //{
            //    message = "رمز عبور باید شامل کاراکتر های خاص ( ~ ? ! @ # $ % ^ & * , ... ) باشد";
            //    return false;
            //}
            //if (str.Length < 6)
            //{
            //    message = "رمز عبور باید 6 کاراکتر به بالا باشد";
            //    return false;
            //}
            //return true;
        }
        //آیا متن فارسی است؟
        public static bool IsFarsi(this string Str)
        {
            //char[] AllowChr = new char[47] { 'آ', 'ا', 'ب', 'پ', 'ت', 'ث', 'ج', 'چ', 'ح', 'خ', 'د', 'ذ', 'ر', 'ز', 'ژ', 'س', 'ش', 'ص', 'ض', 'ط', 'ظ', 'ع', 'غ', 'ف', 'ق', 'ک', 'گ', 'ل', 'ا', 'ن', 'و', 'ه', 'ی', 'ة', 'ي', 'ؤ', 'إ', 'أ', 'ء', 'ئ', 'ۀ', ' ', 'ك', 'ﮎ', 'ﮏ', 'ﮐ', 'ﮑ' };
            var AllowChar = new[] { 1590, 1589, 1579, 1602, 1601, 1594, 1593, 1607, 1582, 1581, 1580, 1670, 1662, 1588, 1587, 1740, 1576, 1604, 1575, 1578, 1606, 1605, 1705, 1711, 1592, 1591, 1586, 1585, 1584, 1583, 1574, 1608, 1577, 1610, 1688, 1572, 1573, 1571, 1569, 1570, 1728, 32, 1603, 64398, 64399, 64400, 64401 };
            return Str.Select(item => (int)item).All(AllowChar.Contains);
        }
        //آیا پسوند فایل تصویر است؟
        public static bool IsImageExt(this string fileName)
        {
            var exts = new[] { ".jpeg", ".jpg", ".png", ".bmp", ".gif", ".tif", ".tiff" };
            var ext = Path.GetExtension(fileName).ToLower();
            return Array.IndexOf(exts, ext) != -1;
        }
        #endregion

        #region DateTime
        //تصحیح تاریخ به نوع استاندارد 
        public static string FixDateTime(this string text)
        {
            string result;
            string year;
            string month;
            var day = "00";
            string hour;
            string min;
            var sec = "00";
            var arr = text.Split(' ');

            if (arr.Length == 1)
            {
                if (arr[0].Contains('/'))
                {
                    //only date
                    var arr2 = arr[0].Split('/');
                    if (arr2.Length == 2)
                    {
                        //has year
                        if (arr2[0].Length == 2)//92
                            year = "13" + arr2[0];
                        else if (arr2[0].Length == 4)//1392
                            year = arr2[0];
                        else
                            throw new FormatException();

                        //has month
                        if (arr2[1].Length == 1)//9
                            month = "0" + arr2[1];
                        else if (arr2[1].Length == 2)//09
                            month = arr2[1];
                        else
                            throw new FormatException();
                    }
                    else if (arr2.Length == 3)
                    {
                        //has year
                        if (arr2[0].Length == 2)//92
                            year = "13" + arr2[0];
                        else if (arr2[0].Length == 4)//1392
                            year = arr2[0];
                        else
                            throw new FormatException();

                        //has month
                        if (arr2[1].Length == 1)//9
                            month = "0" + arr2[1];
                        else if (arr2[1].Length == 2)//09
                            month = arr2[1];
                        else
                            throw new FormatException();

                        //has day
                        if (arr2[2].Length == 1)//5
                            day = "0" + arr2[2];
                        else if (arr2[2].Length == 2)//05
                            day = arr2[2];
                        else
                            throw new FormatException();
                    }
                    else
                    {
                        throw new FormatException();
                    }
                    result = year + "/" + month + "/" + day;
                }
                else if (arr[0].Contains(':'))
                {
                    //only time
                    var arr3 = arr[0].Split(':');
                    if (arr3.Length == 2)
                    {
                        //has hour
                        if (arr3[0].Length == 1)//2
                            hour = "0" + arr3[0];
                        else if (arr3[0].Length == 2)//02
                            hour = arr3[0];
                        else
                            throw new FormatException();

                        //has min
                        if (arr3[1].Length == 1)//8
                            min = "0" + arr3[1];
                        else if (arr3[1].Length == 2)//08
                            min = arr3[1];
                        else
                            throw new FormatException();
                    }
                    else if (arr3.Length == 3)
                    {
                        //has hour
                        if (arr3[0].Length == 1)//2
                            hour = "0" + arr3[0];
                        else if (arr3[0].Length == 2)//02
                            hour = arr3[0];
                        else
                            throw new FormatException();

                        //has min
                        if (arr3[1].Length == 1)//8
                            min = "0" + arr3[1];
                        else if (arr3[1].Length == 2)//08
                            min = arr3[1];
                        else
                            throw new FormatException();

                        //has sec
                        if (arr3[2].Length == 1)//1
                            sec = "0" + arr3[2];
                        else if (arr3[2].Length == 2)//01
                            sec = arr3[2];
                        else
                            throw new FormatException();
                    }
                    else
                    {
                        throw new FormatException();
                    }
                    result = hour + ":" + min + ":" + sec;
                }
                else
                {
                    throw new FormatException();
                }
            }
            else if (arr.Length == 2)
            {
                //has date
                var arr2 = arr[0].Split('/');
                if (arr2.Length == 2)
                {
                    //has year
                    if (arr2[0].Length == 2)//92
                        year = "13" + arr2[0];
                    else if (arr2[0].Length == 4)//1392
                        year = arr2[0];
                    else
                        throw new FormatException();

                    //has month
                    if (arr2[1].Length == 1)//9
                        month = "0" + arr2[1];
                    else if (arr2[1].Length == 2)//09
                        month = arr2[1];
                    else
                        throw new FormatException();
                }
                else if (arr2.Length == 3)
                {
                    //has year
                    if (arr2[0].Length == 2)//92
                        year = "13" + arr2[0];
                    else if (arr2[0].Length == 4)//1392
                        year = arr2[0];
                    else
                        throw new FormatException();

                    //has month
                    if (arr2[1].Length == 1)//9
                        month = "0" + arr2[1];
                    else if (arr2[1].Length == 2)//09
                        month = arr2[1];
                    else
                        throw new FormatException();

                    //has day
                    if (arr2[2].Length == 1)//5
                        day = "0" + arr2[2];
                    else if (arr2[2].Length == 2)//05
                        day = arr2[2];
                    else
                        throw new FormatException();
                }
                else
                {
                    throw new FormatException();
                }

                //has time
                var arr3 = arr[1].Split(':');
                if (arr3.Length == 2)
                {
                    //has hour
                    if (arr3[0].Length == 1)//2
                        hour = "0" + arr3[0];
                    else if (arr3[0].Length == 2)//02
                        hour = arr3[0];
                    else
                        throw new FormatException();

                    //has min
                    if (arr3[1].Length == 1)//8
                        min = "0" + arr3[1];
                    else if (arr3[1].Length == 2)//08
                        min = arr3[1];
                    else
                        throw new FormatException();
                }
                else if (arr3.Length == 3)
                {
                    //has hour
                    if (arr3[0].Length == 1)//2
                        hour = "0" + arr3[0];
                    else if (arr3[0].Length == 2)//02
                        hour = arr3[0];
                    else
                        throw new FormatException();

                    //has min
                    if (arr3[1].Length == 1)//8
                        min = "0" + arr3[1];
                    else if (arr3[1].Length == 2)//08
                        min = arr3[1];
                    else
                        throw new FormatException();

                    //has sec
                    if (arr3[2].Length == 1)//1
                        sec = "0" + arr3[2];
                    else if (arr3[2].Length == 2)//01
                        sec = arr3[2];
                    else
                        throw new FormatException();
                }
                else
                {
                    throw new FormatException();
                }
                result = year + "/" + month + "/" + day + " " + hour + ":" + min + ":" + sec;
            }
            else
            {
                throw new FormatException();
            }
            return result;
        }
        //نمایش تاریخ : 1394/01/01 3:30 PM
        public static string ToStringDateTime12(this DateTime DT)
        {
            return DT.ToString("yyyy/MM/dd hh:mm tt");
        }
        //نمایش تاریخ : 1394/01/01 15:30
        public static string ToStringDateTime24(this DateTime DT)
        {
            return DT.ToString("yyyy/MM/dd HH:mm");
        }
        //نمایش تاریخ : 1394/01/01
        public static string ToStringDate(this DateTime DT)
        {
            return DT.ToString("yyyy/MM/dd");
        }
        //نمایش تاریخ : 1394/01/01 3:30 ب.ظ
        public static string ToStringDateTime12P(this DateTime DT)
        {
            //return DT.ToString("yyyy/MM/dd hh:mm tt").Replace("AM", "ق.ظ").Replace("PM", "ب.ظ");
            var hh = DT.ToString("HH");
            var tt = hh.ToInt() < 12 ? "ق.ظ" : "ب.ظ";
            return DT.ToString("yyyy/M/d h:mm " + tt);
        }
        //نمایش تاریخ : 1 فروردین 1394
        public static string ToStringShamsiDate(this DateTime dt)
        {
            var PC = new PersianCalendar();
            var intYear = PC.GetYear(dt);
            var intMonth = PC.GetMonth(dt);
            var intDayOfMonth = PC.GetDayOfMonth(dt);
            string strMonthName;
            var strDayName = "";
            switch (intMonth)
            {
                case 1:
                    strMonthName = "فروردین";
                    break;
                case 2:
                    strMonthName = "اردیبهشت";
                    break;
                case 3:
                    strMonthName = "خرداد";
                    break;
                case 4:
                    strMonthName = "تیر";
                    break;
                case 5:
                    strMonthName = "مرداد";
                    break;
                case 6:
                    strMonthName = "شهریور";
                    break;
                case 7:
                    strMonthName = "مهر";
                    break;
                case 8:
                    strMonthName = "آبان";
                    break;
                case 9:
                    strMonthName = "آذر";
                    break;
                case 10:
                    strMonthName = "دی";
                    break;
                case 11:
                    strMonthName = "بهمن";
                    break;
                case 12:
                    strMonthName = "اسفند";
                    break;
                default:
                    strMonthName = "";
                    break;
            }

            //switch (enDayOfWeek)
            //{
            //    case DayOfWeek.Friday:
            //        strDayName = "جمعه";
            //        break;
            //    case DayOfWeek.Monday:
            //        strDayName = "دوشنبه";
            //        break;
            //    case DayOfWeek.Saturday:
            //        strDayName = "شنبه";
            //        break;
            //    case DayOfWeek.Sunday:
            //        strDayName = "یکشنبه";
            //        break;
            //    case DayOfWeek.Thursday:
            //        strDayName = "پنجشنبه";
            //        break;
            //    case DayOfWeek.Tuesday:
            //        strDayName = "سه شنبه";
            //        break;
            //    case DayOfWeek.Wednesday:
            //        strDayName = "چهارشنبه";
            //        break;
            //    default:
            //        strDayName = "";
            //        break;
            //}

            return (string.Format("{0} {1} {2} {3}", strDayName, intDayOfMonth, strMonthName, intYear));
        }
        #endregion

        #region Security
        //تبدیل متن به هش کد md5
        public static string ToMd5Hash(this string str)
        {
            if (string.IsNullOrEmpty(str)) return str;
            using (MD5 md5 = new MD5CryptoServiceProvider())
            {
                var originalBytes = ASCIIEncoding.Default.GetBytes(str);
                var encodedBytes = md5.ComputeHash(originalBytes);
                return BitConverter.ToString(encodedBytes).Replace("-", string.Empty);
            }
        }
        //تبدیل متن به هش کد mdf از نوع byte[]
        public static byte[] ToMd5HashByte(this string str)
        {
            using (MD5 md5 = new MD5CryptoServiceProvider())
            {
                var hashData = md5.ComputeHash(new UTF8Encoding().GetBytes(str));
                return hashData;
            }
        }
        //رمزنگاری متن
        public static string Encrypt(this string str)
        {
            var encData_byte = Encoding.UTF8.GetBytes(str);
            return Convert.ToBase64String(encData_byte);
        }
        //رمز گشایی متن رمز نگاری شده
        public static string Decrypt(this string str)
        {
            var encoder = new UTF8Encoding();
            var utf8Decode = encoder.GetDecoder();
            var todecode_byte = Convert.FromBase64String(str);
            var charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            var decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            return new string(decoded_char);
        }
        #endregion

        #region Converter
        //جدا سازی اعداد به صورت سه کاراکتری جهت نمایش قیمت
        public static string ToPrice(this object dec)
        {
            var Src = dec.ToString();
            Src = Src.Replace(".0000", "");
            if (!Src.Contains("."))
            {
                Src = Src + ".00";
            }
            var price = Src.Split('.');
            if (price[1].Length >= 2)
            {
                price[1] = price[1].Substring(0, 2);
                price[1] = price[1].Replace("00", "");
            }

            string Temp = null;
            int i;
            if ((price[0].Length % 3) >= 1)
            {
                Temp = price[0].Substring(0, (price[0].Length % 3));
                for (i = 0; i <= (price[0].Length / 3) - 1; i++)
                {
                    Temp += "," + price[0].Substring((price[0].Length % 3) + (i * 3), 3);
                }
            }
            else
            {
                for (i = 0; i <= (price[0].Length / 3) - 1; i++)
                {
                    Temp += price[0].Substring((price[0].Length % 3) + (i * 3), 3) + ",";
                }
                Temp = Temp.Substring(0, Temp.Length - 1);
                // Temp = price(0)
                //If price(1).Length > 0 Then
                //    Return price(0) + "." + price(1)
                //End If
            }
            if (price[1].Length > 0)
            {
                return Temp + "." + price[1];
            }
            else
            {
                return Temp;
            }
        }
        //تبدیل اعداد انگلیسی به فارسی
        public static string En2Fa(this string str)
        {
            return str.Replace("0", "۰").Replace("1", "۱").Replace("2", "۲").Replace("3", "۳").Replace("4", "۴").Replace("5", "۵").Replace("6", "۶").Replace("7", "۷").Replace("8", "۸").Replace("9", "۹");
        }
        //تبدیل اعداد فارسی به انگلیسی
        public static string Fa2En(this string str)
        {
            return str.Replace("۰", "0").Replace("۱", "1").Replace("۲", "2").Replace("۳", "3").Replace("۴", "4").Replace("۵", "5").Replace("۶", "6").Replace("۷", "7").Replace("۸", "8").Replace("۹", "9");
        }
        //تبدیل حروف عربی به فارسی
        public static string FixPersianChars(this string str)
        {
            return str.Replace("ﮎ", "ک").Replace("ﮏ", "ک").Replace("ﮐ", "ک").Replace("ﮑ", "ک").Replace("ك", "ک").Replace("ي", "ی");
        }
        //تبدیل عدد به متن فارسی
        public static string ToText(this int digit)
        {
            var txt = digit.ToString();
            var length = txt.Length;

            var a1 = new[] { "-", "یک", "دو", "سه", "چهار", "پنح", "شش", "هفت", "هشت", "نه" };
            var a2 = new[] { "ده", "یازده", "دوازده", "سیزده", "چهارده", "پانزده", "شانزده", "هفده", "هجده", "نوزده" };
            var a3 = new[] { "-", "ده", "بیست", "سی", "چهل", "پنجاه", "شصت", "هفتاد", "هشتاد", "نود" };
            var a4 = new[] { "-", "یک صد", "دویست", "سیصد", "چهارصد", "پانصد", "ششصد", "هفصد", "هشصد", "نهصد" };

            var result = "";
            var isDahegan = false;

            for (var i = 0; i < length; i++)
            {
                var character = txt[i].ToString();
                switch (length - i)
                {
                    case 7://میلیون
                        if (character != "0")
                        {
                            result += a1[Convert.ToInt32(character)] + " میلیون و ";
                        }
                        else
                        {
                            result = result.TrimEnd('و', ' ');
                        }
                        break;
                    case 6://صدهزار
                        if (character != "0")
                        {
                            result += a4[Convert.ToInt32(character)] + " و ";
                        }
                        else
                        {
                            result = result.TrimEnd('و', ' ');
                        }
                        break;
                    case 5://ده هزار
                        if (character == "1")
                        {
                            isDahegan = true;
                        }
                        else if (character != "0")
                        {
                            result += a3[Convert.ToInt32(character)] + " و ";
                        }
                        break;
                    case 4://هزار
                        if (isDahegan)
                        {
                            result += a2[Convert.ToInt32(character)] + " هزار و ";
                            isDahegan = false;
                        }
                        else
                        {
                            if (character != "0")
                            {
                                result += a1[Convert.ToInt32(character)] + " هزار و ";
                            }
                            else
                            {
                                result = result.TrimEnd('و', ' ');
                            }
                        }
                        break;
                    case 3://صد
                        if (character != "0")
                        {
                            result += a4[Convert.ToInt32(character)] + " و ";
                        }
                        break;
                    case 2://ده
                        if (character == "1")
                        {
                            isDahegan = true;
                        }
                        else if (character != "0")
                        {
                            result += a3[Convert.ToInt32(character)] + " و ";
                        }
                        break;
                    case 1://یک
                        if (isDahegan)
                        {
                            result += a2[Convert.ToInt32(character)];
                            isDahegan = false;
                        }
                        else
                        {
                            if (character != "0") result += a1[Convert.ToInt32(character)];
                            else result = result.TrimEnd('و', ' ');
                        }
                        break;
                }
            }
            return result;
        }
        //تبدیل هر چیزی به نوع عددی int
        public static int ToInt(this object obj)
        {
            try
            {
                return Convert.ToInt32(obj.ToString().Replace(",", ""));
            }
            catch
            {
                return Convert.ToInt32(obj);
            }
        }
        #endregion
    }

}