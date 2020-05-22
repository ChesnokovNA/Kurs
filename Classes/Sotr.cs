using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace Kurs
{
    [Table(Name = "Sotr")]
    class Sotr
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "IDSotr")]
        public int IDSotr { get; set; }

        [Column(Name = "Login")]
        public string Login { get; set; }

        [Column(Name = "Password")]
        public string Password { get; set; }

        [Column(Name = "Familia")]
        public string Familia { get; set; }

        [Column(Name = "Name")]
        public string Name { get; set; }

        [Column(Name = "Otchestvo")]
        public string Otchestvo { get; set; }

        [Column(Name = "Status")]
        public bool Status { get; set; }

        [Column(Name = "Rol")]
        public string Rol { get; set; }
    }
}

