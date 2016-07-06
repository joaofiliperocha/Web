using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.DAL.Model
{
    public class Product
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Descrition { get; set; }

        public int ParentProductID { get; set; }

        public virtual Product Parent { get; set; }

    }
}
