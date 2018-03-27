namespace KeyBoxEncryption
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
            this.encryptButton = new System.Windows.Forms.Button();
            this.decryptButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.stepThrough = new System.Windows.Forms.Button();
            this.logText = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableMatrix1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableMatrix2 = new System.Windows.Forms.TableLayoutPanel();
            this.plainCipherText = new System.Windows.Forms.RichTextBox();
            this.keyPos = new System.Windows.Forms.Label();
            this.cipher = new System.Windows.Forms.RichTextBox();
            this.fUnique = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // encryptButton
            // 
            this.encryptButton.Location = new System.Drawing.Point(53, 297);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(182, 23);
            this.encryptButton.TabIndex = 0;
            this.encryptButton.Text = "Encrypt Plain Text";
            this.encryptButton.UseVisualStyleBackColor = true;
            this.encryptButton.Click += new System.EventHandler(this.encryptButton_Click);
            // 
            // decryptButton
            // 
            this.decryptButton.Location = new System.Drawing.Point(241, 297);
            this.decryptButton.Name = "decryptButton";
            this.decryptButton.Size = new System.Drawing.Size(179, 23);
            this.decryptButton.TabIndex = 1;
            this.decryptButton.Text = "Decrypt Cipher Text";
            this.decryptButton.UseVisualStyleBackColor = true;
            this.decryptButton.Click += new System.EventHandler(this.decryptButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(49, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Please enter text to encrypt/decrypt";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(50, 233);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(373, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Please enter a shared password for encryption/decryption";
            // 
            // passwordText
            // 
            this.passwordText.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordText.Location = new System.Drawing.Point(53, 258);
            this.passwordText.Name = "passwordText";
            this.passwordText.Size = new System.Drawing.Size(367, 29);
            this.passwordText.TabIndex = 5;
            // 
            // stepThrough
            // 
            this.stepThrough.Location = new System.Drawing.Point(133, 629);
            this.stepThrough.Name = "stepThrough";
            this.stepThrough.Size = new System.Drawing.Size(207, 23);
            this.stepThrough.TabIndex = 6;
            this.stepThrough.Text = "Step Through";
            this.stepThrough.UseVisualStyleBackColor = true;
            this.stepThrough.Click += new System.EventHandler(this.stepThrough_Click);
            // 
            // logText
            // 
            this.logText.Location = new System.Drawing.Point(0, 389);
            this.logText.Name = "logText";
            this.logText.Size = new System.Drawing.Size(477, 32);
            this.logText.TabIndex = 7;
            this.logText.Text = "Log Area";
            this.logText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 15;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666445F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666445F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666445F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666445F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666445F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666445F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666445F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666445F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.625259F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.625259F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666445F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666445F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666445F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666445F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.669778F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 397);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 15;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(483, 230);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // tableMatrix1
            // 
            this.tableMatrix1.ColumnCount = 2;
            this.tableMatrix1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableMatrix1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableMatrix1.Location = new System.Drawing.Point(15, 339);
            this.tableMatrix1.Name = "tableMatrix1";
            this.tableMatrix1.RowCount = 2;
            this.tableMatrix1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableMatrix1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableMatrix1.Size = new System.Drawing.Size(79, 58);
            this.tableMatrix1.TabIndex = 10;
            // 
            // tableMatrix2
            // 
            this.tableMatrix2.ColumnCount = 2;
            this.tableMatrix2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableMatrix2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableMatrix2.Location = new System.Drawing.Point(392, 342);
            this.tableMatrix2.Name = "tableMatrix2";
            this.tableMatrix2.RowCount = 2;
            this.tableMatrix2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableMatrix2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableMatrix2.Size = new System.Drawing.Size(85, 55);
            this.tableMatrix2.TabIndex = 11;
            // 
            // plainCipherText
            // 
            this.plainCipherText.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plainCipherText.Location = new System.Drawing.Point(53, 156);
            this.plainCipherText.Name = "plainCipherText";
            this.plainCipherText.Size = new System.Drawing.Size(367, 74);
            this.plainCipherText.TabIndex = 13;
            this.plainCipherText.Text = "";
            // 
            // keyPos
            // 
            this.keyPos.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.keyPos.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyPos.Location = new System.Drawing.Point(15, 356);
            this.keyPos.Name = "keyPos";
            this.keyPos.Size = new System.Drawing.Size(462, 41);
            this.keyPos.TabIndex = 14;
            this.keyPos.Text = "keyPos";
            // 
            // cipher
            // 
            this.cipher.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cipher.Location = new System.Drawing.Point(29, 595);
            this.cipher.Name = "cipher";
            this.cipher.ReadOnly = true;
            this.cipher.Size = new System.Drawing.Size(437, 31);
            this.cipher.TabIndex = 15;
            this.cipher.Text = "";
            // 
            // fUnique
            // 
            this.fUnique.AutoSize = true;
            this.fUnique.Location = new System.Drawing.Point(330, 137);
            this.fUnique.Name = "fUnique";
            this.fUnique.Size = new System.Drawing.Size(90, 17);
            this.fUnique.TabIndex = 16;
            this.fUnique.Text = "Force Unique";
            this.fUnique.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(53, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(367, 118);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 653);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.fUnique);
            this.Controls.Add(this.cipher);
            this.Controls.Add(this.tableMatrix2);
            this.Controls.Add(this.tableMatrix1);
            this.Controls.Add(this.keyPos);
            this.Controls.Add(this.plainCipherText);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.logText);
            this.Controls.Add(this.stepThrough);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.decryptButton);
            this.Controls.Add(this.encryptButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button encryptButton;
        private System.Windows.Forms.Button decryptButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.Button stepThrough;
        private System.Windows.Forms.Label logText;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableMatrix1;
        private System.Windows.Forms.TableLayoutPanel tableMatrix2;
        private System.Windows.Forms.RichTextBox plainCipherText;
        private System.Windows.Forms.Label keyPos;
        private System.Windows.Forms.RichTextBox cipher;
        private System.Windows.Forms.CheckBox fUnique;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

