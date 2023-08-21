namespace Image_Explorer
{
    partial class AddTagsForm
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
            this.components = new System.ComponentModel.Container();
            this.addTagButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkedListBox1 = new Image_Explorer.ColorfulCheckedListBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labelTag = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // addTagButton
            // 
            this.addTagButton.Location = new System.Drawing.Point(100, 250);
            this.addTagButton.Name = "addTagButton";
            this.addTagButton.Size = new System.Drawing.Size(75, 23);
            this.addTagButton.TabIndex = 1;
            this.addTagButton.Text = "Add";
            this.addTagButton.UseVisualStyleBackColor = true;
            this.addTagButton.Click += new System.EventHandler(this.addTagButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(265, 250);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.Location = new System.Drawing.Point(40, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(360, 23);
            this.textBox1.TabIndex = 3;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(40, 111);
            this.checkedListBox1.MaximumSize = new System.Drawing.Size(360, 130);
            this.checkedListBox1.MinimumSize = new System.Drawing.Size(360, 130);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(360, 130);
            this.checkedListBox1.TabIndex = 4;
            this.checkedListBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Is always:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Belongs to:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(40, 67);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(360, 23);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // labelTag
            // 
            this.labelTag.AutoSize = true;
            this.labelTag.Location = new System.Drawing.Point(40, 5);
            this.labelTag.Name = "labelTag";
            this.labelTag.Size = new System.Drawing.Size(56, 15);
            this.labelTag.TabIndex = 8;
            this.labelTag.Text = "Keyword:";
            // 
            // AddTagsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(439, 281);
            this.ControlBox = false;
            this.Controls.Add(this.labelTag);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.addTagButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(455, 320);
            this.MinimumSize = new System.Drawing.Size(455, 320);
            this.Name = "AddTagsForm";
            this.Text = "Add Tags";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button addTagButton;
        private Button closeButton;
        private TextBox textBox1;
        public ColorfulCheckedListBox checkedListBox1;
        private Label label1;
        private Label label2;
        private ComboBox comboBox1;
        private Label labelTag;
    }
}