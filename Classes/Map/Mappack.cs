using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotJustSokoban
{
    public class Mappack
    {
        // Class variables

        // Properties
        public int CurrentMapIndex { get; private set; }
        public Map CurrentMap { get; private set; }
        public string[] MapList { get; private set; }
        public string FileExtension { get; set; }
        public string MapsSourceType { get; set; }
        public string Directory { get; set; }

        public Mappack(string mappackName)
        {
            this.CurrentMapIndex = 0;
            Dictionary<string, object> mappackData = MappackLoader.Load(mappackName);

            AssignProperties(mappackData);

            LoadMap();
        }

        // Assign Properties
        private void AssignProperties(Dictionary<string, object> mappackData)
        {
            this.MapList = (string[])mappackData["mapList"];
            this.FileExtension = (string)mappackData["fileExtension"];
            this.MapsSourceType = (string)mappackData["mapsSourceType"];
            this.Directory = (string)mappackData["directory"];
        }


        // MapList iteration
        private void PreviousMapIndex()
        {
            this.CurrentMapIndex--;

            if (this.CurrentMapIndex < 0)
            {
                this.CurrentMapIndex++;
                throw new IndexOutOfRangeException("The CurrentMapIndex cannot be less than 0. CurrentMapIndex returned to first map");
            }
        }

        private void NextMapIndex()
        {
            this.CurrentMapIndex++;

            if (this.CurrentMapIndex >= MapList.Length)
            {
                this.CurrentMapIndex--;
                throw new IndexOutOfRangeException("There is no more maps in the current Mappack. CurrentMapIndex returned to last map");
            }
        }

        public Map GetPreviousMap()
        {
            PreviousMapIndex();

            return LoadMap();
        }

        public Map GetNextMap()
        {
            NextMapIndex();

            return LoadMap();
        }


        // Load Map
        private Map LoadMap()
        {
            Map.Instance.Load(this.MapList[this.CurrentMapIndex], this.MapsSourceType);
            this.CurrentMap = Map.Instance;

            return Map.Instance;
        }
    }
}
