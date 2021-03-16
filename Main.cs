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

namespace SEQ2MIDI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void openSEQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PS1 SEQ File (*.seq)|*.seq";

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "MIDI File (*.mid)|*.mid";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                byte[] data = File.ReadAllBytes(ofd.FileName);
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(sfd.FileName, SEQ.Load(data).ToMIDI());
                }
            }
        }

        private void openMIDIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "MIDI File (*.mid)|*.mid";


            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PS1 SEQ File (*.seq)|*.seq";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                byte[] data = File.ReadAllBytes(ofd.FileName);
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(sfd.FileName, SEQ.FromMIDI(data).Save());
                }
            }
        }
    }
}
