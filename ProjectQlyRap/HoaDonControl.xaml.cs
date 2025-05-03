using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProjectQlyRap
{
    public partial class HoaDonControl : UserControl
    {
        QuanLyRapPhimEntities3 DB = new QuanLyRapPhimEntities3();

        public HoaDonControl()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dgHoaDon.ItemsSource = DB.HoaDons.ToList();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HoaDon newHoaDon = new HoaDon()
                {
                    MaHoaDon = txtMaHoaDon.Text.Trim(),
                    MaKhachHang = txtMaKhachHang.Text.Trim(),
                    NgayBan = dpNgayBan.SelectedDate ?? DateTime.Now,
                    MaNhanVien = txtMaNhanVien.Text.Trim(),
                    MaThanhToan = txtMaThanhToan.Text.Trim()
                };

                DB.HoaDons.Add(newHoaDon);
                DB.SaveChanges();
                MessageBox.Show("Thêm hóa đơn thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadData();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("Lỗi khi thêm hóa đơn: " + ex.InnerException?.Message ?? ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (dgHoaDon.SelectedItem is HoaDon selectedHoaDon)
            {
                try
                {
                    var updateHoaDon = DB.HoaDons.FirstOrDefault(h => h.MaHoaDon == selectedHoaDon.MaHoaDon);
                    if (updateHoaDon != null)
                    {
                        updateHoaDon.MaKhachHang = txtMaKhachHang.Text.Trim();
                        updateHoaDon.NgayBan = dpNgayBan.SelectedDate ?? DateTime.Now;
                        updateHoaDon.MaNhanVien = txtMaNhanVien.Text.Trim();
                        updateHoaDon.MaThanhToan = txtMaThanhToan.Text.Trim();

                        DB.SaveChanges();
                        MessageBox.Show("Cập nhật hóa đơn thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa hóa đơn: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần sửa!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (dgHoaDon.SelectedItem is HoaDon selectedHoaDon)
            {
                var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (confirm == MessageBoxResult.Yes)
                {
                    try
                    {
                        DB.HoaDons.Remove(selectedHoaDon);
                        DB.SaveChanges();
                        MessageBox.Show("Xóa hóa đơn thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa hóa đơn: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần xóa!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnLamMoi_Click(object sender, RoutedEventArgs e)
        {
            txtMaHoaDon.Clear();
            txtMaKhachHang.Clear();
            dpNgayBan.SelectedDate = null;
            txtMaNhanVien.Clear();
            txtMaThanhToan.Clear();
            LoadData();
        }
    }
}
