namespace TechSupportApp
{
    partial class frmAddModifyProduct
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
            lblProductCode = new Label();
            lblName = new Label();
            label1 = new Label();
            lblReleaseDate = new Label();
            txtProductCode = new TextBox();
            txtName = new TextBox();
            txtVersion = new TextBox();
            txtReleaseDate = new TextBox();
            btnAccept = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblProductCode
            // 
            lblProductCode.AutoSize = true;
            lblProductCode.Location = new Point(12, 9);
            lblProductCode.Name = "lblProductCode";
            lblProductCode.Size = new Size(102, 20);
            lblProductCode.TabIndex = 0;
            lblProductCode.Text = "Product Code:";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(59, 41);
            lblName.Name = "lblName";
            lblName.Size = new Size(52, 20);
            lblName.TabIndex = 1;
            lblName.Text = "Name:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(51, 74);
            label1.Name = "label1";
            label1.Size = new Size(60, 20);
            label1.TabIndex = 2;
            label1.Text = "Version:";
            // 
            // lblReleaseDate
            // 
            lblReleaseDate.AutoSize = true;
            lblReleaseDate.Location = new Point(12, 107);
            lblReleaseDate.Name = "lblReleaseDate";
            lblReleaseDate.Size = new Size(99, 20);
            lblReleaseDate.TabIndex = 3;
            lblReleaseDate.Text = "Release Date:";
            // 
            // txtProductCode
            // 
            txtProductCode.Location = new Point(117, 9);
            txtProductCode.MaxLength = 10;
            txtProductCode.Name = "txtProductCode";
            txtProductCode.Size = new Size(125, 27);
            txtProductCode.TabIndex = 4;
            txtProductCode.Tag = "Product Code";
            // 
            // txtName
            // 
            txtName.Location = new Point(117, 41);
            txtName.MaxLength = 50;
            txtName.Name = "txtName";
            txtName.Size = new Size(125, 27);
            txtName.TabIndex = 5;
            txtName.Tag = "Name";
            // 
            // txtVersion
            // 
            txtVersion.Location = new Point(117, 74);
            txtVersion.MaxLength = 19;
            txtVersion.Name = "txtVersion";
            txtVersion.Size = new Size(125, 27);
            txtVersion.TabIndex = 6;
            txtVersion.Tag = "Version";
            // 
            // txtReleaseDate
            // 
            txtReleaseDate.Location = new Point(117, 107);
            txtReleaseDate.MaxLength = 10;
            txtReleaseDate.Name = "txtReleaseDate";
            txtReleaseDate.Size = new Size(125, 27);
            txtReleaseDate.TabIndex = 7;
            txtReleaseDate.Tag = "Release Date";
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(20, 147);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(94, 29);
            btnAccept.TabIndex = 8;
            btnAccept.Text = "&Accept";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(154, 147);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmAddModifyProduct
            // 
            AcceptButton = btnAccept;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(282, 203);
            Controls.Add(btnCancel);
            Controls.Add(btnAccept);
            Controls.Add(txtReleaseDate);
            Controls.Add(txtVersion);
            Controls.Add(txtName);
            Controls.Add(txtProductCode);
            Controls.Add(lblReleaseDate);
            Controls.Add(label1);
            Controls.Add(lblName);
            Controls.Add(lblProductCode);
            Name = "frmAddModifyProduct";
            Text = "Text";
            Load += frmAddModifyProduct_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblProductCode;
        private Label lblName;
        private Label label1;
        private Label lblReleaseDate;
        private TextBox txtProductCode;
        private TextBox txtName;
        private TextBox txtVersion;
        private TextBox txtReleaseDate;
        private Button btnAccept;
        private Button btnCancel;
    }
}