namespace HealthcareForms
{
    partial class Allergies
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
            this.labelName = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.txtAllergen = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnGeneralMedHistory = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnViewMedications = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSelectionForm = new System.Windows.Forms.Button();
            this.btnViewFamily = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.dataGridViewAllergyHistory = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllergyHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(56, 160);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(0, 16);
            this.labelName.TabIndex = 29;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(258, 308);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(177, 107);
            this.txtDescription.TabIndex = 7;
            // 
            // txtEndDate
            // 
            this.txtEndDate.Location = new System.Drawing.Point(258, 272);
            this.txtEndDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(177, 22);
            this.txtEndDate.TabIndex = 6;
            // 
            // txtStartDate
            // 
            this.txtStartDate.Location = new System.Drawing.Point(258, 233);
            this.txtStartDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(177, 22);
            this.txtStartDate.TabIndex = 5;
            // 
            // txtAllergen
            // 
            this.txtAllergen.Location = new System.Drawing.Point(258, 196);
            this.txtAllergen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAllergen.Name = "txtAllergen";
            this.txtAllergen.Size = new System.Drawing.Size(177, 22);
            this.txtAllergen.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 308);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Allergy description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(123, 275);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Allergy end date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 236);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Allergy start date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Allergen";
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(107, 471);
            this.btnModify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(91, 23);
            this.btnModify.TabIndex = 28;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click_1);
            // 
            // btnGeneralMedHistory
            // 
            this.btnGeneralMedHistory.Location = new System.Drawing.Point(15, 71);
            this.btnGeneralMedHistory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGeneralMedHistory.Name = "btnGeneralMedHistory";
            this.btnGeneralMedHistory.Size = new System.Drawing.Size(181, 37);
            this.btnGeneralMedHistory.TabIndex = 10;
            this.btnGeneralMedHistory.Text = "View Gen. Medical History";
            this.btnGeneralMedHistory.UseVisualStyleBackColor = true;
            this.btnGeneralMedHistory.Click += new System.EventHandler(this.btnGeneralMedHistory_Click_1);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(15, 16);
            this.btnView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(181, 37);
            this.btnView.TabIndex = 5;
            this.btnView.Text = "View Demographics";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click_1);
            // 
            // btnViewMedications
            // 
            this.btnViewMedications.Location = new System.Drawing.Point(15, 218);
            this.btnViewMedications.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnViewMedications.Name = "btnViewMedications";
            this.btnViewMedications.Size = new System.Drawing.Size(181, 34);
            this.btnViewMedications.TabIndex = 9;
            this.btnViewMedications.Text = "View Patient Medications";
            this.btnViewMedications.UseVisualStyleBackColor = true;
            this.btnViewMedications.Click += new System.EventHandler(this.btnViewMedications_Click_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PowderBlue;
            this.panel2.Controls.Add(this.btnSelectionForm);
            this.panel2.Controls.Add(this.btnGeneralMedHistory);
            this.panel2.Controls.Add(this.btnView);
            this.panel2.Controls.Add(this.btnViewMedications);
            this.panel2.Controls.Add(this.btnViewFamily);
            this.panel2.Location = new System.Drawing.Point(526, 183);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(209, 264);
            this.panel2.TabIndex = 26;
            // 
            // btnSelectionForm
            // 
            this.btnSelectionForm.Location = new System.Drawing.Point(15, 169);
            this.btnSelectionForm.Name = "btnSelectionForm";
            this.btnSelectionForm.Size = new System.Drawing.Size(181, 34);
            this.btnSelectionForm.TabIndex = 11;
            this.btnSelectionForm.Text = "Patient Select Form";
            this.btnSelectionForm.UseVisualStyleBackColor = true;
            this.btnSelectionForm.Click += new System.EventHandler(this.btnSelectionForm_Click);
            // 
            // btnViewFamily
            // 
            this.btnViewFamily.Location = new System.Drawing.Point(15, 119);
            this.btnViewFamily.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnViewFamily.Name = "btnViewFamily";
            this.btnViewFamily.Size = new System.Drawing.Size(181, 34);
            this.btnViewFamily.TabIndex = 8;
            this.btnViewFamily.Text = "View Family History";
            this.btnViewFamily.UseVisualStyleBackColor = true;
            this.btnViewFamily.Click += new System.EventHandler(this.btnViewFamily_Click_1);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(10, 471);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(91, 23);
            this.btnAdd.TabIndex = 25;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(417, 471);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(91, 23);
            this.btnDelete.TabIndex = 24;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(310, 471);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 23);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Location = new System.Drawing.Point(204, 471);
            this.btnUndo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(91, 23);
            this.btnUndo.TabIndex = 22;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click_1);
            // 
            // dataGridViewAllergyHistory
            // 
            this.dataGridViewAllergyHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAllergyHistory.Location = new System.Drawing.Point(26, 12);
            this.dataGridViewAllergyHistory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewAllergyHistory.Name = "dataGridViewAllergyHistory";
            this.dataGridViewAllergyHistory.RowHeadersWidth = 51;
            this.dataGridViewAllergyHistory.RowTemplate.Height = 24;
            this.dataGridViewAllergyHistory.Size = new System.Drawing.Size(709, 167);
            this.dataGridViewAllergyHistory.TabIndex = 20;
            this.dataGridViewAllergyHistory.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewAllergyHistory_RowHeaderMouseClick);
            // 
            // Allergies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(762, 511);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEndDate);
            this.Controls.Add(this.txtStartDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtAllergen);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewAllergyHistory);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Allergies";
            this.Text = "Allergies";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllergyHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtEndDate;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.TextBox txtAllergen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnGeneralMedHistory;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnViewMedications;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnViewFamily;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.DataGridView dataGridViewAllergyHistory;
        private System.Windows.Forms.Button btnSelectionForm;
    }
}