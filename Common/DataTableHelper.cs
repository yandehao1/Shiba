using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace RuRo.Common
{
    public class DataTableHelper
    {
        public static DataTable ToDataTable(DataRow[] rows)
        {
            if(rows==null||rows.Length==0) return null;
            DataTable dt = rows[0].Table.Clone();
            foreach(DataRow row in rows)
            {
                dt.Rows.Add(row.ItemArray);
            }
            return dt;
        }
    }
}
