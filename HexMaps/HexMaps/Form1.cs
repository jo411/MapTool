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
        List<HexNode> nodes;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addNode(textBox1.Text, textBox2.Text);
            Debug.WriteLine(nodes.Count);
        }


        private void addNode(string name, string comment)
        {
            nodes.Add(new HexNode(name, comment));
        }

     
        private void Form1_Load(object sender, EventArgs e)
        {
           
            nodes = new List<HexNode>();
        }

        private string serialize(HexNode node)
        {
            return JsonConvert.SerializeObject(node);           
        }

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
        public void saveMap()
        {
           
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "map files (*.map)|*.map";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    if ((saveFileDialog1.FileName) != null)
                    {
                        using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                        {
                            foreach (HexNode current in nodes)
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
        public void openMap()
        {           
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            string file="";

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "map files (*.map)|*.map";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((openFileDialog1.FileName) != null)
                    {
                        using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                        {
                            file = sr.ReadToEnd();
                        }
                         

                      
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

            foreach (string current in file.Split('\n'))
            {
                if(current !="")
                {
                    nodes.Add(deserialize(current));
                }
            
            }

        }
    }
}
