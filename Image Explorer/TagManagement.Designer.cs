namespace Image_Explorer
{
    partial class TagManagement
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
            this.labelTag = new System.Windows.Forms.Label();
            this.labelKeywords = new System.Windows.Forms.Label();
            this.labelHas = new System.Windows.Forms.Label();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.unownedTags = new Image_Explorer.ColorfulCheckedListBox(this.components);
            this.ownedTags = new Image_Explorer.ColorfulCheckedListBox(this.components);
            this.myTag = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTag
            // 
            this.labelTag.AutoSize = true;
            this.labelTag.Location = new System.Drawing.Point(26, 16);
            this.labelTag.Name = "labelTag";
            this.labelTag.Size = new System.Drawing.Size(28, 15);
            this.labelTag.TabIndex = 0;
            this.labelTag.Text = "Tag:";
            // 
            // labelKeywords
            // 
            this.labelKeywords.AutoSize = true;
            this.labelKeywords.Location = new System.Drawing.Point(58, 72);
            this.labelKeywords.Name = "labelKeywords";
            this.labelKeywords.Size = new System.Drawing.Size(61, 15);
            this.labelKeywords.TabIndex = 1;
            this.labelKeywords.Text = "Keywords:";
            // 
            // labelHas
            // 
            this.labelHas.AutoSize = true;
            this.labelHas.Location = new System.Drawing.Point(306, 72);
            this.labelHas.Name = "labelHas";
            this.labelHas.Size = new System.Drawing.Size(68, 15);
            this.labelHas.TabIndex = 2;
            this.labelHas.Text = "Always has:";
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(334, 28);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirm.TabIndex = 3;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(186, 150);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = ">>";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(186, 200);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 5;
            this.buttonRemove.Text = "<<";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(186, 317);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 6;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // unownedTags
            // 
            this.unownedTags.CheckOnClick = true;
            this.unownedTags.FormattingEnabled = true;
            this.unownedTags.Location = new System.Drawing.Point(18, 90);
            this.unownedTags.Name = "unownedTags";
            this.unownedTags.Size = new System.Drawing.Size(162, 220);
            this.unownedTags.TabIndex = 7;
            this.unownedTags.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ChecklistSelectedIndexChanged);
            // 
            // ownedTags
            // 
            this.ownedTags.CheckOnClick = true;
            this.ownedTags.FormattingEnabled = true;
            this.ownedTags.Location = new System.Drawing.Point(267, 90);
            this.ownedTags.Name = "ownedTags";
            this.ownedTags.Size = new System.Drawing.Size(162, 220);
            this.ownedTags.TabIndex = 8;
            this.ownedTags.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ChecklistSelectedIndexChanged);
            // 
            // myTag
            // 
            this.myTag.Location = new System.Drawing.Point(60, 12);
            this.myTag.Name = "myTag";
            this.myTag.Size = new System.Drawing.Size(268, 23);
            this.myTag.TabIndex = 9;
            this.myTag.KeyDown += new System.Windows.Forms.KeyEventHandler(this.myTag_KeyDown);
            this.myTag.Leave += new System.EventHandler(this.myTag_Leave);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(60, 43);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(268, 23);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.Leave += new System.EventHandler(this.comboBox1_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Group:";
            // 
            // TagManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(454, 351);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.myTag);
            this.Controls.Add(this.ownedTags);
            this.Controls.Add(this.unownedTags);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.labelHas);
            this.Controls.Add(this.labelKeywords);
            this.Controls.Add(this.labelTag);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(470, 390);
            this.MinimumSize = new System.Drawing.Size(470, 390);
            this.Name = "TagManagement";
            this.Text = "Manage Tag";
            this.TopMost = true;
            this.Click += new System.EventHandler(this.TagManagement_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelTag;
        private Label labelKeywords;
        private Label labelHas;
        private Button buttonConfirm;
        private Button buttonAdd;
        private Button buttonRemove;
        private Button buttonClose;
        private ColorfulCheckedListBox unownedTags;
        private ColorfulCheckedListBox ownedTags;
        private TextBox myTag;
        private ComboBox comboBox1;
        private Label label1;
    }
}