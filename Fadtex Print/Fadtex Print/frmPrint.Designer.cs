namespace Fadtex_Print
{
    partial class frmPrint
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrint));
            this.Picture = new System.Windows.Forms.PictureBox();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.btOpen = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btPrint = new System.Windows.Forms.Button();
            this.cbPrinters = new System.Windows.Forms.ComboBox();
            this.lbPrinter = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configurarServidorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.tbBD = new System.Windows.Forms.TextBox();
            this.btConectarSQL = new System.Windows.Forms.Button();
            this.btGuardarServidor = new System.Windows.Forms.Button();
            this.tbContrasena = new System.Windows.Forms.TextBox();
            this.tbUsuario = new System.Windows.Forms.TextBox();
            this.tbTabla = new System.Windows.Forms.TextBox();
            this.tbServidor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Picture
            // 
            this.Picture.Location = new System.Drawing.Point(61, 132);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(500, 250);
            this.Picture.TabIndex = 0;
            this.Picture.TabStop = false;
            this.Picture.Visible = false;
            // 
            // tbFileName
            // 
            this.tbFileName.Enabled = false;
            this.tbFileName.Location = new System.Drawing.Point(105, 55);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(508, 20);
            this.tbFileName.TabIndex = 1;
            this.tbFileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btOpen
            // 
            this.btOpen.Location = new System.Drawing.Point(2, 55);
            this.btOpen.Name = "btOpen";
            this.btOpen.Size = new System.Drawing.Size(97, 20);
            this.btOpen.TabIndex = 2;
            this.btOpen.Text = "Abrir etiqueta";
            this.btOpen.UseVisualStyleBackColor = true;
            this.btOpen.Click += new System.EventHandler(this.btOpen_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(2, 388);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(611, 188);
            this.dataGridView1.TabIndex = 3;
            // 
            // btPrint
            // 
            this.btPrint.Enabled = false;
            this.btPrint.Location = new System.Drawing.Point(476, 582);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(137, 36);
            this.btPrint.TabIndex = 4;
            this.btPrint.Text = "Imprimir";
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // cbPrinters
            // 
            this.cbPrinters.FormattingEnabled = true;
            this.cbPrinters.Location = new System.Drawing.Point(105, 96);
            this.cbPrinters.Name = "cbPrinters";
            this.cbPrinters.Size = new System.Drawing.Size(265, 21);
            this.cbPrinters.TabIndex = 5;
            this.cbPrinters.Visible = false;
            this.cbPrinters.SelectedIndexChanged += new System.EventHandler(this.cbPrinters_SelectedIndexChanged);
            // 
            // lbPrinter
            // 
            this.lbPrinter.AutoSize = true;
            this.lbPrinter.Location = new System.Drawing.Point(43, 99);
            this.lbPrinter.Name = "lbPrinter";
            this.lbPrinter.Size = new System.Drawing.Size(56, 13);
            this.lbPrinter.TabIndex = 6;
            this.lbPrinter.Text = "Impresora:";
            this.lbPrinter.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configurarServidorToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(618, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configurarServidorToolStripMenuItem
            // 
            this.configurarServidorToolStripMenuItem.Name = "configurarServidorToolStripMenuItem";
            this.configurarServidorToolStripMenuItem.Size = new System.Drawing.Size(122, 20);
            this.configurarServidorToolStripMenuItem.Text = "Configurar Servidor";
            this.configurarServidorToolStripMenuItem.Click += new System.EventHandler(this.configurarServidorToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tbBD);
            this.panel1.Controls.Add(this.btConectarSQL);
            this.panel1.Controls.Add(this.btGuardarServidor);
            this.panel1.Controls.Add(this.tbContrasena);
            this.panel1.Controls.Add(this.tbUsuario);
            this.panel1.Controls.Add(this.tbTabla);
            this.panel1.Controls.Add(this.tbServidor);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(611, 117);
            this.panel1.TabIndex = 8;
            this.panel1.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Base de datos:";
            // 
            // tbBD
            // 
            this.tbBD.Location = new System.Drawing.Point(90, 26);
            this.tbBD.Name = "tbBD";
            this.tbBD.Size = new System.Drawing.Size(377, 20);
            this.tbBD.TabIndex = 5;
            // 
            // btConectarSQL
            // 
            this.btConectarSQL.Location = new System.Drawing.Point(474, 14);
            this.btConectarSQL.Name = "btConectarSQL";
            this.btConectarSQL.Size = new System.Drawing.Size(130, 43);
            this.btConectarSQL.TabIndex = 9;
            this.btConectarSQL.Text = "Conectar";
            this.btConectarSQL.UseVisualStyleBackColor = true;
            this.btConectarSQL.Click += new System.EventHandler(this.btConectarSQL_Click);
            // 
            // btGuardarServidor
            // 
            this.btGuardarServidor.Location = new System.Drawing.Point(473, 66);
            this.btGuardarServidor.Name = "btGuardarServidor";
            this.btGuardarServidor.Size = new System.Drawing.Size(130, 42);
            this.btGuardarServidor.TabIndex = 10;
            this.btGuardarServidor.Text = "Guardar";
            this.btGuardarServidor.UseVisualStyleBackColor = true;
            this.btGuardarServidor.Click += new System.EventHandler(this.GuardarServidor_Click);
            // 
            // tbContrasena
            // 
            this.tbContrasena.Location = new System.Drawing.Point(90, 92);
            this.tbContrasena.Name = "tbContrasena";
            this.tbContrasena.Size = new System.Drawing.Size(377, 20);
            this.tbContrasena.TabIndex = 8;
            // 
            // tbUsuario
            // 
            this.tbUsuario.Location = new System.Drawing.Point(90, 70);
            this.tbUsuario.Name = "tbUsuario";
            this.tbUsuario.Size = new System.Drawing.Size(377, 20);
            this.tbUsuario.TabIndex = 7;
            // 
            // tbTabla
            // 
            this.tbTabla.Location = new System.Drawing.Point(90, 48);
            this.tbTabla.Name = "tbTabla";
            this.tbTabla.Size = new System.Drawing.Size(377, 20);
            this.tbTabla.TabIndex = 6;
            // 
            // tbServidor
            // 
            this.tbServidor.Location = new System.Drawing.Point(90, 3);
            this.tbServidor.Name = "tbServidor";
            this.tbServidor.Size = new System.Drawing.Size(377, 20);
            this.tbServidor.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tabla:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Contraseña:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Usuario:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Servidor:";
            // 
            // frmPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 628);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btOpen);
            this.Controls.Add(this.tbFileName);
            this.Controls.Add(this.Picture);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lbPrinter);
            this.Controls.Add(this.cbPrinters);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrint";
            this.Text = "Impresión RFID";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrint_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Picture;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.Button btOpen;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btPrint;
        private System.Windows.Forms.ComboBox cbPrinters;
        private System.Windows.Forms.Label lbPrinter;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configurarServidorToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btGuardarServidor;
        private System.Windows.Forms.TextBox tbContrasena;
        private System.Windows.Forms.TextBox tbUsuario;
        private System.Windows.Forms.TextBox tbTabla;
        private System.Windows.Forms.TextBox tbServidor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btConectarSQL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbBD;
    }
}

