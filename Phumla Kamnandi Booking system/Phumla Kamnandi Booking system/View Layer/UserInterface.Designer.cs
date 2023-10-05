namespace Phumla_Kamnandi_Booking_system.View_Layer
{
    partial class UserInterface
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
            this.label1 = new System.Windows.Forms.Label();
            this.singleRadioButton = new System.Windows.Forms.RadioButton();
            this.doubleRadioButton = new System.Windows.Forms.RadioButton();
            this.tripleRadioButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkInDatePicker = new System.Windows.Forms.DateTimePicker();
            this.checkOutDatePicker = new System.Windows.Forms.DateTimePicker();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.page2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(315, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter reservation details";
            // 
            // singleRadioButton
            // 
            this.singleRadioButton.AutoSize = true;
            this.singleRadioButton.Location = new System.Drawing.Point(43, 64);
            this.singleRadioButton.Name = "singleRadioButton";
            this.singleRadioButton.Size = new System.Drawing.Size(124, 20);
            this.singleRadioButton.TabIndex = 1;
            this.singleRadioButton.TabStop = true;
            this.singleRadioButton.Text = "Single bedroom";
            this.singleRadioButton.UseVisualStyleBackColor = true;
            // 
            // doubleRadioButton
            // 
            this.doubleRadioButton.AutoSize = true;
            this.doubleRadioButton.Location = new System.Drawing.Point(328, 64);
            this.doubleRadioButton.Name = "doubleRadioButton";
            this.doubleRadioButton.Size = new System.Drawing.Size(130, 20);
            this.doubleRadioButton.TabIndex = 2;
            this.doubleRadioButton.TabStop = true;
            this.doubleRadioButton.Text = "Double bedroom";
            this.doubleRadioButton.UseVisualStyleBackColor = true;
            // 
            // tripleRadioButton
            // 
            this.tripleRadioButton.AutoSize = true;
            this.tripleRadioButton.Location = new System.Drawing.Point(614, 64);
            this.tripleRadioButton.Name = "tripleRadioButton";
            this.tripleRadioButton.Size = new System.Drawing.Size(122, 20);
            this.tripleRadioButton.TabIndex = 3;
            this.tripleRadioButton.TabStop = true;
            this.tripleRadioButton.Text = "Triple Bedroom";
            this.tripleRadioButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(325, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Check-in date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(317, 291);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Check-out date";
            // 
            // checkInDatePicker
            // 
            this.checkInDatePicker.Location = new System.Drawing.Point(260, 201);
            this.checkInDatePicker.Name = "checkInDatePicker";
            this.checkInDatePicker.Size = new System.Drawing.Size(242, 22);
            this.checkInDatePicker.TabIndex = 6;
            // 
            // checkOutDatePicker
            // 
            this.checkOutDatePicker.Location = new System.Drawing.Point(260, 345);
            this.checkOutDatePicker.Name = "checkOutDatePicker";
            this.checkOutDatePicker.Size = new System.Drawing.Size(239, 22);
            this.checkOutDatePicker.TabIndex = 7;
            // 
            // PreviousButton
            // 
            this.PreviousButton.Location = new System.Drawing.Point(159, 486);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(75, 23);
            this.PreviousButton.TabIndex = 8;
            this.PreviousButton.Text = "Previous";
            this.PreviousButton.UseVisualStyleBackColor = true;
            this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(578, 486);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(75, 23);
            this.NextButton.TabIndex = 9;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.page2);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(803, 452);
            this.panel2.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkOutDatePicker);
            this.panel1.Controls.Add(this.checkInDatePicker);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tripleRadioButton);
            this.panel1.Controls.Add(this.doubleRadioButton);
            this.panel1.Controls.Add(this.singleRadioButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(803, 452);
            this.panel1.TabIndex = 8;
            // 
            // page2
            // 
            this.page2.AutoSize = true;
            this.page2.Location = new System.Drawing.Point(363, 57);
            this.page2.Name = "page2";
            this.page2.Size = new System.Drawing.Size(49, 16);
            this.page2.TabIndex = 9;
            this.page2.Text = "page 2";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(12, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(803, 452);
            this.panel3.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(363, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "page 3";
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 567);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.PreviousButton);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "UserInterface";
            this.Text = "UserInterface";
            this.Load += new System.EventHandler(this.UserInterface_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton singleRadioButton;
        private System.Windows.Forms.RadioButton doubleRadioButton;
        private System.Windows.Forms.RadioButton tripleRadioButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker checkInDatePicker;
        private System.Windows.Forms.DateTimePicker checkOutDatePicker;
        private System.Windows.Forms.Button PreviousButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label page2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
    }
}