using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HexMaps
{
    /// <summary>
    /// Organizes sets of hexes into a grid. Could later be used to convert from cartesian to hexical coordinates if the system needs to change without needing to update the front end logic. 
    /// </summary>
    public class HexGrid
    {
        [JsonProperty]
        public int width;//width of the map (number of hexes)
        [JsonProperty]
        public int height;//height of the map (number of hexes)
        [JsonProperty]
        private List<HexNode> hexList;//a list of the hexe positions with information in them used for efficient saving

        private HexNode[,] map;//holds all the hexes
        public HexGrid(int width, int height)
        {
            this.width = width;
            this.height = height;
            map = new HexNode[height, width];
            hexList = new List<HexNode>();
        }

        /// <summary>
        ///Json constructor
        /// </summary>
        [JsonConstructor]
        public HexGrid(int width, int height, List<HexNode> hexList)
        {
            this.width = width;
            this.height = height;
            map = new HexNode[height, width];
            this.hexList = hexList;
            addListToMap();

        }
        /// <summary>
        /// used by the json constructor to save files with less memory. Adds the list of interesting nodes back into the whole map
        /// </summary>
        private void addListToMap()
        {
            foreach(HexNode current in hexList)
            {
                addHex(current, true);//add all the hexes in the list to the array
            }
        }
        public void construct()
        {

        }

        /// <summary>
        /// Tries to insert a hex into the map overwriting if specified. Otherwise checks if the space is valid and returns the sucess of the action.
        /// </summary>
        /// <param name="newHex">The hex to set</param>
        /// <param name="overwrite">Whether the map should the erase contents of a hex for the new one</param>
        /// <returns></returns>
        public bool addHex(HexNode newHex, bool overwrite)
        {
            Tuple<int, int> pos = newHex.getPos();

            if (pos.Item1 < height && pos.Item2 < width)
            {
                if (overwrite || map[pos.Item1, pos.Item2] == null)//overwite if needed otherwise check if the space if free
                {
                    map[pos.Item1, pos.Item2] = newHex;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Prepares the map for serialization by adding the proper hexes to the list
        /// </summary>
        /// <returns></returns>
        [OnSerializing]
        private void preSerialize(StreamingContext context)
        {
            hexList.Clear();
            for(int i=0;i< height;i++)
            {
                for(int j=0;j< width;j++)
                {
                    if(map[i,j]!=null)
                    {
                        hexList.Add(map[i, j]);
                    }
                }
            }

           
        }
        
        public HexNode getHex(int row, int col)
        {
            if(row<height && col<width)
            {
                return map[row, col];
            }

            throw new IndexOutOfRangeException("This position is not on the map: (" + row + "," + col + ")");
        }
        /// <summary>
        /// Tells if a location is valid on this map
        /// </summary>
        /// <param name="row">The row position</param>
        /// <param name="col"The col position></param>
        /// <returns>True if valid, false else</returns>
        public bool isValid(int row, int col)
        {
            return (row < height && col < width);
        }
    }
}
