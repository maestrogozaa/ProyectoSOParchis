namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.IP = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.loginButton = new System.Windows.Forms.Button();
            this.signupButton = new System.Windows.Forms.Button();
            this.loginEntrarButton = new System.Windows.Forms.Button();
            this.loginLabel = new System.Windows.Forms.Label();
            this.loginContraseñatextBox = new System.Windows.Forms.TextBox();
            this.loginUsuariotextBox = new System.Windows.Forms.TextBox();
            this.loginContraseñaLabel = new System.Windows.Forms.Label();
            this.loginUsuarioLabel = new System.Windows.Forms.Label();
            this.signupRegistrarButton = new System.Windows.Forms.Button();
            this.signupCorreotextBox = new System.Windows.Forms.TextBox();
            this.signupCorreoLabel = new System.Windows.Forms.Label();
            this.signupLabel = new System.Windows.Forms.Label();
            this.signupContraseñatextBox = new System.Windows.Forms.TextBox();
            this.signupUsuariotextBox = new System.Windows.Forms.TextBox();
            this.signupContraseñaLabel = new System.Windows.Forms.Label();
            this.signupUsuarioLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.desconectarButton = new System.Windows.Forms.Button();
            this.unsubscribeSarseBajaButton = new System.Windows.Forms.Button();
            this.unsubscribeCorreotextBox = new System.Windows.Forms.TextBox();
            this.unsubscribeCorreoLbl = new System.Windows.Forms.Label();
            this.unsubscribeLbl = new System.Windows.Forms.Label();
            this.unsubscribeContraseñatextBox = new System.Windows.Forms.TextBox();
            this.unsubscribeUsuariotextBox = new System.Windows.Forms.TextBox();
            this.unsubscribeContraseñaLbl = new System.Windows.Forms.Label();
            this.unsubscribeUsuarioLbl = new System.Windows.Forms.Label();
            this.unsubscribeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(140, 104);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Servidor:";
            // 
            // IP
            // 
            this.IP.Location = new System.Drawing.Point(248, 104);
            this.IP.Margin = new System.Windows.Forms.Padding(4);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(193, 22);
            this.IP.TabIndex = 2;
            this.IP.Text = "10.4.119.5";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(207, 144);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 38);
            this.button1.TabIndex = 4;
            this.button1.Text = "Conectar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(266, 205);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(151, 51);
            this.loginButton.TabIndex = 9;
            this.loginButton.Text = "Iniciar sesión";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Visible = false;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // signupButton
            // 
            this.signupButton.Location = new System.Drawing.Point(109, 205);
            this.signupButton.Name = "signupButton";
            this.signupButton.Size = new System.Drawing.Size(151, 51);
            this.signupButton.TabIndex = 10;
            this.signupButton.Text = "Registrarse";
            this.signupButton.UseVisualStyleBackColor = true;
            this.signupButton.Visible = false;
            this.signupButton.Click += new System.EventHandler(this.signupButton_Click);
            // 
            // loginEntrarButton
            // 
            this.loginEntrarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginEntrarButton.Location = new System.Drawing.Point(282, 416);
            this.loginEntrarButton.Name = "loginEntrarButton";
            this.loginEntrarButton.Size = new System.Drawing.Size(99, 40);
            this.loginEntrarButton.TabIndex = 16;
            this.loginEntrarButton.Text = "Entrar";
            this.loginEntrarButton.UseVisualStyleBackColor = true;
            this.loginEntrarButton.Visible = false;
            this.loginEntrarButton.Click += new System.EventHandler(this.loginEntrarButton_Click);
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginLabel.Location = new System.Drawing.Point(247, 291);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(194, 32);
            this.loginLabel.TabIndex = 15;
            this.loginLabel.Text = "Iniciar sesión";
            this.loginLabel.Visible = false;
            // 
            // loginContraseñatextBox
            // 
            this.loginContraseñatextBox.Location = new System.Drawing.Point(258, 379);
            this.loginContraseñatextBox.Name = "loginContraseñatextBox";
            this.loginContraseñatextBox.PasswordChar = '*';
            this.loginContraseñatextBox.Size = new System.Drawing.Size(188, 22);
            this.loginContraseñatextBox.TabIndex = 14;
            this.loginContraseñatextBox.Visible = false;
            // 
            // loginUsuariotextBox
            // 
            this.loginUsuariotextBox.Location = new System.Drawing.Point(258, 340);
            this.loginUsuariotextBox.Name = "loginUsuariotextBox";
            this.loginUsuariotextBox.Size = new System.Drawing.Size(188, 22);
            this.loginUsuariotextBox.TabIndex = 13;
            this.loginUsuariotextBox.Visible = false;
            // 
            // loginContraseñaLabel
            // 
            this.loginContraseñaLabel.AutoSize = true;
            this.loginContraseñaLabel.Location = new System.Drawing.Point(162, 379);
            this.loginContraseñaLabel.Name = "loginContraseñaLabel";
            this.loginContraseñaLabel.Size = new System.Drawing.Size(90, 16);
            this.loginContraseñaLabel.TabIndex = 12;
            this.loginContraseñaLabel.Text = "Contraseña:";
            this.loginContraseñaLabel.Visible = false;
            // 
            // loginUsuarioLabel
            // 
            this.loginUsuarioLabel.AutoSize = true;
            this.loginUsuarioLabel.Location = new System.Drawing.Point(192, 340);
            this.loginUsuarioLabel.Name = "loginUsuarioLabel";
            this.loginUsuarioLabel.Size = new System.Drawing.Size(69, 16);
            this.loginUsuarioLabel.TabIndex = 11;
            this.loginUsuarioLabel.Text = "Usuario: ";
            this.loginUsuarioLabel.Visible = false;
            // 
            // signupRegistrarButton
            // 
            this.signupRegistrarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signupRegistrarButton.Location = new System.Drawing.Point(289, 444);
            this.signupRegistrarButton.Name = "signupRegistrarButton";
            this.signupRegistrarButton.Size = new System.Drawing.Size(109, 45);
            this.signupRegistrarButton.TabIndex = 24;
            this.signupRegistrarButton.Text = "Registrar";
            this.signupRegistrarButton.UseVisualStyleBackColor = true;
            this.signupRegistrarButton.Visible = false;
            this.signupRegistrarButton.Click += new System.EventHandler(this.signupRegistrarButton_Click);
            // 
            // signupCorreotextBox
            // 
            this.signupCorreotextBox.Location = new System.Drawing.Point(207, 329);
            this.signupCorreotextBox.Name = "signupCorreotextBox";
            this.signupCorreotextBox.Size = new System.Drawing.Size(278, 22);
            this.signupCorreotextBox.TabIndex = 23;
            this.signupCorreotextBox.Visible = false;
            // 
            // signupCorreoLabel
            // 
            this.signupCorreoLabel.AutoSize = true;
            this.signupCorreoLabel.Location = new System.Drawing.Point(62, 332);
            this.signupCorreoLabel.Name = "signupCorreoLabel";
            this.signupCorreoLabel.Size = new System.Drawing.Size(139, 16);
            this.signupCorreoLabel.TabIndex = 22;
            this.signupCorreoLabel.Text = "Correo electrónico:";
            this.signupCorreoLabel.Visible = false;
            // 
            // signupLabel
            // 
            this.signupLabel.AutoSize = true;
            this.signupLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signupLabel.Location = new System.Drawing.Point(260, 291);
            this.signupLabel.Name = "signupLabel";
            this.signupLabel.Size = new System.Drawing.Size(170, 32);
            this.signupLabel.TabIndex = 21;
            this.signupLabel.Text = "Registrarse";
            this.signupLabel.Visible = false;
            // 
            // signupContraseñatextBox
            // 
            this.signupContraseñatextBox.Location = new System.Drawing.Point(207, 405);
            this.signupContraseñatextBox.Name = "signupContraseñatextBox";
            this.signupContraseñatextBox.PasswordChar = '*';
            this.signupContraseñatextBox.Size = new System.Drawing.Size(278, 22);
            this.signupContraseñatextBox.TabIndex = 20;
            this.signupContraseñatextBox.Visible = false;
            // 
            // signupUsuariotextBox
            // 
            this.signupUsuariotextBox.Location = new System.Drawing.Point(207, 366);
            this.signupUsuariotextBox.Name = "signupUsuariotextBox";
            this.signupUsuariotextBox.Size = new System.Drawing.Size(278, 22);
            this.signupUsuariotextBox.TabIndex = 19;
            this.signupUsuariotextBox.Visible = false;
            // 
            // signupContraseñaLabel
            // 
            this.signupContraseñaLabel.AutoSize = true;
            this.signupContraseñaLabel.Location = new System.Drawing.Point(111, 405);
            this.signupContraseñaLabel.Name = "signupContraseñaLabel";
            this.signupContraseñaLabel.Size = new System.Drawing.Size(90, 16);
            this.signupContraseñaLabel.TabIndex = 18;
            this.signupContraseñaLabel.Text = "Contraseña:";
            this.signupContraseñaLabel.Visible = false;
            // 
            // signupUsuarioLabel
            // 
            this.signupUsuarioLabel.AutoSize = true;
            this.signupUsuarioLabel.Location = new System.Drawing.Point(141, 366);
            this.signupUsuarioLabel.Name = "signupUsuarioLabel";
            this.signupUsuarioLabel.Size = new System.Drawing.Size(69, 16);
            this.signupUsuarioLabel.TabIndex = 17;
            this.signupUsuarioLabel.Text = "Usuario: ";
            this.signupUsuarioLabel.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(199, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 46);
            this.label2.TabIndex = 25;
            this.label2.Text = "Parchis";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(349, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 46);
            this.label3.TabIndex = 26;
            this.label3.Text = ".com";
            // 
            // desconectarButton
            // 
            this.desconectarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desconectarButton.Location = new System.Drawing.Point(341, 144);
            this.desconectarButton.Margin = new System.Windows.Forms.Padding(4);
            this.desconectarButton.Name = "desconectarButton";
            this.desconectarButton.Size = new System.Drawing.Size(144, 38);
            this.desconectarButton.TabIndex = 27;
            this.desconectarButton.Text = "Desconectar";
            this.desconectarButton.UseVisualStyleBackColor = true;
            this.desconectarButton.Click += new System.EventHandler(this.desconectarButton_Click);
            // 
            // unsubscribeSarseBajaButton
            // 
            this.unsubscribeSarseBajaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unsubscribeSarseBajaButton.Location = new System.Drawing.Point(272, 444);
            this.unsubscribeSarseBajaButton.Name = "unsubscribeSarseBajaButton";
            this.unsubscribeSarseBajaButton.Size = new System.Drawing.Size(145, 45);
            this.unsubscribeSarseBajaButton.TabIndex = 35;
            this.unsubscribeSarseBajaButton.Text = "Darse de baja";
            this.unsubscribeSarseBajaButton.UseVisualStyleBackColor = true;
            this.unsubscribeSarseBajaButton.Visible = false;
            this.unsubscribeSarseBajaButton.Click += new System.EventHandler(this.unsubscribeSarseBajaButton_Click);
            // 
            // unsubscribeCorreotextBox
            // 
            this.unsubscribeCorreotextBox.Location = new System.Drawing.Point(208, 329);
            this.unsubscribeCorreotextBox.Name = "unsubscribeCorreotextBox";
            this.unsubscribeCorreotextBox.Size = new System.Drawing.Size(278, 22);
            this.unsubscribeCorreotextBox.TabIndex = 34;
            this.unsubscribeCorreotextBox.Visible = false;
            // 
            // unsubscribeCorreoLbl
            // 
            this.unsubscribeCorreoLbl.AutoSize = true;
            this.unsubscribeCorreoLbl.Location = new System.Drawing.Point(63, 332);
            this.unsubscribeCorreoLbl.Name = "unsubscribeCorreoLbl";
            this.unsubscribeCorreoLbl.Size = new System.Drawing.Size(139, 16);
            this.unsubscribeCorreoLbl.TabIndex = 33;
            this.unsubscribeCorreoLbl.Text = "Correo electrónico:";
            this.unsubscribeCorreoLbl.Visible = false;
            // 
            // unsubscribeLbl
            // 
            this.unsubscribeLbl.AutoSize = true;
            this.unsubscribeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unsubscribeLbl.Location = new System.Drawing.Point(252, 291);
            this.unsubscribeLbl.Name = "unsubscribeLbl";
            this.unsubscribeLbl.Size = new System.Drawing.Size(203, 32);
            this.unsubscribeLbl.TabIndex = 32;
            this.unsubscribeLbl.Text = "Darse de baja";
            this.unsubscribeLbl.Visible = false;
            // 
            // unsubscribeContraseñatextBox
            // 
            this.unsubscribeContraseñatextBox.Location = new System.Drawing.Point(208, 405);
            this.unsubscribeContraseñatextBox.Name = "unsubscribeContraseñatextBox";
            this.unsubscribeContraseñatextBox.PasswordChar = '*';
            this.unsubscribeContraseñatextBox.Size = new System.Drawing.Size(278, 22);
            this.unsubscribeContraseñatextBox.TabIndex = 31;
            this.unsubscribeContraseñatextBox.Visible = false;
            // 
            // unsubscribeUsuariotextBox
            // 
            this.unsubscribeUsuariotextBox.Location = new System.Drawing.Point(208, 366);
            this.unsubscribeUsuariotextBox.Name = "unsubscribeUsuariotextBox";
            this.unsubscribeUsuariotextBox.Size = new System.Drawing.Size(278, 22);
            this.unsubscribeUsuariotextBox.TabIndex = 30;
            this.unsubscribeUsuariotextBox.Visible = false;
            // 
            // unsubscribeContraseñaLbl
            // 
            this.unsubscribeContraseñaLbl.AutoSize = true;
            this.unsubscribeContraseñaLbl.Location = new System.Drawing.Point(112, 405);
            this.unsubscribeContraseñaLbl.Name = "unsubscribeContraseñaLbl";
            this.unsubscribeContraseñaLbl.Size = new System.Drawing.Size(90, 16);
            this.unsubscribeContraseñaLbl.TabIndex = 29;
            this.unsubscribeContraseñaLbl.Text = "Contraseña:";
            this.unsubscribeContraseñaLbl.Visible = false;
            // 
            // unsubscribeUsuarioLbl
            // 
            this.unsubscribeUsuarioLbl.AutoSize = true;
            this.unsubscribeUsuarioLbl.Location = new System.Drawing.Point(142, 366);
            this.unsubscribeUsuarioLbl.Name = "unsubscribeUsuarioLbl";
            this.unsubscribeUsuarioLbl.Size = new System.Drawing.Size(69, 16);
            this.unsubscribeUsuarioLbl.TabIndex = 28;
            this.unsubscribeUsuarioLbl.Text = "Usuario: ";
            this.unsubscribeUsuarioLbl.Visible = false;
            // 
            // unsubscribeButton
            // 
            this.unsubscribeButton.Location = new System.Drawing.Point(423, 205);
            this.unsubscribeButton.Name = "unsubscribeButton";
            this.unsubscribeButton.Size = new System.Drawing.Size(151, 51);
            this.unsubscribeButton.TabIndex = 36;
            this.unsubscribeButton.Text = "Darse de baja";
            this.unsubscribeButton.UseVisualStyleBackColor = true;
            this.unsubscribeButton.Visible = false;
            this.unsubscribeButton.Click += new System.EventHandler(this.unsubscribeButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(680, 520);
            this.Controls.Add(this.unsubscribeButton);
            this.Controls.Add(this.unsubscribeSarseBajaButton);
            this.Controls.Add(this.unsubscribeCorreotextBox);
            this.Controls.Add(this.unsubscribeCorreoLbl);
            this.Controls.Add(this.unsubscribeLbl);
            this.Controls.Add(this.unsubscribeContraseñatextBox);
            this.Controls.Add(this.unsubscribeUsuariotextBox);
            this.Controls.Add(this.unsubscribeContraseñaLbl);
            this.Controls.Add(this.unsubscribeUsuarioLbl);
            this.Controls.Add(this.desconectarButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.signupRegistrarButton);
            this.Controls.Add(this.signupCorreotextBox);
            this.Controls.Add(this.signupCorreoLabel);
            this.Controls.Add(this.signupLabel);
            this.Controls.Add(this.signupContraseñatextBox);
            this.Controls.Add(this.signupUsuariotextBox);
            this.Controls.Add(this.signupContraseñaLabel);
            this.Controls.Add(this.signupUsuarioLabel);
            this.Controls.Add(this.loginEntrarButton);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.loginContraseñatextBox);
            this.Controls.Add(this.loginUsuariotextBox);
            this.Controls.Add(this.loginContraseñaLabel);
            this.Controls.Add(this.loginUsuarioLabel);
            this.Controls.Add(this.signupButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.IP);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IP;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button signupButton;
        private System.Windows.Forms.Button loginEntrarButton;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.TextBox loginContraseñatextBox;
        private System.Windows.Forms.TextBox loginUsuariotextBox;
        private System.Windows.Forms.Label loginContraseñaLabel;
        private System.Windows.Forms.Label loginUsuarioLabel;
        private System.Windows.Forms.Button signupRegistrarButton;
        private System.Windows.Forms.TextBox signupCorreotextBox;
        private System.Windows.Forms.Label signupCorreoLabel;
        private System.Windows.Forms.Label signupLabel;
        private System.Windows.Forms.TextBox signupContraseñatextBox;
        private System.Windows.Forms.TextBox signupUsuariotextBox;
        private System.Windows.Forms.Label signupContraseñaLabel;
        private System.Windows.Forms.Label signupUsuarioLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button desconectarButton;
        private System.Windows.Forms.Button unsubscribeSarseBajaButton;
        private System.Windows.Forms.TextBox unsubscribeCorreotextBox;
        private System.Windows.Forms.Label unsubscribeCorreoLbl;
        private System.Windows.Forms.Label unsubscribeLbl;
        private System.Windows.Forms.TextBox unsubscribeContraseñatextBox;
        private System.Windows.Forms.TextBox unsubscribeUsuariotextBox;
        private System.Windows.Forms.Label unsubscribeContraseñaLbl;
        private System.Windows.Forms.Label unsubscribeUsuarioLbl;
        private System.Windows.Forms.Button unsubscribeButton;
    }
}

