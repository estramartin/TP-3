﻿namespace Agencia_Autos
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menúToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conChoferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sinChoferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarDatosDeVehiculoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarVehiculoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarRegistrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alquilerVigenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarValoresDeAlquilerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verGraficosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conSinChoferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.DGV1 = new System.Windows.Forms.DataGridView();
            this.CMARCA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMOODELO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCAPACIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCOMBUSTIBLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CKMS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CDISPONIBILE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPRECIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbChofer = new System.Windows.Forms.ComboBox();
            this.cbVehiculos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PrintTicket = new System.Drawing.Printing.PrintDocument();
            this.tbFiltro = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.printComprobante = new System.Drawing.Printing.PrintDocument();
            this.printPermisos = new System.Drawing.Printing.PrintDocument();
            this.printArchivo = new System.Drawing.Printing.PrintDocument();
            this.agregarUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pblogo = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pblogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menúToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1373, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menúToolStripMenuItem
            // 
            this.menúToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem,
            this.borrarRegistrosToolStripMenuItem,
            this.modificarValoresDeAlquilerToolStripMenuItem,
            this.verGraficosToolStripMenuItem,
            this.agregarUsuarioToolStripMenuItem});
            this.menúToolStripMenuItem.Name = "menúToolStripMenuItem";
            this.menúToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menúToolStripMenuItem.Text = "Menú";
            // 
            // agregarToolStripMenuItem
            // 
            this.agregarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conChoferToolStripMenuItem,
            this.sinChoferToolStripMenuItem,
            this.modificarDatosDeVehiculoToolStripMenuItem,
            this.eliminarVehiculoToolStripMenuItem});
            this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            this.agregarToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.agregarToolStripMenuItem.Text = "Agregar Vehículo";
            this.agregarToolStripMenuItem.Click += new System.EventHandler(this.agregarToolStripMenuItem_Click);
            // 
            // conChoferToolStripMenuItem
            // 
            this.conChoferToolStripMenuItem.Name = "conChoferToolStripMenuItem";
            this.conChoferToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.conChoferToolStripMenuItem.Text = "Con Chofer";
            this.conChoferToolStripMenuItem.Click += new System.EventHandler(this.conChoferToolStripMenuItem_Click);
            // 
            // sinChoferToolStripMenuItem
            // 
            this.sinChoferToolStripMenuItem.Name = "sinChoferToolStripMenuItem";
            this.sinChoferToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.sinChoferToolStripMenuItem.Text = "Sin Chofer";
            this.sinChoferToolStripMenuItem.Click += new System.EventHandler(this.sinChoferToolStripMenuItem_Click);
            // 
            // modificarDatosDeVehiculoToolStripMenuItem
            // 
            this.modificarDatosDeVehiculoToolStripMenuItem.Name = "modificarDatosDeVehiculoToolStripMenuItem";
            this.modificarDatosDeVehiculoToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.modificarDatosDeVehiculoToolStripMenuItem.Text = "Modificar Datos de Vehiculo";
            this.modificarDatosDeVehiculoToolStripMenuItem.Click += new System.EventHandler(this.modificarDatosDeVehiculoToolStripMenuItem_Click);
            // 
            // eliminarVehiculoToolStripMenuItem
            // 
            this.eliminarVehiculoToolStripMenuItem.Name = "eliminarVehiculoToolStripMenuItem";
            this.eliminarVehiculoToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.eliminarVehiculoToolStripMenuItem.Text = "Eliminar Vehiculo";
            this.eliminarVehiculoToolStripMenuItem.Click += new System.EventHandler(this.eliminarVehiculoToolStripMenuItem_Click);
            // 
            // borrarRegistrosToolStripMenuItem
            // 
            this.borrarRegistrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.historicoToolStripMenuItem,
            this.alquilerVigenteToolStripMenuItem});
            this.borrarRegistrosToolStripMenuItem.Name = "borrarRegistrosToolStripMenuItem";
            this.borrarRegistrosToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.borrarRegistrosToolStripMenuItem.Text = "Borrar Registros";
            this.borrarRegistrosToolStripMenuItem.Click += new System.EventHandler(this.borrarRegistrosToolStripMenuItem_Click);
            // 
            // historicoToolStripMenuItem
            // 
            this.historicoToolStripMenuItem.Name = "historicoToolStripMenuItem";
            this.historicoToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.historicoToolStripMenuItem.Text = "Historico";
            this.historicoToolStripMenuItem.Click += new System.EventHandler(this.historicoToolStripMenuItem_Click);
            // 
            // alquilerVigenteToolStripMenuItem
            // 
            this.alquilerVigenteToolStripMenuItem.Name = "alquilerVigenteToolStripMenuItem";
            this.alquilerVigenteToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.alquilerVigenteToolStripMenuItem.Text = "Alquiler Vigente";
            this.alquilerVigenteToolStripMenuItem.Click += new System.EventHandler(this.alquilerVigenteToolStripMenuItem_Click);
            // 
            // modificarValoresDeAlquilerToolStripMenuItem
            // 
            this.modificarValoresDeAlquilerToolStripMenuItem.Name = "modificarValoresDeAlquilerToolStripMenuItem";
            this.modificarValoresDeAlquilerToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.modificarValoresDeAlquilerToolStripMenuItem.Text = "Modificar valores de alquiler";
            this.modificarValoresDeAlquilerToolStripMenuItem.Click += new System.EventHandler(this.modificarValoresDeAlquilerToolStripMenuItem_Click);
            // 
            // verGraficosToolStripMenuItem
            // 
            this.verGraficosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asientosToolStripMenuItem,
            this.conSinChoferToolStripMenuItem});
            this.verGraficosToolStripMenuItem.Name = "verGraficosToolStripMenuItem";
            this.verGraficosToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.verGraficosToolStripMenuItem.Text = "Ver Graficos";
            this.verGraficosToolStripMenuItem.Click += new System.EventHandler(this.verGraficosToolStripMenuItem_Click);
            // 
            // asientosToolStripMenuItem
            // 
            this.asientosToolStripMenuItem.Name = "asientosToolStripMenuItem";
            this.asientosToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.asientosToolStripMenuItem.Text = "Asientos";
            this.asientosToolStripMenuItem.Click += new System.EventHandler(this.asientosToolStripMenuItem_Click);
            // 
            // conSinChoferToolStripMenuItem
            // 
            this.conSinChoferToolStripMenuItem.Name = "conSinChoferToolStripMenuItem";
            this.conSinChoferToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.conSinChoferToolStripMenuItem.Text = "Con/Sin Chofer";
            this.conSinChoferToolStripMenuItem.Click += new System.EventHandler(this.conSinChoferToolStripMenuItem_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 168);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(164, 30);
            this.button3.TabIndex = 7;
            this.button3.Text = "Ver lista de Alquileres";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 222);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(166, 35);
            this.button4.TabIndex = 8;
            this.button4.Text = "Ver Historico";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(21, 510);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(129, 26);
            this.btnSalir.TabIndex = 13;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // DGV1
            // 
            this.DGV1.AllowUserToAddRows = false;
            this.DGV1.AllowUserToResizeColumns = false;
            this.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CMARCA,
            this.CMOODELO,
            this.CCAPACIDAD,
            this.CCOMBUSTIBLE,
            this.CKMS,
            this.CDISPONIBILE,
            this.CPRECIO});
            this.DGV1.Location = new System.Drawing.Point(184, 110);
            this.DGV1.Name = "DGV1";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV1.Size = new System.Drawing.Size(747, 406);
            this.DGV1.TabIndex = 17;
            this.DGV1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV1_CellContentClick);
            this.DGV1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV1_CellContentDoubleClick);
            this.DGV1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV1_CellDoubleClick);
            // 
            // CMARCA
            // 
            this.CMARCA.HeaderText = "MARCA";
            this.CMARCA.Name = "CMARCA";
            this.CMARCA.ReadOnly = true;
            // 
            // CMOODELO
            // 
            this.CMOODELO.HeaderText = "MODELO";
            this.CMOODELO.Name = "CMOODELO";
            this.CMOODELO.ReadOnly = true;
            // 
            // CCAPACIDAD
            // 
            this.CCAPACIDAD.HeaderText = "CAPACIDAD";
            this.CCAPACIDAD.Name = "CCAPACIDAD";
            this.CCAPACIDAD.ReadOnly = true;
            // 
            // CCOMBUSTIBLE
            // 
            this.CCOMBUSTIBLE.HeaderText = "COMBUSTIBLE";
            this.CCOMBUSTIBLE.Name = "CCOMBUSTIBLE";
            this.CCOMBUSTIBLE.ReadOnly = true;
            // 
            // CKMS
            // 
            this.CKMS.HeaderText = "KMS";
            this.CKMS.Name = "CKMS";
            this.CKMS.ReadOnly = true;
            // 
            // CDISPONIBILE
            // 
            this.CDISPONIBILE.HeaderText = "DISPONIBLE";
            this.CDISPONIBILE.Name = "CDISPONIBILE";
            this.CDISPONIBILE.ReadOnly = true;
            // 
            // CPRECIO
            // 
            this.CPRECIO.HeaderText = "PRECIO";
            this.CPRECIO.Name = "CPRECIO";
            this.CPRECIO.ReadOnly = true;
            // 
            // cbChofer
            // 
            this.cbChofer.FormattingEnabled = true;
            this.cbChofer.Items.AddRange(new object[] {
            "CON CHOFER",
            "SIN CHOFER"});
            this.cbChofer.Location = new System.Drawing.Point(810, 85);
            this.cbChofer.Name = "cbChofer";
            this.cbChofer.Size = new System.Drawing.Size(121, 21);
            this.cbChofer.TabIndex = 18;
            this.cbChofer.Text = "Con/Sin";
            this.cbChofer.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // cbVehiculos
            // 
            this.cbVehiculos.FormattingEnabled = true;
            this.cbVehiculos.Items.AddRange(new object[] {
            "Marca y Modelos",
            "Capacidad",
            "Tipo de Combustible"});
            this.cbVehiculos.Location = new System.Drawing.Point(184, 83);
            this.cbVehiculos.Name = "cbVehiculos";
            this.cbVehiculos.Size = new System.Drawing.Size(121, 21);
            this.cbVehiculos.TabIndex = 14;
            this.cbVehiculos.Text = "Filtrar por";
            this.cbVehiculos.SelectedIndexChanged += new System.EventHandler(this.cbVehiculos_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(763, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Chofer:";
            // 
            // PrintTicket
            // 
            this.PrintTicket.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintTicket_PrintPage);
            // 
            // tbFiltro
            // 
            this.tbFiltro.Location = new System.Drawing.Point(311, 83);
            this.tbFiltro.Name = "tbFiltro";
            this.tbFiltro.Size = new System.Drawing.Size(121, 20);
            this.tbFiltro.TabIndex = 20;
            this.tbFiltro.TextChanged += new System.EventHandler(this.tbFiltro_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1088, 499);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1164, 58);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 23);
            this.button2.TabIndex = 23;
            this.button2.Text = "Mostrar Registros";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // printComprobante
            // 
            this.printComprobante.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printComprobante_PrintPage);
            // 
            // printPermisos
            // 
            this.printPermisos.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printPermisos_PrintPage);
            // 
            // printArchivo
            // 
            this.printArchivo.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printArchivo_PrintPage);
            // 
            // agregarUsuarioToolStripMenuItem
            // 
            this.agregarUsuarioToolStripMenuItem.Name = "agregarUsuarioToolStripMenuItem";
            this.agregarUsuarioToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.agregarUsuarioToolStripMenuItem.Text = "Agregar Usuario";
            this.agregarUsuarioToolStripMenuItem.Click += new System.EventHandler(this.agregarUsuarioToolStripMenuItem_Click);
            // 
            // pblogo
            // 
            this.pblogo.Location = new System.Drawing.Point(0, 30);
            this.pblogo.Name = "pblogo";
            this.pblogo.Size = new System.Drawing.Size(178, 132);
            this.pblogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pblogo.TabIndex = 22;
            this.pblogo.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(938, 110);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(423, 308);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1373, 548);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pblogo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbFiltro);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbChofer);
            this.Controls.Add(this.DGV1);
            this.Controls.Add(this.cbVehiculos);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ALQUILAUTO 1.0";
            this.TransparencyKey = System.Drawing.SystemColors.ActiveBorder;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pblogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menúToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrarRegistrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarValoresDeAlquilerToolStripMenuItem;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem conChoferToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sinChoferToolStripMenuItem;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView DGV1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CMARCA;
        private System.Windows.Forms.DataGridViewTextBoxColumn CMOODELO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCAPACIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCOMBUSTIBLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CKMS;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDISPONIBILE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPRECIO;
        public System.Windows.Forms.ComboBox cbChofer;
        public System.Windows.Forms.ComboBox cbVehiculos;
        private System.Windows.Forms.Label label1;
        private System.Drawing.Printing.PrintDocument PrintTicket;
        private System.Windows.Forms.TextBox tbFiltro;
        private System.Windows.Forms.ToolStripMenuItem modificarDatosDeVehiculoToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pblogo;
        private System.Windows.Forms.Button button2;
        private System.Drawing.Printing.PrintDocument printComprobante;
        private System.Drawing.Printing.PrintDocument printPermisos;
        private System.Windows.Forms.ToolStripMenuItem eliminarVehiculoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verGraficosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asientosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conSinChoferToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historicoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alquilerVigenteToolStripMenuItem;
        private System.Drawing.Printing.PrintDocument printArchivo;
        private System.Windows.Forms.ToolStripMenuItem agregarUsuarioToolStripMenuItem;
    }
}

