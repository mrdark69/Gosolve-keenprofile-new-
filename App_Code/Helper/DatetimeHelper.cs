﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Diagnostics;
using System.Net;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Summary description for globalHelper
/// </summary>
/// 
public enum App_Zone : int
{
    SE_Asia_Standard_Time = 1910



}

public static class DatetimeHelper
    {
        
        public static DateTime ApiService_ToUTC(this DateTime dDate)
        {
            return dDate.ToUniversalTime();
        }

        public static DateTime _UTCNow()
        {
            return DateTime.Now.ToUniversalTime();
        }

        public static DateTime ToZone(this DateTime instance, App_Zone appzone = App_Zone.SE_Asia_Standard_Time)
        {
            //Update By Darkman 
            var zone = TimeZoneInfo.FindSystemTimeZoneById(genZon(appzone));
            //TimeZone.CurrentTimeZone.StandardName;
            //DateTime.UtcNow
            return TimeZoneInfo.ConvertTimeFromUtc(instance, zone);
        //return DateTime.Now.AddHours(13);.ToUniversalTime()
        //int intMinute = (12 * 60);
        //return DateTime.Now.AddMinutes(intMinute);
    }


    /// <summary>
    /// Extension Method; Return DateTime.AddHousrs(+14)
    /// </summary>
    /// <param name="CurrentTime"></param>
    /// <returns></returns>
    public static DateTime ToThaiDateTime(this DateTime CurrentTime)
        {
            //return CurrentTime.AddHours(13);
            var zone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

        DateTime local = TimeZoneInfo.ConvertTimeFromUtc(CurrentTime, zone);
        return local;
        //int intMinute = (12 * 60);.ToUniversalTime()
        //return CurrentTime.AddMinutes(intMinute);
    }

    public static DateTime ApiService_TimeStampToDate(this string timeStamp)
        {
            //string timestamp = txtTimeStamp.Text;

            double doutimestamp = double.Parse(timeStamp);

            // First make a System.DateTime equivalent to the UNIX Epoch.
            System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);

            // Add the number of seconds in UNIX timestamp to be converted.
            dateTime = dateTime.AddSeconds(doutimestamp).ToLocalTime().ApiService_ToUTC(); ;

            // The dateTime now contains the right date/time so to format the string,
            // use the standard formatting methods of the DateTime object.
            //string printDate = dateTime.ToShortDateString() + " " + dateTime.ToShortTimeString();

            return dateTime;

        }


        public static String ApiService_DateToTimestamp(this DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssfff");
        }

        public static string genZon(App_Zone appzone)
        {
            string ret = string.Empty;
            switch (appzone)
            {
                case App_Zone.SE_Asia_Standard_Time:
                ret = "SE Asia Standard Time";
                    break;
            }

        return ret;
        }


    public static DateTime DateSplitYear(this string strTimeCurrent, char chrCharToSplit)
    {

        string[] arrstrTimeCurrent = strTimeCurrent.Split(chrCharToSplit);

        DateTime ret =  DateTime.Now.ApiService_ToUTC();

        if (arrstrTimeCurrent.Count() == 3)
        {
            int y = int.Parse(arrstrTimeCurrent[0]);
            int m = int.Parse(arrstrTimeCurrent[1]);
            int d = int.Parse(arrstrTimeCurrent[2]);
            ret = new DateTime(y, m, d);
        }

        return ret;
       
    }

}

//ID
//Time zone name
//Display string
//0
//Dateline Standard Time
//(UTC-12:00) International Date Line West
//110
//UTC-11
//(UTC-11:00) Coordinated Universal Time -11
//200
//Hawaiian Standard Time
//(UTC-10:00) Hawaii
//300
//Alaskan Standard Time
//(UTC-09:00) Alaska
//400
//Pacific Standard Time
//(UTC-08:00) Pacific Time(US and Canada)
//410
//Pacific Standard Time(Mexico)
//(UTC-08:00)Baja California
//500
//Mountain Standard Time
//(UTC-07:00) Mountain Time(US and Canada)
//510
//Mountain Standard Time(Mexico)
//(UTC-07:00) Chihuahua, La Paz, Mazatlan
//520
//US Mountain Standard Time
//(UTC-07:00) Arizona
//600
//Canada Central Standard Time
//(UTC-06:00) Saskatchewan
//610
//Central America Standard Time
//(UTC-06:00) Central America
//620
//Central Standard Time
//(UTC-06:00) Central Time(US and Canada)
//630
//Central Standard Time(Mexico)
//((UTC-06:00) Guadalajara, Mexico City, Monterrey
//700
//Eastern Standard Time
//(UTC-05:00) Eastern Time(US and Canada)
//710
//SA Pacific Standard Time
//(UTC-05:00) Bogota, Lima, Quito
//720
//US Eastern Standard Time
//(UTC-05:00) Indiana(East)
//840
//Venezuela Standard Time
//(UTC-04:30) Caracas
//800
//Atlantic Standard Time
//(UTC-04:00) Atlantic Time(Canada)
//810
//Central Brazilian Standard Time
//(UTC-04:00) Cuiaba
//820
//Pacific SA Standard Time
//(UTC-04:00) Santiago
//830
//SA Western Standard Time
//(UTC-04:00) Georgetown, La Paz, Manaus, San Juan
//850
//Paraguay Standard Time
//(UTC-04:00) Asuncion
//900
//Newfoundland Standard Time
//(UTC-03:30) Newfoundland
//910
//E.South America Standard Time
//(UTC-03:00) Brasilia
//920
//Greenland Standard Time
//(UTC-03:00) Greenland
//930
//Montevideo Standard Time
//(UTC-03:00) Montevideo
//940
//SA Eastern Standard Time
//(UTC-03:00) Cayenne, Fortaleza
//950
//Argentina Standard Time
//(UTC-03:00) Buenos Aires
//1000
//Mid-Atlantic Standard Time
//(UTC-02:00) Mid-Atlantic
//1010
//UTC-2
//(UTC-02:00) Coordinated Universal Time -02
//1100
//Azores Standard Time
//(UTC-01:00) Azores
//1110
//Cabo Verde Standard Time
//(UTC-01:00) Cabo Verde Is.
//1200
//GMT Standard Time
//(UTC) Dublin, Edinburgh, Lisbon, London
//1210
//Greenwich Standard Time
//(UTC) Monrovia, Reykjavik
//1220
//Morocco Standard Time
//(UTC) Casablanca
//1230
//UTC
//(UTC) Coordinated Universal Time
//1300
//Central Europe Standard Time
//(UTC+01:00) Belgrade, Bratislava, Budapest, Ljubljana, Prague
//1310
//Central European Standard Time
//(UTC+01:00) Sarajevo, Skopje, Warsaw, Zagreb
//1320
//Romance Standard Time
//(UTC+01:00) Brussels, Copenhagen, Madrid, Paris
//1330
//W.Central Africa Standard Time
//(UTC+01:00) West Central Africa
//1340
//W.Europe Standard Time
//(UTC+01:00) Amsterdam, Berlin, Bern, Rome, Stockholm, Vienna
//1350
//Namibia Standard Time
//(UTC+01:00) Windhoek
//1400
//E.Europe Standard Time
//(UTC+02:00) Minsk
//1410
//Egypt Standard Time
//(UTC+02:00) Cairo
//1420
//FLE Standard Time
//(UTC+02:00) Helsinki, Kyiv, Riga, Sofia, Tallinn, Vilnius
//1430
//GTB Standard Time
//(UTC+02:00) Athens, Bucharest
//1440
//Israel Standard Time
//(UTC+02:00) Jerusalem
//1450
//Jordan Standard Time
//(UTC+02:00) Amman
//1460
//Middle East Standard Time
//(UTC+02:00) Beirut
//1470
//South Africa Standard Time
//(UTC+02:00) Harare, Pretoria
//1480
//Syria Standard Time
//(UTC+02:00) Damascus
//1490
//Turkey Standard Time
//(UTC+02:00) Istanbul
//1500
//Arab Standard Time
//(UTC+03:00) Kuwait, Riyadh
//1510
//Arabic Standard Time
//(UTC+03:00) Baghdad
//1520
//E.Africa Standard Time
//(UTC+03:00) Nairobi
//1530
//Kaliningrad Standard Time
//(UTC+03:00) Kaliningrad
//1550
//Iran Standard Time
//(UTC+03:30) Tehran
//1540
//Russian Standard Time
//(UTC+04:00) Moscow, St.Petersburg, Volgograd
//1600
//Arabian Standard Time
//(UTC+04:00) Abu Dhabi, Muscat
//1610
//Azerbaijan Standard Time
//(UTC+04:00) Baku
//1620
//Caucasus Standard Time
//(UTC+04:00) Yerevan
//1640
//Georgian Standard Time
//(UTC+04:00) Tbilisi
//1650
//Mauritius Standard Time
//(UTC+04:00) Port Louis
//1630
//Afghanistan Standard Time
//(UTC+04:30) Kabul
//1710
//West Asia Standard Time
//(UTC+05:00) Tashkent
//1750
//Pakistan Standard Time
//(UTC+05:00) Islamabad, Karachi
//1720
//India Standard Time
//(UTC+05:30) Chennai, Kolkata, Mumbai, New Delhi
//1730
//Sri Lanka Standard Time
//(UTC+05:30) Sri Jayawardenepura
//1740
//Nepal Standard Time
//(UTC+05:45) Kathmandu
//1700
//Ekaterinburg Standard Time
//(UTC+06:00) Ekaterinburg
//1800
//Central Asia Standard Time
//(UTC+06:00) Astana
//1830
//Bangladesh Standard Time
//(UTC+06:00) Dhaka
//1820
//Myanmar Standard Time
//(UTC+06:30) Yangon(Rangoon)
//1810
//N.Central Asia Standard Time
//(UTC+07:00) Novosibirsk
//1910
//SE Asia Standard Time
//(UTC+07:00) Bangkok, Hanoi, Jakarta
//1900
//North Asia Standard Time
//(UTC+08:00) Krasnoyarsk
//2000
//China Standard Time
//(UTC+08:00) Beijing, Chongqing, Hong Kong, Urumqi
//2020
//Singapore Standard Time
//(UTC+08:00) Kuala Lumpur, Singapore
//2030
//Taipei Standard Time
//(UTC+08:00) Taipei
//2040
//W.Australia Standard Time
//(UTC+08:00) Perth
//2050
//Ulaanbaatar Standard Time
//(UTC+08:00) Ulaanbaatar
//2010
//North Asia East Standard Time
//(UTC+09:00) Irkutsk
//2100
//Korea Standard Time
//(UTC+09:00) Seoul
//2110
//Tokyo Standard Time
//(UTC+09:00) Osaka, Sapporo, Tokyo
//2130
//AUS Central Standard Time
//(UTC+09:30) Darwin
//2140
//Cen.Australia Standard Time
//(UTC+09:30) Adelaide
//2120
//Yakutsk Standard Time
//(UTC+10:00) Yakutsk
//2200
//AUS Eastern Standard Time
//(UTC+10:00) Canberra, Melbourne, Sydney
//2210
//E.Australia Standard Time
//(UTC+10:00) Brisbane
//2220
//Tasmania Standard Time
//(UTC+10:00) Hobart
//2240
//West Pacific Standard Time
//(UTC+10:00) Guam, Port Moresby
//2230
//Vladivostok Standard Time
//(UTC+11:00) Vladivostok
//2300
//Central Pacific Standard Time
//(UTC+11:00) Solomon Is., New Caledonia
//2310
//Magadan Standard Time
//(UTC+12:00) Magadan
//2400
//Fiji Standard Time
//(UTC+12:00) Fiji
//2410
//New Zealand Standard Time
//(UTC+12:00) Auckland, Wellington
//2430
//UTC+12
//(UTC+12:00) Coordinated Universal Time +12
//2500
//Tonga Standard Time
//(UTC+13:00) Nuku'alofa
//2510
//Samoa Standard Time
//(UTC-11:00)Samoa