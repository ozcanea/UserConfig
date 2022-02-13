using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace UserConfig
{
    
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        

        List<User> users = new List<User>();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            foreach (User user in users)
            {
                if(user.UserID == txtUserID.Text&&user.Password==txtPwd.Text)
                {
                    ConfigScreencs configScreen=new ConfigScreencs(user);
                    XmlWriter writer = XmlWriter.Create(Application.StartupPath + user.FileLocation);
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(User));
                    xmlSerializer.Serialize(writer, user);
                    writer.Close();
                    configScreen.Show();
                    this.Hide();
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath+@"\XMLAdmin.xml")==false && File.Exists(Application.StartupPath+@"\XMLUser.xml")==false)
            {
                //File.Create("XMLAdmin.xml");
                //File.Create("XMLUser.xml");
                users.Add(new User("admin", "1234", @"\XMLAdmin.xml", 1000, 1000, 1000, 1000));
                users.Add(new User("user", "123", @"\XMLUser.xml", 1000, 1000, 1000, 1000));

            }
            else if(File.Exists(Application.StartupPath + @"\XMLAdmin.xml") && File.Exists(Application.StartupPath + @"\XMLUser.xml") == false)
            {
                Read(@"\XMLAdmin.xml");
                users.Add(new User("user", "123", @"\XMLUser.xml", 1000, 1000, 1000, 1000));

            }
            else if(File.Exists(Application.StartupPath + @"\XMLAdmin.xml") == false && File.Exists(Application.StartupPath + @"\XMLUser.xml") )
            {
                users.Add(new User("admin", "1234", @"\XMLAdmin.xml", 1000, 1000, 1000, 1000));
                Read(@"\XMLUser.xml");
            }
            else
            {
                Read(@"\XMLAdmin.xml");
                Read(@"\XMLUser.xml");
            }
        }
        void Read(string path)
        {
            XmlReader reader = XmlReader.Create(Application.StartupPath + path);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(User));
            User user = (User)xmlSerializer.Deserialize(reader);
            users.Add(user);
            reader.Close();
        }
    }
}
