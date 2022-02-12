using System;
using System.Collections.Generic;
using System.Text;
using ToolGood.Words;

namespace YiSha.Util
{
    public class StringHelper
    {
        public static string GetFirstPinyin(string words)
        {
            return WordsHelper.GetFirstPinyin(words);
        }
    }
}
