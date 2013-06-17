using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotJustSokoban
{
    public static class JTokenToTypeConverter
    {
        public static int ParseTokenToInt(JToken token)
        {
            // int parsedToken = int.Parse(token.ToString());
            int parsedToken = (int)token;

            return parsedToken;
        }

        public static string ParseTokenToString(JToken token)
        {
            string parsedToken = token.ToString();

            return parsedToken;
        }

        public static int[] ParseTokenToIntArray(IList<JToken> tokens)
        {
            List<int> tokenList = new List<int>();
            foreach (JToken token in tokens)
            {
                int parsedToken = ParseTokenToInt(token);
                tokenList.Add(parsedToken);
            }

            return tokenList.ToArray();
        }

        public static string[] ParseTokenToStringArray(IList<JToken> tokens)
        {
            List<string> tokenList = new List<string>();
            foreach (JToken token in tokens)
            {
                string parsedToken = ParseTokenToString(token);
                tokenList.Add(parsedToken);
            }

            return tokenList.ToArray();
        }
    }
}
