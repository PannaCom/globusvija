﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Globus.Models;
namespace Globus
{
    public class Config
    {
        public static int imgWidthBigSlide = 655;
        public static int imgHeightBigSlide = 296;
        public static int imgWidthBigAbout = 620;
        public static int imgHeightBigAbout = 182;
        public static int imgWidthBigNews = 620;
        public static int imgHeightBigNews = 206;
        public static string SlideImagePath = "/Images/Slide";
        public static string AboutImagePath = "/Images/About";
        public static string NewsImagePath = "/Images/News";
        public static int PageSize = 2;
        private static DB_9C4C62_globusEntities db = new DB_9C4C62_globusEntities();
        //convert tieng viet thanh khong dau va them dau -
        public static string unicodeToNoMark(string input)
        {
            input = input.ToLowerInvariant().Trim();
            if (input == null) return "";
            string noMark = "a,a,a,a,a,a,a,a,a,a,a,a,a,a,a,a,a,a,e,e,e,e,e,e,e,e,e,e,e,e,u,u,u,u,u,u,u,u,u,u,u,u,o,o,o,o,o,o,o,o,o,o,o,o,o,o,o,o,o,o,i,i,i,i,i,i,y,y,y,y,y,y,d,A,A,E,U,O,O,D";
            string unicode = "a,á,à,ả,ã,ạ,â,ấ,ầ,ẩ,ẫ,ậ,ă,ắ,ằ,ẳ,ẵ,ặ,e,é,è,ẻ,ẽ,ẹ,ê,ế,ề,ể,ễ,ệ,u,ú,ù,ủ,ũ,ụ,ư,ứ,ừ,ử,ữ,ự,o,ó,ò,ỏ,õ,ọ,ơ,ớ,ờ,ở,ỡ,ợ,ô,ố,ồ,ổ,ỗ,ộ,i,í,ì,ỉ,ĩ,ị,y,ý,ỳ,ỷ,ỹ,ỵ,đ,Â,Ă,Ê,Ư,Ơ,Ô,Đ";
            string[] a_n = noMark.Split(',');
            string[] a_u = unicode.Split(',');
            for (int i = 0; i < a_n.Length; i++)
            {
                input = input.Replace(a_u[i], a_n[i]);
            }
            input = input.Replace("  ", " ");
            input = Regex.Replace(input, "[^a-zA-Z0-9% ._]", string.Empty);
            input = removeSpecialChar(input);
            input = input.Replace(" ", "-");
            input = input.Replace("--", "-");
            return input;
        }
        public static string getTheHotline() {
            try
            {
                var p = (from q in db.hotlines select new { line = q.line }).FirstOrDefault();
                return p.line;
            }
            catch (Exception ex) {
                return "";
            }
        }
        public static string removeSpecialChar(string input)
        {
            input = input.Replace("-", "").Replace(":", "").Replace(",", "").Replace("_", "").Replace("'", "").Replace("\"", "").Replace(";", "").Replace("”", "").Replace(".", "").Replace("%", "");
            return input;
        }
        public static string getDateYear(DateTime d) {
            try
            {
                return d.ToString("MM/yyyy");
            }
            catch (Exception ex) {
                return "";
            }
        }
        public static string getDay(DateTime d)
        {
            try
            {
                return d.ToString("dd");
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}