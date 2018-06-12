using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;

namespace MOIST
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSCRAPE_Click(object sender, EventArgs e)
        {
            using (WebClient client = new WebClient())
            {
                string data = client.DownloadString(txtURL.Text);
                string pattern = @"[A-Za-z0-9_\-\+]+@[A-Za-z0-9_\-]+\.([A-Za-z]{2,3})(?:\.[a-z]{2})?";

                MatchCollection matches = Regex.Matches(data, pattern);

                if(matches.Count > 0)
                {
                    foreach(Match m in matches)
                    {
                        txtEmail.AppendText(m.Groups[0].Value + Environment.NewLine);
                    }
                }
            }

        }
    }
}
