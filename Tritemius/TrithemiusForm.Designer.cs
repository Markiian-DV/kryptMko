namespace Caesar
{
    partial class TrithemiusForm
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
            this.richTextBoxInput = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sbAmountRows = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encryptMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decryptMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frequencyTableMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.attackMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.richTextBoxResult = new System.Windows.Forms.RichTextBox();
            this.numericUpDownKey1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxAlphabet = new System.Windows.Forms.ComboBox();
            this.numericUpDownKey2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownKey3 = new System.Windows.Forms.NumericUpDown();
            this.radioButtonTwoDimensionalKey = new System.Windows.Forms.RadioButton();
            this.radioButtonThreeDimensionalKey = new System.Windows.Forms.RadioButton();
            this.radioButtonGaslo = new System.Windows.Forms.RadioButton();
            this.textBoxGaslo = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKey1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKey2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKey3)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBoxInput
            // 
            this.richTextBoxInput.Location = new System.Drawing.Point(33, 195);
            this.richTextBoxInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBoxInput.Name = "richTextBoxInput";
            this.richTextBoxInput.Size = new System.Drawing.Size(282, 179);
            this.richTextBoxInput.TabIndex = 10;
            this.richTextBoxInput.Text = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbAmountRows,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 410);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip1.Size = new System.Drawing.Size(695, 26);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sbAmountRows
            // 
            this.sbAmountRows.Name = "sbAmountRows";
            this.sbAmountRows.Size = new System.Drawing.Size(115, 20);
            this.sbAmountRows.Text = "Amount of rows";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 20);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.actionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(695, 28);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMenuItem,
            this.openMenuItem,
            this.saveMenuItem,
            this.saveAsMenuItem,
            this.exitMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileMenuItem.Text = "&File";
            // 
            // newMenuItem
            // 
            this.newMenuItem.Name = "newMenuItem";
            this.newMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newMenuItem.Size = new System.Drawing.Size(231, 26);
            this.newMenuItem.Text = "&New";
            this.newMenuItem.Click += new System.EventHandler(this.newMenuItem_Click);
            // 
            // openMenuItem
            // 
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.ShortcutKeyDisplayString = "";
            this.openMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openMenuItem.Size = new System.Drawing.Size(231, 26);
            this.openMenuItem.Text = "&Open";
            this.openMenuItem.Click += new System.EventHandler(this.openMenuItem_Click);
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveMenuItem.Size = new System.Drawing.Size(231, 26);
            this.saveMenuItem.Text = "&Save";
            this.saveMenuItem.Click += new System.EventHandler(this.saveMenuItem_Click);
            // 
            // saveAsMenuItem
            // 
            this.saveAsMenuItem.Name = "saveAsMenuItem";
            this.saveAsMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsMenuItem.Size = new System.Drawing.Size(231, 26);
            this.saveAsMenuItem.Text = "&Save as";
            this.saveAsMenuItem.Click += new System.EventHandler(this.saveAsMenuItem_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitMenuItem.Size = new System.Drawing.Size(231, 26);
            this.exitMenuItem.Text = "&Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.encryptMenuItem,
            this.decryptMenuItem,
            this.frequencyTableMenuItem,
            this.attackMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.actionsToolStripMenuItem.Text = "Actions";
            // 
            // encryptMenuItem
            // 
            this.encryptMenuItem.Name = "encryptMenuItem";
            this.encryptMenuItem.Size = new System.Drawing.Size(197, 26);
            this.encryptMenuItem.Text = "Encrypt";
            this.encryptMenuItem.Click += new System.EventHandler(this.encryptMenuItem_Click);
            // 
            // decryptMenuItem
            // 
            this.decryptMenuItem.Name = "decryptMenuItem";
            this.decryptMenuItem.Size = new System.Drawing.Size(197, 26);
            this.decryptMenuItem.Text = "Decrypt";
            this.decryptMenuItem.Click += new System.EventHandler(this.decryptMenuItem_Click);
            // 
            // frequencyTableMenuItem
            // 
            this.frequencyTableMenuItem.Name = "frequencyTableMenuItem";
            this.frequencyTableMenuItem.Size = new System.Drawing.Size(197, 26);
            this.frequencyTableMenuItem.Text = "Frequency table";
            this.frequencyTableMenuItem.Click += new System.EventHandler(this.frequencyTableMenuItem_Click);
            // 
            // attackMenuItem
            // 
            this.attackMenuItem.Name = "attackMenuItem";
            this.attackMenuItem.Size = new System.Drawing.Size(197, 26);
            this.attackMenuItem.Text = "Attack";
            this.attackMenuItem.Click += new System.EventHandler(this.attackMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*txt";
            this.openFileDialog1.Filter = "Text File|*.txt|Html file|*.htm|All Files (*.*)|*.*";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Text File|*.txt|Html file|*.htm|All Files (*.*)|*.*";
            // 
            // richTextBoxResult
            // 
            this.richTextBoxResult.Location = new System.Drawing.Point(372, 195);
            this.richTextBoxResult.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBoxResult.Name = "richTextBoxResult";
            this.richTextBoxResult.Size = new System.Drawing.Size(282, 179);
            this.richTextBoxResult.TabIndex = 11;
            this.richTextBoxResult.Text = "";
            // 
            // numericUpDownKey1
            // 
            this.numericUpDownKey1.Location = new System.Drawing.Point(207, 102);
            this.numericUpDownKey1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDownKey1.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDownKey1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownKey1.Name = "numericUpDownKey1";
            this.numericUpDownKey1.Size = new System.Drawing.Size(107, 22);
            this.numericUpDownKey1.TabIndex = 12;
            this.numericUpDownKey1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(203, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 25);
            this.label1.TabIndex = 13;
            this.label1.Text = "Key:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(116, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "Input text";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(433, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "Converted text";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(28, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 25);
            this.label4.TabIndex = 16;
            this.label4.Text = "Alphabet";
            // 
            // comboBoxAlphabet
            // 
            this.comboBoxAlphabet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxAlphabet.FormattingEnabled = true;
            this.comboBoxAlphabet.Items.AddRange(new object[] {
            "English",
            "Ukrainian"});
            this.comboBoxAlphabet.Location = new System.Drawing.Point(28, 101);
            this.comboBoxAlphabet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxAlphabet.Name = "comboBoxAlphabet";
            this.comboBoxAlphabet.Size = new System.Drawing.Size(108, 24);
            this.comboBoxAlphabet.TabIndex = 17;
            // 
            // numericUpDownKey2
            // 
            this.numericUpDownKey2.Location = new System.Drawing.Point(349, 100);
            this.numericUpDownKey2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDownKey2.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDownKey2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownKey2.Name = "numericUpDownKey2";
            this.numericUpDownKey2.Size = new System.Drawing.Size(107, 22);
            this.numericUpDownKey2.TabIndex = 18;
            this.numericUpDownKey2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownKey3
            // 
            this.numericUpDownKey3.Location = new System.Drawing.Point(462, 101);
            this.numericUpDownKey3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDownKey3.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDownKey3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownKey3.Name = "numericUpDownKey3";
            this.numericUpDownKey3.Size = new System.Drawing.Size(107, 22);
            this.numericUpDownKey3.TabIndex = 19;
            this.numericUpDownKey3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // radioButtonTwoDimensionalKey
            // 
            this.radioButtonTwoDimensionalKey.AutoSize = true;
            this.radioButtonTwoDimensionalKey.Checked = true;
            this.radioButtonTwoDimensionalKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonTwoDimensionalKey.Location = new System.Drawing.Point(261, 66);
            this.radioButtonTwoDimensionalKey.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonTwoDimensionalKey.Name = "radioButtonTwoDimensionalKey";
            this.radioButtonTwoDimensionalKey.Size = new System.Drawing.Size(121, 22);
            this.radioButtonTwoDimensionalKey.TabIndex = 20;
            this.radioButtonTwoDimensionalKey.TabStop = true;
            this.radioButtonTwoDimensionalKey.Text = "2-dimensional";
            this.radioButtonTwoDimensionalKey.UseVisualStyleBackColor = true;
            this.radioButtonTwoDimensionalKey.CheckedChanged += new System.EventHandler(this.radioButtonTwoDimensionalKey_CheckedChanged);
            // 
            // radioButtonThreeDimensionalKey
            // 
            this.radioButtonThreeDimensionalKey.AutoSize = true;
            this.radioButtonThreeDimensionalKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonThreeDimensionalKey.Location = new System.Drawing.Point(414, 66);
            this.radioButtonThreeDimensionalKey.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonThreeDimensionalKey.Name = "radioButtonThreeDimensionalKey";
            this.radioButtonThreeDimensionalKey.Size = new System.Drawing.Size(121, 22);
            this.radioButtonThreeDimensionalKey.TabIndex = 21;
            this.radioButtonThreeDimensionalKey.Text = "3-dimensional";
            this.radioButtonThreeDimensionalKey.UseVisualStyleBackColor = true;
            this.radioButtonThreeDimensionalKey.CheckedChanged += new System.EventHandler(this.radioButtonThreeDimensionalKey_CheckedChanged);
            // 
            // radioButtonGaslo
            // 
            this.radioButtonGaslo.AutoSize = true;
            this.radioButtonGaslo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonGaslo.Location = new System.Drawing.Point(569, 67);
            this.radioButtonGaslo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonGaslo.Name = "radioButtonGaslo";
            this.radioButtonGaslo.Size = new System.Drawing.Size(65, 22);
            this.radioButtonGaslo.TabIndex = 22;
            this.radioButtonGaslo.Text = "gaslo";
            this.radioButtonGaslo.UseVisualStyleBackColor = true;
            this.radioButtonGaslo.CheckedChanged += new System.EventHandler(this.radioButtonGaslo_CheckedChanged);
            // 
            // textBoxGaslo
            // 
            this.textBoxGaslo.Location = new System.Drawing.Point(163, 100);
            this.textBoxGaslo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxGaslo.Name = "textBoxGaslo";
            this.textBoxGaslo.Size = new System.Drawing.Size(164, 22);
            this.textBoxGaslo.TabIndex = 23;
            this.textBoxGaslo.TextChanged += new System.EventHandler(this.textBoxGaslo_TextChanged);
            // 
            // TrithemiusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 436);
            this.Controls.Add(this.textBoxGaslo);
            this.Controls.Add(this.radioButtonGaslo);
            this.Controls.Add(this.radioButtonThreeDimensionalKey);
            this.Controls.Add(this.radioButtonTwoDimensionalKey);
            this.Controls.Add(this.numericUpDownKey3);
            this.Controls.Add(this.numericUpDownKey2);
            this.Controls.Add(this.comboBoxAlphabet);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownKey1);
            this.Controls.Add(this.richTextBoxResult);
            this.Controls.Add(this.richTextBoxInput);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "TrithemiusForm";
            this.Text = "Trithemius";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKey1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKey2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKey3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxInput;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sbAmountRows;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem encryptMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decryptMenuItem;
        private System.Windows.Forms.RichTextBox richTextBoxResult;
        private System.Windows.Forms.NumericUpDown numericUpDownKey1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ToolStripMenuItem frequencyTableMenuItem;
        private System.Windows.Forms.ToolStripMenuItem attackMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxAlphabet;
        private System.Windows.Forms.NumericUpDown numericUpDownKey2;
        private System.Windows.Forms.NumericUpDown numericUpDownKey3;
        private System.Windows.Forms.RadioButton radioButtonTwoDimensionalKey;
        private System.Windows.Forms.RadioButton radioButtonThreeDimensionalKey;
        private System.Windows.Forms.RadioButton radioButtonGaslo;
        private System.Windows.Forms.TextBox textBoxGaslo;
    }
}

