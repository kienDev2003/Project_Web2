using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web2_New
{
    public class Date
    {
        public static string GetCurrentDateTimeString()
        {
            // Đặt múi giờ cho Việt Nam
            TimeZoneInfo vietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

            // Lấy thời gian hiện tại theo múi giờ của Việt Nam
            DateTime currentVietnamDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, vietnamTimeZone);

            // Lấy giờ và phút
            int hour = currentVietnamDateTime.Hour;
            int minute = currentVietnamDateTime.Minute;

            // Lấy ngày, tháng và năm
            int day = currentVietnamDateTime.Day;
            int month = currentVietnamDateTime.Month;
            int year = currentVietnamDateTime.Year;

            // Chuyển thành chuỗi
            string hourMinute = $"{hour:D2}:{minute:D2}";
            string dayMonthYear = $"{day:D2}/{month:D2}/{year}";

            // Kết hợp thành chuỗi cuối cùng
            string datenow = $"{hourMinute}-{dayMonthYear}";

            // Trả về kết quả
            return datenow;
        }
    }
}