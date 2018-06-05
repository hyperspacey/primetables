using System.Windows.Forms;

namespace PrimeTables
{
    partial class InterfaceForm
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
            this.InstructionLabel = new System.Windows.Forms.Label();
            this.inputText = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.output = new System.Windows.Forms.TextBox();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // InstructionLabel
            // 
            this.InstructionLabel.AutoSize = true;
            this.InstructionLabel.Location = new System.Drawing.Point(13, 9);
            this.InstructionLabel.Name = "InstructionLabel";
            this.InstructionLabel.Size = new System.Drawing.Size(254, 26);
            this.InstructionLabel.TabIndex = 0;
            this.InstructionLabel.Text = "Generates multiplication table of consecutive primes.\r\nEnter number of primes:";
            // 
            // inputText
            // 
            this.inputText.Location = new System.Drawing.Point(16, 38);
            this.inputText.Name = "inputText";
            this.inputText.Size = new System.Drawing.Size(115, 20);
            this.inputText.TabIndex = 1;
            this.inputText.KeyDown += new KeyEventHandler(this.inputText_KeyDown);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(137, 38);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 20);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "Generate";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // output
            // 
            this.output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.output.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.output.Location = new System.Drawing.Point(13, 84);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.output.Size = new System.Drawing.Size(663, 335);
            this.output.TabIndex = 3;
            // 
            // ResultLabel
            // 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.Location = new System.Drawing.Point(16, 65);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(37, 13);
            this.ResultLabel.TabIndex = 4;
            this.ResultLabel.Text = "Result";
            // 
            // InterfaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 431);
            this.Controls.Add(this.ResultLabel);
            this.Controls.Add(this.output);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.inputText);
            this.Controls.Add(this.InstructionLabel);
            this.Name = "InterfaceForm";
            this.Text = "Prime Tables Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InstructionLabel;
        private System.Windows.Forms.TextBox inputText;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.Label ResultLabel;
    }
}

