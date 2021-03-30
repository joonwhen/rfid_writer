using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using RFID;
using System.Runtime.InteropServices;
using Npgsql;
using System.IO;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
            button11.Enabled = false;

            bn_AddItem.Enabled = false;
            bn_ClearEntry.Enabled = false;
            bn_return.Enabled = false;
            bn_CheckOut.Enabled = false;

            string strSN = "";
            byte[] arrBuffer = new byte[512];
            int iHidNumber = 0;
            UInt16 iIndex = 0;
            comboBox1.Items.Clear();
            iHidNumber = RFID.CFHidApi.CFHid_GetUsbCount();
            for (iIndex = 0; iIndex < iHidNumber; iIndex++)
            {
                RFID.CFHidApi.CFHid_GetUsbInfo(iIndex, arrBuffer);
                strSN = System.Text.Encoding.Default.GetString(arrBuffer);
                comboBox1.Items.Add(strSN);
            }
            if (iHidNumber > 0)
                comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {  
            byte[] arrBuffer = new byte[64];

            if (RFID.CFHidApi.CFHid_OpenDevice((UInt16)comboBox1.SelectedIndex))
            {
				this.SetText("Open Success\r\n");
                if (RFID.CFHidApi.CFHid_GetDeviceSystemInfo(0xFF,arrBuffer) == false) //获取系统信息失败
                {
                    this.SetText("Device is Out\r\n");
                    //RFID.CFHidApi.CFHid_CloseDevice();
                    //return;
                }
                button6.Enabled = true;
            }
            else
            {
                this.SetText("Failed\r\n");
                return;
            }

            string str = "",str1="";
            str = String.Format("SoftVer:{0:D}.{0:D}\r\n", arrBuffer[0] >> 4, arrBuffer[0] & 0x0F);
            this.SetText(str);
            str = String.Format("HardVer:{0:D}.{0:D}\r\n", arrBuffer[1] >> 4, arrBuffer[1] & 0x0F);
            this.SetText(str);
            str = "SN:";
            for (int i = 0; i < 7; i++)
            {
                str1 = String.Format("{0:X2}", arrBuffer[2 + i]);
                str = str + str1;
            }
            str = str + "\r\n";
            this.SetText(str);
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            RFID.CFHidApi.CFHid_CloseDevice();
            button1.Enabled = true;
            button2.Enabled = false;
            button6.Enabled = false; //jw
            button11.Enabled = false;
            this.SetText("Close\r\n");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            button6.Enabled = true;
            button11.Enabled = false;
            bn_AddItem.Enabled = false;
            bn_ClearEntry.Enabled = false;
            bn_return.Enabled = false;
            bn_CheckOut.Enabled = false;
        }

        delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            if (this.textBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                if (this.textBox1.TextLength > 1000) this.textBox1.Text = "";
                this.textBox1.Text = this.textBox1.Text + text;
                this.textBox1.SelectionStart = this.textBox1.Text.Length;
                this.textBox1.ScrollToCaret(); 
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.SetText("Real Time Mode Running ...\r\n");
            RFID.CFHidApi.CFHid_ClearTagBuf();
            timer1.Interval = 100;
            timer1.Enabled = true;
            button6.Enabled = false;
            button11.Enabled = true;
            bn_AddItem.Enabled = true;
            bn_ClearEntry.Enabled = true;
            bn_return.Enabled = true;
            bn_CheckOut.Enabled = true;
            connected_db = status_check();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            string strSN = "";
            byte[] arrBuffer = new byte[256];
            int iHidNumber = 0;
            UInt16 iIndex = 0;
            comboBox1.Items.Clear();
            iHidNumber = RFID.CFHidApi.CFHid_GetUsbCount();
            for (iIndex = 0; iIndex < iHidNumber; iIndex++)
            {
                RFID.CFHidApi.CFHid_GetUsbInfo(iIndex, arrBuffer);
                strSN = System.Text.Encoding.Default.GetString(arrBuffer);
                comboBox1.Items.Add(strSN);
            }
            if (iHidNumber > 0)
                comboBox1.SelectedIndex = 0;
        }
 
        private void timer1_Tick(object sender, EventArgs e)
        {
            byte[] arrBuffer = new byte[64000];
            int iNum = 0;
            int iTotalLen = 0;
            byte bRet = 0;

            bRet = RFID.CFHidApi.CFHid_GetTagBuf(arrBuffer, out iTotalLen, out iNum);
            if (bRet == 1)
            {
                this.SetText("DevOut");
                return; //DevOut
            }
            else if (bRet == 0) return; //No Connect
            int iTagLength = 0;
            int iTagNumber = 0;
            iTagLength = iTotalLen;
            iTagNumber = iNum;
            if (iTagNumber == 0) return;
            int iIndex = 0;
            int iLength = 0;
            byte bPackLength = 0;
            int i = 0;
            int iIDLen = 0;
            for (iIndex = 0; iIndex < iTagNumber; iIndex++)
            {
                bPackLength = arrBuffer[iLength];
                string str2 = "";
                string str1 = "";
                str1 = arrBuffer[1 + iLength + 0].ToString("X2");
                str2 = str2 + "Type:" + str1 + " ";  //Tag Type
                if ((arrBuffer[1 + iLength + 0] & 0x80) == 0x80)
                {   // with TimeStamp , last 6 bytes is time
                    iIDLen = bPackLength - 7;
                }
                else iIDLen = bPackLength - 1;

                str1 = arrBuffer[1 + iLength + 1].ToString("X2");
                str2 = str2 + "Ant:" + str1 + " Tag:";  //Ant

                string str3 = "";
                for (i = 2; i < iIDLen; i++)
                {
                    str1 = arrBuffer[1 + iLength + i].ToString("X2");
                    str3 = str3 + str1 + " ";
                }
                str2 = str2 + str3;
                //get epc
                user_choice(str3);
                str1 = arrBuffer[1 + iLength + i].ToString("X2");
                str2 = str2 + "RSSI:" + str1 + "\r\n";  //RSSI
                iLength = iLength + bPackLength + 1;
                //this.SetText(str2);
            }
        }

        public static bool epc_in_list;
        public volatile bool connected_db = false;

        private void user_choice(string raw_epc)
        {
            string epc = raw_epc.Replace(" ", "");
            tb_epc.Text = epc;
            tb_epc_checkout.Text = epc;
            tb_return_epc.Text = epc;
            string connstring = String.Format("Host=localhost;Port=5432;User Id=Admin;Password=password;Database=Inventory;");
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            if(connected_db)
            {
                try
                {
                    conn.Open();
                    var command = new NpgsqlCommand("SELECT EXISTS (SELECT 1 FROM item_inventory WHERE epc = '" + epc + "');", conn);
                    epc_in_list = bool.Parse(command.ExecuteScalar().ToString());
                    conn.Close();
                }
                catch(Exception em)
                {
                }
                
            }
            else
            {
            }
        }

        private void bn_AddItem_Click(object sender, EventArgs e)
        {
            connected_db = status_check();
            if (connected_db)
            {
                string connstring = String.Format("Host=localhost;Port=5432;User Id=Admin;Password=password;Database=Inventory;");
                string epc = tb_epc.Text;
                string tagname = tb_name.Text;
                string tagloc = tb_loc.Text;
                string tagdesc = tb_desc.Text;
                string item_sn = tb_sn.Text;
                string time_now = DateTime.Now.ToString();
                string user = tb_user_CheckIn.Text;
                string item_condition = cb_condition.Text;
                bool added_to_db = true;
                NpgsqlConnection conn = new NpgsqlConnection(connstring);
                conn.Open();

                foreach (Control control in gb_add_items.Controls)
                {
                    if (control is TextBox)
                    {
                        TextBox tb = control as TextBox;
                        if (string.IsNullOrEmpty(tb.Text))
                        {
                            added_to_db = false;
                            break;
                        }
                    }
                }

                if (cb_condition.SelectedIndex > -1)
                {
                }

                else
                {
                    added_to_db = false;
                }

                if (added_to_db)
                {

                    if (epc_in_list)
                    {
                        MessageBox.Show("Error: Unable to add this entry into the database as the EPC already exists.");
                    }
                    else
                    {
                        var command = new NpgsqlCommand("BEGIN; " +
                            "INSERT INTO item_status(epc, automated_status, manual_status, last_read_time, error_status) VALUES('"+epc+"', 'Available', 'Available', '"+ time_now + "', ' '); " +
                            "INSERT INTO item_inventory(epc, item_name, item_location, item_serial_number, item_condition, item_description) VALUES('" + epc + "', '" + tagname + "', '" + tagloc + "', '" + item_sn + "', '" + item_condition + "', '" + tagdesc + "'); " +
                            "INSERT INTO item_movement(epc, personnel_checked_in, time_in)  VALUES('" + epc + "', '" + user + "', '" + time_now + "');" +
                            "COMMIT; ", conn);
                        int success = command.ExecuteNonQuery();
                        if (success == -1)
                        {
                            MessageBox.Show("Error: Unable to add the entry to database!");
                        }
                        else
                        {
                            MessageBox.Show("Successfully added to the database!");
                            string logtext = "[" + time_now + "][IN]" + " EPC: " + epc + " has been added by " + user + ". Condition of item: " + item_condition + Environment.NewLine;
                            File.AppendAllText("logs/InventoryLog.txt", logtext);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error: Failed to add to database. Missing information.");
                }
                conn.Close();
            }
            else
            {
                MessageBox.Show("Error: Not Connected to Database.");
            }
        }

        private bool status_check()
        {
            string connstring = String.Format("Host=localhost;Port=5432;User Id=Admin;Password=password;Database=Inventory;");
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            try
            {
                conn.Open();
                conn.Close();
                return true;
            }
            catch (Exception em)
            {
                return false;
            }
        }

        private void bn_return_Click(object sender, EventArgs e)
        {
            connected_db = status_check();
            if (connected_db)
            {
                string epc = tb_return_epc.Text;
                string user = tb_return_user.Text;
                string item_condition = cb_return_condition.Text;
                string time_now = DateTime.Now.ToString();
                string connstring = String.Format("Host=localhost;Port=5432;User Id=Admin;Password=password;Database=Inventory;");
                string item_status;
                bool return_item = false;
                NpgsqlConnection conn = new NpgsqlConnection(connstring);
                if (epc_in_list)
                {
                    conn.Open();
                    var command = new NpgsqlCommand("SELECT * FROM item_status WHERE epc = '" + epc + "';", conn);
                    NpgsqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            item_status = reader["manual_status"].ToString();
                            if (item_status == "Available")
                            {
                                return_item = false;
                                command.Cancel();
                                MessageBox.Show("Item has already been returned.");
                            }
                            else if (item_status == "Checked Out")
                            {
                                return_item = true;
                                command.Cancel();
                            }
                        }
                    }
                    conn.Close();

                    if (return_item)
                    {
                        bool return_success = true;

                        foreach (Control control in gb_return.Controls)
                        {
                            if (control is TextBox)
                            {
                                TextBox tb = control as TextBox;
                                if (string.IsNullOrEmpty(tb.Text))
                                {
                                    return_success = false;
                                    break;
                                }
                            }
                        }

                        if (return_success)
                        {
                            conn.Open();
                            command = new NpgsqlCommand("BEGIN; " +
                            "UPDATE item_status SET manual_status = 'Available' where epc = '" + epc + "'; " +
                            "UPDATE item_movement SET personnel_checked_in = '" + user + "', time_in = '" + time_now + "' where epc = '" + epc + "' ;" +
                            "COMMIT; ", conn) ;
                            bool success = Convert.ToBoolean(command.ExecuteNonQuery());
                            if (success)
                            {
                                MessageBox.Show("Item has been returned.");
                                string logtext = "[" + time_now + "][IN]" + " EPC: " + epc + " has been returned by " + user + ". Condition of item: " + item_condition + Environment.NewLine;
                                File.AppendAllText("logs/InventoryLog.txt", logtext);
                            }
                            else
                            {
                                MessageBox.Show("Error occurred returning item.");
                            }
                            conn.Close();
                        }
                        else
                        {
                            MessageBox.Show("Error: Failed to return item. Please provide the details.");
                        }

                    }
                }
                else
                {
                    MessageBox.Show("EPC not in list.");
                }
            }
            else
            {
                MessageBox.Show("Error: Not Connected to Database.");
            }
        }

        private void bn_CheckOut_Click(object sender, EventArgs e)
        {
            connected_db = status_check();
            if (connected_db)
            {
                if (epc_in_list)
                {
                    string connstring = String.Format("Host=localhost;Port=5432;User Id=Admin;Password=password;Database=Inventory;");
                    NpgsqlConnection conn = new NpgsqlConnection(connstring); conn.Open();
                    string epc = tb_epc.Text;
                    string user = tb_CheckOutUser.Text;
                    string time_now = DateTime.Now.ToString();
                    string item_desc = tb_CheckOut_Desc.Text;
                    string item_status;
                    bool checkout = false;
                    //Check if item is already checked out
                    var command = new NpgsqlCommand("SELECT * FROM item_status WHERE epc = '" + epc + "';", conn);
                    NpgsqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            item_status = reader["manual_status"].ToString();
                            if (item_status == "Available")
                            {
                                checkout = true;
                                command.Cancel();
                            }
                            else if (item_status == "Checked Out")
                            {
                                MessageBox.Show("Sorry, the item you wish to check out has already been checked out.");
                                command.Cancel();
                            }
                        }
                    }
                    reader.Close();
                    conn.Close();

                    if (checkout)
                    {
                        bool checkout_success = true;

                        foreach (Control control in gb_checkout.Controls)
                        {
                            if (control is TextBox)
                            {
                                TextBox tb = control as TextBox;
                                if (string.IsNullOrEmpty(tb.Text))
                                {
                                    checkout_success = false;
                                    break;
                                }
                            }
                        }

                        if (checkout_success)
                        {
                            conn.Open();
                            command = new NpgsqlCommand("BEGIN; " +
                            "UPDATE item_status SET manual_status = 'Checked Out', last_read_time = '" + time_now + "' where epc = '" + epc + "'; " +
                            "UPDATE item_movement SET personnel_checked_out = '" + user + "', time_out = '" + time_now + "' where epc = '" + epc + "' ;" +
                            "COMMIT; ", conn); 
                            bool success = Convert.ToBoolean(command.ExecuteNonQuery());
                            conn.Close();
                            if (success)
                            {
                                MessageBox.Show("Item has been checked out by " + user + " at " + time_now);
                                string logtext = "[" + time_now + "][OUT]" + " EPC: " + epc + " has been checked out by " + user + ". Remarks: " + item_desc + Environment.NewLine;
                                File.AppendAllText("logs/InventoryLog.txt", logtext);
                            }
                            else
                            {
                                MessageBox.Show("Error: Item has not been checked out.");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Error: Failed to check out. Please provide your details.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Unable to check item out as it does not exist on the database.");
                }
            }
            else
            {
                MessageBox.Show("Error: Not Connected to Database.");
            }
        }

        private void bn_ClearEntry_Click(object sender, EventArgs e)
        {
            tb_name.Clear();
            tb_loc.Clear();
            tb_desc.Clear();
            tb_sn.Clear();
            tb_user_CheckIn.Clear();
        }

    }
}