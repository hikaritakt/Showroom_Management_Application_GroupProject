using ShowroomApp.Models;
using ShowroomApp.Services;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ShowroomApp.GUI
{
    public partial class MainView : Window
    {
        private readonly CarService _carService = new();
        private readonly InventoryService _inventoryService = new();
        private readonly AccessoryService _accessoryService = new();
        private readonly LookupService _lookupService = new();

        private int? _selectedCarId;
        private int? _selectedAccessoryId;

        public MainView()
        {
            InitializeComponent();
            LoadLookups();
            LoadAllData();
        }

        private void LoadLookups()
        {
            cbBrand.ItemsSource = _lookupService.GetBrands();
            cbModel.ItemsSource = _lookupService.GetModels();
            cbColor.ItemsSource = _lookupService.GetColors();
            cbStatus.ItemsSource = _lookupService.GetStatuses();

            cbInventoryCar.ItemsSource = _lookupService.GetCars();
            cbAccessoryInventory.ItemsSource = _lookupService.GetAccessories();
        }

        private void LoadAllData()
        {
            dgCars.ItemsSource = _carService.GetAllCars();
            dgCarInventory.ItemsSource = _inventoryService.GetCarTransactions();
            dgAccessories.ItemsSource = _accessoryService.GetAllAccessories();
            dgAccessoryInventory.ItemsSource = _inventoryService.GetAccessoryTransactions();

            cbInventoryCar.ItemsSource = _lookupService.GetCars();
            cbAccessoryInventory.ItemsSource = _lookupService.GetAccessories();
        }

        private void AddCar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var car = new Car
                {
                    CarName = txtCarName.Text.Trim(),
                    Price = decimal.Parse(txtCarPrice.Text),
                    Quantity = int.Parse(txtCarQuantity.Text),
                    BrandId = (int)cbBrand.SelectedValue,
                    ModelId = cbModel.SelectedValue as int?,
                    ColorId = cbColor.SelectedValue as int?,
                    StatusId = cbStatus.SelectedValue as int?
                };

                _carService.AddCar(car);
                LoadAllData();
                ClearCarForm();
                MessageBox.Show("Đã thêm xe thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thêm xe: {ex.Message}");
            }
        }

        private void UpdateCar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_selectedCarId == null)
                {
                    MessageBox.Show("Vui lòng chọn xe cần sửa.");
                    return;
                }

                var car = new Car
                {
                    CarId = _selectedCarId.Value,
                    CarName = txtCarName.Text.Trim(),
                    Price = decimal.Parse(txtCarPrice.Text),
                    Quantity = int.Parse(txtCarQuantity.Text),
                    BrandId = (int)cbBrand.SelectedValue,
                    ModelId = cbModel.SelectedValue as int?,
                    ColorId = cbColor.SelectedValue as int?,
                    StatusId = cbStatus.SelectedValue as int?
                };

                _carService.UpdateCar(car);
                LoadAllData();
                ClearCarForm();
                MessageBox.Show("Đã cập nhật xe thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cập nhật xe: {ex.Message}");
            }
        }

        private void DeleteCar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_selectedCarId == null)
                {
                    MessageBox.Show("Vui lòng chọn xe cần xóa.");
                    return;
                }

                _carService.DeleteCar(_selectedCarId.Value);
                LoadAllData();
                ClearCarForm();
                MessageBox.Show("Đã xóa xe thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xóa xe: {ex.Message}");
            }
        }

        private void ImportCar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _inventoryService.ImportCar(
                    (int)cbInventoryCar.SelectedValue,
                    int.Parse(txtInventoryQuantity.Text),
                    decimal.Parse(txtInventoryPrice.Text),
                    txtInventoryNote.Text.Trim());

                LoadAllData();
                MessageBox.Show("Nhập xe thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi nhập kho xe: {ex.Message}");
            }
        }

        private void ExportCar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _inventoryService.ExportCar(
                    (int)cbInventoryCar.SelectedValue,
                    int.Parse(txtInventoryQuantity.Text),
                    decimal.Parse(txtInventoryPrice.Text),
                    txtInventoryNote.Text.Trim());

                LoadAllData();
                MessageBox.Show("Xuất xe thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xuất kho xe: {ex.Message}");
            }
        }

        private void AddAccessory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var accessory = new Accessory
                {
                    AccessoryName = txtAccessoryName.Text.Trim(),
                    UnitPrice = decimal.Parse(txtAccessoryPrice.Text),
                    Quantity = int.Parse(txtAccessoryQuantity.Text),
                    Description = txtAccessoryDescription.Text.Trim()
                };

                _accessoryService.AddAccessory(accessory);
                LoadAllData();
                ClearAccessoryForm();
                MessageBox.Show("Đã thêm phụ kiện thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thêm phụ kiện: {ex.Message}");
            }
        }

        private void UpdateAccessory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_selectedAccessoryId == null)
                {
                    MessageBox.Show("Vui lòng chọn phụ kiện cần sửa.");
                    return;
                }

                var accessory = new Accessory
                {
                    AccessoryId = _selectedAccessoryId.Value,
                    AccessoryName = txtAccessoryName.Text.Trim(),
                    UnitPrice = decimal.Parse(txtAccessoryPrice.Text),
                    Quantity = int.Parse(txtAccessoryQuantity.Text),
                    Description = txtAccessoryDescription.Text.Trim()
                };

                _accessoryService.UpdateAccessory(accessory);
                LoadAllData();
                ClearAccessoryForm();
                MessageBox.Show("Đã cập nhật phụ kiện thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cập nhật phụ kiện: {ex.Message}");
            }
        }

        private void DeleteAccessory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_selectedAccessoryId == null)
                {
                    MessageBox.Show("Vui lòng chọn phụ kiện cần xóa.");
                    return;
                }

                _accessoryService.DeleteAccessory(_selectedAccessoryId.Value);
                LoadAllData();
                ClearAccessoryForm();
                MessageBox.Show("Đã xóa phụ kiện thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xóa phụ kiện: {ex.Message}");
            }
        }

        private void ImportAccessory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _inventoryService.ImportAccessory(
                    (int)cbAccessoryInventory.SelectedValue,
                    int.Parse(txtAccessoryInventoryQuantity.Text),
                    decimal.Parse(txtAccessoryInventoryPrice.Text),
                    txtAccessoryInventoryNote.Text.Trim());

                LoadAllData();
                MessageBox.Show("Nhập phụ kiện thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi nhập kho phụ kiện: {ex.Message}");
            }
        }

        private void ExportAccessory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _inventoryService.ExportAccessory(
                    (int)cbAccessoryInventory.SelectedValue,
                    int.Parse(txtAccessoryInventoryQuantity.Text),
                    decimal.Parse(txtAccessoryInventoryPrice.Text),
                    txtAccessoryInventoryNote.Text.Trim());

                LoadAllData();
                MessageBox.Show("Xuất phụ kiện thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xuất kho phụ kiện: {ex.Message}");
            }
        }

        private void dgCars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgCars.SelectedItem is not CarDisplayItem selected)
                return;

            _selectedCarId = selected.CarId;
            txtCarName.Text = selected.CarName;
            txtCarPrice.Text = selected.Price.ToString();
            txtCarQuantity.Text = selected.Quantity.ToString();

            var brands = _lookupService.GetBrands();
            var models = _lookupService.GetModels();
            var colors = _lookupService.GetColors();
            var statuses = _lookupService.GetStatuses();

            cbBrand.SelectedItem = brands.FirstOrDefault(x => x.BrandName == selected.BrandName);
            cbModel.SelectedItem = models.FirstOrDefault(x => x.ModelName == selected.ModelName);
            cbColor.SelectedItem = colors.FirstOrDefault(x => x.ColorName == selected.ColorName);
            cbStatus.SelectedItem = statuses.FirstOrDefault(x => x.StatusName == selected.StatusName);
        }

        private void dgAccessories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgAccessories.SelectedItem is not Accessory selected)
                return;

            _selectedAccessoryId = selected.AccessoryId;
            txtAccessoryName.Text = selected.AccessoryName;
            txtAccessoryPrice.Text = selected.UnitPrice.ToString();
            txtAccessoryQuantity.Text = selected.Quantity.ToString();
            txtAccessoryDescription.Text = selected.Description ?? string.Empty;
        }

        private void RefreshAll_Click(object sender, RoutedEventArgs e)
        {
            LoadLookups();
            LoadAllData();
            ClearCarForm();
            ClearAccessoryForm();
        }

        private void ClearCarForm()
        {
            _selectedCarId = null;
            txtCarName.Clear();
            txtCarPrice.Clear();
            txtCarQuantity.Clear();
            cbBrand.SelectedIndex = -1;
            cbModel.SelectedIndex = -1;
            cbColor.SelectedIndex = -1;
            cbStatus.SelectedIndex = -1;
            dgCars.SelectedItem = null;
        }

        private void ClearAccessoryForm()
        {
            _selectedAccessoryId = null;
            txtAccessoryName.Clear();
            txtAccessoryPrice.Clear();
            txtAccessoryQuantity.Clear();
            txtAccessoryDescription.Clear();
            dgAccessories.SelectedItem = null;
        }
    }
}