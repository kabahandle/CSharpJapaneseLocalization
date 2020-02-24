using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Ｃシャープ日本語化リフレクション
{
    public class FunctionSelector
    {
        public FunctionSelector() { }

        public virtual List<string> SelectFunctions(string line, int level, out string returnType, out List<string> args, out string publicprotected, out string virtualString)
        {
            List<string> functions = new List<string>();
            returnType = string.Empty;
            args = new List<string>();
            publicprotected = string.Empty;
            virtualString = string.Empty;

            if (line.StartsWith("public "))
            {
                line = line.Substring("public ".Length).Trim();
                publicprotected = "public";
            }
            if (line.StartsWith("protected"))
            {
                line = line.Substring("protected ".Length).Trim();
                publicprotected = "protected";
            }
            if (line.StartsWith("private "))
            {
                line = line.Substring("private ".Length).Trim();
                publicprotected = "private";
            }
            if (line.StartsWith("virtual "))
            {
                line = line.Substring("virtual ".Length).Trim();
                virtualString = "virtual";
            }

            Regex regex = new System.Text.RegularExpressions.Regex(@"[a-zA-Z0-9_.\[\]\<\>]+");

            int startlv = 0;
            StringBuilder funcName = new StringBuilder();
            StringBuilder hikisu = new StringBuilder();
            List<string> funcs = new List<string>();
            bool inFunc = false;
            for (int i = 0; i < line.Length; i++)
            {
                string mono = line[i].ToString();

                if (inFunc == false && regex.IsMatch(mono))
                {
                    funcName.Append(mono);
                    continue;
                }
                else if ("(".Equals(mono))
                {
                    startlv++;
                    if (startlv == level)
                    {
                        inFunc = true;
                    }
                    else
                    {
                        hikisu.Append(mono);
                    }
                    continue;
                }
                else if (",".Equals(mono))
                {
                    //args.Add(this.NormalizeArgsString(hikisu.ToString()));
                    args.Add(hikisu.ToString().Trim());
                    hikisu.Clear();
                }
                else if (")".Equals(mono))
                {
                    if (startlv == level)
                    {
                        inFunc = false;

                        funcs.Add(funcName.ToString().Trim());// + "(" + hikisu.ToString() + ")");
                        //args.Add(this.NormalizeArgsString(hikisu.ToString()));
                        args.Add(hikisu.ToString().Trim());
                        funcName.Clear();
                        hikisu.Clear();
                    }
                    else
                    {
                        hikisu.Append(mono);
                    }
                    startlv--;
                }
                else if (inFunc == true)
                {
                    hikisu.Append(mono);
                }
                else if (" ".Equals(mono))
                {
                    returnType = funcName.ToString().Trim();
                    funcName.Clear();
                }
                else
                {
                    funcName.Clear();
                }
            }

            return funcs;
        }

        private string NormalizeArgsString(string argString)
        {
            string[] sep = { " " };
            string[] tmp = argString.ToString().Trim().Split(sep, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sbtmp = new StringBuilder();

            for( int i = 0; i < tmp.Length; i++ )
            {
                sbtmp.Append(tmp[i]);
                if (i - 1 < tmp.Length)
                {
                    sbtmp.Append(" ");
                }
            }

            return sbtmp.ToString();
        }
    }
}
