using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FT.Plugins.PersonCard
{
    public partial class PersonCardManager : UserControl
    {
        public PersonCardManager()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PersonCardBrowser form = new PersonCardBrowser(new Card());
            form.ShowDialog();
        }
    }
}
