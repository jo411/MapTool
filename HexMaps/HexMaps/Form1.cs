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
        bool showDebug = true;//control debug logging output
        HexGrid map;//class for tracking the world state
        HexNode currentSelection;//currently active hex (null if there is no info for one stored)
        Tuple<int, int> currentTempPos;//because empty hexes are null we need to store the current position to allow adjacent movement
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Adds a new hex with the specified data to the list.
        /// </summary>
        /// <param name="name">Name of the hex</param>
        /// <param name="comment">Comments for the hex</param>
        private void addNode(string name, string comment, int row, int col, bool overwrite)
        {
            if (!map.addHex(new HexNode(name, comment, row, col), overwrite))
            {
                showError("An error occured adding the hex");
            }else//if it all worked clear the forms
            {
                txtNameInput.Text = "";
                txtRowInput.Text = "";
                txtColInput.Text = "";
                txtCommentInput.Text = "";

            }
        }

        /// <summary>
        /// Resets the formm values
        /// </summary>
        public void resetForm()
        {
          //Current hex section
            txtHexName.Text = "";
            txtRowSearchInput.Text = "";
            txtColSearchInput.Text = "";
            txtHexComments.Text = "";

            //New hex section
            currentSelection = null;
            currentTempPos = null;
            lblHexPos.Text = "";
            txtNameInput.Text = "";
            txtRowInput.Text = "";
            txtColInput.Text = "";
            txtCommentInput.Text = "";
        }
     
        private void Form1_Load(object sender, EventArgs e)
        {
            resetForm();
        }

        /// <summary>
        /// Serialize a hexNode
        /// </summary>
        /// <param name="node">The node to serialize</param>
        /// <returns>The Json string for the object</returns>
        private string serializeMap()
        {
            return  JsonConvert.SerializeObject(map);
        }

        /// <summary>
        /// deserializes a hexNode json string
        /// </summary>
        /// <param name="text">the json string of a hex</param>
        /// <returns>The hex object of the string</returns>
        private HexGrid deserialize(string text)
        {            
            
            try
            {
                return JsonConvert.DeserializeObject<HexGrid>(text);              
            }catch            
            {
                showError("Could not deserialize object");
                return null;
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
            if (!mapCheck()) { return; }//proceed if map is open

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
                            
                                sw.Write(serializeMap());//write the map string to file
                            //TODO: Be smarter and ignore nulls to save memory. May require some different data structures
                            
                        }                           
                       
                       
                    }                  
                }
                catch(Exception e)
                {
                    showError("Error: Could not write file to disk. Original error: " + e.Message);

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
                            map = deserialize(file);
                        }

                         

                      
                    }
                }
                catch (Exception ex)
                {
                    showError("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }          

        }

        public void newMap()
        {
            bool valid = false;
            string rowS = "";//strings for parsing
            string colS = "";
            int numRows=0, numCols = 0;
            if(ShowInputDialog(ref rowS,"How Many Rows?")==System.Windows.Forms.DialogResult.OK)//show dialogs but allow a cancel to stop both from running
            {
                if (ShowInputDialog(ref colS, "How Many Columns?") == System.Windows.Forms.DialogResult.OK)
                {
                   if( Int32.TryParse(rowS, out numRows)&& Int32.TryParse(colS,out numCols))//if both numbers pars fine.
                    {
                        valid = true;
                    }
                    else
                    {
                        showError("Invalid input!");
                    }
                }
            }          
            
            if(valid)
            {
                map = new HexGrid(numCols, numRows);
            }

        }

        private void newMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newMap();
        }

        /// <summary>
        /// Pops up a prompt for entering data. Modified from a post on stack overflow by user Gorkem (https://stackoverflow.com/users/2138992/gorkem)
        /// </summary>
        /// <param name="input">A ref String to store input. Also sets the default text of the input text box</param>
        /// <param name="title">Name of the popup window</param>
        /// <returns>The dialog status of the input buttons</returns>
        private static DialogResult ShowInputDialog(ref string input,string title)
        {
            System.Drawing.Size size = new System.Drawing.Size(400, 70);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = title;

            System.Windows.Forms.TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(5, 5);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();

           
            input = textBox.Text;
         
            return result;
        }

        /// <summary>
        /// Print a string to the debug console if debug output is enabled
        /// </summary>
        /// <param name="x">The string to write</param>
        public void print(string x)
        {
            if(showDebug)
            {
                Debug.WriteLine(x);
            }
        }

        /// <summary>
        /// Display an error message to the user through a message box. 
        /// </summary>
        /// <param name="message">The error message to display</param>
        public void showError(string message)
        {
            MessageBox.Show("An Error Occured: " + message);
        }

       
        private void btnHexSearch_Click(object sender, EventArgs e)
        {
            if (!mapCheck()) { return; }//proceed if map is open

            int row = 0, col = 0;

            if (Int32.TryParse(txtRowSearchInput.Text, out row) && Int32.TryParse(txtColSearchInput.Text, out col))//if valid input was given begin the display process
            {
                displayHex(row, col);
            }
        }

        /// <summary>
        /// Grabs the hex at a specified location. NOTE: Will throw exceptions for out of bounds. Check the validity of input with map.isValid() beforehand
        /// </summary>
        /// <param name="row">The row of the Hex</param>
        /// <param name="col">The column of the Hex</param>
        /// <returns></returns>
        public HexNode searchHex(int row, int col)
        {        
                return map.getHex(row, col);             
         
        }

        /// <summary>
        /// Displays a hex to the form
        /// </summary>
        /// <param name="row">The row of the Hex</param>
        /// <param name="col">The column of the Hex</param>
        public void displayHex(int row, int col)
        {
            HexNode selected;
            if (map.isValid(row, col))
            {
             selected = searchHex(row, col);//if the location is valid grab the hex
            }
            else
            {
                showError("That position is invalid.");
                return;
            }
              
            currentSelection = selected;//store the selection

            if (selected==null)//check if the selected node has an entry and update the display accordingly
            {
                txtHexName.Text = HexNode.defaultName;
                txtHexComments.Text = HexNode.defaultComment;
                lblHexPos.Text = "(" + row+ "," +col + ")";
                currentTempPos = new Tuple<int, int>(row, col); //set the temp pos             
            }
            else
            {              
                txtHexName.Text = selected.getName();
                txtHexComments.Text = selected.getComment();
                lblHexPos.Text = "(" + selected.getPos().Item1 + "," + selected.getPos().Item2 + ")";
                currentTempPos = null;//reset the temp pos
            }
         
        }

        
        private void btnAddHex_Click(object sender, EventArgs e)
        {
            if (!mapCheck()) { return; }//proceed if map is open
            if (map == null) { showError("No open Map"); return; }//don't go if there is no map

            int row = 0, col = 0;

            if(Int32.TryParse(txtRowInput.Text,out row)&& Int32.TryParse(txtColInput.Text, out col))//check for valid parsed input
            {
                addNode(txtNameInput.Text, txtCommentInput.Text, row, col,chkOverwrite.Checked);//add the node
            }
            else
            {
                showError("Invalid Input!");
            }

       
        }
        /// <summary>
        /// Check for a valid open map. 
        /// </summary>
        /// <returns>False if there is no open map and true else</returns>
        public bool mapCheck()
        {
            if (map == null) { showError("No open map."); return false; }//don't go if there is no map
            return true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!mapCheck()) { return; }//proceed if map is open

            if(currentSelection==null)//check if this node has an entry already
            {            
                addNode(txtHexName.Text, txtHexComments.Text, currentTempPos.Item1, currentTempPos.Item2, true);//update data
                displayHex(currentTempPos.Item1, currentTempPos.Item2);//update display

            }
            else
            {
                currentSelection.setName(txtHexName.Text);//update data
                currentSelection.setComment(txtHexComments.Text);
                displayHex(currentSelection.getPos().Item1, currentSelection.getPos().Item2);//update display
            }
            

        }
    }
}
