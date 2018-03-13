using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocket.CodeBuilder.Template
{
    public class NameTable
    {
        public string NameToNewName(string name)
        {
            foreach (var dic in NameDic())
            {
                name = name.Replace(dic.Key, dic.Value);
            }
            return name;
        }

        public Dictionary<string, string> NameDic()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("user", "User");
            dic.Add("info", "Info");
            dic.Add("account", "Account");
            dic.Add("goods", "Goods");
            dic.Add("store", "Store");
            dic.Add("shop", "Shop");
            dic.Add("order", "Order");
            dic.Add("category", "Category");
            dic.Add("code", "Code");
            dic.Add("image", "Image");
            dic.Add("coupon", "Coupon");
            dic.Add("relation", "Relation");
            dic.Add("unit", "Unit");
            dic.Add("history", "History");
            dic.Add("detail", "Detail");
            dic.Add("trade", "Trade");
            return dic;
        }
    }
}
