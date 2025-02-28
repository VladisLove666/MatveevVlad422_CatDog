using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace catdooog.BD
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
