namespace ITS245Project
{
    partial class FamilyHistoryForm
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
            this.dataGridViewFamilyHistory = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnMedicationsForm = new System.Windows.Forms.Button();
            this.btnGeneralMedicalHistory = new System.Windows.Forms.Button();
            this.btnAllergyForm = new System.Windows.Forms.Button();
            this.btnDemographic = new System.Windows.Forms.Button();
            this.btnPatientSelectForm = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblRelation = new System.Windows.Forms.Label();
            this.txtRelation = new System.Windows.Forms.TextBox();
            this.cbAlive = new System.Windows.Forms.CheckBox();
            this.lblAlive = new System.Windows.Forms.Label();
            this.lblLivesWithPatient = new System.Windows.Forms.Label();
            this.cbLivesWithPatient = new System.Windows.Forms.CheckBox();
            this.lblMajorDisorder = new System.Windows.Forms.Label();
            this.txtMajorDisorder = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFamilyHistory)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewFamilyHistory
            // 
            this.dataGridViewFamilyHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFamilyHistory.Location = new System.Drawing.Point(12, 33);
            this.dataGridViewFamilyHistory.Name = "dataGridViewFamilyHistory";
            this.dataGridViewFamilyHistory.RowHeadersWidth = 51;
            this.dataGridViewFamilyHistory.RowTemplate.Height = 24;
            this.dataGridViewFamilyHistory.Size = new System.Drawing.Size(478, 199);
            this.dataGridViewFamilyHistory.TabIndex = 0;
            this.dataGridViewFamilyHistory.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewFamilyHistory_RowHeaderMouseClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CadetBlue;
            this.panel2.Controls.Add(this.btnMedicationsForm);
            this.panel2.Controls.Add(this.btnGeneralMedicalHistory);
            this.panel2.Controls.Add(this.btnAllergyForm);
            this.panel2.Controls.Add(this.btnDemographic);
            this.panel2.Controls.Add(this.btnPatientSelectForm);
            this.panel2.Location = new System.Drawing.Point(609, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(193, 438);
            this.panel2.TabIndex = 3;
            // 
            // btnMedicationsForm
            // 
            this.btnMedicationsForm.Location = new System.Drawing.Point(26, 272);
            this.btnMedicationsForm.Name = "btnMedicationsForm";
            this.btnMedicationsForm.Size = new System.Drawing.Size(153, 49);
            this.btnMedicationsForm.TabIndex = 4;
            this.btnMedicationsForm.Text = "Medications Form";
            this.btnMedicationsForm.UseVisualStyleBackColor = true;
            this.btnMedicationsForm.Click += new System.EventHandler(this.btnMedicationsForm_Click);
            // 
            // btnGeneralMedicalHistory
            // 
            this.btnGeneralMedicalHistory.Location = new System.Drawing.Point(26, 362);
            this.btnGeneralMedicalHistory.Name = "btnGeneralMedicalHistory";
            this.btnGeneralMedicalHistory.Size = new System.Drawing.Size(153, 47);
            this.btnGeneralMedicalHistory.TabIndex = 3;
            this.btnGeneralMedicalHistory.Text = "General Medical History";
            this.btnGeneralMedicalHistory.UseVisualStyleBackColor = true;
            this.btnGeneralMedicalHistory.Click += new System.EventHandler(this.btnGeneralMedicalHistory_Click);
            // 
            // btnAllergyForm
            // 
            this.btnAllergyForm.Location = new System.Drawing.Point(26, 185);
            this.btnAllergyForm.Name = "btnAllergyForm";
            this.btnAllergyForm.Size = new System.Drawing.Size(153, 47);
            this.btnAllergyForm.TabIndex = 2;
            this.btnAllergyForm.Text = "Allergy Form";
            this.btnAllergyForm.UseVisualStyleBackColor = true;
            this.btnAllergyForm.Click += new System.EventHandler(this.btnAllergyForm_Click);
            // 
            // btnDemographic
            // 
            this.btnDemographic.Location = new System.Drawing.Point(26, 99);
            this.btnDemographic.Name = "btnDemographic";
            this.btnDemographic.Size = new System.Drawing.Size(153, 47);
            this.btnDemographic.TabIndex = 1;
            this.btnDemographic.Text = "Demographics Form";
            this.btnDemographic.UseVisualStyleBackColor = true;
            this.btnDemographic.Click += new System.EventHandler(this.btnDemographic_Click);
            // 
            // btnPatientSelectForm
            // 
            this.btnPatientSelectForm.Location = new System.Drawing.Point(26, 21);
            this.btnPatientSelectForm.Name = "btnPatientSelectForm";
            this.btnPatientSelectForm.Size = new System.Drawing.Size(153, 45);
            this.btnPatientSelectForm.TabIndex = 0;
            this.btnPatientSelectForm.Text = "Patient Select Form";
            this.btnPatientSelectForm.UseVisualStyleBackColor = true;
            this.btnPatientSelectForm.Click += new System.EventHandler(this.btnPatientSelectForm_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(512, 33);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(512, 76);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 5;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click_1);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(512, 123);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Location = new System.Drawing.Point(512, 166);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(75, 23);
            this.btnUndo.TabIndex = 7;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(512, 209);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientName.Location = new System.Drawing.Point(12, 11);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(52, 17);
            this.lblPatientName.TabIndex = 9;
            this.lblPatientName.Text = "label1";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(16, 256);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(48, 18);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(91, 252);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(113, 22);
            this.txtFullName.TabIndex = 2;
            // 
            // lblRelation
            // 
            this.lblRelation.AutoSize = true;
            this.lblRelation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRelation.Location = new System.Drawing.Point(12, 294);
            this.lblRelation.Name = "lblRelation";
            this.lblRelation.Size = new System.Drawing.Size(62, 18);
            this.lblRelation.TabIndex = 3;
            this.lblRelation.Text = "Relation";
            // 
            // txtRelation
            // 
            this.txtRelation.Location = new System.Drawing.Point(91, 294);
            this.txtRelation.Name = "txtRelation";
            this.txtRelation.Size = new System.Drawing.Size(113, 22);
            this.txtRelation.TabIndex = 4;
            // 
            // cbAlive
            // 
            this.cbAlive.AutoSize = true;
            this.cbAlive.Location = new System.Drawing.Point(319, 252);
            this.cbAlive.Name = "cbAlive";
            this.cbAlive.Size = new System.Drawing.Size(18, 17);
            this.cbAlive.TabIndex = 5;
            this.cbAlive.UseVisualStyleBackColor = true;
            // 
            // lblAlive
            // 
            this.lblAlive.AutoSize = true;
            this.lblAlive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlive.Location = new System.Drawing.Point(343, 249);
            this.lblAlive.Name = "lblAlive";
            this.lblAlive.Size = new System.Drawing.Size(38, 18);
            this.lblAlive.TabIndex = 6;
            this.lblAlive.Text = "Alive";
            // 
            // lblLivesWithPatient
            // 
            this.lblLivesWithPatient.AutoSize = true;
            this.lblLivesWithPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLivesWithPatient.Location = new System.Drawing.Point(343, 298);
            this.lblLivesWithPatient.Name = "lblLivesWithPatient";
            this.lblLivesWithPatient.Size = new System.Drawing.Size(121, 18);
            this.lblLivesWithPatient.TabIndex = 7;
            this.lblLivesWithPatient.Text = "Lives with Patient";
            // 
            // cbLivesWithPatient
            // 
            this.cbLivesWithPatient.AutoSize = true;
            this.cbLivesWithPatient.Location = new System.Drawing.Point(319, 301);
            this.cbLivesWithPatient.Name = "cbLivesWithPatient";
            this.cbLivesWithPatient.Size = new System.Drawing.Size(18, 17);
            this.cbLivesWithPatient.TabIndex = 8;
            this.cbLivesWithPatient.UseVisualStyleBackColor = true;
            // 
            // lblMajorDisorder
            // 
            this.lblMajorDisorder.AutoSize = true;
            this.lblMajorDisorder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMajorDisorder.Location = new System.Drawing.Point(9, 341);
            this.lblMajorDisorder.Name = "lblMajorDisorder";
            this.lblMajorDisorder.Size = new System.Drawing.Size(107, 18);
            this.lblMajorDisorder.TabIndex = 9;
            this.lblMajorDisorder.Text = "Major Disorder";
            // 
            // txtMajorDisorder
            // 
            this.txtMajorDisorder.Location = new System.Drawing.Point(12, 374);
            this.txtMajorDisorder.Name = "txtMajorDisorder";
            this.txtMajorDisorder.Size = new System.Drawing.Size(214, 64);
            this.txtMajorDisorder.TabIndex = 10;
            this.txtMajorDisorder.Text = "";
            // 
            // FamilyHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtMajorDisorder);
            this.Controls.Add(this.lblMajorDisorder);
            this.Controls.Add(this.txtRelation);
            this.Controls.Add(this.cbLivesWithPatient);
            this.Controls.Add(this.lblRelation);
            this.Controls.Add(this.lblPatientName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.cbAlive);
            this.Controls.Add(this.lblAlive);
            this.Controls.Add(this.lblLivesWithPatient);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridViewFamilyHistory);
            this.Name = "FamilyHistoryForm";
            this.Text = "FamilyHistoryForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFamilyHistory)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewFamilyHistory;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPatientSelectForm;
        private System.Windows.Forms.Button btnDemographic;
        private System.Windows.Forms.Button btnAllergyForm;
        private System.Windows.Forms.Button btnGeneralMedicalHistory;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblRelation;
        private System.Windows.Forms.TextBox txtRelation;
        private System.Windows.Forms.CheckBox cbAlive;
        private System.Windows.Forms.Label lblAlive;
        private System.Windows.Forms.Label lblLivesWithPatient;
        private System.Windows.Forms.CheckBox cbLivesWithPatient;
        private System.Windows.Forms.Label lblMajorDisorder;
        private System.Windows.Forms.RichTextBox txtMajorDisorder;
        private System.Windows.Forms.Button btnMedicationsForm;
    }
}