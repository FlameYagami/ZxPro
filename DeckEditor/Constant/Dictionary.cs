﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckEditor.Constant
{
    public class Dictionary
    {
        public static Dictionary<string, string> AbilityTypeDic = new Dictionary<string, string>
        {
            {"Lv", "Lv"},
            {"射程", "【常】射程"},
            {"绝界", "【常】绝界"},
            {"起始卡", "【常】起始卡"},
            {"生命恢复", "【常】生命恢复"},
            {"虚空使者", "【常】虚空使者"},
            {"进化原力", "【自】进化原力"},
            {"零点优化", "【※】零点优化"}
        };

        public static Dictionary<string, string> ImgSignPathDic = new Dictionary<string, string>
        {
            {"-", String.Empty},
            {"点燃", Const.TexturesPath + "Ig.png"},
            {"觉醒之种", Const.TexturesPath + "El.png"}
        };

        public static Dictionary<string, string> ImgRestrictPathDic = new Dictionary<string, string>
        {
            {"0", Const.TexturesPath + "Restrict.png"}
        };

        public static Dictionary<string, string> ImgCampPathDic = new Dictionary<string, string>
        {
            {"红", Const.TexturesPath + "Red.png"},
            {"蓝", Const.TexturesPath + "Blue.png"},
            {"白", Const.TexturesPath + "White.png"},
            {"黑", Const.TexturesPath + "Black.png"},
            {"绿", Const.TexturesPath + "Green.png"},
            {"无", Const.TexturesPath + "Void.png"}
        };
    }
}
