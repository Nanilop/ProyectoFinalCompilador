//using Grpc.Core;
using Compilador.CompiladoresDataSet1TableAdapters;
using Compilador.CompiladoresDataSetTableAdapters;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Presentation;
//using Microsoft.Graph.Models;
//using Compilador.CompiladoresDataSetTableAdapters;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsultaReporteLogsTableAdapter = Compilador.CompiladoresDataSet1TableAdapters.ConsultaReporteLogsTableAdapter;
using Path = System.IO.Path;
//using static System.Net.Mime.MediaTypeNames;

namespace Compilador
{
    public partial class Form1 : Form
    {
        private String token;
        private int estado = 0;
        private int posicion = 0;
        private object[,] Matriz = new object[50, 50];
        private bool PR = false;
        private int Direc = 0;
        private int DirPR = 0;
        private String caracter;
        private bool errores;
        private OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
        private object[] VectorPalabrasReservadas;
        private bool verContr = false;
        private bool verContrN = false;
        private bool verContrCon = false;
        private bool? poder;
        private string preser;
        private string matz;
        private int? u;
        public Form1()
        {
            // Esta llamada es exigida por el diseñador.
            InitializeComponent();
            this.usuarioTableAdapter.Fill(this.compiladoresDataSet1.Usuario);
            // TODO: esta línea de código carga datos en la tabla 'compiladoresDataSet1.Lenguaje' Puede moverla o quitarla según sea necesario.
            this.lenguajeTableAdapter.Fill(this.compiladoresDataSet1.Lenguaje);
            OpenFileDialog1 = new OpenFileDialog();
            //LeeMatrizEstados("C:\\Users\\LOPEZ\\Desktop\\López Rodríguez Daniela\\8vo semestre\\BlocMatrizCobolt.csv");
            btnExportar.Image = Image.FromFile("file_export_icon_138621.png");
            VerContraseña.Image = Image.FromFile("eye_show_regular_icon_203603.png");
            btnVerContraNueva.Image = Image.FromFile("eye_show_regular_icon_203603.png");
            btnVerConfirmar.Image = Image.FromFile("eye_show_regular_icon_203603.png");
            DGVSalida.Columns.Add("Token", "Token");
            DGVSalida.Columns.Add("Tipo", "Tipo");
            DGVSalida.Columns.Add("Directorio", "Directorio");
        }
        private void btnCarga_Click(object sender, EventArgs e)
        {
            btnExportar.Enabled = true;
            btnCompila.Enabled = true;
            lbEnter.Items.Clear();
            DGVSalida.Rows.Clear();
            lbIden.Items.Clear();
            lbStr.Items.Clear();
            lbReal.Items.Clear();
            lbEntra.Items.Clear();
            string archivo;
            if (OpenFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            //Abre el explorador de archivos

            archivo = OpenFileDialog1.FileName;//Obtiene Nombre del archivo

            System.IO.StreamReader read = new StreamReader(archivo); //Lector de archivos
            //read = My.Computer.FileSystem.OpenTextFileReader(archivo); //Abre el archivo
            String StringRead;

            while (!(read.EndOfStream))
            {//Mientras no se acabe de leer el archivo
                StringRead = read.ReadLine();//Lee una linea
                                             //MsgBox(StringRead)
                lbEntra.Items.Add(StringRead); //Agrega la linea al Listbox
            }

        }
        private void BuscaPalabraReservada()
        {
            int linea = 0;
            String palres;
            while (linea < VectorPalabrasReservadas.Length)
            {
                palres = VectorPalabrasReservadas[linea].ToString();

                if (palres.ToUpper() == token.ToUpper()) {
                    PR = true;
                    DirPR = linea + 1;
                }
                linea += 1;
            }

        }
        private void BuscaUnicas(System.Windows.Forms.ListBox txtU) {
            bool encontro;
            int renglon2;
            encontro = false; //false - No la a encontrado, Verdadero - Ya la encontro
            renglon2 = 0;
            //'*-
            //'while (verdadera)  and (verdadera)
            while ((!encontro) && (renglon2 < txtU.Items.Count)) {
                txtU.SelectedIndex = renglon2;
                if (token.ToUpper() == txtU.Text.ToUpper()) { //'compara las varables en modo mayusculas
                    encontro = true;
                    Direc = renglon2 + 1;
                }
                renglon2 = renglon2 + 1;
            }
            if (!encontro) {
                txtU.Items.Add(token);
                Direc = renglon2 + 1;
            }
        }
        private void ReconoceToken() {
            if (estado == 100)
            {
                errores = false;
                token = token + caracter;
                BuscaUnicas(lbStr);
                DGVSalida.Rows.Add(token, "Cte. String", Direc.ToString());
            }
            else if (estado == 101)
            {
                errores = false;
                token = token + caracter;
                DGVSalida.Rows.Add(token, " Comentario ", "");
            }
            else if (estado == 102)
            {
                errores = false;
                token = token + caracter;
                DGVSalida.Rows.Add(token, " C. Especial ", "");
            }
            else if (estado == 103)
            {
                errores = false;
                token = token + caracter;
                DGVSalida.Rows.Add(token, " C. Especial ", "");
            }
            else if (estado == 104)
            {
                errores = false;
                token = token + caracter;
                DGVSalida.Rows.Add(token, " C. Especial ", "");
            }
            else if (estado == 105)
            {
                errores = false;
                token = token + caracter;
                DGVSalida.Rows.Add(token, " C. Especial ", "");
            }
            else if (estado == 106)
            {
                errores = false;
                token = token + caracter;
                DGVSalida.Rows.Add(token, " C. Especial ", "");
            }
            else if (estado == 107)
            {
                errores = false;
                token = token + caracter;
                DGVSalida.Rows.Add(token, " C. Especial ", "");
            }
            else if (estado == 108)
            {
                errores = false;
                DGVSalida.Rows.Add(token, " C. Especial ", "");
                posicion = posicion - 1;
            }
            else if (estado == 109)
            {
                errores = false;
                DGVSalida.Rows.Add(token, " C. Especial ", "");
                posicion = posicion - 1;
            }
            else if (estado == 110)
            {
                errores = false;
                token = token + caracter;
                DGVSalida.Rows.Add(token, " C. Especial ", "");
            }
            else if (estado == 111)
            {
                errores = false;
                token = token + caracter;
                DGVSalida.Rows.Add(token, " C. Especial ", "");
            }
            else if (estado == 112)
            {
                errores = false;
                token = token + caracter;
                DGVSalida.Rows.Add(token, " C. Especial ", "");
            }
            else if (estado == 113)
            {
                errores = false;
                token = token + caracter;
                DGVSalida.Rows.Add(token, " C. Especial ", "");
            }
            else if (estado == 114)
            {
                errores = false;
                token = token + caracter;
                DGVSalida.Rows.Add(token, " C. Especial ", "");
            }
            else if (estado == 115)
            {
                errores = false;
                token = token + caracter;
                DGVSalida.Rows.Add(token, " C. Especial ", "");
            }
            else if (estado == 116)
            {
                errores = false;
                token = token + caracter;
                DGVSalida.Rows.Add(token, " C. Especial ", "");
            }
            else if (estado == 117)
            {
                errores = false;
                token = token + caracter;
                DGVSalida.Rows.Add(token, " C. Especial ", "");
            }
            else if (estado == 118)
            {
                errores = false;
                token = token + caracter;
                DGVSalida.Rows.Add(token, " C. Especial ", "");
            }
            else if (estado == 119)
            {
                errores = false;
                DGVSalida.Rows.Add(token, " C. Especial ", "");
                posicion = posicion - 1;
            }
            else if (estado == 120)
            {
                errores = false;
                token = token + caracter;
                DGVSalida.Rows.Add(token, " C. Especial ", "");
            }
            else if (estado == 121)
            {
                errores = false;
                token = token + caracter;
                DGVSalida.Rows.Add(token, " C. Especial ", "");
            }
            else if (estado == 122)
            {
                errores = false;
                DGVSalida.Rows.Add(token, " C. Especial ", "");
                posicion = posicion - 1;
            }
            else if (estado == 123)
            {
                errores = false;
                token = token + caracter;
                DGVSalida.Rows.Add(token, " C. Especial ", "");
            }
            else if (estado == 124)
            {
                errores = false;
                BuscaUnicas(lbReal);
                DGVSalida.Rows.Add(token, " Cte. Real ", Direc.ToString());
                posicion = posicion - 1;
            }
            else if (estado == 125)
            {
                errores = false;
                BuscaUnicas(lbEnter);
                DGVSalida.Rows.Add(token, " Cte. Entera ", Direc.ToString());
                posicion = posicion - 1;
            }
            else if (estado == 126)
            {
                errores = false;
                posicion = posicion - 1;
                PR = false;
                BuscaPalabraReservada();
                if (PR == false)
                {
                    //No es palabra reservada
                    BuscaUnicas(lbIden);
                    DGVSalida.Rows.Add(token, "Ident.", Direc.ToString());
                }
                else
                {
                    //Es palabra reservada
                    DGVSalida.Rows.Add(token, " PR. ", DirPR.ToString());
                }
            }
            else if (estado == 300)
            {
                errores = true;
                DGVSalida.Rows.Clear();
                MessageBox.Show("Expresión lógica erronea, se esperaba un &.");
            }
            else if (estado == 301)
            {
                errores = true;
                DGVSalida.Rows.Clear();
                MessageBox.Show("Identificador invalido, no puede iniciar con guión bajo.");
            }
            else if (estado == 302)
            {
                errores = true;
                DGVSalida.Rows.Clear();
                MessageBox.Show("Identificador invalido, puede iniciar solamente con una letra.");
            }
            else if (estado == 303)
            {
                errores = true;
                DGVSalida.Rows.Clear();
                MessageBox.Show("Expresión lógica invalida, se esperaba |.");
            }
            else if (estado == 304)
            {
                errores = true;
                DGVSalida.Rows.Clear();
                MessageBox.Show("Expresión lógica invalida, se esperaba =.");
            }
            else if (estado == 305)
            {
                errores = true;
                DGVSalida.Rows.Clear();
                MessageBox.Show("Identificador invalido, no puede iniciar con punto.");
            }
            else if (estado == 306)
            {
                errores = true;
                DGVSalida.Rows.Clear();
                MessageBox.Show("Identificador invalido, no puede terminar en guión bajo.");
            }
            }
        private void btnExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialogoGuardar = new SaveFileDialog();
            dialogoGuardar.Filter = "Archivos de texto (*.txt)|*.txt|Archivo de valores separados por comas de Microsoft Excel (*.csv)|*.csv|Hoja de cálculo de Microsoft Excel (*.xlsx)|*.xlsx";
            if (dialogoGuardar.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            if (dialogoGuardar.FilterIndex == 3) {
                Microsoft.Office.Interop.Excel.Application aplicacion;
                Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                aplicacion = new Microsoft.Office.Interop.Excel.Application();
                libros_trabajo = aplicacion.Workbooks.Add();
                hoja_trabajo =(Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
                //Recorremos el DataGridView rellenando la hoja de trabajo
                int a = 2;
                hoja_trabajo.Cells[1, 1] = "Nombre";
                hoja_trabajo.Cells[1, 2] = "Usuario";
                hoja_trabajo.Cells[1, 3] = "Lenguaje";
                hoja_trabajo.Cells[1, 4] = "Archivo";
                hoja_trabajo.Cells[1, 5] = "Fecha_Hora";
                foreach (DataGridViewRow Fila in DGVReporte.Rows)
                {
                    if (Fila.Cells[0].Value != null)
                    {
                        hoja_trabajo.Cells[a, 1] = Fila.Cells[0].Value.ToString();
                        hoja_trabajo.Cells[a, 2] = Fila.Cells[1].Value.ToString();
                        hoja_trabajo.Cells[a, 3] = Fila.Cells[2].Value.ToString();
                        hoja_trabajo.Cells[a, 4] = Fila.Cells[3].Value.ToString();
                        hoja_trabajo.Cells[a, 5] = Fila.Cells[4].Value.ToString();
                        a++;
                    }
                }
                libros_trabajo.SaveAs(dialogoGuardar.FileName);
                libros_trabajo.Close(true);
                aplicacion.Quit();
                ////////Workbook wb = new Workbook();
                ////////// Agregue una nueva hoja de cálculo al objeto de Excel.
                ////////// Obtenga la referencia de la hoja de trabajo recién agregada pasando su índice de hoja.
                ////////Worksheet worksheet = wb.Worksheets[0];
                ////////int a = 2;
                ////////worksheet.Cells["A1"].PutValue( "Token");
                ////////worksheet.Cells["B1"].PutValue("Tipo");
                ////////worksheet.Cells["C1"].PutValue("Directorio");
                ////////// Agregue valores ficticios a las celdas.
                ////////foreach (DataGridViewRow Fila in DGVSalida.Rows)
                ////////{
                ////////    if (Fila.Cells["Token"].Value != null)
                ////////    {
                ////////        worksheet.Cells["A"+a.ToString()].PutValue(Fila.Cells["Token"].Value.ToString());
                ////////        worksheet.Cells["B" + a.ToString()].PutValue(Fila.Cells["Tipo"].Value.ToString());
                ////////        worksheet.Cells["C" + a.ToString()].PutValue(Fila.Cells["Directorio"].Value.ToString());
                ////////        a++;
                ////////    }
                ////////}
                ////////wb.Save(dialogoGuardar.FileName, SaveFormat.Xlsx);
            }
            else
            {
                String archivo = dialogoGuardar.FileName;
                StreamWriter sw = new StreamWriter(archivo);
                if (DGVReporte.Rows.Count > 0)
                {
                    foreach (DataGridViewRow Fila in DGVReporte.Rows)
                    {
                        if (Fila.Cells[0].Value != null)
                        {
                            sw.WriteLine(Fila.Cells[0].Value.ToString() + ", " + Fila.Cells[1].Value.ToString() + ", " + Fila.Cells[2].Value.ToString() + ", " + Fila.Cells[3].Value.ToString() + ", " + Fila.Cells[4].Value.ToString());
                        }
                    }
                }
                sw.Close();
            }
        }
        private void btnCompila_Click(object sender, EventArgs e)
        {
            btnExportar.Enabled = true;
            lbEnter.Items.Clear();
            DGVSalida.Rows.Clear();
            lbIden.Items.Clear();
            lbStr.Items.Clear();
            lbReal.Items.Clear();
            token = "";
            estado = 0;
            posicion = 1;
            var renglon = 0;
            string items;
            string str = Console.ReadLine();
            int exporta = 0;
            while ((renglon < lbEntra.Items.Count))
            {
                lbEntra.SelectedIndex = renglon;
                items = lbEntra.SelectedItem.ToString();
                var longitud = Strings.Len(items);
                posicion = 1;
                while ((posicion <= longitud))
                {
                    caracter = Strings.Mid(items, posicion, 1); // MID - Regresa una cadena de caracteres a partir de la posicion, 1 caracter
                    estado = Convert.ToInt32(Matriz[estado, Columnas(caracter)]);
                    if (estado >= 100)
                    {
                        ReconoceToken();
                        estado = 0;
                        token = "";
                    }
                    else if (estado == 0)
                    {
                    }
                    else
                    {
                        token = token + caracter;
                    }
                    // *---
                    posicion = posicion + 1;
                    // *---
                    if (errores)
                    {
                        posicion = longitud + 1;
                        renglon = lbEntra.Items.Count;
                        exporta = 1;
                    }
                }
                if (estado != 4)
                {
                    estado = Convert.ToInt32(Matriz[estado, Columnas(" ")]);
                    ReconoceToken();
                    estado = 0;
                    token = "";
                }
                renglon = renglon + 1;
            }
            if (estado == 4)
            {
                DGVSalida.Rows.Clear();
                MessageBox.Show("Constante String invalida, se esperaba un '.");
                exporta = 1;
            }
            if (exporta == 0) {
                DateTime f = DateTime.Now;
                String archivo = Path.GetFullPath("ArchivosDeSalida\\") + "Output" + cbLenguaje.Text + txtUsuario.Text + f.Day.ToString()
                    + f.Month.ToString() + f.Year.ToString() + "_" + f.Hour.ToString() + "-" +
                    f.Minute.ToString() + ".txt";

                StreamWriter sw = new StreamWriter(archivo);
                if (DGVSalida.Rows.Count > 0)
                {
                    foreach (DataGridViewRow Fila in DGVSalida.Rows)
                    {

                        if (Fila.Cells["Token"].Value != null)
                        {
                            sw.WriteLine(Fila.Cells["Token"].Value.ToString() + ", " + Fila.Cells["Tipo"].Value.ToString() + ", " + Fila.Cells["Directorio"].Value.ToString());

                        }
                    }
                }
                sw.Close();
                MessageBox.Show(archivo + " exportado exitosamente");
                CompiladorBoton.Enabled = false;
                CompiladorBoton.Visible = false;
                UsersBox.Visible = true;
                UsersBox.Enabled = true;
                query a = new query();
                a.GetUsuario(txtUsuario.Text, ref u);
                a.InsertRegistroLog(u, (int?)cbLenguaje.SelectedValue, f, ("Output" + cbLenguaje.Text + txtUsuario.Text + f.Day.ToString()
                    + f.Month.ToString() + f.Year.ToString() + "_" + f.Hour.ToString() + "-" +
                    f.Minute.ToString() + ".txt"));
                //ConsultaReporteLogsTableAdapter n = new ConsultaReporteLogsTableAdapter();
                consultaReporteLogsTableAdapter.Fill(compiladoresDataSet1.ConsultaReporteLogs, null, null, null, null);
                //CompiladoresDataSet1.ConsultaReporteLogsDataTable g = n.GetData(null, null, null, null);
                //DGVReporte.DataSource = g;
                    //g.AsDataView();

            }

        }
        private void LeeMatrizEstados(string archivo)
        {
            string renglon;
            string[] datosRenglon;
            StreamReader Lector = new StreamReader(archivo);
            int r = 0;
            while (!Lector.EndOfStream)
            {
                renglon = Lector.ReadLine();
                datosRenglon = renglon.Split(',');
                for (var c = 0; c <= datosRenglon.Length - 1; c++)
                    Matriz[r, c] = datosRenglon[c];
                r += 1;
            }
        }
        private void LeePalabrasReservadas(string archivo)
        {
            // Dim read As System.IO.StreamReader 'Lector de archivos
            // read = My.Computer.FileSystem.OpenTextFileReader(archivo) 'Abre el archivo
            // Dim StringRead As String

            // While Not (read.EndOfStream) 'Mientras no se acabe de leer el archivo
            // StringRead = read.ReadLine() 'Lee una linea
            // 'MsgBox(StringRead)
            // ListBox3.Items.Add(StringRead) 'Agrega la linea al Listbox
            // End While


            // Ctrl+RR cambia de todas partes la palabra que escribas

            string renglon;
            
            StreamReader Lector = new StreamReader(archivo);
            renglon = Lector.ReadLine();
            VectorPalabrasReservadas = renglon.Split(',');
        }
        private int Columnas(string cara)
        {
            int col;

            if ((Strings.Asc(cara) >= 65 & Strings.Asc(cara) <= 90) | (Strings.Asc(cara) >= 97 & Strings.Asc(cara) <= 122))
                col = 0;
            else if ((Strings.Asc(cara) >= 48 & Strings.Asc(cara) <= 57))
                col = 1;
            else if (cara == "'")
                col = 2;
            else if (cara == "/")
                col = 3;
            else if (cara == "+")
                col = 4;
            else if (cara == "-")
                col = 5;
            else if (cara == "#")
                col = 6;
            else if (cara == "=")
                col = 7;
            else if (cara == "<")
                col = 8;
            else if (cara == ">")
                col = 9;
            else if (cara == @"\")
                col = 10;
            else if (cara == "$")
                col = 11;
            else if (cara == "&")
                col = 12;
            else if (cara == ";")
                col = 13;
            else if (cara == ".")
                col = 14;
            else if (cara == "(")
                col = 15;
            else if (cara == ")")
                col = 16;
            else if (cara == ",")
                col = 17;
            else if (cara == "^")
                col = 18;
            else if (cara == "|")
                col = 19;
            else if (cara == "!")
                col = 20;
            else if (cara == "*")
                col = 21;
            else if (cara == "_")
                col = 22;
            else if (cara == " ")
                col = 23;
            else
                col = 24;
            return col;
        }
        private void VerContraseña_Click(object sender, EventArgs e)
        {
            if (verContr)
            {
                verContr = false;
                VerContraseña.Image = Image.FromFile("eye_show_regular_icon_203603.png");
                txtContraseña.PasswordChar = '*';
            }
            else {
                verContr = true;
                VerContraseña.Image = Image.FromFile("eye_hide_regular_icon_203604.png");
                txtContraseña.PasswordChar = (char)0;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'compiladoresDataSet1.Usuario' Puede moverla o quitarla según sea necesario.
           
            // TODO: esta línea de código carga datos en la tabla 'compiladoresDataSet1.Lenguaje' Puede moverla o quitarla según sea necesario.
            

        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            query a = new query();
            a.GetMatriz(Convert.ToInt32(cbLenguaje.SelectedValue),ref matz, ref preser);
            EleccionLenguaje.Enabled= false;
            EleccionLenguaje.Visible=false;
            CompiladorBoton.Visible = true;
            CompiladorBoton.Enabled = true;
            LeeMatrizEstados(matz);
            ListBox3.Items.Clear();
            //LeePalabrasReservadas("C:\\Users\\LOPEZ\\Desktop\\López Rodríguez Daniela\\7MO SEMESTRE\\PR.txt");

            LeePalabrasReservadas(preser);
            for (var i = 0; i <= VectorPalabrasReservadas.Length - 1; i++)
                ListBox3.Items.Add(VectorPalabrasReservadas[i] + "");

        }
        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            txtConfirContra.Clear();
            txtNombreNuevo.Clear();
            txtTelefono.Clear();
            txtNuevoContraseña.Clear();
            txtNuevoUser.Clear();
            txtCorreo.Clear();
            LoginBox.Enabled= false;
            LoginBox.Visible= false;
            Registrobox.Visible= true;
            Registrobox.Enabled= true;
        }
        private void btnVerConfirmar_Click(object sender, EventArgs e)
        {
            if (verContrCon)
            {
                verContrCon = false;
                btnVerConfirmar.Image = Image.FromFile("eye_show_regular_icon_203603.png");
                txtConfirContra.PasswordChar = '*';
            }
            else
            {
                verContrCon = true;
                btnVerConfirmar.Image = Image.FromFile("eye_hide_regular_icon_203604.png");
                txtConfirContra.PasswordChar = (char)0;
            }
        }
        private void btnVerContraNueva_Click(object sender, EventArgs e)
        {
            if (verContrN)
            {
                verContrN = false;
                btnVerContraNueva.Image = Image.FromFile("eye_show_regular_icon_203603.png");
                txtNuevoContraseña.PasswordChar = '*';
            }
            else
            {
                verContrN = true;
                btnVerContraNueva.Image = Image.FromFile("eye_hide_regular_icon_203604.png");
                txtNuevoContraseña.PasswordChar = (char)0;
            }
        }
        private void btnCancelaNuevo_Click(object sender, EventArgs e)
        {
            txtUsuario.Clear();
            txtContraseña.Clear();
            Registrobox.Enabled = false;
            Registrobox.Visible = false;
            LoginBox.Visible = true;
            LoginBox.Enabled = true;
        }
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            query a = new query();
            a.ValidarContraseña(Encriptado(txtContraseña.Text), txtUsuario.Text,ref poder);
            if (poder == false) {
                MessageBox.Show("Acceso Denegado");
                txtUsuario.Clear();
                txtContraseña.Clear();
            }
            else
            {
                txtContraseña.Clear();
                LoginBox.Enabled = false;
                LoginBox.Visible = false;
                EleccionLenguaje.Visible = true;
                EleccionLenguaje.Enabled = true;
            }
        }
        private string Encriptado(string co) {
                using (var sha256 = new SHA256Managed())
                {
                    return BitConverter.ToString(sha256.ComputeHash(Encoding.UTF8.GetBytes(co))).Replace("-", "");
                }
     }
        private void btnRegistraNuevo_Click(object sender, EventArgs e)
        {
            query a = new query();
            a.UsuarioExistente(txtNombreNuevo.Text, txtNuevoUser.Text, Encriptado(txtNuevoContraseña.Text), txtCorreo.Text, txtTelefono.Text, ref poder);
            if (poder == true)
            {
                MessageBox.Show("Usuario registrado correctamente");
                txtUsuario.Clear();
                txtContraseña.Clear();
                Registrobox.Enabled = false;
                Registrobox.Visible = false;
                LoginBox.Visible = true;
                LoginBox.Enabled = true;
            }
            else {
                MessageBox.Show("Usuario existente");
            }
        }
        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            int y = 0;
            if (txtTelefono.Text.Length > 10) {
                MessageBox.Show("Ingrese un teléfono valido");
                btnRegistraNuevo.Enabled = false;
                
            }
            else {
                foreach (char a in txtTelefono.Text){
                    if (!(a > 47 && a < 58)) {
                        MessageBox.Show("Ingrese un teléfono valido");
                        btnRegistraNuevo.Enabled = false;
                        y = 1;
                        break;
                    }
                }
                if (y==0) {
                    VerificarDatos(); }
            }
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
        private void chkUser_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUser.Checked)
            {
                cbUsuariofilt.Enabled = true;
            }
            else {
                cbUsuariofilt.Enabled = false;
            }
        }
        private void chkLen_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLen.Checked)
            {
                cbLengfilt.Enabled = true;
                
            }
            else
            {
                cbLengfilt.Enabled = false;
            }

        }
        private void chkInicio_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInicio.Checked)
            {
                dtIniciofilt.Enabled = true;
                
            }
            else
            {
                dtIniciofilt.Enabled = false;
            }
        }
        private void chkFin_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFin.Checked)
            {
                dtFinfilt.Enabled = true;
                
            }
            else
            {
                dtFinfilt.Enabled = false;
            }
        }
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            int? usu = null;
            int? l = null;
            DateTime? i = null;
            DateTime? fi = null;
            if (chkUser.Checked)
            {
                usu = (int?)cbUsuariofilt.SelectedValue;
            }
            if (chkLen.Checked)
            {
                l =(int?) cbLengfilt.SelectedValue;
            }
            if (chkInicio.Checked)
            {
                i = (DateTime?)dtIniciofilt.Value;
            }
            if (chkFin.Checked)
            {
                fi = (DateTime?)dtFinfilt.Value;
            }
            consultaReporteLogsTableAdapter.Fill(compiladoresDataSet1.ConsultaReporteLogs, usu, l, i, fi);
        }
        private void label17_Click(object sender, EventArgs e)
        {
        }

        private void label18_Click(object sender, EventArgs e)
        {
        }
        private void VerificarDatos() {
            if (txtTelefono.Text.Length == 10) {
                if (txtNuevoUser.Text.Length >= 5 && txtNuevoUser.Text.Length <= 20) {
                    if (txtNuevoContraseña.Text.Length>= 10 && txtNuevoContraseña.Text.Length <= 20) {
                        if (txtNuevoContraseña.Text == txtConfirContra.Text) {
                            if (IsValidEmail(txtCorreo.Text)) {
                                btnRegistraNuevo.Enabled = true; 
                            }
                        }
                    }
                }
            }
        }

        private void txtNombreNuevo_TextChanged(object sender, EventArgs e)
        {
            int y = 0;
            foreach (char a in txtNombreNuevo.Text)
            {
                if ((a > 47 && a < 58))
                {
                    MessageBox.Show("Ingrese un nombre valido");
                    btnRegistraNuevo.Enabled = false;
                    y = 1;
                    break;
                }
            }
            if (y==0) {
                VerificarDatos(); }
        }

        private void txtNuevoUser_TextChanged(object sender, EventArgs e)
        {
            VerificarDatos();
        }

        private void txtNuevoContraseña_TextChanged(object sender, EventArgs e)
        {
            VerificarDatos();
        }

        private void txtConfirContra_TextChanged(object sender, EventArgs e)
        {
            VerificarDatos();
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            VerificarDatos();
        }
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
            }
