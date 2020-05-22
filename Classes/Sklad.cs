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
    [Table(Name = "Sklad")]
    class Sklad
    {
        [Column(Name = "idSclad")]
        public int idSclad { get; set; }

        [Column(Name = "Nameizd")]
        public string Nameizd { get; set; }

        [Column(Name = "KolvoIzd")]
        public int KolvoIzd { get; set; }

        [Column(Name = "IdSotr")]
        public int IdSotr { get; set; }

        [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "idIzd")]
        public int idIzd { get; set; }

    }
}

