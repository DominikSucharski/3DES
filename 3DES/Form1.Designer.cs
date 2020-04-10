﻿namespace _3DES
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
            this.textBoxKey1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxKey2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxKey3 = new System.Windows.Forms.TextBox();
            this.textBoxDecrypted = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxEncrypted = new System.Windows.Forms.TextBox();
            this.buttonEncipher = new System.Windows.Forms.Button();
            this.buttonDecipher = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxKey1
            // 
            this.textBoxKey1.Location = new System.Drawing.Point(264, 145);
            this.textBoxKey1.MaxLength = 16;
            this.textBoxKey1.Name = "textBoxKey1";
            this.textBoxKey1.Size = new System.Drawing.Size(178, 22);
            this.textBoxKey1.TabIndex = 0;
            this.textBoxKey1.Text = "0123456789ABCDEF";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Klucz 1 (hex)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Klucz 2 (hex)";
            // 
            // textBoxKey2
            // 
            this.textBoxKey2.Location = new System.Drawing.Point(264, 173);
            this.textBoxKey2.MaxLength = 16;
            this.textBoxKey2.Name = "textBoxKey2";
            this.textBoxKey2.Size = new System.Drawing.Size(178, 22);
            this.textBoxKey2.TabIndex = 2;
            this.textBoxKey2.Text = "23456789ABCDEF01";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(168, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Klucz 3 (hex)";
            // 
            // textBoxKey3
            // 
            this.textBoxKey3.Location = new System.Drawing.Point(264, 201);
            this.textBoxKey3.MaxLength = 16;
            this.textBoxKey3.Name = "textBoxKey3";
            this.textBoxKey3.Size = new System.Drawing.Size(178, 22);
            this.textBoxKey3.TabIndex = 4;
            this.textBoxKey3.Text = "456789ABCDEF0123";
            // 
            // textBoxDecrypted
            // 
            this.textBoxDecrypted.Location = new System.Drawing.Point(264, 80);
            this.textBoxDecrypted.Multiline = true;
            this.textBoxDecrypted.Name = "textBoxDecrypted";
            this.textBoxDecrypted.Size = new System.Drawing.Size(178, 42);
            this.textBoxDecrypted.TabIndex = 6;
            this.textBoxDecrypted.Text = "5468652071756663";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(144, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Szyfrowany tekst";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(129, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Zaszyfrowany tekst";
            // 
            // textBoxEncrypted
            // 
            this.textBoxEncrypted.Location = new System.Drawing.Point(264, 253);
            this.textBoxEncrypted.Multiline = true;
            this.textBoxEncrypted.Name = "textBoxEncrypted";
            this.textBoxEncrypted.Size = new System.Drawing.Size(178, 42);
            this.textBoxEncrypted.TabIndex = 8;
            // 
            // buttonEncipher
            // 
            this.buttonEncipher.Location = new System.Drawing.Point(229, 323);
            this.buttonEncipher.Name = "buttonEncipher";
            this.buttonEncipher.Size = new System.Drawing.Size(99, 50);
            this.buttonEncipher.TabIndex = 10;
            this.buttonEncipher.Text = "Szyfruj";
            this.buttonEncipher.UseVisualStyleBackColor = true;
            this.buttonEncipher.Click += new System.EventHandler(this.buttonEncipher_Click);
            // 
            // buttonDecipher
            // 
            this.buttonDecipher.Location = new System.Drawing.Point(400, 323);
            this.buttonDecipher.Name = "buttonDecipher";
            this.buttonDecipher.Size = new System.Drawing.Size(99, 50);
            this.buttonDecipher.TabIndex = 14;
            this.buttonDecipher.Text = "Deszyfruj";
            this.buttonDecipher.UseVisualStyleBackColor = true;
            this.buttonDecipher.Click += new System.EventHandler(this.buttonDecipher_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonDecipher);
            this.Controls.Add(this.buttonEncipher);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxEncrypted);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxDecrypted);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxKey3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxKey2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxKey1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxKey1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxKey2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxKey3;
        private System.Windows.Forms.TextBox textBoxDecrypted;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxEncrypted;
        private System.Windows.Forms.Button buttonEncipher;
        private System.Windows.Forms.Button buttonDecipher;
    }
}

