using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace frmBlocNotas
{
    public partial class frmBloc : Form
    {
        public frmBloc()
        {
            InitializeComponent();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rxtEditor.Clear();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OpenFileDialog abrir = new OpenFileDialog();
            System.IO.StreamReader abrir= null;

            ofdArchivo.Title = "Abrir archivo";
            ofdArchivo.Filter = "Text [*.txt*]|*.txt|All files [*,*]|*,*";
            ofdArchivo.CheckFileExists = true;
            ofdArchivo.ShowDialog(this);
            try
            {
                ofdArchivo.OpenFile();
                abrir = System.IO.File.OpenText(ofdArchivo.FileName);
                rxtEditor.Text = abrir.ReadToEnd();
            }
            catch (Exception)
            { }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.IO.StreamWriter guardar = null;
            sfdArchivo.Title="Guardar como";
            sfdArchivo.Filter = "Text (*.txt)|*.txt|HTML(*.html*)|*.html|All files(*.*)|*.*";
            sfdArchivo.CheckPathExists = true;
            sfdArchivo.ShowDialog(this);
            try
            {
                guardar = System.IO.File.AppendText(sfdArchivo.FileName);
                guardar.Write(rxtEditor.Text);
                guardar.Flush();
            }
            catch (Exception)
            { }
        }
    }
}
