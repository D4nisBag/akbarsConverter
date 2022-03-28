using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class User
    {
        string name;
        string surname;
        string email;
        string password;
        public string Name 
        {
            get {return name; }
            set {name = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

    }

   /* public List<User> getUser()
    {
        return user;
    }
   */


}
