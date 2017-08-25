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
        [JsonProperty]
        private string hexName;
        [JsonProperty]
        private string comments;

        public HexNode(string name, string comment)
        {
            hexName = name;
            comments = comment;
        }

        public void appendComment(string text)
        {
            comments += text+"\n";
        }

        public void setComment(string text)
        {
            comments = text;
        }

        public void setName(string name)
        {
            hexName = name;
        }
    }
}
