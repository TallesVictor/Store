using Store.Dao;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Controllers
{
    internal class StoreController
    {

        public bool createStore(StoreModel store)
        {
            return store.save();

        }

        public bool updateStore(StoreModel store)
        {
            return store.update();

        }

        public void deleteStore(int storeId)
        {
            StoreDao storeDao = new StoreDao();
            storeDao.DeleteStore(storeId);

        }

        public StoreModel GetStore(int storeId)
        {
            StoreDao storeDao = new StoreDao();
            StoreModel store = storeDao.SearchStoreForId(storeId);
            return store;
        }
    }
}
