using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexMaps
{
    class ConnectionNode
    {
        private Tuple<int,int> connectedTo;//position of the node that this connection refers to
        private string description;
        public ConnectionNode(HexNode connectedTo, string description)
        {
            this.connectedTo = connectedTo.getPos();
            this.description = description;
        }

  
        /// <summary>
        /// Returns thenode that this connection points to from the map given. Throws an exception if the node doesn't exist so check beforhand.
        /// </summary>
        /// <param name="map">The map the nodes reside in</param>
        /// <returns>A HexNode object </returns>
        public HexNode getConnectedTo(HexGrid map)
        {
            return map.getHex(this.connectedTo.Item1, this.connectedTo.Item2);
        }

        /// <summary>
        /// Returns the description field
        /// </summary>
        /// <returns></returns>
        public string getDescription()
        {
            return this.description;
        }

        /// <summary>
        /// Sets the description string
        /// </summary>
        /// <param name="newDesc">The new text to use as a description</param>
        public void setDescription(string newDesc)
        {
            this.description = newDesc;
        }
                  
                

    }
}
