namespace prfSchool_Registration
{
    partial class Dashboard
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tABLESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.professorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bt_disconnect = new System.Windows.Forms.Button();
            this.bt_connect = new System.Windows.Forms.Button();
            this.cbox_ports = new System.Windows.Forms.ComboBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.dgv_users = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbFields = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtFname = new System.Windows.Forms.TextBox();
            this.txtLname = new System.Windows.Forms.TextBox();
            this.txtUserType = new System.Windows.Forms.TextBox();
            this.txtSID = new System.Windows.Forms.TextBox();
            this.txtRFID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_users)).BeginInit();
            this.gbFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Khaki;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1097, 96);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(881, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(949, 28);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(134, 20);
            this.txtSearch.TabIndex = 12;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Poppins", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registration";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tABLESToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 72);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1097, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tABLESToolStripMenuItem
            // 
            this.tABLESToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.staffToolStripMenuItem,
            this.professorsToolStripMenuItem,
            this.studentsToolStripMenuItem});
            this.tABLESToolStripMenuItem.Name = "tABLESToolStripMenuItem";
            this.tABLESToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.tABLESToolStripMenuItem.Text = "TABLES:";
            // 
            // staffToolStripMenuItem
            // 
            this.staffToolStripMenuItem.Name = "staffToolStripMenuItem";
            this.staffToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.staffToolStripMenuItem.Text = "Staff";
            // 
            // professorsToolStripMenuItem
            // 
            this.professorsToolStripMenuItem.Name = "professorsToolStripMenuItem";
            this.professorsToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.professorsToolStripMenuItem.Text = "Professors";
            // 
            // studentsToolStripMenuItem
            // 
            this.studentsToolStripMenuItem.Name = "studentsToolStripMenuItem";
            this.studentsToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.studentsToolStripMenuItem.Text = "Students";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel2.Controls.Add(this.bt_disconnect);
            this.panel2.Controls.Add(this.bt_connect);
            this.panel2.Controls.Add(this.cbox_ports);
            this.panel2.Controls.Add(this.btnDel);
            this.panel2.Controls.Add(this.btnEdit);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Controls.Add(this.btnLogOut);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 519);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1097, 80);
            this.panel2.TabIndex = 1;
            // 
            // bt_disconnect
            // 
            this.bt_disconnect.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.bt_disconnect.Location = new System.Drawing.Point(637, 31);
            this.bt_disconnect.Name = "bt_disconnect";
            this.bt_disconnect.Size = new System.Drawing.Size(75, 23);
            this.bt_disconnect.TabIndex = 11;
            this.bt_disconnect.Text = "Disconnect";
            this.bt_disconnect.UseVisualStyleBackColor = false;
            this.bt_disconnect.Visible = false;
            this.bt_disconnect.Click += new System.EventHandler(this.bt_disconnect_Click);
            // 
            // bt_connect
            // 
            this.bt_connect.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.bt_connect.Location = new System.Drawing.Point(637, 31);
            this.bt_connect.Name = "bt_connect";
            this.bt_connect.Size = new System.Drawing.Size(75, 23);
            this.bt_connect.TabIndex = 6;
            this.bt_connect.Text = "Connect";
            this.bt_connect.UseVisualStyleBackColor = false;
            this.bt_connect.Click += new System.EventHandler(this.bt_connect_Click);
            // 
            // cbox_ports
            // 
            this.cbox_ports.FormattingEnabled = true;
            this.cbox_ports.Location = new System.Drawing.Point(510, 32);
            this.cbox_ports.Name = "cbox_ports";
            this.cbox_ports.Size = new System.Drawing.Size(121, 21);
            this.cbox_ports.TabIndex = 10;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnDel.Location = new System.Drawing.Point(401, 20);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(91, 43);
            this.btnDel.TabIndex = 9;
            this.btnDel.Text = "&Delete";
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnEdit.Location = new System.Drawing.Point(304, 20);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(91, 43);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(207, 20);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 43);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(110, 20);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 43);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnNew.Location = new System.Drawing.Point(13, 20);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(91, 43);
            this.btnNew.TabIndex = 5;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogOut.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnLogOut.Location = new System.Drawing.Point(995, 20);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(91, 43);
            this.btnLogOut.TabIndex = 13;
            this.btnLogOut.Text = "&Log-Out";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // dgv_users
            // 
            this.dgv_users.AllowUserToAddRows = false;
            this.dgv_users.AllowUserToDeleteRows = false;
            this.dgv_users.AllowUserToResizeColumns = false;
            this.dgv_users.AllowUserToResizeRows = false;
            this.dgv_users.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_users.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgv_users.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_users.Location = new System.Drawing.Point(271, 96);
            this.dgv_users.MultiSelect = false;
            this.dgv_users.Name = "dgv_users";
            this.dgv_users.ReadOnly = true;
            this.dgv_users.RowHeadersVisible = false;
            this.dgv_users.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_users.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_users.Size = new System.Drawing.Size(826, 423);
            this.dgv_users.TabIndex = 14;
            this.dgv_users.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_users_CellClick);
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "id";
            this.Column8.HeaderText = "ID";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "fname";
            this.Column1.HeaderText = "First Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "lname";
            this.Column2.HeaderText = "Last Name";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "id_lvl";
            this.Column3.HeaderText = "User Level";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "school_id";
            this.Column4.HeaderText = "School ID";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "rfid_uid";
            this.Column5.HeaderText = "RFID";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // gbFields
            // 
            this.gbFields.BackColor = System.Drawing.SystemColors.Window;
            this.gbFields.Controls.Add(this.pictureBox1);
            this.gbFields.Controls.Add(this.txtFname);
            this.gbFields.Controls.Add(this.txtLname);
            this.gbFields.Controls.Add(this.txtUserType);
            this.gbFields.Controls.Add(this.txtSID);
            this.gbFields.Controls.Add(this.txtRFID);
            this.gbFields.Controls.Add(this.label4);
            this.gbFields.Controls.Add(this.label7);
            this.gbFields.Controls.Add(this.label6);
            this.gbFields.Controls.Add(this.label5);
            this.gbFields.Controls.Add(this.label3);
            this.gbFields.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbFields.Enabled = false;
            this.gbFields.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFields.Location = new System.Drawing.Point(0, 96);
            this.gbFields.Name = "gbFields";
            this.gbFields.Size = new System.Drawing.Size(271, 423);
            this.gbFields.TabIndex = 0;
            this.gbFields.TabStop = false;
            this.gbFields.Text = "Fields:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::prfSchool_Registration.Properties.Resources.RFID___Search;
            this.pictureBox1.Location = new System.Drawing.Point(108, 211);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(157, 139);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // txtFname
            // 
            this.txtFname.Location = new System.Drawing.Point(108, 47);
            this.txtFname.Name = "txtFname";
            this.txtFname.Size = new System.Drawing.Size(157, 27);
            this.txtFname.TabIndex = 1;
            this.txtFname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFname_KeyPress);
            // 
            // txtLname
            // 
            this.txtLname.Location = new System.Drawing.Point(108, 79);
            this.txtLname.Name = "txtLname";
            this.txtLname.Size = new System.Drawing.Size(157, 27);
            this.txtLname.TabIndex = 2;
            // 
            // txtUserType
            // 
            this.txtUserType.Location = new System.Drawing.Point(108, 112);
            this.txtUserType.Name = "txtUserType";
            this.txtUserType.Size = new System.Drawing.Size(157, 27);
            this.txtUserType.TabIndex = 3;
            this.txtUserType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserType_KeyPress);
            // 
            // txtSID
            // 
            this.txtSID.Location = new System.Drawing.Point(108, 145);
            this.txtSID.Name = "txtSID";
            this.txtSID.Size = new System.Drawing.Size(157, 27);
            this.txtSID.TabIndex = 4;
            this.txtSID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSID_KeyPress);
            // 
            // txtRFID
            // 
            this.txtRFID.Location = new System.Drawing.Point(108, 178);
            this.txtRFID.Name = "txtRFID";
            this.txtRFID.Size = new System.Drawing.Size(157, 27);
            this.txtRFID.TabIndex = 8;
            this.txtRFID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "School ID:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 23);
            this.label7.TabIndex = 4;
            this.label7.Text = "RFID:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 23);
            this.label6.TabIndex = 3;
            this.label6.Text = "Last Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "User Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "First Name:";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 599);
            this.ControlBox = false;
            this.Controls.Add(this.dgv_users);
            this.Controls.Add(this.gbFields);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "School Registration: KIOSK";
            this.Activated += new System.EventHandler(this.Dashboard_Activated);
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_users)).EndInit();
            this.gbFields.ResumeLayout(false);
            this.gbFields.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_users;
        private System.Windows.Forms.GroupBox gbFields;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRFID;
        private System.Windows.Forms.TextBox txtFname;
        private System.Windows.Forms.TextBox txtLname;
        private System.Windows.Forms.TextBox txtUserType;
        private System.Windows.Forms.TextBox txtSID;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tABLESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem staffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem professorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentsToolStripMenuItem;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.ComboBox cbox_ports;
        private System.Windows.Forms.Button bt_connect;
        private System.Windows.Forms.Button bt_disconnect;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;

    }
}

