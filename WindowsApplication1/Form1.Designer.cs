namespace WindowsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// 
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows

        /// <summary>
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.COM = new System.Windows.Forms.Label();
            this.button30 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbl_epc = new System.Windows.Forms.Label();
            this.gb_add_items = new System.Windows.Forms.GroupBox();
            this.bn_AddItem = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_condition = new System.Windows.Forms.ComboBox();
            this.tb_user_CheckIn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_desc = new System.Windows.Forms.TextBox();
            this.lbl_desc = new System.Windows.Forms.Label();
            this.tb_loc = new System.Windows.Forms.TextBox();
            this.lbl_loc = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.lbl_name = new System.Windows.Forms.Label();
            this.tb_sn = new System.Windows.Forms.TextBox();
            this.lbl_sn = new System.Windows.Forms.Label();
            this.tb_epc = new System.Windows.Forms.TextBox();
            this.gb_checkout = new System.Windows.Forms.GroupBox();
            this.tb_CheckOut_Desc = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_CheckOutUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_epc_checkout = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gb_return = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_return_epc = new System.Windows.Forms.TextBox();
            this.tb_return_user = new System.Windows.Forms.TextBox();
            this.cb_return_condition = new System.Windows.Forms.ComboBox();
            this.bn_return = new System.Windows.Forms.Button();
            this.bn_CheckOut = new System.Windows.Forms.Button();
            this.bn_ClearEntry = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gb_add_items.SuspendLayout();
            this.gb_checkout.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.gb_return.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(96, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteCustomSource.AddRange(new string[] {
            "COM1",
            "COM2"});
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10"});
            this.comboBox1.Location = new System.Drawing.Point(47, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(190, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Tag = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(177, 50);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 50);
            this.button2.TabIndex = 2;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button6
            // 
            this.button6.Enabled = false;
            this.button6.Location = new System.Drawing.Point(6, 25);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(110, 41);
            this.button6.TabIndex = 0;
            this.button6.Text = "Read Tag";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(132, 25);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(110, 41);
            this.button11.TabIndex = 10;
            this.button11.Text = "Stop Reading";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.COM);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.button30);
            this.groupBox3.Location = new System.Drawing.Point(12, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(248, 116);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Connection";
            // 
            // COM
            // 
            this.COM.AutoSize = true;
            this.COM.Location = new System.Drawing.Point(12, 19);
            this.COM.Name = "COM";
            this.COM.Size = new System.Drawing.Size(32, 13);
            this.COM.TabIndex = 3;
            this.COM.Text = "USB:";
            // 
            // button30
            // 
            this.button30.Location = new System.Drawing.Point(15, 50);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(60, 50);
            this.button30.TabIndex = 4;
            this.button30.Text = "Scan USB";
            this.button30.UseVisualStyleBackColor = true;
            this.button30.Click += new System.EventHandler(this.button30_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button11);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Location = new System.Drawing.Point(12, 133);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 72);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ActiveMode";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbl_epc
            // 
            this.lbl_epc.AutoSize = true;
            this.lbl_epc.Location = new System.Drawing.Point(40, 24);
            this.lbl_epc.Name = "lbl_epc";
            this.lbl_epc.Size = new System.Drawing.Size(31, 13);
            this.lbl_epc.TabIndex = 30;
            this.lbl_epc.Text = "EPC:";
            // 
            // gb_add_items
            // 
            this.gb_add_items.Controls.Add(this.bn_ClearEntry);
            this.gb_add_items.Controls.Add(this.bn_AddItem);
            this.gb_add_items.Controls.Add(this.label3);
            this.gb_add_items.Controls.Add(this.cb_condition);
            this.gb_add_items.Controls.Add(this.tb_user_CheckIn);
            this.gb_add_items.Controls.Add(this.label1);
            this.gb_add_items.Controls.Add(this.tb_desc);
            this.gb_add_items.Controls.Add(this.lbl_desc);
            this.gb_add_items.Controls.Add(this.tb_loc);
            this.gb_add_items.Controls.Add(this.lbl_loc);
            this.gb_add_items.Controls.Add(this.tb_name);
            this.gb_add_items.Controls.Add(this.lbl_name);
            this.gb_add_items.Controls.Add(this.tb_sn);
            this.gb_add_items.Controls.Add(this.lbl_sn);
            this.gb_add_items.Controls.Add(this.tb_epc);
            this.gb_add_items.Controls.Add(this.lbl_epc);
            this.gb_add_items.Location = new System.Drawing.Point(266, 7);
            this.gb_add_items.Name = "gb_add_items";
            this.gb_add_items.Size = new System.Drawing.Size(270, 316);
            this.gb_add_items.TabIndex = 31;
            this.gb_add_items.TabStop = false;
            this.gb_add_items.Text = "Add Items to Store";
            // 
            // bn_AddItem
            // 
            this.bn_AddItem.Location = new System.Drawing.Point(73, 286);
            this.bn_AddItem.Name = "bn_AddItem";
            this.bn_AddItem.Size = new System.Drawing.Size(89, 23);
            this.bn_AddItem.TabIndex = 52;
            this.bn_AddItem.Text = "Add Item";
            this.bn_AddItem.UseVisualStyleBackColor = true;
            this.bn_AddItem.Click += new System.EventHandler(this.bn_AddItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Condition:";
            // 
            // cb_condition
            // 
            this.cb_condition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_condition.FormattingEnabled = true;
            this.cb_condition.Items.AddRange(new object[] {
            "Spoilt",
            "Tested Working",
            "Untested"});
            this.cb_condition.Location = new System.Drawing.Point(73, 259);
            this.cb_condition.Name = "cb_condition";
            this.cb_condition.Size = new System.Drawing.Size(188, 21);
            this.cb_condition.TabIndex = 47;
            // 
            // tb_user_CheckIn
            // 
            this.tb_user_CheckIn.Location = new System.Drawing.Point(73, 232);
            this.tb_user_CheckIn.Name = "tb_user_CheckIn";
            this.tb_user_CheckIn.Size = new System.Drawing.Size(188, 20);
            this.tb_user_CheckIn.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Name:";
            // 
            // tb_desc
            // 
            this.tb_desc.Location = new System.Drawing.Point(73, 126);
            this.tb_desc.Multiline = true;
            this.tb_desc.Name = "tb_desc";
            this.tb_desc.Size = new System.Drawing.Size(188, 100);
            this.tb_desc.TabIndex = 39;
            // 
            // lbl_desc
            // 
            this.lbl_desc.AutoSize = true;
            this.lbl_desc.Location = new System.Drawing.Point(4, 129);
            this.lbl_desc.Name = "lbl_desc";
            this.lbl_desc.Size = new System.Drawing.Size(63, 13);
            this.lbl_desc.TabIndex = 38;
            this.lbl_desc.Text = "Description:";
            // 
            // tb_loc
            // 
            this.tb_loc.Location = new System.Drawing.Point(73, 100);
            this.tb_loc.Name = "tb_loc";
            this.tb_loc.Size = new System.Drawing.Size(188, 20);
            this.tb_loc.TabIndex = 37;
            // 
            // lbl_loc
            // 
            this.lbl_loc.AutoSize = true;
            this.lbl_loc.Location = new System.Drawing.Point(19, 103);
            this.lbl_loc.Name = "lbl_loc";
            this.lbl_loc.Size = new System.Drawing.Size(51, 13);
            this.lbl_loc.TabIndex = 36;
            this.lbl_loc.Text = "Location:";
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(73, 74);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(188, 20);
            this.tb_name.TabIndex = 35;
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(10, 77);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(61, 13);
            this.lbl_name.TabIndex = 34;
            this.lbl_name.Text = "Item Name:";
            // 
            // tb_sn
            // 
            this.tb_sn.Location = new System.Drawing.Point(73, 47);
            this.tb_sn.Name = "tb_sn";
            this.tb_sn.Size = new System.Drawing.Size(188, 20);
            this.tb_sn.TabIndex = 33;
            // 
            // lbl_sn
            // 
            this.lbl_sn.AutoSize = true;
            this.lbl_sn.Location = new System.Drawing.Point(40, 50);
            this.lbl_sn.Name = "lbl_sn";
            this.lbl_sn.Size = new System.Drawing.Size(30, 13);
            this.lbl_sn.TabIndex = 32;
            this.lbl_sn.Text = "S/N:";
            // 
            // tb_epc
            // 
            this.tb_epc.Location = new System.Drawing.Point(73, 21);
            this.tb_epc.Name = "tb_epc";
            this.tb_epc.ReadOnly = true;
            this.tb_epc.Size = new System.Drawing.Size(188, 20);
            this.tb_epc.TabIndex = 31;
            // 
            // gb_checkout
            // 
            this.gb_checkout.Controls.Add(this.bn_CheckOut);
            this.gb_checkout.Controls.Add(this.tb_CheckOut_Desc);
            this.gb_checkout.Controls.Add(this.label8);
            this.gb_checkout.Controls.Add(this.tb_CheckOutUser);
            this.gb_checkout.Controls.Add(this.label4);
            this.gb_checkout.Controls.Add(this.tb_epc_checkout);
            this.gb_checkout.Controls.Add(this.label5);
            this.gb_checkout.Location = new System.Drawing.Point(542, 158);
            this.gb_checkout.Name = "gb_checkout";
            this.gb_checkout.Size = new System.Drawing.Size(289, 214);
            this.gb_checkout.TabIndex = 43;
            this.gb_checkout.TabStop = false;
            this.gb_checkout.Text = "Checkout Item from Store";
            // 
            // tb_CheckOut_Desc
            // 
            this.tb_CheckOut_Desc.Location = new System.Drawing.Point(70, 73);
            this.tb_CheckOut_Desc.Multiline = true;
            this.tb_CheckOut_Desc.Name = "tb_CheckOut_Desc";
            this.tb_CheckOut_Desc.Size = new System.Drawing.Size(188, 100);
            this.tb_CheckOut_Desc.TabIndex = 53;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 52;
            this.label8.Text = "Description:";
            // 
            // tb_CheckOutUser
            // 
            this.tb_CheckOutUser.Location = new System.Drawing.Point(70, 47);
            this.tb_CheckOutUser.Name = "tb_CheckOutUser";
            this.tb_CheckOutUser.Size = new System.Drawing.Size(188, 20);
            this.tb_CheckOutUser.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Name:";
            // 
            // tb_epc_checkout
            // 
            this.tb_epc_checkout.Location = new System.Drawing.Point(70, 20);
            this.tb_epc_checkout.Name = "tb_epc_checkout";
            this.tb_epc_checkout.ReadOnly = true;
            this.tb_epc_checkout.Size = new System.Drawing.Size(188, 20);
            this.tb_epc_checkout.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "EPC:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox1);
            this.groupBox5.Location = new System.Drawing.Point(12, 329);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(524, 94);
            this.groupBox5.TabIndex = 45;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Console:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 19);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(509, 69);
            this.textBox1.TabIndex = 33;
            // 
            // gb_return
            // 
            this.gb_return.Controls.Add(this.bn_return);
            this.gb_return.Controls.Add(this.cb_return_condition);
            this.gb_return.Controls.Add(this.tb_return_user);
            this.gb_return.Controls.Add(this.tb_return_epc);
            this.gb_return.Controls.Add(this.label9);
            this.gb_return.Controls.Add(this.label6);
            this.gb_return.Controls.Add(this.label2);
            this.gb_return.Location = new System.Drawing.Point(542, 7);
            this.gb_return.Name = "gb_return";
            this.gb_return.Size = new System.Drawing.Size(289, 142);
            this.gb_return.TabIndex = 46;
            this.gb_return.TabStop = false;
            this.gb_return.Text = "Return Items to Store";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 54;
            this.label9.Text = "Condition:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "EPC:";
            // 
            // tb_return_epc
            // 
            this.tb_return_epc.Location = new System.Drawing.Point(70, 21);
            this.tb_return_epc.Name = "tb_return_epc";
            this.tb_return_epc.ReadOnly = true;
            this.tb_return_epc.Size = new System.Drawing.Size(188, 20);
            this.tb_return_epc.TabIndex = 55;
            // 
            // tb_return_user
            // 
            this.tb_return_user.Location = new System.Drawing.Point(70, 47);
            this.tb_return_user.Name = "tb_return_user";
            this.tb_return_user.Size = new System.Drawing.Size(188, 20);
            this.tb_return_user.TabIndex = 56;
            // 
            // cb_return_condition
            // 
            this.cb_return_condition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_return_condition.FormattingEnabled = true;
            this.cb_return_condition.Items.AddRange(new object[] {
            "Spoilt",
            "Tested Working",
            "Untested"});
            this.cb_return_condition.Location = new System.Drawing.Point(70, 73);
            this.cb_return_condition.Name = "cb_return_condition";
            this.cb_return_condition.Size = new System.Drawing.Size(188, 21);
            this.cb_return_condition.TabIndex = 57;
            // 
            // bn_return
            // 
            this.bn_return.Location = new System.Drawing.Point(70, 103);
            this.bn_return.Name = "bn_return";
            this.bn_return.Size = new System.Drawing.Size(188, 23);
            this.bn_return.TabIndex = 58;
            this.bn_return.Text = "Return Item";
            this.bn_return.UseVisualStyleBackColor = true;
            this.bn_return.Click += new System.EventHandler(this.bn_return_Click);
            // 
            // bn_CheckOut
            // 
            this.bn_CheckOut.Location = new System.Drawing.Point(70, 179);
            this.bn_CheckOut.Name = "bn_CheckOut";
            this.bn_CheckOut.Size = new System.Drawing.Size(188, 23);
            this.bn_CheckOut.TabIndex = 54;
            this.bn_CheckOut.Text = "Checkout";
            this.bn_CheckOut.UseVisualStyleBackColor = true;
            this.bn_CheckOut.Click += new System.EventHandler(this.bn_CheckOut_Click);
            // 
            // bn_ClearEntry
            // 
            this.bn_ClearEntry.Location = new System.Drawing.Point(172, 286);
            this.bn_ClearEntry.Name = "bn_ClearEntry";
            this.bn_ClearEntry.Size = new System.Drawing.Size(89, 23);
            this.bn_ClearEntry.TabIndex = 53;
            this.bn_ClearEntry.Text = "Clear";
            this.bn_ClearEntry.UseVisualStyleBackColor = true;
            this.bn_ClearEntry.Click += new System.EventHandler(this.bn_ClearEntry_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 429);
            this.Controls.Add(this.gb_return);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.gb_checkout);
            this.Controls.Add(this.gb_add_items);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Name = "Form1";
            this.Text = "USB";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.gb_add_items.ResumeLayout(false);
            this.gb_add_items.PerformLayout();
            this.gb_checkout.ResumeLayout(false);
            this.gb_checkout.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.gb_return.ResumeLayout(false);
            this.gb_return.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label COM;
        private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button30;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbl_epc;
        private System.Windows.Forms.GroupBox gb_add_items;
        private System.Windows.Forms.TextBox tb_epc;
        private System.Windows.Forms.TextBox tb_desc;
        private System.Windows.Forms.Label lbl_desc;
        private System.Windows.Forms.TextBox tb_loc;
        private System.Windows.Forms.Label lbl_loc;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.TextBox tb_sn;
        private System.Windows.Forms.Label lbl_sn;
        private System.Windows.Forms.GroupBox gb_checkout;
        private System.Windows.Forms.TextBox tb_CheckOutUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_epc_checkout;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_user_CheckIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_condition;
        private System.Windows.Forms.GroupBox gb_return;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_CheckOut_Desc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bn_AddItem;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cb_return_condition;
        private System.Windows.Forms.TextBox tb_return_user;
        private System.Windows.Forms.TextBox tb_return_epc;
        private System.Windows.Forms.Button bn_return;
        private System.Windows.Forms.Button bn_CheckOut;
        private System.Windows.Forms.Button bn_ClearEntry;
    }
}

