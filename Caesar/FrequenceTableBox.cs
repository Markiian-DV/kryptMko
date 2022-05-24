using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caesar
{
    public partial class FrequenceTableBox : Form
    {
        public FrequenceTableBox()
        {
            InitializeComponent();
        }

        private void FrequenceTableBox_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = ((CaesarForm)Owner).frequenceTable;
        }
    }
}
