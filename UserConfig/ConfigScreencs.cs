using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Xml;


namespace UserConfig
{
    
    public partial class ConfigScreencs : Form
    {
        User user1;
        
        public ConfigScreencs()
        {
            InitializeComponent();
        }
        public ConfigScreencs(User user)
        {
            InitializeComponent();
            this.user1 = user;
        }

        private void ConfigScreencs_Load(object sender, EventArgs e)
        {
            this.Width = user1.Width;
            this.Height = user1.Height;
            this.Location=new Point(user1.LocationX, user1.LocationY);
            txtH.Text=user1.Height.ToString();
            txtW.Text=user1.Width.ToString();
            txtX.Text=user1.LocationX.ToString();
            txtY.Text=user1.LocationY.ToString();


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            user1.Width=Convert.ToInt32(txtW.Text);
            user1.Height = Convert.ToInt32(txtH.Text);
            user1.LocationX = Convert.ToInt32(txtX.Text);
            user1.LocationY = Convert.ToInt32(txtY.Text);
            XmlWriter writer = XmlWriter.Create(Application.StartupPath+user1.FileLocation);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(User));
            xmlSerializer.Serialize(writer, user1);
            writer.Close();
            Application.Exit();
        }
    }
}
