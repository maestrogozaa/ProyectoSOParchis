namespace WindowsFormsApplication1
{
    partial class Form2
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
            this.ListaConectadosLbl = new System.Windows.Forms.Label();
            this.invitacionesBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.conectados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.perfilBtn = new System.Windows.Forms.Button();
            this.bloquearBtn = new System.Windows.Forms.Button();
            this.usuarioLbl = new System.Windows.Forms.Label();
            this.crearSalaBtn = new System.Windows.Forms.Button();
            this.abandonarSalaBtn = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.JugadoresSala = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salaJuegoLbl = new System.Windows.Forms.Label();
            this.chatSalaLbl = new System.Windows.Forms.Label();
            this.escribirMensajesTextBox = new System.Windows.Forms.TextBox();
            this.mensajeslistBox = new System.Windows.Forms.ListBox();
            this.enviarMensajeBtn = new System.Windows.Forms.Button();
            this.empezarpartidaBtn = new System.Windows.Forms.Button();
            this.consultasBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // ListaConectadosLbl
            // 
            this.ListaConectadosLbl.AutoSize = true;
            this.ListaConectadosLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListaConectadosLbl.Location = new System.Drawing.Point(87, 268);
            this.ListaConectadosLbl.Name = "ListaConectadosLbl";
            this.ListaConectadosLbl.Size = new System.Drawing.Size(251, 32);
            this.ListaConectadosLbl.TabIndex = 34;
            this.ListaConectadosLbl.Text = "Usuarios en línea";
            // 
            // invitacionesBtn
            // 
            this.invitacionesBtn.Location = new System.Drawing.Point(264, 439);
            this.invitacionesBtn.Name = "invitacionesBtn";
            this.invitacionesBtn.Size = new System.Drawing.Size(132, 50);
            this.invitacionesBtn.TabIndex = 33;
            this.invitacionesBtn.Text = "Invitar";
            this.invitacionesBtn.UseVisualStyleBackColor = true;
            this.invitacionesBtn.Click += new System.EventHandler(this.invitacionesBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(85, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 46);
            this.label1.TabIndex = 39;
            this.label1.Text = "Parchis";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(252, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 46);
            this.label4.TabIndex = 40;
            this.label4.Text = ".com";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.conectados});
            this.dataGridView1.Location = new System.Drawing.Point(50, 315);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(208, 450);
            this.dataGridView1.TabIndex = 41;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // conectados
            // 
            this.conectados.HeaderText = "Usuarios conectados";
            this.conectados.MinimumWidth = 6;
            this.conectados.Name = "conectados";
            this.conectados.ReadOnly = true;
            this.conectados.Width = 125;
            // 
            // perfilBtn
            // 
            this.perfilBtn.Location = new System.Drawing.Point(264, 384);
            this.perfilBtn.Name = "perfilBtn";
            this.perfilBtn.Size = new System.Drawing.Size(132, 49);
            this.perfilBtn.TabIndex = 42;
            this.perfilBtn.Text = "Ver perfil";
            this.perfilBtn.UseVisualStyleBackColor = true;
            // 
            // bloquearBtn
            // 
            this.bloquearBtn.Location = new System.Drawing.Point(264, 495);
            this.bloquearBtn.Name = "bloquearBtn";
            this.bloquearBtn.Size = new System.Drawing.Size(132, 50);
            this.bloquearBtn.TabIndex = 43;
            this.bloquearBtn.Text = "Bloquear";
            this.bloquearBtn.UseVisualStyleBackColor = true;
            this.bloquearBtn.Click += new System.EventHandler(this.bloquearBtn_Click);
            // 
            // usuarioLbl
            // 
            this.usuarioLbl.AutoSize = true;
            this.usuarioLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuarioLbl.Location = new System.Drawing.Point(116, 107);
            this.usuarioLbl.Name = "usuarioLbl";
            this.usuarioLbl.Size = new System.Drawing.Size(0, 32);
            this.usuarioLbl.TabIndex = 44;
            // 
            // crearSalaBtn
            // 
            this.crearSalaBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crearSalaBtn.Location = new System.Drawing.Point(44, 160);
            this.crearSalaBtn.Name = "crearSalaBtn";
            this.crearSalaBtn.Size = new System.Drawing.Size(176, 62);
            this.crearSalaBtn.TabIndex = 45;
            this.crearSalaBtn.Text = "Crear sala";
            this.crearSalaBtn.UseVisualStyleBackColor = true;
            this.crearSalaBtn.Click += new System.EventHandler(this.crearSalaBtn_Click);
            // 
            // abandonarSalaBtn
            // 
            this.abandonarSalaBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.abandonarSalaBtn.Location = new System.Drawing.Point(226, 160);
            this.abandonarSalaBtn.Name = "abandonarSalaBtn";
            this.abandonarSalaBtn.Size = new System.Drawing.Size(203, 62);
            this.abandonarSalaBtn.TabIndex = 46;
            this.abandonarSalaBtn.Text = "Abandonar sala";
            this.abandonarSalaBtn.UseVisualStyleBackColor = true;
            this.abandonarSalaBtn.Click += new System.EventHandler(this.abandonarSalaBtn_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.JugadoresSala});
            this.dataGridView2.Location = new System.Drawing.Point(489, 108);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(231, 221);
            this.dataGridView2.TabIndex = 47;
            this.dataGridView2.Visible = false;
            // 
            // JugadoresSala
            // 
            this.JugadoresSala.HeaderText = "Jugadores en la sala";
            this.JugadoresSala.MinimumWidth = 6;
            this.JugadoresSala.Name = "JugadoresSala";
            this.JugadoresSala.ReadOnly = true;
            this.JugadoresSala.Width = 125;
            // 
            // salaJuegoLbl
            // 
            this.salaJuegoLbl.AutoSize = true;
            this.salaJuegoLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salaJuegoLbl.Location = new System.Drawing.Point(504, 62);
            this.salaJuegoLbl.Name = "salaJuegoLbl";
            this.salaJuegoLbl.Size = new System.Drawing.Size(202, 32);
            this.salaJuegoLbl.TabIndex = 48;
            this.salaJuegoLbl.Text = "Sala de juego";
            this.salaJuegoLbl.Visible = false;
            // 
            // chatSalaLbl
            // 
            this.chatSalaLbl.AutoSize = true;
            this.chatSalaLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatSalaLbl.Location = new System.Drawing.Point(504, 429);
            this.chatSalaLbl.Name = "chatSalaLbl";
            this.chatSalaLbl.Size = new System.Drawing.Size(185, 32);
            this.chatSalaLbl.TabIndex = 49;
            this.chatSalaLbl.Text = "Chat de sala";
            this.chatSalaLbl.Visible = false;
            // 
            // escribirMensajesTextBox
            // 
            this.escribirMensajesTextBox.Location = new System.Drawing.Point(460, 761);
            this.escribirMensajesTextBox.Multiline = true;
            this.escribirMensajesTextBox.Name = "escribirMensajesTextBox";
            this.escribirMensajesTextBox.Size = new System.Drawing.Size(216, 37);
            this.escribirMensajesTextBox.TabIndex = 51;
            this.escribirMensajesTextBox.Visible = false;
            // 
            // mensajeslistBox
            // 
            this.mensajeslistBox.FormattingEnabled = true;
            this.mensajeslistBox.ItemHeight = 16;
            this.mensajeslistBox.Location = new System.Drawing.Point(460, 473);
            this.mensajeslistBox.Name = "mensajeslistBox";
            this.mensajeslistBox.Size = new System.Drawing.Size(279, 292);
            this.mensajeslistBox.TabIndex = 52;
            this.mensajeslistBox.Visible = false;
            // 
            // enviarMensajeBtn
            // 
            this.enviarMensajeBtn.Location = new System.Drawing.Point(677, 761);
            this.enviarMensajeBtn.Name = "enviarMensajeBtn";
            this.enviarMensajeBtn.Size = new System.Drawing.Size(62, 41);
            this.enviarMensajeBtn.TabIndex = 53;
            this.enviarMensajeBtn.Text = ">>";
            this.enviarMensajeBtn.UseVisualStyleBackColor = true;
            this.enviarMensajeBtn.Visible = false;
            this.enviarMensajeBtn.Click += new System.EventHandler(this.enviarMensajeBtn_Click);
            // 
            // empezarpartidaBtn
            // 
            this.empezarpartidaBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empezarpartidaBtn.Location = new System.Drawing.Point(499, 335);
            this.empezarpartidaBtn.Name = "empezarpartidaBtn";
            this.empezarpartidaBtn.Size = new System.Drawing.Size(207, 62);
            this.empezarpartidaBtn.TabIndex = 54;
            this.empezarpartidaBtn.Text = "Empezar partida";
            this.empezarpartidaBtn.UseVisualStyleBackColor = true;
            this.empezarpartidaBtn.Visible = false;
            this.empezarpartidaBtn.Click += new System.EventHandler(this.empezarpartidaBtn_Click);
            // 
            // consultasBtn
            // 
            this.consultasBtn.Location = new System.Drawing.Point(264, 329);
            this.consultasBtn.Name = "consultasBtn";
            this.consultasBtn.Size = new System.Drawing.Size(132, 49);
            this.consultasBtn.TabIndex = 55;
            this.consultasBtn.Text = "Consultar";
            this.consultasBtn.UseVisualStyleBackColor = true;
            this.consultasBtn.Click += new System.EventHandler(this.consultasBtn_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.ClientSize = new System.Drawing.Size(787, 829);
            this.Controls.Add(this.consultasBtn);
            this.Controls.Add(this.empezarpartidaBtn);
            this.Controls.Add(this.mensajeslistBox);
            this.Controls.Add(this.enviarMensajeBtn);
            this.Controls.Add(this.escribirMensajesTextBox);
            this.Controls.Add(this.chatSalaLbl);
            this.Controls.Add(this.salaJuegoLbl);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.abandonarSalaBtn);
            this.Controls.Add(this.crearSalaBtn);
            this.Controls.Add(this.usuarioLbl);
            this.Controls.Add(this.bloquearBtn);
            this.Controls.Add(this.perfilBtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ListaConectadosLbl);
            this.Controls.Add(this.invitacionesBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ListaConectadosLbl;
        private System.Windows.Forms.Button invitacionesBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn conectados;
        private System.Windows.Forms.Button perfilBtn;
        private System.Windows.Forms.Button bloquearBtn;
        private System.Windows.Forms.Label usuarioLbl;
        private System.Windows.Forms.Button crearSalaBtn;
        private System.Windows.Forms.Button abandonarSalaBtn;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label salaJuegoLbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn JugadoresSala;
        private System.Windows.Forms.Label chatSalaLbl;
        private System.Windows.Forms.TextBox escribirMensajesTextBox;
        private System.Windows.Forms.ListBox mensajeslistBox;
        private System.Windows.Forms.Button enviarMensajeBtn;
        private System.Windows.Forms.Button empezarpartidaBtn;
        private System.Windows.Forms.Button consultasBtn;
    }
}