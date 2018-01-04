using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerAndDeSer.UseNewtonSoftJson
{
    class DataTableJsonTest
    {
        public static void Exec()
        {
            var json = "[{\"F1\":3, \"F2\":\"朝野布告\"},{\"F1\":99, \"F2\":\"打开\"}]";
            var dt = JsonConvert.DeserializeObject<DataTable>(json);

        }
    }
}
