using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexMaps
{
    class HexNode
    {
        //These can hold more specialized fields later. Currently a proof of concept. 
        [JsonProperty]
        private string hexName;
        [JsonProperty]
        private string comments;

        public HexNode(string name, string comment)
        {
            hexName = name;
            comments = comment;
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
    }
}
