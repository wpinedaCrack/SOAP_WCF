﻿namespace Pacagroup.Comercial.Creditos.InstaladorEXE
{
    partial class frmServerWCF
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
            this.btnIniciar = new System.Windows.Forms.Button();
            this.btnDetener = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(41, 80);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(89, 52);
            this.btnIniciar.TabIndex = 0;
            this.btnIniciar.Text = "Iniciar Servicio";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // btnDetener
            // 
            this.btnDetener.Location = new System.Drawing.Point(184, 80);
            this.btnDetener.Name = "btnDetener";
            this.btnDetener.Size = new System.Drawing.Size(88, 52);
            this.btnDetener.TabIndex = 1;
            this.btnDetener.Text = "Detener Servicio";
            this.btnDetener.UseVisualStyleBackColor = true;
            this.btnDetener.Click += new System.EventHandler(this.btnDetener_Click);
            // 
            // frmServerWCF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnDetener);
            this.Controls.Add(this.btnIniciar);
            this.Name = "frmServerWCF";
            this.Text = "Server WCF";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button btnDetener;
    }
}

