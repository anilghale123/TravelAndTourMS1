namespace TravelAndTourMS
{
    partial class Form13
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.RoomNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckaInDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckOutDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hotel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.availabiliti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RoomNum,
            this.CheckaInDate,
            this.CheckOutDate,
            this.RoomType,
            this.hotel,
            this.availabiliti});
            this.dataGridView1.Location = new System.Drawing.Point(208, 95);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(793, 503);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // RoomNum
            // 
            this.RoomNum.HeaderText = "RoomNum";
            this.RoomNum.MinimumWidth = 6;
            this.RoomNum.Name = "RoomNum";
            this.RoomNum.Width = 125;
            // 
            // CheckaInDate
            // 
            this.CheckaInDate.HeaderText = "CheckaInDate";
            this.CheckaInDate.MinimumWidth = 6;
            this.CheckaInDate.Name = "CheckaInDate";
            this.CheckaInDate.Width = 125;
            // 
            // CheckOutDate
            // 
            this.CheckOutDate.HeaderText = "CheckOutDate";
            this.CheckOutDate.MinimumWidth = 6;
            this.CheckOutDate.Name = "CheckOutDate";
            this.CheckOutDate.Width = 125;
            // 
            // RoomType
            // 
            this.RoomType.HeaderText = "RoomType";
            this.RoomType.MinimumWidth = 6;
            this.RoomType.Name = "RoomType";
            this.RoomType.Width = 125;
            // 
            // hotel
            // 
            this.hotel.HeaderText = "hotel";
            this.hotel.MinimumWidth = 6;
            this.hotel.Name = "hotel";
            this.hotel.Width = 125;
            // 
            // availabiliti
            // 
            this.availabiliti.HeaderText = "availabiliti";
            this.availabiliti.MinimumWidth = 6;
            this.availabiliti.Name = "availabiliti";
            this.availabiliti.Width = 125;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(488, 667);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(673, 677);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 29);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(825, 677);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 29);
            this.button3.TabIndex = 3;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // Form13
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 741);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form13";
            this.Text = "Form13";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn RoomNum;
        private DataGridViewTextBoxColumn CheckaInDate;
        private DataGridViewTextBoxColumn CheckOutDate;
        private DataGridViewTextBoxColumn RoomType;
        private DataGridViewTextBoxColumn hotel;
        private DataGridViewTextBoxColumn availabiliti;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}