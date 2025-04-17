namespace ISP_Manager

{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            clientsBtn = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            Tickets = new Button();
            employeBtn = new Button();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            logoutBtn = new Button();
            panel1 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            exitBtn = new Label();
            label1 = new Label();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // clientsBtn
            // 
            clientsBtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            clientsBtn.Font = new Font("Lucida Sans Unicode", 9F);
            clientsBtn.Location = new Point(3, 209);
            clientsBtn.Margin = new Padding(3, 2, 3, 2);
            clientsBtn.Name = "clientsBtn";
            clientsBtn.Size = new Size(157, 46);
            clientsBtn.TabIndex = 1;
            clientsBtn.Text = "Show Clients";
            clientsBtn.UseVisualStyleBackColor = true;
            clientsBtn.Click += Clients_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(Tickets, 0, 4);
            tableLayoutPanel1.Controls.Add(employeBtn, 0, 3);
            tableLayoutPanel1.Controls.Add(clientsBtn, 0, 2);
            tableLayoutPanel1.Controls.Add(button1, 0, 1);
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(logoutBtn, 0, 5);
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 157F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(163, 515);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // Tickets
            // 
            Tickets.Font = new Font("Lucida Sans Unicode", 9F);
            Tickets.Location = new Point(3, 310);
            Tickets.Name = "Tickets";
            Tickets.Size = new Size(157, 44);
            Tickets.TabIndex = 3;
            Tickets.Text = "Tickets";
            Tickets.UseVisualStyleBackColor = true;
            // 
            // employeBtn
            // 
            employeBtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            employeBtn.Font = new Font("Lucida Sans Unicode", 9F);
            employeBtn.Location = new Point(3, 260);
            employeBtn.Name = "employeBtn";
            employeBtn.Size = new Size(157, 44);
            employeBtn.TabIndex = 2;
            employeBtn.Text = "Business";
            employeBtn.UseVisualStyleBackColor = true;
            employeBtn.Click += empBtn_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Lucida Sans Unicode", 9F);
            button1.Location = new Point(3, 160);
            button1.Name = "button1";
            button1.Size = new Size(157, 44);
            button1.TabIndex = 4;
            button1.Text = "Dashboard";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.ISP_Logo;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(156, 151);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // logoutBtn
            // 
            logoutBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            logoutBtn.Font = new Font("Lucida Sans Unicode", 9F);
            logoutBtn.Location = new Point(3, 468);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.Size = new Size(157, 44);
            logoutBtn.TabIndex = 6;
            logoutBtn.Text = "Log out";
            logoutBtn.UseVisualStyleBackColor = true;
            logoutBtn.Click += logoutBtn_Click;
            // 
            // panel1
            // 
            panel1.Location = new Point(172, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(918, 515);
            panel1.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.BackColor = Color.SkyBlue;
            flowLayoutPanel1.Controls.Add(tableLayoutPanel1);
            flowLayoutPanel1.Controls.Add(panel1);
            flowLayoutPanel1.Location = new Point(2, 31);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1095, 518);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // exitBtn
            // 
            exitBtn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            exitBtn.AutoSize = true;
            exitBtn.BackColor = Color.Transparent;
            exitBtn.Font = new Font("Lucida Sans Unicode", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitBtn.Location = new Point(1066, -2);
            exitBtn.Name = "exitBtn";
            exitBtn.Padding = new Padding(0, 5, 0, 0);
            exitBtn.Size = new Size(26, 30);
            exitBtn.TabIndex = 5;
            exitBtn.Text = "X";
            exitBtn.TextAlign = ContentAlignment.MiddleCenter;
            exitBtn.Click += exitBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Lucida Sans Unicode", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(9, 5);
            label1.Name = "label1";
            label1.Size = new Size(238, 20);
            label1.TabIndex = 6;
            label1.Text = "ISP Operational Management";
            // 
            // Form1
            // 
            AccessibleRole = AccessibleRole.None;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1094, 548);
            Controls.Add(label1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(exitBtn);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button clientsBtn;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button employeBtn;
        private Button Tickets;
        private Label exitBtn;
        private Label label1;
        private Button button1;
        private PictureBox pictureBox1;
        private Button logoutBtn;
    }
}
