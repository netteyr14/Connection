using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.Odbc;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Xml.Linq;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace prfSchool_Registration
{
    class modData
    {
        //public static OdbcConnection dbcon;

        //here is the http variables
        private static readonly HttpClient client = new HttpClient();

        // Flask API Base URL (behind Nginx + Waitress)
        private static string apiBaseUrl = "http://192.168.1.7:8080/api";

        // Async method to load table data from Flask API
        public static async Task loadTableHTTP(DataGridView dgv, string search = "")
        {
            try
            {
                // Build API URL
                string url = apiBaseUrl + "/reg_table";
                if (!string.IsNullOrWhiteSpace(search))
                {
                    url += "?search=" + Uri.EscapeDataString(search.Trim());
                }

                // 1 Send GET request
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                // 2 Deserialize JSON into a list of dictionaries
                var list = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(responseBody);

                // 3. Convert list into proper DataTable
                DataTable newData = new DataTable();
                
                // 4 Always create columns, even if list is empty
                string[] columnNames = { "id", "fname", "lname", "id_lvl", "school_id", "rfid_uid" };
                foreach (var col in columnNames)
                    newData.Columns.Add(col);
                
                if (list.Count > 0)
                {
                    // 5 Add rows if list has any
                    foreach (var dict in list)
                    {
                        DataRow row = newData.NewRow();
                        foreach (var key in dict.Keys)
                            row[key] = dict[key] ?? DBNull.Value;
                        newData.Rows.Add(row);
                    }
                }

                // 6. Bind the fresh DataTable to the DataGridView
                dgv.Invoke(new MethodInvoker(delegate
                {
                    dgv.DataSource = newData; // fresh table every time
                    dgv.ClearSelection();
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Loading Data!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static async Task stored_procs(string sql, Dictionary<string, string> parameters, string sqlOperation)
        {
            try
            {
                string url = apiBaseUrl + "/" + sqlOperation;

                // Build JSON dynamically
                var data = new Dictionary<string, object> { { "Query", sql } };
                foreach (var kvp in parameters)
                    data[kvp.Key] = kvp.Value;

                string jsonData = JsonConvert.SerializeObject(data);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                // Send HTTP request based on operation
                switch (sqlOperation.ToLower())
                {
                    case "insert":
                        response = await client.PostAsync(url, content);
                        break;
                    case "update":
                        response = await client.PutAsync(url, content);
                        break;
                    case "delete":
                        var request = new HttpRequestMessage
                        {
                            Method = HttpMethod.Delete,
                            RequestUri = new Uri(url),
                            Content = content
                        };
                        response = await client.SendAsync(request);
                        break;
                    default:
                        MessageBox.Show("Invalid SQL operation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }

                // Process response
                string responseBody = await response.Content.ReadAsStringAsync();
                var jsonResponse = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseBody);

                if (jsonResponse != null && jsonResponse.ContainsKey("status"))
                {
                    string status = jsonResponse["status"];
                    string message = jsonResponse.ContainsKey("message") ? jsonResponse["message"] : "";

                    if (status == "success")
                        MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Unexpected server response: " + responseBody, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Sending Request!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //public static void db_connect()
        //{

        //    dbcon = new OdbcConnection(Properties.Resources.myDSN1);
        //    try
        //    {
        //        if (dbcon.State == ConnectionState.Closed)
        //        {
        //            dbcon.Open();
        //            // messagebox.show("connected!");
        //        }
        //        else
        //        {
        //            dbcon.Close();
        //            dbcon.Dispose();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "failed to connect to database!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        GC.Collect();
        //    }
        //}

        //public static void loadTable(string sql, DataGridView dgv, string str = "") //also for searching
        //{
        //    try
        //    {
        //        db_connect(); // Call your connection method (assumes dbcon is public/static)

        //        using (OdbcCommand cmd = new OdbcCommand(sql, dbcon))
        //        {
        //            cmd.Parameters.AddWithValue("?", "%" + str.Trim() + "%");
        //            cmd.Parameters.AddWithValue("?", "%" + str.Trim() + "%");
        //            cmd.Parameters.AddWithValue("?", "%" + str.Trim() + "%");
        //            cmd.Parameters.AddWithValue("?", "%" + str.Trim() + "%");
        //            cmd.Parameters.AddWithValue("?", "%" + str.Trim() + "%");
        //            cmd.Parameters.AddWithValue("?", "%" + str.Trim() + "%");
        //            using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
        //            {
        //                DataTable dt = new DataTable();
        //                da.Fill(dt);
        //                dgv.DataSource = dt;
        //                dgv.ClearSelection();

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error Loading Data!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        public static void NumericKey(TextBox sender, KeyPressEventArgs e, bool allowDecimal = false)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (!allowDecimal || e.KeyChar != '.' || sender.Text.Contains('.')))
            {
                // (e.KeyChar != '.') = Allows dot to be pressed avoiding e.Handled = true
                // sender.Text.Contains('.') = Allows only one dot to be pressed avoiding multiple dots
                e.Handled = true; // To stop receiving inputs
            }
        }

        public static void AlphabetsKey(TextBox sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; 
            }
        }

    }
}
