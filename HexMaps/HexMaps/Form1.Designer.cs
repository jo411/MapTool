namespace HexMaps
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtHexComments = new System.Windows.Forms.TextBox();
            this.txtColSearchInput = new System.Windows.Forms.TextBox();
            this.btnHexSearch = new System.Windows.Forms.Button();
            this.lblHexNameDisp = new System.Windows.Forms.Label();
            this.lblHexPosDisp = new System.Windows.Forms.Label();
            this.lblHexPos = new System.Windows.Forms.Label();
            this.txtCommentInput = new System.Windows.Forms.TextBox();
            this.btnAddHex = new System.Windows.Forms.Button();
            this.chkOverwrite = new System.Windows.Forms.CheckBox();
            this.lblNameInputDisp = new System.Windows.Forms.Label();
            this.txtNameInput = new System.Windows.Forms.TextBox();
            this.txtRowInput = new System.Windows.Forms.TextBox();
            this.lblRowInputDisp = new System.Windows.Forms.Label();
            this.txtColInput = new System.Windows.Forms.TextBox();
            this.lblColInputDisp = new System.Windows.Forms.Label();
            this.txtRowSearchInput = new System.Windows.Forms.TextBox();
            this.lblRowSearchDisp = new System.Windows.Forms.Label();
            this.lblColSearchDisp = new System.Windows.Forms.Label();
            this.txtHexName = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.mapToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(918, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMapToolStripMenuItem,
            this.openMapToolStripMenuItem,
            this.saveMapToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newMapToolStripMenuItem
            // 
            this.newMapToolStripMenuItem.Name = "newMapToolStripMenuItem";
            this.newMapToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newMapToolStripMenuItem.Text = "New Map";
            this.newMapToolStripMenuItem.Click += new System.EventHandler(this.newMapToolStripMenuItem_Click);
            // 
            // openMapToolStripMenuItem
            // 
            this.openMapToolStripMenuItem.Name = "openMapToolStripMenuItem";
            this.openMapToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openMapToolStripMenuItem.Text = "Open Map";
            this.openMapToolStripMenuItem.Click += new System.EventHandler(this.openMapToolStripMenuItem_Click);
            // 
            // saveMapToolStripMenuItem
            // 
            this.saveMapToolStripMenuItem.Name = "saveMapToolStripMenuItem";
            this.saveMapToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveMapToolStripMenuItem.Text = "Save Map";
            this.saveMapToolStripMenuItem.Click += new System.EventHandler(this.saveMapToolStripMenuItem_Click);
            // 
            // txtHexComments
            // 
            this.txtHexComments.Location = new System.Drawing.Point(255, 396);
            this.txtHexComments.Multiline = true;
            this.txtHexComments.Name = "txtHexComments";
            this.txtHexComments.Size = new System.Drawing.Size(651, 132);
            this.txtHexComments.TabIndex = 5;
            // 
            // txtColSearchInput
            // 
            this.txtColSearchInput.Location = new System.Drawing.Point(866, 345);
            this.txtColSearchInput.Name = "txtColSearchInput";
            this.txtColSearchInput.Size = new System.Drawing.Size(40, 20);
            this.txtColSearchInput.TabIndex = 6;
            // 
            // btnHexSearch
            // 
            this.btnHexSearch.Location = new System.Drawing.Point(817, 371);
            this.btnHexSearch.Name = "btnHexSearch";
            this.btnHexSearch.Size = new System.Drawing.Size(89, 23);
            this.btnHexSearch.TabIndex = 8;
            this.btnHexSearch.Text = "Search";
            this.btnHexSearch.UseVisualStyleBackColor = true;
            this.btnHexSearch.Click += new System.EventHandler(this.btnHexSearch_Click);
            // 
            // lblHexNameDisp
            // 
            this.lblHexNameDisp.AutoSize = true;
            this.lblHexNameDisp.Location = new System.Drawing.Point(252, 345);
            this.lblHexNameDisp.Name = "lblHexNameDisp";
            this.lblHexNameDisp.Size = new System.Drawing.Size(63, 13);
            this.lblHexNameDisp.TabIndex = 9;
            this.lblHexNameDisp.Text = "Hex Name: ";
            // 
            // lblHexPosDisp
            // 
            this.lblHexPosDisp.AutoSize = true;
            this.lblHexPosDisp.Location = new System.Drawing.Point(252, 368);
            this.lblHexPosDisp.Name = "lblHexPosDisp";
            this.lblHexPosDisp.Size = new System.Drawing.Size(72, 13);
            this.lblHexPosDisp.TabIndex = 12;
            this.lblHexPosDisp.Text = "Hex Position: ";
            // 
            // lblHexPos
            // 
            this.lblHexPos.AutoSize = true;
            this.lblHexPos.Location = new System.Drawing.Point(321, 368);
            this.lblHexPos.Name = "lblHexPos";
            this.lblHexPos.Size = new System.Drawing.Size(54, 13);
            this.lblHexPos.TabIndex = 13;
            this.lblHexPos.Text = "Placehold";
            // 
            // txtCommentInput
            // 
            this.txtCommentInput.Location = new System.Drawing.Point(255, 126);
            this.txtCommentInput.Multiline = true;
            this.txtCommentInput.Name = "txtCommentInput";
            this.txtCommentInput.Size = new System.Drawing.Size(651, 113);
            this.txtCommentInput.TabIndex = 14;
            // 
            // btnAddHex
            // 
            this.btnAddHex.Location = new System.Drawing.Point(700, 245);
            this.btnAddHex.Name = "btnAddHex";
            this.btnAddHex.Size = new System.Drawing.Size(206, 48);
            this.btnAddHex.TabIndex = 15;
            this.btnAddHex.Text = "Add Hex";
            this.btnAddHex.UseVisualStyleBackColor = true;
            this.btnAddHex.Click += new System.EventHandler(this.btnAddHex_Click);
            // 
            // chkOverwrite
            // 
            this.chkOverwrite.AutoSize = true;
            this.chkOverwrite.Location = new System.Drawing.Point(740, 299);
            this.chkOverwrite.Name = "chkOverwrite";
            this.chkOverwrite.Size = new System.Drawing.Size(138, 17);
            this.chkOverwrite.TabIndex = 16;
            this.chkOverwrite.Text = "Overwrite Existing Hex?";
            this.chkOverwrite.UseVisualStyleBackColor = true;
            // 
            // lblNameInputDisp
            // 
            this.lblNameInputDisp.AutoSize = true;
            this.lblNameInputDisp.Location = new System.Drawing.Point(252, 77);
            this.lblNameInputDisp.Name = "lblNameInputDisp";
            this.lblNameInputDisp.Size = new System.Drawing.Size(41, 13);
            this.lblNameInputDisp.TabIndex = 17;
            this.lblNameInputDisp.Text = "Name?";
            // 
            // txtNameInput
            // 
            this.txtNameInput.Location = new System.Drawing.Point(300, 74);
            this.txtNameInput.Name = "txtNameInput";
            this.txtNameInput.Size = new System.Drawing.Size(120, 20);
            this.txtNameInput.TabIndex = 18;
            // 
            // txtRowInput
            // 
            this.txtRowInput.Location = new System.Drawing.Point(300, 100);
            this.txtRowInput.Name = "txtRowInput";
            this.txtRowInput.Size = new System.Drawing.Size(30, 20);
            this.txtRowInput.TabIndex = 20;
            // 
            // lblRowInputDisp
            // 
            this.lblRowInputDisp.AutoSize = true;
            this.lblRowInputDisp.Location = new System.Drawing.Point(252, 103);
            this.lblRowInputDisp.Name = "lblRowInputDisp";
            this.lblRowInputDisp.Size = new System.Drawing.Size(35, 13);
            this.lblRowInputDisp.TabIndex = 19;
            this.lblRowInputDisp.Text = "Row?";
            // 
            // txtColInput
            // 
            this.txtColInput.Location = new System.Drawing.Point(390, 100);
            this.txtColInput.Name = "txtColInput";
            this.txtColInput.Size = new System.Drawing.Size(30, 20);
            this.txtColInput.TabIndex = 21;
            // 
            // lblColInputDisp
            // 
            this.lblColInputDisp.AutoSize = true;
            this.lblColInputDisp.Location = new System.Drawing.Point(336, 103);
            this.lblColInputDisp.Name = "lblColInputDisp";
            this.lblColInputDisp.Size = new System.Drawing.Size(48, 13);
            this.lblColInputDisp.TabIndex = 22;
            this.lblColInputDisp.Text = "Column?";
            // 
            // txtRowSearchInput
            // 
            this.txtRowSearchInput.Location = new System.Drawing.Point(817, 345);
            this.txtRowSearchInput.Name = "txtRowSearchInput";
            this.txtRowSearchInput.Size = new System.Drawing.Size(40, 20);
            this.txtRowSearchInput.TabIndex = 23;
            // 
            // lblRowSearchDisp
            // 
            this.lblRowSearchDisp.AutoSize = true;
            this.lblRowSearchDisp.Location = new System.Drawing.Point(814, 329);
            this.lblRowSearchDisp.Name = "lblRowSearchDisp";
            this.lblRowSearchDisp.Size = new System.Drawing.Size(29, 13);
            this.lblRowSearchDisp.TabIndex = 24;
            this.lblRowSearchDisp.Text = "Row";
            // 
            // lblColSearchDisp
            // 
            this.lblColSearchDisp.AutoSize = true;
            this.lblColSearchDisp.Location = new System.Drawing.Point(863, 329);
            this.lblColSearchDisp.Name = "lblColSearchDisp";
            this.lblColSearchDisp.Size = new System.Drawing.Size(42, 13);
            this.lblColSearchDisp.TabIndex = 25;
            this.lblColSearchDisp.Text = "Column";
            // 
            // txtHexName
            // 
            this.txtHexName.Location = new System.Drawing.Point(324, 342);
            this.txtHexName.Name = "txtHexName";
            this.txtHexName.Size = new System.Drawing.Size(96, 20);
            this.txtHexName.TabIndex = 26;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(700, 534);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(206, 48);
            this.btnUpdate.TabIndex = 27;
            this.btnUpdate.Text = "Update Info";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // mapToolStripMenuItem
            // 
            this.mapToolStripMenuItem.Name = "mapToolStripMenuItem";
            this.mapToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.mapToolStripMenuItem.Text = "Map";
            this.mapToolStripMenuItem.Click += new System.EventHandler(this.mapToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 615);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtHexName);
            this.Controls.Add(this.lblColSearchDisp);
            this.Controls.Add(this.lblRowSearchDisp);
            this.Controls.Add(this.txtRowSearchInput);
            this.Controls.Add(this.lblColInputDisp);
            this.Controls.Add(this.txtColInput);
            this.Controls.Add(this.txtRowInput);
            this.Controls.Add(this.lblRowInputDisp);
            this.Controls.Add(this.txtNameInput);
            this.Controls.Add(this.lblNameInputDisp);
            this.Controls.Add(this.chkOverwrite);
            this.Controls.Add(this.btnAddHex);
            this.Controls.Add(this.txtCommentInput);
            this.Controls.Add(this.lblHexPos);
            this.Controls.Add(this.lblHexPosDisp);
            this.Controls.Add(this.lblHexNameDisp);
            this.Controls.Add(this.btnHexSearch);
            this.Controls.Add(this.txtColSearchInput);
            this.Controls.Add(this.txtHexComments);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Hex Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newMapToolStripMenuItem;
        private System.Windows.Forms.TextBox txtHexComments;
        private System.Windows.Forms.TextBox txtColSearchInput;
        private System.Windows.Forms.Button btnHexSearch;
        private System.Windows.Forms.Label lblHexNameDisp;
        private System.Windows.Forms.Label lblHexPosDisp;
        private System.Windows.Forms.Label lblHexPos;
        private System.Windows.Forms.TextBox txtCommentInput;
        private System.Windows.Forms.Button btnAddHex;
        private System.Windows.Forms.CheckBox chkOverwrite;
        private System.Windows.Forms.Label lblNameInputDisp;
        private System.Windows.Forms.TextBox txtNameInput;
        private System.Windows.Forms.TextBox txtRowInput;
        private System.Windows.Forms.Label lblRowInputDisp;
        private System.Windows.Forms.TextBox txtColInput;
        private System.Windows.Forms.Label lblColInputDisp;
        private System.Windows.Forms.TextBox txtRowSearchInput;
        private System.Windows.Forms.Label lblRowSearchDisp;
        private System.Windows.Forms.Label lblColSearchDisp;
        private System.Windows.Forms.TextBox txtHexName;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ToolStripMenuItem mapToolStripMenuItem;
    }
}

