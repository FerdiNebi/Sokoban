using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotJustSokoban
{
    class ParseJSONMappackToNormalMappack
    {
        public static Dictionary<string, object> ParseJSONMappack(string jsonText)
        {
            // Get the JSON Object
            JObject jsonData = JObject.Parse(jsonText);

            
            string[] mapList = ParseMapList(jsonData);
            string fileExtension = ParseFileExtension(jsonData);
            string mapsSourceType = ParseMapsSourceType(jsonData);
            string directory = ParseDirectory(jsonData);

            // Mappack properties container
            Dictionary<string, object> parsedMappack = new Dictionary<string, object>();

            // Add the mappack properties
            parsedMappack["mapList"] = mapList;
            parsedMappack["fileExtension"] = fileExtension;
            parsedMappack["mapsSourceType"] = mapsSourceType;
            parsedMappack["directory"] = directory;

            return parsedMappack;
        }

        private static string[] ParseMapList(JObject jsonObject)
        {
            IList<JToken> token = jsonObject["mapFileNames"].Children().ToList();

            string[] mapList = JTokenToTypeConverter.ParseTokenToStringArray(token);

            return mapList;
        }


        private static string ParseFileExtension(JObject jsonObject)
        {
            JToken token = jsonObject["fileExtension"];

            string fileExtension = JTokenToTypeConverter.ParseTokenToString(token);

            return fileExtension;
        }


        private static string ParseMapsSourceType(JObject jsonObject)
        {
            JToken token = jsonObject["mapsSourceType"];

            string mapsSourceType = JTokenToTypeConverter.ParseTokenToString(token);

            return mapsSourceType;
        }


        private static string ParseDirectory(JObject jsonObject)
        {
            JToken token = jsonObject["directory"];

            string directory = JTokenToTypeConverter.ParseTokenToString(token);

            return directory;
        }
    }
}
