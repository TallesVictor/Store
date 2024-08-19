using Store.Dao;
using Store.Helpers;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store
{
    public partial class Loja : Form
    {
        public Loja()
        {
            InitializeComponent();
            listStores();



        }

        private void btSave_Click_1(object sender, EventArgs e)
        {

            StoreModel store = FillStore();
            bool saveStore = store.save();
            if (saveStore)
            {
                ClearTxt();
                listStores();
                MessageBox.Show($"Usuário {store.Name}, cadastrado com sucesso!");
            }
            else
            {
                MessageBox.Show("Erro na criação!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvStores.SelectedItems.Count == 0) return;

            var confirmResult = MessageBox.Show("Deseja excluir?", "Deletar Loja", MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                int id = int.Parse(lvStores.SelectedItems[0].SubItems[0].Text);
                lvStores.Items.RemoveAt(lvStores.SelectedIndices[0]);

                StoreDao storeDao = new StoreDao();
                storeDao.DeleteStore(id);

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            string btnUpdateText = btnUpdate.Text;

            if (btnUpdateText.Equals("Atualizar"))
            {
                StoreModel store = FillStore();
                store.update();
                btnUpdate.Text = "Detalhes";
                ClearTxt();
                listStores();
                MessageBox.Show("Atualizado com Sucesso!");
            }
            else
            {
                GetStore();
            }


        }


        //Preencher o Model Store, com os valores do formulário
        private StoreModel FillStore()
        {
            string name = txtName.Text;
            string cnpj = txtCnpj.Text;
            string description = txtDescription.Text;
            string address = txtAddress.Text;

            string id = lbId.Text;

            if (!name.Equals("") && !cnpj.Equals("") && !description.Equals("") && !address.Equals(""))
            {
                StoreModel store = new StoreModel(cnpj, name, description, address);

                if (!id.Equals("")) store.Id = int.Parse(id);

                return store;
            }

            MessageBox.Show("Por favor, preencha todos os campos!");
            return null;
        }


        //Buscar a loja do ListView
        private void GetStore()
        {
            StoreModel store = SearchStore();
            if (store == null) return;

            txtName.Text = store.Name;
            txtDescription.Text = store.Description;
            txtAddress.Text = store.Address;
            txtCnpj.Text = store.Cnpj;
            lbId.Text = store.Id + "";

            btnUpdate.Text = "Atualizar";
        }

        //Buscar a loja no BD
        private StoreModel SearchStore()
        {
            StoreDao storeDao = new StoreDao();
            StoreModel store = new StoreModel();

            if (lvStores.SelectedItems.Count == 0) return null;
            int id = int.Parse(lvStores.SelectedItems[0].SubItems[0].Text);
            store = storeDao.SearchStoreForId(id);

            return store;
        }

        //Limpar campos
        private void ClearTxt()
        {
            txtName.Clear();
            txtCnpj.Clear();
            txtDescription.Clear();
            txtAddress.Clear();
        }

        private void listStores()
        {
            StoreDao storeDao = new StoreDao();
            List<StoreModel> stores = storeDao.GetStoreList();

            lvStores.Items.Clear();

            foreach (StoreModel store in stores)
            {
                var listViewItem = new ListViewItem(store.Id + "");
                listViewItem.SubItems.Add(store.Name);
                listViewItem.SubItems.Add(store.Cnpj);
                listViewItem.SubItems.Add(store.Description);
                listViewItem.SubItems.Add(store.Address);

                lvStores.Items.Add(listViewItem);

            }

        }

        private async Task FillFields()
        {
            string cnpj = txtCnpj.Text;

            CnpjApiModel cnpjApiModel = await HelpApi.searchCnpj(cnpj);
            txtName.Text = cnpjApiModel.Name;
            txtDescription.Text = cnpjApiModel.Description;
            txtAddress.Text = cnpjApiModel.Address;
        }

        private void txtCnpj_TextChanged(object sender, EventArgs e)
        {
            if (txtCnpj.TextLength >= 14)
            {
                FillFields();
            }
        }
    }
}
