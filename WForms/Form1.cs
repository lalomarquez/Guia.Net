using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WForms
{
    public partial class Form1 : Form
    {        
        string[] filePaths;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textRutaArchivos.Enabled = true;
            btnGuardar.Enabled = false;
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            DialogResult result = folder.ShowDialog();            

            try
            {
                if (result == DialogResult.OK)
                {
                    textRutaArchivos.Text = folder.SelectedPath;
                    filePaths = Directory.GetFiles(textRutaArchivos.Text, "*", SearchOption.AllDirectories);
                    btnGuardar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrio el siguiente error: " + Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string path = string.Empty;
            StringBuilder sb = new StringBuilder();
            SaveFileDialog save = new SaveFileDialog();                       
            save.RestoreDirectory = true;
            save.CheckPathExists = true;
            save.RestoreDirectory = true;            
            save.DefaultExt = "txt";
            save.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            try
            {
                if (!string.IsNullOrWhiteSpace(textRutaArchivos.Text) && save.ShowDialog() == DialogResult.OK)
                {
                    btnGuardar.Enabled = true;
                    filePaths = Directory.GetFiles(textRutaArchivos.Text, "*", SearchOption.AllDirectories);
                    path = save.FileName;

                    foreach (var item in filePaths)
                    {
                        Console.WriteLine(item);
                        sb.AppendLine(item.ToString());
                    }

                    if (!string.IsNullOrWhiteSpace(path))
                    {
                        using (StreamWriter outfile = new StreamWriter(path, true))
                        {
                            outfile.Write(sb.ToString());
                        }  
                        MessageBox.Show("Archivo gurdado en:" + Environment.NewLine + path, "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }                    
                }
                else
                    MessageBox.Show("Verifica que exista la ruta donde se guardara el archivo!!!" + Environment.NewLine + path, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio el siguiente error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                path = string.Empty;
            }
        }
    }
}
