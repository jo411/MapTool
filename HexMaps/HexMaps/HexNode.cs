using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexMaps
{
    public class HexNode
    {
        //These can hold more specialized fields later. Currently a proof of concept. 
        [JsonProperty]
        private string hexName;
        [JsonProperty]
        private string comments;
        [JsonProperty]
        private Tuple<int,int> pos;//position of the node. its index

        //Default values for empty hexes
        public static string defaultName = "This hex has no name";
        public static string defaultComment = "There is nothing of Interest here";

        /// <summary>
        /// Getter for comments
        /// </summary>
        /// <returns></returns>
      public string getComment()
        {
            return comments;
        }

        /// <summary>
        /// Getter for name
        /// </summary>
        /// <returns></returns>
        public string getName()
        {
            return hexName;
        }

        public HexNode(string name, string comment, int row, int col)
        {
            hexName = name;
            comments = comment;
            pos = new Tuple<int, int>(row, col);
        }

        /// <summary>
        /// Appends a comment to the end of the current comment field followed by a newline.
        /// </summary>
        /// <param name="text">Comment to be appended</param>
        public void appendComment(string text)
        {
            comments += text+"\n";
        }

        /// <summary>
        /// Set the entire contents of the comment field overriding any previous data.
        /// </summary>
        /// <param name="text">Comment to be written</param>
        public void setComment(string text)
        {
            comments = text;
        }

        /// <summary>
        /// Sets the name of a hex.
        /// </summary>
        /// <param name="name">The name to set</param>
        public void setName(string name)
        {
            hexName = name;
        }

        /// <summary>
        /// Return the uid tuple for identification
        /// </summary>
        /// <returns>uid tuple(int,int)</in></returns>
        public Tuple<int,int> getPos()
        {
            return pos;
        }
    }
}
