﻿
using FluentIcon.WinUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    public class FluentIconSymbolTest
    {
        public string Name { get; set; }
        public string Glyph { get; set; }
        public FluentRegularIconSymbol Symbol { get; set; }
        public FluentIconSymbolTest(FluentRegularIconSymbol symbol)
        {
            this.Symbol = symbol;
            this.Name = symbol.ToString();

            //var glyph = char.ConvertFromUtf32((int)symbol);            
            var Code = ((int)symbol).ToString("X");
            var Character = char.ConvertFromUtf32(Convert.ToInt32(Code, 16));

            string CodeGlyph  = "\\u" + Code;
            string TextGlyph  =  "&#x" + Code + ";";

            this.Glyph = TextGlyph;
        }
        public static string String2Unicode(string source)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(source);
            StringBuilder stringBuilder = new StringBuilder();
            for (var i = 0; i < bytes.Length; i += 2)
            {
                stringBuilder.AppendFormat("\\u{0:x2}{1:x2}", bytes[i + 1], bytes[i]);
            }
            return stringBuilder.ToString().ToUpper().Replace("\\U", "\\u");
        }
    }
}
