using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Models;

namespace Server.DatabaseManager
{
    internal interface IDQL
    {
        string Insert(Record record);

        string Update(Record record);

        string Delete(int id);
    }
}
