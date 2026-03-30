using ShowroomApp.Models;
using ShowroomApp.Services;
using ShowroomApp.Shared;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ShowroomApp.GUI
{
    public partial class SupplierView : Page
    {
        private readonly SupplierService _service;

        public SupplierView()
        {
            InitializeComponent();
            _service = new SupplierService();
            LoadData();

            // Setup authorization UI
            if (CurrentUser.Role != "Admin")
            {
                btnDelete.Visibility = Visibility.Collapsed;
            }
        }

        private void LoadData()
        {
            dgSuppliers.ItemsSource = _service.GetAll();
        }

        private void DgSuppliers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgSuppliers.SelectedItem is Supplier sup)
            {
                txtName.Text = sup.Name;
                txtAddress.Text = sup.Address;
                txtPhone.Text = sup.Phone;
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var sup = new Supplier { Name = txtName.Text, Address = txtAddress.Text, Phone = txtPhone.Text };
                _service.Insert(sup);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgSuppliers.SelectedItem is Supplier selected)
                {
                    selected.Name = txtName.Text;
                    selected.Address = txtAddress.Text;
                    selected.Phone = txtPhone.Text;
                    _service.Update(selected);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgSuppliers.SelectedItem is Supplier selected)
                {
                    _service.Delete(selected.SupplierId);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
