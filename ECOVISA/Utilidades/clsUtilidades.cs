using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public class clsUtilidades
    {
        public List<Dictionary<string, object>> DataTableToSerealize(System.Data.DataTable dt)
        {
            var dictList = new List<Dictionary<string, object>>();
            foreach (System.Data.DataRow row in dt.Rows)
            {
                var dict = new Dictionary<string, object>();
                foreach (System.Data.DataColumn col in dt.Columns)
                {
                    dict[col.ColumnName] = row[col];
                }
                dictList.Add(dict);
            }
            return dictList;
        }
    }
}
