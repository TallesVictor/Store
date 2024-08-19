using Mysqlx.Expr;
using Store.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    internal class CnpjApiModel
    {
        private string cnpj;
        private string name;
        private string address;
        private string description;

        public CnpjApiModel() { }

        public string Cnpj { get => cnpj; set => cnpj = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Description { get => description; set => description = value; }
    }
}
