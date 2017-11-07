namespace perceptronic
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.w_datagridview = new System.Windows.Forms.DataGridView();
            this.dgv_W_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_W_result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.E_min_txtbx = new System.Windows.Forms.TextBox();
            this.E_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.reset_bttn = new System.Windows.Forms.Button();
            this.alpha_txtbx = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SamplesUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.start_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.NeuronsUpDown = new System.Windows.Forms.NumericUpDown();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radio_sin = new System.Windows.Forms.RadioButton();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.blending_UP_DOWN = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.w_datagridview)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SamplesUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NeuronsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blending_UP_DOWN)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(974, 522);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 241F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(974, 522);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.w_datagridview, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(736, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(235, 386);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // w_datagridview
            // 
            this.w_datagridview.AllowUserToAddRows = false;
            this.w_datagridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.w_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.w_datagridview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv_W_column,
            this.dgv_W_result});
            this.w_datagridview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.w_datagridview.Location = new System.Drawing.Point(3, 79);
            this.w_datagridview.Name = "w_datagridview";
            this.w_datagridview.RowHeadersVisible = false;
            this.w_datagridview.Size = new System.Drawing.Size(229, 304);
            this.w_datagridview.TabIndex = 1;
            // 
            // dgv_W_column
            // 
            this.dgv_W_column.HeaderText = "W";
            this.dgv_W_column.Name = "dgv_W_column";
            this.dgv_W_column.Width = 43;
            // 
            // dgv_W_result
            // 
            this.dgv_W_result.HeaderText = "result";
            this.dgv_W_result.Name = "dgv_W_result";
            this.dgv_W_result.Width = 57;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.E_min_txtbx);
            this.panel4.Controls.Add(this.E_label);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(229, 70);
            this.panel4.TabIndex = 2;
            // 
            // E_min_txtbx
            // 
            this.E_min_txtbx.Location = new System.Drawing.Point(0, 44);
            this.E_min_txtbx.Name = "E_min_txtbx";
            this.E_min_txtbx.Size = new System.Drawing.Size(226, 20);
            this.E_min_txtbx.TabIndex = 2;
            // 
            // E_label
            // 
            this.E_label.AutoSize = true;
            this.E_label.Location = new System.Drawing.Point(3, 27);
            this.E_label.Name = "E_label";
            this.E_label.Size = new System.Drawing.Size(32, 13);
            this.E_label.TabIndex = 1;
            this.E_label.Text = "E=....";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(64, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Results";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.blending_UP_DOWN);
            this.panel2.Controls.Add(this.reset_bttn);
            this.panel2.Controls.Add(this.alpha_txtbx);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.SamplesUpDown);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.start_button);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.NeuronsUpDown);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(736, 395);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(235, 124);
            this.panel2.TabIndex = 2;
            // 
            // reset_bttn
            // 
            this.reset_bttn.Location = new System.Drawing.Point(0, 90);
            this.reset_bttn.Name = "reset_bttn";
            this.reset_bttn.Size = new System.Drawing.Size(83, 28);
            this.reset_bttn.TabIndex = 7;
            this.reset_bttn.Text = "Reset";
            this.reset_bttn.UseVisualStyleBackColor = true;
            this.reset_bttn.Click += new System.EventHandler(this.reset_bttn_Click);
            // 
            // alpha_txtbx
            // 
            this.alpha_txtbx.Location = new System.Drawing.Point(3, 64);
            this.alpha_txtbx.Name = "alpha_txtbx";
            this.alpha_txtbx.Size = new System.Drawing.Size(229, 20);
            this.alpha_txtbx.TabIndex = 6;
            this.alpha_txtbx.Text = "0.1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Alpha";
            // 
            // SamplesUpDown
            // 
            this.SamplesUpDown.Location = new System.Drawing.Point(71, 21);
            this.SamplesUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.SamplesUpDown.Name = "SamplesUpDown";
            this.SamplesUpDown.Size = new System.Drawing.Size(48, 20);
            this.SamplesUpDown.TabIndex = 4;
            this.SamplesUpDown.Value = new decimal(new int[] {
            180,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Samples";
            // 
            // start_button
            // 
            this.start_button.Location = new System.Drawing.Point(149, 90);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(83, 28);
            this.start_button.TabIndex = 2;
            this.start_button.Text = "Start";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Neurons";
            // 
            // NeuronsUpDown
            // 
            this.NeuronsUpDown.Location = new System.Drawing.Point(3, 21);
            this.NeuronsUpDown.Name = "NeuronsUpDown";
            this.NeuronsUpDown.Size = new System.Drawing.Size(48, 20);
            this.NeuronsUpDown.TabIndex = 0;
            this.NeuronsUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NeuronsUpDown.ValueChanged += new System.EventHandler(this.NeuronsUpDown_ValueChanged);
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(733, 392);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.splitContainer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 395);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(727, 124);
            this.panel3.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.radioButton2);
            this.splitContainer1.Panel2.Controls.Add(this.radioButton1);
            this.splitContainer1.Panel2.Controls.Add(this.radio_sin);
            this.splitContainer1.Size = new System.Drawing.Size(727, 124);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(326, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Formulas to learning";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(4, 28);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(90, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.Text = "Sin X + Cos X";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radio_sin
            // 
            this.radio_sin.AutoSize = true;
            this.radio_sin.Location = new System.Drawing.Point(4, 4);
            this.radio_sin.Name = "radio_sin";
            this.radio_sin.Size = new System.Drawing.Size(50, 17);
            this.radio_sin.TabIndex = 0;
            this.radio_sin.Text = "Sin X";
            this.radio_sin.UseVisualStyleBackColor = true;
            this.radio_sin.CheckedChanged += new System.EventHandler(this.radio_sin_CheckedChanged);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // blending_UP_DOWN
            // 
            this.blending_UP_DOWN.Location = new System.Drawing.Point(182, 21);
            this.blending_UP_DOWN.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.blending_UP_DOWN.Name = "blending_UP_DOWN";
            this.blending_UP_DOWN.Size = new System.Drawing.Size(44, 20);
            this.blending_UP_DOWN.TabIndex = 8;
            this.blending_UP_DOWN.Value = new decimal(new int[] {
            51,
            0,
            0,
            0});
            this.blending_UP_DOWN.ValueChanged += new System.EventHandler(this.blending_UP_DOWN_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(179, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Smooth";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(4, 51);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(131, 17);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.Text = "(Sin X + Cos X )*Sin2X";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 522);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Main Window";
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.w_datagridview)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SamplesUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NeuronsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.blending_UP_DOWN)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView w_datagridview;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_W_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_W_result;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown NeuronsUpDown;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label E_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox E_min_txtbx;
        private System.Windows.Forms.RadioButton radio_sin;
        private System.Windows.Forms.NumericUpDown SamplesUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TextBox alpha_txtbx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button reset_bttn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown blending_UP_DOWN;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}

