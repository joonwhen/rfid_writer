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
        }

        private void button7_Click(object sender, EventArgs e)
        {
            byte[] arrBuffer = new byte[64000];
            ushort iNum = 0;
            ushort iTotalLen = 0; 
            this.SetText("AnswerMode\r\n");
            if (RFID.CFHidApi.CFHid_InventoryG2(0xFF, arrBuffer, out iTotalLen, out iNum) == false)
            {
                this.SetText("Failed\r\n");
                return;
            }
            int iTagLength = 0;
            int iTagNumber = 0;
            iTagLength = iTotalLen;
            iTagNumber = iNum;
            if (iTagNumber == 0) return;
            int iIndex = 0;
            int iLength = 0;
            byte bPackLength = 0;
            int iIDLen = 0;
            int i = 0;

            for (iIndex = 0; iIndex < iTagNumber; iIndex++)
            {
                bPackLength = arrBuffer[iLength];
                string str2 = "";
                string str1 = "";
                str1 = arrBuffer[1 + iLength + 0].ToString("X2");
                if ((arrBuffer[1 + iLength + 0] & 0x80) == 0x80)
                {   // with TimeStamp , last 6 bytes is time
                    iIDLen = bPackLength - 7;
                }
                else iIDLen = bPackLength - 1;

                str2 = str2 + "Type:" + str1 + " ";  //Tag Type

                str1 = arrBuffer[1 + iLength + 1].ToString("X2");
                str2 = str2 + "Ant:" + str1 + " Tag:";  //Ant

                string str3 = "";
                for (i = 2; i < iIDLen; i++)
                {
                    str1 = arrBuffer[1 + iLength + i].ToString("X2");
                    str3 = str3 + str1 + " ";
                }
                str2 = str2 + str3;
                str1 = arrBuffer[1 + iLength + i].ToString("X2");
                str2 = str2 + "RSSI:" + str1 + "\r\n";  //RSSI
                iLength = iLength + bPackLength + 1;
                this.SetText(str2);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] Password = new byte[4];
            Password[0] = 0; 
            Password[1] = 0;
            Password[2] = 0;
            Password[3] = 0;
            byte[] arrBuffer = new byte[12];
            arrBuffer[0] = 0x00;
            arrBuffer[1] = 0x11;
            arrBuffer[2] = 0x22;
            arrBuffer[3] = 0x33;
            arrBuffer[4] = 0x44;
            arrBuffer[5] = 0x55;
            arrBuffer[6] = 0x66;
            arrBuffer[7] = 0x77;
            arrBuffer[8] = 0x88;
            arrBuffer[9] = 0x99;
            arrBuffer[10] = 0xAA;
            arrBuffer[11] = 0xBB;
            if (RFID.CFHidApi.CFHid_WriteCardG2(0xFF, Password, 1, 2, 6, arrBuffer) == false)
            {
                this.SetText("Faild");
                return;
            }
            this.SetText("Success");
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

        private void button4_Click(object sender, EventArgs e)
        {  //ReadRFPower
            byte bParamAddr = 0;
            byte[] bValue = new byte[2];

            /*  01: Transport
                02: WorkMode
                03: DeviceAddr
                04: FilterTime
                05: RFPower
                06: BeepEnable
                07: UartBaudRate*/
            bParamAddr = 0x05;

            if (RFID.CFHidApi.CFHid_ReadDeviceOneParam(0xFF, bParamAddr, bValue) == false)
            {
                this.SetText("Faild");
                return;
            }
            string str1 = "";
            str1 = bValue[0].ToString("d2");
            str1 = "RF:"+str1 + "\r\n";

            comboBox2.SelectedIndex = bValue[0];
            this.SetText(str1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            byte bParamAddr = 0;
            byte bValue = 0;

            /*  01: Transport
                02: WorkMode
                03: DeviceAddr
                04: FilterTime
                05: RFPower
                06: BeepEnable
                07: UartBaudRate*/
            bParamAddr = 0x05;
            //bValue = 26;   //RF = 26

            bValue = (byte)Convert.ToInt16(comboBox2.SelectedItem);

            if (RFID.CFHidApi.CFHid_SetDeviceOneParam(0xFF, bParamAddr, bValue) == false)
            {
                this.SetText("Faild");
                return;
            }
            this.SetText("Success");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (RFID.CFHidApi.CFHid_RelayOn(0xFF) == false)
            {
                this.SetText("Faild");
                return;
            }
            this.SetText("Success");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (RFID.CFHidApi.CFHid_RelayOff(0xFF) == false)
            {
                this.SetText("Faild");
                return;
            }
            this.SetText("Success");
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
                this.SetText(str2);
            }
        }

        public bool epc_in_list;

        private void user_choice(string raw_epc)
        {
            string epc = raw_epc.Replace(" ", "");
            tb_epc.Text = epc;
            tb_epc_checkout.Text = epc;
            string connstring = String.Format("Host=localhost;Port=5432;User Id=Admin;Password=password;Database=Inventory;");
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();
            var command = new NpgsqlCommand("SELECT EXISTS (SELECT 1 FROM RFID_Inventory WHERE epc = '"+epc+"');", conn);
            epc_in_list = bool.Parse(command.ExecuteScalar().ToString());
            conn.Close();
        }

        private void bn_CheckOut_Click(object sender, EventArgs e)
        {
            if(epc_in_list)
            {
                string connstring = String.Format("Host=localhost;Port=5432;User Id=Admin;Password=password;Database=Inventory;");
                NpgsqlConnection conn = new NpgsqlConnection(connstring);
                conn.Open();
                string epc = tb_epc.Text;
                string user = tb_CheckOutUser.Text;
                string time_now = DateTime.Now.ToString();
                string item_status;
                bool checkout = false;
                //Check if item is already checked out
                var command = new NpgsqlCommand("SELECT * FROM RFID_Inventory WHERE epc = '" + epc + "';", conn);
                NpgsqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    while (reader.Read())
                    {
                        item_status = reader["item_status_manual"].ToString();
                        if (item_status == "Available")
                        {
                            checkout = true;
                            command.Cancel();
                        }
                        else if (item_status == "Checked Out")
                        {
                            MessageBox.Show("Sorry, the item you wish to check out has already been checked out on the database. Check with your colleagues if they forgot to check in the item.");
                            command.Cancel();
                        }
                    }
                }
                conn.Close();
                
                if(checkout)
                {
                    conn.Open();
                    command = new NpgsqlCommand("UPDATE RFID_Inventory SET item_status_manual = 'Checked Out', personnel_checked_out = '" + user + "', time_check_out = '" + time_now + "' WHERE epc = '" + epc + "';", conn);
                    bool success = Convert.ToBoolean(command.ExecuteNonQuery());
                    conn.Close();
                    if (success)
                    {
                        MessageBox.Show("Item has been checked out by " + user + " at " + time_now);
                    }
                    else
                    {
                        MessageBox.Show("Error: Item has not been checked out.");
                    }
                    string logtext = "[OUT][" + time_now + "]" + " EPC: " + epc + " has been checked out by " + user + "." + Environment.NewLine;
                    File.AppendAllText("InventoryLog.txt", logtext);
                }

            }
            else
            {
                MessageBox.Show("Unable to check item out as it does not exist on the database.");
            }
        }

        private void bn_AddItem_Click(object sender, EventArgs e)
        {
            string connstring = String.Format("Host=localhost;Port=5432;User Id=Admin;Password=password;Database=Inventory;");
            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();
            string epc = tb_epc.Text;
            string tagname = tb_name.Text;
            string tagloc = tb_loc.Text;
            string tagdesc = tb_desc.Text;
            string item_sn = tb_sn.Text;
            string time_now = DateTime.Now.ToString();
            string user = tb_user_CheckIn.Text;

            if (epc_in_list)
            {
                MessageBox.Show("Unable to add this entry into the database as the EPC already exists.");
            }
            else
            {
                var command = new NpgsqlCommand("INSERT INTO RFID_Inventory (epc, tagname, tagloc, tagdesc, item_sn, personnel_checked_in, time_checked_in, item_status_manual) VALUES ('" + epc + "', '" + tagname + "', '" + tagloc + "', '" + tagdesc + "', '" + item_sn + "', '" + user + "', '" + time_now + "', 'Available');", conn);
                int success = command.ExecuteNonQuery();
                if (success == -1)
                {
                    MessageBox.Show("Error: Unable to add the entry to database!");
                }
                else
                {
                    MessageBox.Show("Successfully added to the database!");
                    string logtext = "[IN][" + time_now + "]" + " EPC: " + epc + " has been checked in." + Environment.NewLine;
                    File.AppendAllText("InventoryLog.txt", logtext);
                }
            }
            conn.Close();
        }

        private void bn_ClearEntry_Click(object sender, EventArgs e)
        {
            tb_epc.Clear();
            tb_name.Clear();
            tb_loc.Clear();
            tb_desc.Clear();
            tb_sn.Clear();
        }
    }
}