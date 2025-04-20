using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace LimpadorSistema
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            try
            {
                string tempFolder = Path.GetTempPath();
                DirectoryInfo tempDir = new DirectoryInfo(tempFolder);

                foreach (FileInfo file in tempDir.GetFiles()) file.Delete();
                foreach (DirectoryInfo dir in tempDir.GetDirectories()) dir.Delete(true);

                MessageBox.Show("Arquivos temporários removidos!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao limpar arquivos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("C:\\Program Files\\Windows Defender\\MpCmdRun.exe", "-Scan -ScanType 2");
                MessageBox.Show("Varredura iniciada!", "Antivírus", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao iniciar varredura: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
