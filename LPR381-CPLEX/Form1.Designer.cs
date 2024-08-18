
namespace LPR381_CPLEX
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridViewCanonicalForm = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxConstraintInput = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.metroSetPanel1 = new MetroSet_UI.Controls.MetroSetPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.metroSetRichTextBox1 = new MetroSet_UI.Controls.MetroSetRichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.metroSetRichTextBox2 = new MetroSet_UI.Controls.MetroSetRichTextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.metroSetRichTextBox3 = new MetroSet_UI.Controls.MetroSetRichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCanonicalForm)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 31);
            this.button1.TabIndex = 0;
            this.button1.Text = "Primal Simplex";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 86);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(178, 35);
            this.button2.TabIndex = 1;
            this.button2.Text = "Knapsack";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(242, 35);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(178, 31);
            this.button3.TabIndex = 2;
            this.button3.Text = "Branch and Bound";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(248, 86);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(178, 35);
            this.button4.TabIndex = 3;
            this.button4.Text = "Cutting Plane";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataGridViewCanonicalForm
            // 
            this.dataGridViewCanonicalForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCanonicalForm.Location = new System.Drawing.Point(514, 93);
            this.dataGridViewCanonicalForm.Name = "dataGridViewCanonicalForm";
            this.dataGridViewCanonicalForm.RowHeadersWidth = 51;
            this.dataGridViewCanonicalForm.RowTemplate.Height = 24;
            this.dataGridViewCanonicalForm.Size = new System.Drawing.Size(832, 304);
            this.dataGridViewCanonicalForm.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(509, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "Linear Programming Solver";
            // 
            // textBoxConstraintInput
            // 
            this.textBoxConstraintInput.Location = new System.Drawing.Point(6, 60);
            this.textBoxConstraintInput.Name = "textBoxConstraintInput";
            this.textBoxConstraintInput.Size = new System.Drawing.Size(409, 22);
            this.textBoxConstraintInput.TabIndex = 6;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(237, 97);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(178, 35);
            this.button5.TabIndex = 7;
            this.button5.Text = "Add Constraint";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.textBoxConstraintInput);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Location = new System.Drawing.Point(46, 256);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 141);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add constraint";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Upload text file first";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(6, 97);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(178, 35);
            this.button6.TabIndex = 8;
            this.button6.Text = "Upload";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(6, 34);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(196, 35);
            this.button7.TabIndex = 9;
            this.button7.Text = "Duality analysis";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // metroSetPanel1
            // 
            this.metroSetPanel1.BackgroundColor = System.Drawing.Color.White;
            this.metroSetPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.metroSetPanel1.BorderThickness = 1;
            this.metroSetPanel1.IsDerivedStyle = true;
            this.metroSetPanel1.Location = new System.Drawing.Point(967, 444);
            this.metroSetPanel1.Name = "metroSetPanel1";
            this.metroSetPanel1.Size = new System.Drawing.Size(379, 333);
            this.metroSetPanel1.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetPanel1.StyleManager = null;
            this.metroSetPanel1.TabIndex = 10;
            this.metroSetPanel1.ThemeAuthor = "Narwin";
            this.metroSetPanel1.ThemeName = "MetroLite";
            this.metroSetPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.metroSetPanel1_Paint);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Location = new System.Drawing.Point(46, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(426, 142);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Solvers";
            // 
            // metroSetRichTextBox1
            // 
            this.metroSetRichTextBox1.AutoWordSelection = false;
            this.metroSetRichTextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.metroSetRichTextBox1.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.metroSetRichTextBox1.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.metroSetRichTextBox1.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.metroSetRichTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.metroSetRichTextBox1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.metroSetRichTextBox1.IsDerivedStyle = true;
            this.metroSetRichTextBox1.Lines = null;
            this.metroSetRichTextBox1.Location = new System.Drawing.Point(6, 90);
            this.metroSetRichTextBox1.MaxLength = 32767;
            this.metroSetRichTextBox1.Name = "metroSetRichTextBox1";
            this.metroSetRichTextBox1.ReadOnly = false;
            this.metroSetRichTextBox1.Size = new System.Drawing.Size(196, 211);
            this.metroSetRichTextBox1.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetRichTextBox1.StyleManager = null;
            this.metroSetRichTextBox1.TabIndex = 12;
            this.metroSetRichTextBox1.Text = "Duality";
            this.metroSetRichTextBox1.ThemeAuthor = "Narwin";
            this.metroSetRichTextBox1.ThemeName = "MetroLite";
            this.metroSetRichTextBox1.WordWrap = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.metroSetRichTextBox1);
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.Location = new System.Drawing.Point(46, 444);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(229, 320);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Duality analysis";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button8);
            this.groupBox4.Controls.Add(this.metroSetRichTextBox2);
            this.groupBox4.Location = new System.Drawing.Point(323, 444);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(229, 320);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Shadow Price";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.metroSetRichTextBox3);
            this.groupBox5.Controls.Add(this.button9);
            this.groupBox5.Location = new System.Drawing.Point(612, 444);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(333, 320);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Sensitivity Analysis";
            // 
            // metroSetRichTextBox2
            // 
            this.metroSetRichTextBox2.AutoWordSelection = false;
            this.metroSetRichTextBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.metroSetRichTextBox2.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.metroSetRichTextBox2.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.metroSetRichTextBox2.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.metroSetRichTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.metroSetRichTextBox2.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.metroSetRichTextBox2.IsDerivedStyle = true;
            this.metroSetRichTextBox2.Lines = null;
            this.metroSetRichTextBox2.Location = new System.Drawing.Point(17, 90);
            this.metroSetRichTextBox2.MaxLength = 32767;
            this.metroSetRichTextBox2.Name = "metroSetRichTextBox2";
            this.metroSetRichTextBox2.ReadOnly = false;
            this.metroSetRichTextBox2.Size = new System.Drawing.Size(196, 211);
            this.metroSetRichTextBox2.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetRichTextBox2.StyleManager = null;
            this.metroSetRichTextBox2.TabIndex = 13;
            this.metroSetRichTextBox2.Text = "Shadow Price";
            this.metroSetRichTextBox2.ThemeAuthor = "Narwin";
            this.metroSetRichTextBox2.ThemeName = "MetroLite";
            this.metroSetRichTextBox2.WordWrap = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(17, 34);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(196, 35);
            this.button8.TabIndex = 13;
            this.button8.Text = "Shadow Price";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(16, 34);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(299, 35);
            this.button9.TabIndex = 14;
            this.button9.Text = "Sensitivity Analysis";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // metroSetRichTextBox3
            // 
            this.metroSetRichTextBox3.AutoWordSelection = false;
            this.metroSetRichTextBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.metroSetRichTextBox3.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.metroSetRichTextBox3.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.metroSetRichTextBox3.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.metroSetRichTextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.metroSetRichTextBox3.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.metroSetRichTextBox3.IsDerivedStyle = true;
            this.metroSetRichTextBox3.Lines = null;
            this.metroSetRichTextBox3.Location = new System.Drawing.Point(16, 90);
            this.metroSetRichTextBox3.MaxLength = 32767;
            this.metroSetRichTextBox3.Name = "metroSetRichTextBox3";
            this.metroSetRichTextBox3.ReadOnly = false;
            this.metroSetRichTextBox3.Size = new System.Drawing.Size(299, 211);
            this.metroSetRichTextBox3.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetRichTextBox3.StyleManager = null;
            this.metroSetRichTextBox3.TabIndex = 14;
            this.metroSetRichTextBox3.Text = "Sensitivity";
            this.metroSetRichTextBox3.ThemeAuthor = "Narwin";
            this.metroSetRichTextBox3.ThemeName = "MetroLite";
            this.metroSetRichTextBox3.WordWrap = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1363, 815);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.metroSetPanel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewCanonicalForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Group K2";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCanonicalForm)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataGridViewCanonicalForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxConstraintInput;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private MetroSet_UI.Controls.MetroSetPanel metroSetPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private MetroSet_UI.Controls.MetroSetRichTextBox metroSetRichTextBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button8;
        private MetroSet_UI.Controls.MetroSetRichTextBox metroSetRichTextBox2;
        private MetroSet_UI.Controls.MetroSetRichTextBox metroSetRichTextBox3;
        private System.Windows.Forms.Button button9;
    }
}

