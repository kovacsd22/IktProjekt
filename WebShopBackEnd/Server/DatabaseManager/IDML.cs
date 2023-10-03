using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Models;

namespace Server.DatabaseManager
{
    internal interface IDML
    {
        List<Record> Select();
    }
}
