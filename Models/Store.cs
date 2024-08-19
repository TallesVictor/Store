using Mysqlx.Expr;
using Store.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    internal class StoreModel
    {
        private int id;
        private string cnpj;
        private string name;
        private string address;
        private string description;

        public StoreModel() { }

        public StoreModel(string cnpj, string name, string description, string address)
        {
            this.cnpj = cnpj;
            this.name = name;
            this.description = description;
            this.address = address;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Cnpj
        {
            get { return cnpj; }
            set { cnpj = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public bool save()
        {
            StoreDao storeDao = new StoreDao();
            return storeDao.CreateStore(this);
        }

        public bool update()
        {
            StoreDao storeDao = new StoreDao();
            return storeDao.UpdateStore(this);
        }

        public bool delete()
        {
            StoreDao storeDao = new StoreDao();
            return storeDao.DeleteStore(this.id);
        }


    }
}
