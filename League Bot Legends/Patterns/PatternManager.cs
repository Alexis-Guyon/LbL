using League_Bot_Legends.IO;
using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace League_Bot_Legends.Patterns
{
    public class PatternManager
    {
        public const string PATH = "Patterns\\";
        public const string extension = ".cs";

        private static Dictionary<string, Type> scripts = new Dictionary<string, Type>();
    }
}