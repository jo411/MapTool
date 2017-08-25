using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace HexMaps
{
    public partial class Form1 : Form
    {
        List<HexNode> nodes;//Temp holding for hexes will prompt later and create a 2d array        

        /*  The buttons and text fields are all temp and just gave me a way to add data.
            The first field is name the second is comment. The button adds a new node with the data to the list.            
        */

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addNode(textBox1.Text, textBox2.Text);            
        }


        /// <summary>
        /// Adds a new hex with the specified data to the list.
        /// </summary>
        /// <param name="name">Name of the hex</param>
        /// <param name="comment">Comments for the hex</param>
        private void addNode(string name, string comment)
        {
            nodes.Add(new HexNode(name, comment));
        }

     
        private void Form1_Load(object sender, EventArgs e)
        {           
            nodes = new List<HexNode>();
        }

        /// <summary>
        /// Serialize a hexNode
        /// </summary>
        /// <param name="node">The node to serialize</param>
        /// <returns>The Json string for the object</returns>
        private string serialize(HexNode node)
        {
            return JsonConvert.SerializeObject(node);           
        }

        /// <summary>
        /// deserializes a hexNode json string
        /// </summary>
        /// <param name="text">the json string of a hex</param>
        /// <returns>The hex object of the string</returns>
        private HexNode deserialize(string text)
        {            
            Debug.WriteLine(text);
            try
            {
                HexNode converted = JsonConvert.DeserializeObject<HexNode>(text);
                return converted;
            }catch            
            {
                MessageBox.Show("Could not deserialize object");
                return new HexNode("Error", "There was an error reading this node");
            }
           
        }    

        private void openMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openMap();

        }

        private void saveMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveMap();
        }

        /// <summary>
        /// Save the map file
        /// </summary>
        public void saveMap()
        {
           
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "map files (*.map)|*.map";//text filter for map files
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)//show dialog and proceed if a file was chosen
            {
                try
                {

                    if ((saveFileDialog1.FileName) != null)//if we have a valid file
                    {
                        using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))//open a stream 
                        {
                            foreach (HexNode current in nodes)//write each hex followed by a newline to the stream
                            {
                                sw.Write(serialize(current)+'\n');
                            }
                        }                           
                       
                       
                    }                  
                }
                catch(Exception e)
                {
                    MessageBox.Show("Error: Could not write file to disk. Original error: " + e.Message);

                }
               

            }
        }
        /// <summary>
        /// Open a map file from disk
        /// </summary>
        public void openMap()
        {           
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            string file="";

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "map files (*.map)|*.map";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)//show dialog and proceed if a file was chosen
            {
                try
                {
                    if ((openFileDialog1.FileName) != null)//if we have a valid file
                    {
                        using (StreamReader sr = new StreamReader(openFileDialog1.FileName))//open a stream
                        {
                            file = sr.ReadToEnd();//read the entire contents into a string
                        }
                         

                      
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

            foreach (string current in file.Split('\n'))//split the string into one for each hex (by neline)
            {
                if(current !="")
                {
                    nodes.Add(deserialize(current));//add the deserialized nodes into the list
                }
            
            }

        }
    }
}
