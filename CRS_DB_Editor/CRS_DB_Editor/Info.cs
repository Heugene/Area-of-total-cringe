using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSS_DB_Editor
{
    public partial class Info : Form
    {
        public Info()
        {
            InitializeComponent();
        }

        private void Info_Load(object sender, EventArgs e)
        {
            label1.Text = "Додаток був розроблений у:\n- MS Visual Studio 2013 v12.0.40629.0\n- MS SQL Management Studio 2014 v2014.120.2000.8\n- SQL Server 2014\n\nАвтор: Геока Євгеній\nТравень 2022";
        }
    }
}
