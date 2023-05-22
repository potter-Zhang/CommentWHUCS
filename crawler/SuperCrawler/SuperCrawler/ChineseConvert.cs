using Microsoft.International.Converters.PinYinConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SuperCrawler
{
    public class ChineseConvert
    {
        public static List<string> NameList2Pinyin(List<string> namelist) 
        {
            List<string> list = new List<string>();
            foreach (string name in namelist)
            {
                list.Add(Name2Pinyin(name));
            }
            return list;
        }
        public static string Name2Pinyin(string name)
        {
            string Pinyin = "";
            string First = "";
            
            foreach (var n in name)
            {
                if (!ChineseChar.IsValidChar(n))
                    continue;
                ChineseChar c = new ChineseChar(n);
                string s = Regex.Replace(c.Pinyins.ToList()[0], @"\d", "").ToLower();
                if (First == "")
                    First = s;
                else
                    Pinyin += s;

            }

            return Pinyin + " " + First;
            
        }
    }
}
