using Store.Controllers;
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
            txtCnpj.Mask = "00\\.000\\.000/0000-00";
            ListStores();
        }

        private void btSave_Click_1(object sender, EventArgs e)
        {

            StoreController controller = new StoreController();

            StoreModel store = FillStore();

            if (store != null)
            {
                bool saveStore = controller.createStore(store);

                if (saveStore)
                {
                    ClearTxt();
                    ListStores();
                    MessageBox.Show($"Usuário {store.Name}, cadastrado com sucesso!");
                }
                else
                {
                    MessageBox.Show("Erro na criação!");
                }
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

                StoreController controller = new StoreController();
                controller.deleteStore(id);

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            StoreController controller = new StoreController();
            string btnUpdateText = btnUpdate.Text;

            if (btnUpdateText.Equals("Atualizar"))
            {
                StoreModel store = FillStore();
                controller.updateStore(store);

                btnUpdate.Text = "Detalhes";
                ClearTxt();
                ListStores();
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
            string cnpj = Util.ExtractNumber(txtCnpj.Text);
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

            StoreController store = new StoreController();

            if (lvStores.SelectedItems.Count == 0) return null;
            int id = int.Parse(lvStores.SelectedItems[0].SubItems[0].Text);

            return store.GetStore(id);
        }

        //Limpar campos
        private void ClearTxt()
        {
            txtName.Clear();
            txtCnpj.Clear();
            txtDescription.Clear();
            txtAddress.Clear();
        }

        private void ListStores()
        {
            StoreDao storeDao = new StoreDao();
            List<StoreModel> stores = storeDao.GetStoreList();

            lvStores.Items.Clear();

            foreach (StoreModel store in stores)
            {
                var listViewItem = new ListViewItem(store.Id + "");
                listViewItem.SubItems.Add(store.Name);
                listViewItem.SubItems.Add(Util.MaskCnpj(store.Cnpj));
                listViewItem.SubItems.Add(store.Description);
                listViewItem.SubItems.Add(store.Address);

                lvStores.Items.Add(listViewItem);

            }

        }

        private void txtCnpj_TextChanged(object sender, EventArgs e)
        {

            string cnpj = Util.ExtractNumber(txtCnpj.Text);

            if (cnpj.Length >= 14)
            {
                lbLoadingCnpj.Text = "Buscando CNPJ...";
                lbLoadingCnpj.Visible = true;

                FillFields(cnpj);
            }
        }

        private async Task FillFields(string cnpj)
        {
            CnpjApiModel cnpjApiModel = await Util.searchCnpj(cnpj);

            lbLoadingCnpj.Text = "";
            lbLoadingCnpj.Visible = false;

            txtName.Text = cnpjApiModel.Name;
            txtDescription.Text = cnpjApiModel.Description;
            txtAddress.Text = cnpjApiModel.Address;
        }
    }
}
