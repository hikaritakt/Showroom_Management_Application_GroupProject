using ShowroomApp.Models;
using ShowroomApp.Services;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ShowroomApp.GUI
{
    public partial class EmployeeView : Page
    {
        private readonly EmployeeService _service;

        public EmployeeView()
        {
            InitializeComponent();
            _service = new EmployeeService();
            LoadData();
        }

        private void LoadData()
        {
            dgEmployees.ItemsSource = _service.GetAll();
        }

        private void DgEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgEmployees.SelectedItem is Employee emp)
            {
                txtName.Text = emp.Name;
                txtEmail.Text = emp.Email;
                txtPhone.Text = emp.Phone;
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var emp = new Employee { Name = txtName.Text, Email = txtEmail.Text, Phone = txtPhone.Text };
                _service.Insert(emp);
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
                if (dgEmployees.SelectedItem is Employee selected)
                {
                    selected.Name = txtName.Text;
                    selected.Email = txtEmail.Text;
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
                if (dgEmployees.SelectedItem is Employee selected)
                {
                    _service.Delete(selected.EmployeeId);
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
