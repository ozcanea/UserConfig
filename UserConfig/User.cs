using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserConfig
{
    [Serializable()]
    public class User:UserConfiguration
    {
        public string FileLocation { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }

        public User()
        {

        }
        public User(string id,string pwd,string file,int width,int height,int locationx,int locationy)
        {
            this.UserID = id;
            this.Password = pwd;
            this.FileLocation = file;
            this.Width = width;
            this.Height = height;
            this.LocationX = locationx;
            this.LocationY = locationy;
        }
    }
}
