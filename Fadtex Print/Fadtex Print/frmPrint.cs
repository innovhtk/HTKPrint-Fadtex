using HTKRestClient;
using NiceEngine5WR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Fadtex_Print
{
    public partial class frmPrint : Form
    {
        public frmPrint()
        {
            InitializeComponent();
        }
        public NiceLabel LabelIntf;
        public string LabelFileNameBMP;
        public string ActualLabelFileName;
        public string PreviewFileName;
        public bool Result;

        const string csFormCaption = "LabelBrowser";
        const string csConnected = "Connected";
        const string csNotConnected = "Not connected";

        public bool SQLConnected = false;

        public string ConectionString { get { return String.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", Server, DataBase, User, Pass); } }
        public string Server { get { return tbServidor.Text; } }
        public string Table { get { return tbTabla.Text; } }
        public string DataBase { get { return tbBD.Text; } }
        public string User { get { return tbUsuario.Text; } }
        public string Pass { get { return tbContrasena.Text; } }
        public List<string> Columnas = new List<string>();
        public List<string> Valores = new List<string>();
        public string dataFile = "server_data.conf";
        public string licenceFile = "fadtex.conf";
        public SqlConnection SQL = null;

        public NiceApp nice;
        private void Form1_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (!RevisarLicencia())
            {
                if (ConteoSinLicencia() > 5)
                {
                    MessageBox.Show("No se pudo validar la licencia");
                    this.Close();
                    Application.Exit();
                }

            }
            nice = new NiceEngine5WR.NiceApp();
            LeerDatosDeServer();
            InicializarSQL();
            Cursor.Current = Cursors.Default;
        }

        private bool RevisarLicencia()
        {
            RestClient client = new RestClient(@"http://webservice.assetsapp.com/mobile/api/License?client=fadtex", HttpVerb.GET);
            var respuesta = client.MakeRequest();
            bool licenciaValida = false;
            try
            {
                licenciaValida = respuesta.ToLower().Contains("true");
                if (licenciaValida)
                {
                    if (File.Exists(licenceFile))
                    {
                        using (StreamWriter writer = new StreamWriter(licenceFile))
                        {
                            writer.Write("0");
                        }
                    }
                }

            }
            catch (Exception) { }
            return licenciaValida;
        }
        private int ConteoSinLicencia()
        {
            int conteo = 0;
            if (!File.Exists(licenceFile))
            {
                using (StreamWriter writer = new StreamWriter(licenceFile))
                {
                    writer.Write("0");
                }
            }
            else
            {
                try
                {
                    using (StreamReader reader = new StreamReader(licenceFile))
                    {
                        var lineaDatos = reader.ReadToEnd();
                        var datos = lineaDatos.Replace("\r\n", "");
                        try
                        {
                            conteo = Convert.ToInt32(datos);
                        }
                        catch (Exception)
                        {
                            conteo = 6;
                        }
                    }
                    conteo++;
                    using (StreamWriter write = new StreamWriter(licenceFile))
                    {
                        write.Write(conteo);
                    }
                }
                catch (Exception)
                {
                    return 0;
                }
            }
            return conteo;
        }
        private void LeerDatosDeServer()
        {
            if (!File.Exists(dataFile))
            {
                using (StreamWriter writer = new StreamWriter(dataFile))
                {
                    writer.Write("");
                }
            }
            else
            {
                try
                {
                    using (StreamReader reader = new StreamReader(dataFile))
                    {
                        var lineaDatos = reader.ReadToEnd();
                        var datos = lineaDatos.Replace("\r\n", "").Split('|');
                        if (datos.Length == 5)
                        {
                            tbServidor.Text = datos[0];
                            tbBD.Text = datos[1];
                            tbTabla.Text = datos[2];
                            tbUsuario.Text = datos[3];
                            tbContrasena.Text = datos[4];
                        }
                    }
                }
                catch (Exception)
                {
                }

            }
        }
        public string Query(string table, string columns, string values)
        {
            return String.Format("INSERT INTO {0} ({1}) VALUES({2})", table, columns, values);
        }
        public void InsertSQL(List<string> columns, List<string> values)
        {
            if (!SQLConnected)
                return;

            for (int i = 0; i < columns.Count; i++)
            {
                if (columns[i].ToLower() == "length" || columns[i].ToLower() == "metros" || columns[i].ToLower() == "metros2")
                    continue;
                values[i] = "\'" + values[i] + "\'";
            }

            string cols = string.Join(",", columns);
            string vals = string.Join(",", values);

            string query = Query(Table, cols, vals);
            try
            {
                using (SqlConnection connection = new SqlConnection(ConectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }


        }
        private DataTable GetTable(string LabelFileName)
        {
            DataTable table = new DataTable();
            List<string> variables = new List<string>();
            for (int i = 0; i < LabelIntf.Variables.Count; i++)
            {
                try
                {
                    if (LabelIntf.Variables.Item(i).Name.ToString() == "EPC")
                        continue;
                    table.Columns.Add(LabelIntf.Variables.Item(i).Name, typeof(string));
                }
                catch (Exception) { }
            }
            table.Columns.Add("Cantidad", typeof(string));

            return table;
        }

        private void OpenLabel(string LabelFileName)
        {
            CloseLabel();
            LabelIntf = nice.LabelOpenEx(LabelFileName);
            LabelFileNameBMP = LabelFileName.Replace(".lbl", ".bmp");
            if (File.Exists(LabelFileNameBMP))
            {
                File.Delete(LabelFileNameBMP);
            }
            for (int i = 0; i < LabelIntf.Variables.Count; i++)
            {
                var Var = (NiceEngine5WR.WRVar)LabelIntf.Variables.Item(i);
                if (!(Var == null))
                {
                    if (LabelIntf.Variables.Item(i).Name.ToString() == "EPC")
                    {
                        Var.SetValue(new string('0', 24));
                    }
                    else
                    {
                        Var.SetValue(LabelIntf.Variables.Item(i).Name);
                    }
                }
            }
            if (LabelIntf.GetLabelPreview(LabelFileNameBMP, 500, 250))
            {
                Picture.Image = Image.FromFile(LabelFileNameBMP);
                Picture.Visible = true;
                DataTable data = GetTable(LabelFileName);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = data;
                ActualLabelFileName = LabelFileName;
                btPrint.Enabled = true;
                cbPrinters.Visible = true;
                lbPrinter.Visible = true;
                string printers = LabelIntf.GetPrintersList();
                foreach (var item in printers.Split(','))
                {
                    cbPrinters.Items.Add(item.Replace("\"", ""));
                }
                if (cbPrinters.Items.Count > 0)
                {
                    cbPrinters.Text = cbPrinters.Items[0].ToString();
                    for (int i = cbPrinters.Items.Count - 1; i > 0; i--)
                    {
                        if (cbPrinters.Items[i].ToString().ToLower().Contains("zdesigner"))
                        {
                            cbPrinters.Text = cbPrinters.Items[i].ToString();
                            break;
                        }
                    }
                    LabelIntf.PrinterName = cbPrinters.Text;
                }
                else
                {
                    btPrint.Enabled = false;
                }

            }
            else
            {
                Picture.Visible = false;
                btPrint.Enabled = false;
                cbPrinters.Visible = false;
                lbPrinter.Visible = false;
            }
        }


        private void Reload()
        {
            CloseLabel();
            LabelIntf = nice.LabelOpenEx(ActualLabelFileName);
            LabelFileNameBMP = ActualLabelFileName.Replace(".lbl", ".bmp");
            if (File.Exists(LabelFileNameBMP))
            {
                File.Delete(LabelFileNameBMP);
            }
            if (LabelIntf.GetLabelPreview(LabelFileNameBMP, 500, 250))
            {
                Picture.Image = Image.FromFile(LabelFileNameBMP);
                Picture.Visible = true;
                DataTable data = GetTable(ActualLabelFileName);
                dataGridView1.DataSource = data;
                cbPrinters.Visible = true;
                lbPrinter.Visible = true;
                btPrint.Visible = true;
            }
            else
            {
                Picture.Visible = false;
                cbPrinters.Visible = false;
                lbPrinter.Visible = false;
                btPrint.Visible = false;
            }
        }


        private void CloseLabel()
        {
            if (LabelIntf != null)
            {
                LabelIntf.Free();
                LabelIntf = null;
                Picture.Image.Dispose();
                Picture.Visible = false;
            }
        }

        private void btOpen_Click(object sender, EventArgs e)
        {
            try
            {
                LabelIntf.Free();
                LabelIntf = null;
            }
            catch (Exception)
            {
            }

            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "archivos lbl (*.lbl)| *.lbl";
            openFileDialog1.Title = "Selecciona una etiqueta";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (openFileDialog1.FileName != "")
                {
                    this.Cursor = Cursors.WaitCursor;
                    tbFileName.Text = openFileDialog1.FileName;
                    OpenLabel(openFileDialog1.FileName);
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            LabelIntf.PrinterName = PrinterName;
            int total = dataGridView1.Rows.Count;
            int send = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Columnas = new List<string>();
                Valores = new List<string>();
                for (int i = 0; i < dataGridView1.Columns.Count - 1; i++)
                {

                    string nombredevariable = dataGridView1.Columns[i].Name;
                    var Var = LabelIntf.Variables.FindByName(nombredevariable);
                    for (int k = 0; k < 4; k++)
                    {
                        Var = LabelIntf.Variables.FindByName(nombredevariable);
                    }
                    //var Var = (NiceEngine5WR.WRVar)LabelIntf.Variables.Item(i);
                    //for (int j = 0; j < 3; j++)
                    //{
                    //    Var = (NiceEngine5WR.WRVar)LabelIntf.Variables.Item(j);
                    //}
                    var nombre = Var.Name;
                    if (nombre.ToLower() == "metros") nombre = "Length";
                    if (nombre.ToLower() == "nombre") nombre = "ItemName";
                    if (nombre.ToLower() == "color") nombre = "ItemColor";
                    if (nombre.ToLower() == "codigo") nombre = "CodeBars";
                    Columnas.Add(nombre);
                    try
                    {
                        if (!(Var == null))
                        {
                            if (row.Cells[i].Value != null)
                            {
                                var valor = row.Cells[i].Value.ToString();
                                Var.SetValue(valor);
                                Valores.Add(valor);
                            }
                            else
                            {
                                Var.SetValue("");
                                Valores.Add("");
                            }
                        }

                    }
                    catch (Exception)
                    {
                        continue;
                    }

                }
                try
                {
                    int nulos = 0;
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        if (row.Cells[0].Value == null)
                        {
                            nulos++;
                        }
                    }
                    if (nulos == dataGridView1.Columns.Count)
                    {
                        continue;
                    }


                    string strcantidad = row.Cells[dataGridView1.Columns.Count - 1].Value.ToString();
                    int cantidad = Convert.ToInt32(strcantidad);
                    for (int i = 0; i < cantidad; i++)
                    {
                        string datestring = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                        string prefix = "FAD" + datestring;
                        string epc = prefix + new string('0', 24 - prefix.Length - i.ToString().Length) + (i + 1).ToString();
                        //MessageBox.Show(epc);
                        var Var = (NiceEngine5WR.WRVar)LabelIntf.Variables.FindByName("EPC");
                        try
                        {
                            if (!(Var == null))
                            {
                                Var.SetValue(epc);
                            }
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                        try
                        {

                            int indice = 0;
                            NiceEngine5WR.WRVar VarMetros = null;
                            if (Columnas.Find(x => x == "Metros") != null)
                            {
                                VarMetros = (NiceEngine5WR.WRVar)LabelIntf.Variables.FindByName("Metros");
                                if (!(VarMetros == null))
                                {
                                    indice = Columnas.IndexOf("Metros");
                                    VarMetros.SetValue(Valores[indice]);
                                }
                            }
                            if (Columnas.Find(x => x == "Metros2") != null)
                            {
                                VarMetros = (NiceEngine5WR.WRVar)LabelIntf.Variables.FindByName("Metros2");
                                if (!(VarMetros == null))
                                {
                                    indice = Columnas.IndexOf("Metros2");
                                    VarMetros.SetValue(Valores[indice]);
                                }
                            }
                            if (Columnas.Find(x => x == "Longitud") != null)
                            {
                                VarMetros = (NiceEngine5WR.WRVar)LabelIntf.Variables.FindByName("Longitud");
                                if (!(VarMetros == null))
                                {
                                    indice = Columnas.IndexOf("Longitud");
                                    VarMetros.SetValue(Valores[indice]);
                                }
                            }
                            if (Columnas.Find(x => x == "Length") != null)
                            {
                                VarMetros = (NiceEngine5WR.WRVar)LabelIntf.Variables.FindByName("Length");
                                if (!(VarMetros == null))
                                {
                                    indice = Columnas.IndexOf("Lenght");
                                    VarMetros.SetValue(Valores[indice]);
                                }
                            }

                        }
                        catch (Exception)
                        {
                        }
                        if (Columnas.Find(x => x == "EPC") != null)
                        {
                            Valores[Columnas.IndexOf("EPC")] = epc;
                        }
                        else
                        {
                            Columnas.Add("EPC");
                            Valores.Add(epc);
                        }
                        if (LabelIntf.Print("1"))
                        {
                            send++;
                            InsertSQL(Columnas, Valores);
                        }

                    }
                    //MessageBox.Show("Se imprimieron " + send.ToString() + " de " + cantidad.ToString() + " etiquetas");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al ingresar los datos en fila " + (row.Index + 1).ToString());
                }

            }
        }





        public string PrinterName { get; set; }

        private void cbPrinters_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LabelIntf.PrinterName = cbPrinters.Text;
            }
            catch (Exception)
            {
            }
        }

        private void frmPrint_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseLabel();
        }

        private void configurarServidorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void GuardarServidor_Click(object sender, EventArgs e)
        {
            if (!File.Exists(dataFile))
            {
                try
                {

                    File.Create(dataFile);
                    SaveData();
                }
                catch (Exception)
                {

                    throw;
                }

            }
            else
            {
                SaveData();
            }
            panel1.Visible = false;

        }
        public void SaveData()
        {
            string data = "";
            data =
              tbServidor.Text + "|"
            + tbBD.Text + "|"
            + tbTabla.Text + "|"
            + tbUsuario.Text + "|"
            + tbContrasena.Text;
            using (StreamWriter writer = new StreamWriter(dataFile))
            {
                writer.WriteLine(data);
            }
        }
        private void btConectarSQL_Click(object sender, EventArgs e)
        {
            InicializarSQL();
        }
        public void InicializarSQL()
        {
            if (SQL != null)
            {
                try
                {
                    SQL.Close();
                    SQL.Dispose();
                }
                catch (Exception) { }

            }
            SQL = null;
            if (Server == "" || Table == "" || User == "" || Pass == "")
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Por favor ingrese todos los datos de la conexión al servidor");
                return;
            }
            SQL = new SqlConnection(ConectionString);
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                SQL.Open();
                SQL.Close();
                SQLConnected = true;
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Conectado correctamente.");

            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("No se pudo establecer la conexión a la base de datos.");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }

}
