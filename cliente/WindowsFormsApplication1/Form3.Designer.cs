namespace WindowsFormsApplication1
{
    partial class Form3
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
            this.consultaLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.consultasComboBox = new System.Windows.Forms.ComboBox();
            this.consultarBtn = new System.Windows.Forms.Button();
            this.nombreJugador1TextBox = new System.Windows.Forms.TextBox();
            this.nombreJugador1Lbl = new System.Windows.Forms.Label();
            this.fechaInicioLbl = new System.Windows.Forms.Label();
            this.fechaFinalLbl = new System.Windows.Forms.Label();
            this.fechaInicioDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.fechaFinalDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Jugadores = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Número = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jugador1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jugador2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jugador3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jugador4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreJugador3TextBox = new System.Windows.Forms.TextBox();
            this.nombreJugador3Lbl = new System.Windows.Forms.Label();
            this.nombreJugador2TextBox = new System.Windows.Forms.TextBox();
            this.nombreJugador2Lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // consultaLbl
            // 
            this.consultaLbl.AutoSize = true;
            this.consultaLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consultaLbl.Location = new System.Drawing.Point(336, 101);
            this.consultaLbl.Name = "consultaLbl";
            this.consultaLbl.Size = new System.Drawing.Size(150, 32);
            this.consultaLbl.TabIndex = 51;
            this.consultaLbl.Text = "Consultas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(442, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 46);
            this.label4.TabIndex = 50;
            this.label4.Text = ".com";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(275, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 46);
            this.label1.TabIndex = 49;
            this.label1.Text = "Parchis";
            // 
            // consultasComboBox
            // 
            this.consultasComboBox.FormattingEnabled = true;
            this.consultasComboBox.Items.AddRange(new object[] {
            "Listado de jugadores con los que he echado alguna partida.",
            "Resultados de las partidas que jugué con un jugador (o jugadores) determinado.",
            "Lista de partidas jugadas en un periodo de tiempo dado."});
            this.consultasComboBox.Location = new System.Drawing.Point(160, 149);
            this.consultasComboBox.Name = "consultasComboBox";
            this.consultasComboBox.Size = new System.Drawing.Size(507, 24);
            this.consultasComboBox.TabIndex = 52;
            this.consultasComboBox.SelectedIndexChanged += new System.EventHandler(this.consultasComboBox_SelectedIndexChanged);
            // 
            // consultarBtn
            // 
            this.consultarBtn.Location = new System.Drawing.Point(342, 266);
            this.consultarBtn.Name = "consultarBtn";
            this.consultarBtn.Size = new System.Drawing.Size(151, 27);
            this.consultarBtn.TabIndex = 53;
            this.consultarBtn.Text = "Consultar";
            this.consultarBtn.UseVisualStyleBackColor = true;
            this.consultarBtn.Visible = false;
            this.consultarBtn.Click += new System.EventHandler(this.consultarBtn_Click);
            // 
            // nombreJugador1TextBox
            // 
            this.nombreJugador1TextBox.Location = new System.Drawing.Point(359, 185);
            this.nombreJugador1TextBox.Name = "nombreJugador1TextBox";
            this.nombreJugador1TextBox.Size = new System.Drawing.Size(212, 22);
            this.nombreJugador1TextBox.TabIndex = 55;
            this.nombreJugador1TextBox.Visible = false;
            // 
            // nombreJugador1Lbl
            // 
            this.nombreJugador1Lbl.AutoSize = true;
            this.nombreJugador1Lbl.Location = new System.Drawing.Point(235, 188);
            this.nombreJugador1Lbl.Name = "nombreJugador1Lbl";
            this.nombreJugador1Lbl.Size = new System.Drawing.Size(108, 16);
            this.nombreJugador1Lbl.TabIndex = 54;
            this.nombreJugador1Lbl.Text = "Nombre jugador:";
            this.nombreJugador1Lbl.Visible = false;
            // 
            // fechaInicioLbl
            // 
            this.fechaInicioLbl.AutoSize = true;
            this.fechaInicioLbl.Location = new System.Drawing.Point(144, 201);
            this.fechaInicioLbl.Name = "fechaInicioLbl";
            this.fechaInicioLbl.Size = new System.Drawing.Size(85, 16);
            this.fechaInicioLbl.TabIndex = 56;
            this.fechaInicioLbl.Text = "Fecha inicial:";
            this.fechaInicioLbl.Visible = false;
            // 
            // fechaFinalLbl
            // 
            this.fechaFinalLbl.AutoSize = true;
            this.fechaFinalLbl.Location = new System.Drawing.Point(459, 201);
            this.fechaFinalLbl.Name = "fechaFinalLbl";
            this.fechaFinalLbl.Size = new System.Drawing.Size(75, 16);
            this.fechaFinalLbl.TabIndex = 58;
            this.fechaFinalLbl.Text = "Fecha final:";
            this.fechaFinalLbl.Visible = false;
            // 
            // fechaInicioDateTimePicker
            // 
            this.fechaInicioDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaInicioDateTimePicker.Location = new System.Drawing.Point(247, 201);
            this.fechaInicioDateTimePicker.Name = "fechaInicioDateTimePicker";
            this.fechaInicioDateTimePicker.Size = new System.Drawing.Size(174, 22);
            this.fechaInicioDateTimePicker.TabIndex = 60;
            this.fechaInicioDateTimePicker.Visible = false;
            // 
            // fechaFinalDateTimePicker
            // 
            this.fechaFinalDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaFinalDateTimePicker.Location = new System.Drawing.Point(545, 201);
            this.fechaFinalDateTimePicker.Name = "fechaFinalDateTimePicker";
            this.fechaFinalDateTimePicker.Size = new System.Drawing.Size(174, 22);
            this.fechaFinalDateTimePicker.TabIndex = 61;
            this.fechaFinalDateTimePicker.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Jugadores});
            this.dataGridView1.Location = new System.Drawing.Point(309, 309);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(208, 291);
            this.dataGridView1.TabIndex = 62;
            this.dataGridView1.Visible = false;
            // 
            // Jugadores
            // 
            this.Jugadores.HeaderText = "Jugadores";
            this.Jugadores.MinimumWidth = 6;
            this.Jugadores.Name = "Jugadores";
            this.Jugadores.ReadOnly = true;
            this.Jugadores.Width = 125;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha,
            this.Número,
            this.Jugador1,
            this.Jugador2,
            this.Jugador3,
            this.Jugador4});
            this.dataGridView2.Location = new System.Drawing.Point(12, 309);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(804, 291);
            this.dataGridView2.TabIndex = 63;
            this.dataGridView2.Visible = false;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.MinimumWidth = 6;
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 125;
            // 
            // Número
            // 
            this.Número.HeaderText = "Número de jugadores";
            this.Número.MinimumWidth = 6;
            this.Número.Name = "Número";
            this.Número.ReadOnly = true;
            this.Número.Width = 125;
            // 
            // Jugador1
            // 
            this.Jugador1.HeaderText = "Jugador 1";
            this.Jugador1.MinimumWidth = 6;
            this.Jugador1.Name = "Jugador1";
            this.Jugador1.ReadOnly = true;
            this.Jugador1.Width = 125;
            // 
            // Jugador2
            // 
            this.Jugador2.HeaderText = "Jugador 2";
            this.Jugador2.MinimumWidth = 6;
            this.Jugador2.Name = "Jugador2";
            this.Jugador2.ReadOnly = true;
            this.Jugador2.Width = 125;
            // 
            // Jugador3
            // 
            this.Jugador3.HeaderText = "Jugador 3";
            this.Jugador3.MinimumWidth = 6;
            this.Jugador3.Name = "Jugador3";
            this.Jugador3.ReadOnly = true;
            this.Jugador3.Width = 125;
            // 
            // Jugador4
            // 
            this.Jugador4.HeaderText = "Jugador 4";
            this.Jugador4.MinimumWidth = 6;
            this.Jugador4.Name = "Jugador4";
            this.Jugador4.ReadOnly = true;
            this.Jugador4.Width = 125;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dataGridView3.Location = new System.Drawing.Point(12, 309);
            this.dataGridView3.MultiSelect = false;
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.RowTemplate.Height = 24;
            this.dataGridView3.Size = new System.Drawing.Size(804, 291);
            this.dataGridView3.TabIndex = 64;
            this.dataGridView3.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Fecha";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Número de jugadores";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Jugador 1";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Jugador 2";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Jugador 3";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Jugador 4";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 125;
            // 
            // nombreJugador3TextBox
            // 
            this.nombreJugador3TextBox.Location = new System.Drawing.Point(359, 238);
            this.nombreJugador3TextBox.Name = "nombreJugador3TextBox";
            this.nombreJugador3TextBox.Size = new System.Drawing.Size(212, 22);
            this.nombreJugador3TextBox.TabIndex = 66;
            this.nombreJugador3TextBox.Visible = false;
            // 
            // nombreJugador3Lbl
            // 
            this.nombreJugador3Lbl.AutoSize = true;
            this.nombreJugador3Lbl.Location = new System.Drawing.Point(235, 241);
            this.nombreJugador3Lbl.Name = "nombreJugador3Lbl";
            this.nombreJugador3Lbl.Size = new System.Drawing.Size(108, 16);
            this.nombreJugador3Lbl.TabIndex = 65;
            this.nombreJugador3Lbl.Text = "Nombre jugador:";
            this.nombreJugador3Lbl.Visible = false;
            // 
            // nombreJugador2TextBox
            // 
            this.nombreJugador2TextBox.Location = new System.Drawing.Point(359, 211);
            this.nombreJugador2TextBox.Name = "nombreJugador2TextBox";
            this.nombreJugador2TextBox.Size = new System.Drawing.Size(212, 22);
            this.nombreJugador2TextBox.TabIndex = 68;
            this.nombreJugador2TextBox.Visible = false;
            // 
            // nombreJugador2Lbl
            // 
            this.nombreJugador2Lbl.AutoSize = true;
            this.nombreJugador2Lbl.Location = new System.Drawing.Point(235, 214);
            this.nombreJugador2Lbl.Name = "nombreJugador2Lbl";
            this.nombreJugador2Lbl.Size = new System.Drawing.Size(108, 16);
            this.nombreJugador2Lbl.TabIndex = 67;
            this.nombreJugador2Lbl.Text = "Nombre jugador:";
            this.nombreJugador2Lbl.Visible = false;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.ClientSize = new System.Drawing.Size(826, 676);
            this.Controls.Add(this.nombreJugador2TextBox);
            this.Controls.Add(this.nombreJugador2Lbl);
            this.Controls.Add(this.nombreJugador3TextBox);
            this.Controls.Add(this.nombreJugador3Lbl);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.fechaFinalDateTimePicker);
            this.Controls.Add(this.fechaInicioDateTimePicker);
            this.Controls.Add(this.fechaFinalLbl);
            this.Controls.Add(this.fechaInicioLbl);
            this.Controls.Add(this.nombreJugador1TextBox);
            this.Controls.Add(this.nombreJugador1Lbl);
            this.Controls.Add(this.consultarBtn);
            this.Controls.Add(this.consultasComboBox);
            this.Controls.Add(this.consultaLbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label consultaLbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox consultasComboBox;
        private System.Windows.Forms.Button consultarBtn;
        private System.Windows.Forms.TextBox nombreJugador1TextBox;
        private System.Windows.Forms.Label nombreJugador1Lbl;
        private System.Windows.Forms.Label fechaInicioLbl;
        private System.Windows.Forms.Label fechaFinalLbl;
        private System.Windows.Forms.DateTimePicker fechaInicioDateTimePicker;
        private System.Windows.Forms.DateTimePicker fechaFinalDateTimePicker;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jugadores;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Número;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jugador1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jugador2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jugador3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jugador4;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.TextBox nombreJugador3TextBox;
        private System.Windows.Forms.Label nombreJugador3Lbl;
        private System.Windows.Forms.TextBox nombreJugador2TextBox;
        private System.Windows.Forms.Label nombreJugador2Lbl;
    }
}