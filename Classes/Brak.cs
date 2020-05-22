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
    [Table(Name = "Brak")]
    class Brak
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "IDbrak")]
        public int IDbrak { get; set; }

        [Column(Name = "Nameizd")]
        public string Nameizd { get; set; }

        [Column(Name = "IdIsd")]
        public int IdIsd { get; set; }
    }
}
