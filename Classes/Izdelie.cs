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
    [Table(Name = "Izdelie")]
    class Izdelie
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "IDizdelia")]
        public int IDizdelia { get; set; }

        [Column(Name = "Nameizd")]
        public string Nameizd { get; set; }

        [Column(Name = "Material")]
        public string Material { get; set; }

        [Column(Name = "Diametr")]
        public int Diametr { get; set; }

        [Column(Name = "Tolschnastenki")]
        public int Tolschnastenki { get; set; }

        [Column(Name = "Profpoperchsech")]
        public int Profpoperchsech { get; set; }
    }
}
