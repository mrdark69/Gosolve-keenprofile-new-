using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for StringUtility
/// </summary>
public static class StringUtility
{
    //public StringUtility()
    //{
    //    //
    //    // TODO: Add constructor logic here
    //    //
    //}
    public static string GetPDFTemplate(string name)
    {
        string text = File.ReadAllText(HttpContext.Current.Server.MapPath("/doc_template/" + name + ".html"), Encoding.UTF8);
        return text;
    }
    public static string GetPDFTemplate_css(string name)
    {
        string text = File.ReadAllText(HttpContext.Current.Server.MapPath("/doc_template/css/" + name + ".css"), Encoding.UTF8);
        return text;
    }

    public static string GetKeywordReplace(this string Content, string tagStart, string tagEnd)
    {
        int startIndex = Content.IndexOf(tagStart);
        int endIndex = Content.LastIndexOf(tagEnd) + tagEnd.Length;
        endIndex = endIndex - startIndex;
        return Content.Substring(startIndex, endIndex);
    }

    // EnCode String 
    public static string EncryptedData(this string EncryptedData)
    {
        byte[] data = Encoding.ASCII.GetBytes(EncryptedData);
        string encodeString = Convert.ToBase64String(data);
        return encodeString;
    }

    //Decode String 
    public static string DecryptedData(this string DecryptedData)
    {
        byte[] decodeString = Convert.FromBase64String(DecryptedData);
        string data = Encoding.ASCII.GetString(decodeString);
        return data;
    }
}