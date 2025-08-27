using Newtonsoft.Json;
using System;
using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Data.Odbc;
using System.Drawing;
using System.IO.Ports;
//using System.Linq;
using System.Net.Http;
//using System.Security.Policy;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Net.WebRequestMethods;


namespace prfSchool_Registration
{
    public partial class Dashboard : Form
    {

        private SerialPort serial_port;
        private static readonly HttpClient client = new HttpClient();
        public Dashboard()// SETUP
        {
            InitializeComponent();

            // Initialize SerialPort
            serial_port = new SerialPort("COM4", 9600);
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)// RFID RECIEVER
        {
            try
            {
                string rfid = serial_port.ReadLine().Trim();

                // safely update the UI from another thread
                this.Invoke((MethodInvoker)delegate
                {
                    // kung existing na yung rfid sa txtbox
                    if (!string.IsNullOrWhiteSpace(txtRFID.Text))
                    {
                        DialogResult result = MessageBox.Show(
                            "This will overwrite the current RFID text. Continue?",
                            "Confirm Overwrite",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (result != DialogResult.Yes)
                        {
                            return; // Don't overwrite
                        }
                    }

                    txtRFID.Text = rfid; // Overwrite after confirmation or if empty
                });
            }
            catch (Exception ex)
            {
                // Optional: log or handle errors
                Cleaner();
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)// NEW ENTRY
        {
            if (serial_port != null && serial_port.IsOpen)
            {
                serial_port.DataReceived += SerialPort_DataReceived;
                try
                {
                    if (!serial_port.IsOpen)
                    {
                        serial_port.Open();
                    }
                    Toggle(true);
                    txtRFID.Enabled = false;
                    ResetGifAnimation(true);
                    Cleaner();
                    txtFname.Focus();
                }
                catch (Exception ex)
                {
                    pictureBox1.Enabled = false;
                    Toggle(false);
                    MessageBox.Show("Failed to open COM port: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                Cleaner();
                MessageBox.Show("No COM port is currently connected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void Toggle(bool value)// BUTTON TOGGLES
        {
            btnSave.Enabled = value;
            btnCancel.Enabled = value;
            gbFields.Enabled = value;

            dgv_users.Enabled = !value;
            btnNew.Enabled = !value;
            btnEdit.Enabled = !value;
            btnDel.Enabled = !value;
            btnLogOut.Enabled = !value;
        }

        private void btnCancel_Click(object sender, EventArgs e)// CANCEL
        {
            Toggle(false);
            ResetGifAnimation(false);
            Cleaner();
        }

        private void ResetGifAnimation(bool value)// RESET ANIMATION
        {
            pictureBox1.Image = null;
            pictureBox1.Image = (Image)Properties.Resources.RFID___Search.Clone(); // Replace 'YourGifName' with the actual name
            pictureBox1.Enabled = value;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dgv_users_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //int idColumnIndex = dgv_users.Columns["ID"].Index; // or use actual column name
                dgv_users.Tag = dgv_users.Rows[e.RowIndex].Cells[0].Value;
                //MessageBox.Show(dgv_users.Tag.ToString());
                loadRecord("SELECT * FROM tbl_views_registration WHERE id = ?", Convert.ToInt32(dgv_users.Tag));
                //MessageBox.Show("here1");
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error From CellClick: " + ex.Message.ToString());
            }
        }

        public async void loadRecord(string sql, int rowID)
        {
            try
            {
                string url = $"http://192.168.1.7:8080/api/user/{rowID}";
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    dynamic data = JsonConvert.DeserializeObject(jsonData);

                    txtFname.Text = data.fname;
                    txtLname.Text = data.lname;
                    txtUserType.Text = data.user_type;
                    txtSID.Text = data.sid;
                    txtRFID.Text = data.rfid;
                }
                else
                {
                    MessageBox.Show("No data found.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async void Dashboard_Load(object sender, EventArgs e)
        {
            await modData.loadTableHTTP(dgv_users);
            //modData.loadTable("SELECT * FROM tbl_views_registration", dgv_users);
            string[] ports = SerialPort.GetPortNames();
            cbox_ports.Items.AddRange(ports);

            if (ports.Length > 0)
                cbox_ports.SelectedIndex = 0;
            else
                cbox_ports.Items.Add("No COM ports found");
        }

        public void Cleaner()
        {
            foreach (Control obj in gbFields.Controls)
            {
                if (obj is TextBox)
                {
                    obj.Text = "";
                }
            }
            dgv_users.Tag = "";
            dgv_users.ClearSelection();

        }

        public bool CheckFields(GroupBox gb, string title)
        {
            foreach (Control obj in gb.Controls)
            {
                if (obj is TextBox)
                {
                    if (obj.Text.Length == 0)
                    {
                        MessageBox.Show("Insufficient Data!", title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtFname.Focus(); // Make sure txtManu is accessible here
                        return false;
                    }
                }
            }
            return true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (CheckFields(gbFields, "Edit"))
            {
                if (serial_port != null && serial_port.IsOpen)
                {
                    serial_port.DataReceived += SerialPort_DataReceived;
                    try
                    {
                        if (!serial_port.IsOpen)
                        {
                            serial_port.Open();
                        }
                        Toggle(true);
                        txtRFID.Enabled = false;
                        ResetGifAnimation(true);
                        txtFname.Focus();
                    }
                    catch (Exception ex)
                    {
                        pictureBox1.Enabled = false;
                        Toggle(false);
                        MessageBox.Show("Failed to open COM port: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No COM port is currently connected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void bt_connect_Click(object sender, EventArgs e)
        {
            string selectedPort = cbox_ports.SelectedItem != null ? cbox_ports.SelectedItem.ToString() : "";

            if (!string.IsNullOrEmpty(selectedPort) && selectedPort.StartsWith("COM"))
            {
                try
                {
                    if (serial_port != null && serial_port.IsOpen)
                    {
                        MessageBox.Show("Already connected.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    serial_port = new SerialPort(selectedPort, 9600);
                    serial_port.NewLine = "\r\n"; // optional, if your device uses newline
                    serial_port.DataReceived += SerialPort_DataReceived;
                    serial_port.Open();

                    MessageBox.Show(string.Format("Connected to {0}", selectedPort), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbox_ports.Enabled = false;
                    bt_disconnect.Visible = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Error: {0}", ex.Message), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a valid COM port.");
            }
        }

        private void bt_disconnect_Click(object sender, EventArgs e)
        {
            if (serial_port != null && serial_port.IsOpen)
            {
                try
                {
                    serial_port.Close();
                    serial_port.Dispose();
                    serial_port = null;

                    MessageBox.Show("Disconnected from COM port.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbox_ports.Enabled = true;
                    bt_disconnect.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Error disconnecting: {0}", ex.Message));
                }
            }
            else
            {
                MessageBox.Show("No COM port is currently connected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnDel_Click(object sender, EventArgs e)
        {
            string sql = "";
            //OdbcCommand cmd;
            if (dgv_users.Tag == null || dgv_users.Tag.ToString().Length == 0)
            {
                MessageBox.Show("Please select a record to Delete (In the Phone List Only)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure you want to DELETE this record?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        //modData.db_connect();

                        sql = "delete from tbl_user_info where id=%s";
                        //cmd = new OdbcCommand(sql, modData.dbcon);
                        //cmd.Parameters.AddWithValue("?", Convert.ToInt32(dgv_users.Tag));
                        //cmd.ExecuteNonQuery();
                        //await modData.loadTableHTTP(dgv_users);
                        //Cleaner();
                        //cmd.Dispose();
                        var data_params = new Dictionary<string, string>
                                {
                                    { "ID", Convert.ToString(dgv_users.Tag) }            // corrected
                                };
                        //MessageBox.Show(Convert.ToString(dgv_users.Tag));

                        await modData.stored_procs(sql, data_params, "delete");
                        Cleaner();
                        //await modData.loadTableHTTP(dgv_users);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error From CellClick: " + ex.Message.ToString());

                    }
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            //OdbcCommand cmd;
            string sql = "";
            //int rowsAffected = 0;
            if (CheckFields(gbFields, "Save"))
            {
                DialogResult result = MessageBox.Show("Are you sure you want to SAVE this record?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        //modData.db_connect();
                        if (dgv_users.Tag.ToString().Length == 0)
                        {
                            sql = "CALL sp_add_user(%s,%s,%s,%s,%s)";
                            //cmd = new OdbcCommand(sql, modData.dbcon);

                            //cmd.Parameters.AddWithValue("?", txtSID.Text.Trim());
                            //cmd.Parameters.AddWithValue("?", txtFname.Text.Trim());
                            //cmd.Parameters.AddWithValue("?", txtLname.Text.Trim());
                            //cmd.Parameters.AddWithValue("?", txtUserType.Text.Trim());
                            //cmd.Parameters.AddWithValue("?", txtRFID.Text.Trim());
                            var data_params = new Dictionary<string, string>
                                {
                                    { "SID", txtSID.Text.Trim() },
                                    { "FirstName", txtFname.Text.Trim() },
                                    { "LastName", txtLname.Text.Trim() },      // corrected
                                    { "UserType", txtUserType.Text.Trim() },   // corrected
                                    { "RFID", txtRFID.Text.Trim() }            // corrected
                                };

                            await modData.stored_procs(sql, data_params, "insert");

                        }
                        else
                        {
                            sql = "CALL sp_update_user(%s,%s,%s,%s,%s,%s)";
                            //cmd = new OdbcCommand(sql, modData.dbcon);
                            //cmd.Parameters.AddWithValue("?", txtSID.Text.Trim());
                            //cmd.Parameters.AddWithValue("?", txtFname.Text.Trim());
                            //cmd.Parameters.AddWithValue("?", txtLname.Text.Trim());
                            //cmd.Parameters.AddWithValue("?", txtUserType.Text.Trim());
                            //cmd.Parameters.AddWithValue("?", txtRFID.Text.Trim());
                            //cmd.Parameters.AddWithValue("?", dgv_users.Tag);

                            var data_params = new Dictionary<string, string>
                                {
                                    { "SID", txtSID.Text.Trim() },
                                    { "FirstName", txtFname.Text.Trim() },
                                    { "LastName", txtLname.Text.Trim() },      // corrected
                                    { "UserType", txtUserType.Text.Trim() },   // corrected
                                    { "RFID", txtRFID.Text.Trim() },
                                    { "ID", Convert.ToString(dgv_users.Tag)}// corrected
                                };

                            await modData.stored_procs(sql, data_params, "update");
                        }
                        
                         //call and get yung value ng rows affected. two in one code
                        //rowsAffected = cmd.ExecuteNonQuery();
                        //if (rowsAffected != -1)
                        //{
                        //    MessageBox.Show("Record saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}

                        await modData.loadTableHTTP(dgv_users);
                        Cleaner();
                        ResetGifAnimation(true);
                        Toggle(false);
                        //cmd.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error From CellClick: " + ex.Message.ToString());                        
                    }
                }
            }
        }                       

        private void txtUserType_KeyPress(object sender, KeyPressEventArgs e)
        {
            modData.NumericKey(txtUserType, e);
        }

        private void txtSID_KeyPress(object sender, KeyPressEventArgs e)
        {
            modData.NumericKey(txtSID, e);
        }

        private async void Dashboard_Activated(object sender, EventArgs e)
        {
            await modData.loadTableHTTP(dgv_users);
        }

        private async void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            //modData.loadTable("select * from tbl_views_registration where id like ? or fname like ? or lname like ? or id_lvl like ? or school_id like ? or rfid_uid like ?", dgv_users, textBox1.Text);
            await modData.loadTableHTTP(dgv_users, txtSearch.Text);
        }

        private void txtFname_KeyPress(object sender, KeyPressEventArgs e)
        {
            modData.AlphabetsKey(txtFname, e);
        }
    }
}
