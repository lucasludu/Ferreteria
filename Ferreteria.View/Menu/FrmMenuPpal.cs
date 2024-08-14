using Ferreteria.View.Consulta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferreteria.View.Menu
{
    public partial class FrmMenuPpal : FrmBase
    {
        public FrmMenuPpal()
        {
            InitializeComponent();
        }

        private void btnFrmLocal_Click(object sender, EventArgs e)
        {
            var frmLocal = new FrmConsultaLocal();
            frmLocal.ShowDialog();
        }
    }
}
