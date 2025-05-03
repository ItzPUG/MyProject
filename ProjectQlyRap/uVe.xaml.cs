using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProjectQlyRap
{
    public partial class uVe : UserControl
    {
        QuanLyRapPhimEntities3 DB = new QuanLyRapPhimEntities3();

        public uVe()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dgVe.ItemsSource = DB.Ves.ToList(); // Lấy dữ liệu từ bảng Ve
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaVe.Text))
            {
                MessageBox.Show("Mã vé không được để trống!");
                return;
            }

            // Kiểm tra mã vé có bị trùng không
            if (DB.Ves.Any(v => v.MaVe == txtMaVe.Text))
            {
                MessageBox.Show("Mã vé đã tồn tại! Vui lòng chọn mã khác.");
                return;
            }

            // Kiểm tra mã suất chiếu có bị trùng không
            string maSuatChieu = txtMaSuatChieu.Text.Trim();
            if (!DB.SuatChieux.Any(s => s.MaSuatChieu.Trim() == maSuatChieu))
            {
                MessageBox.Show("Mã suất chiếu không tồn tại!");
                return;
            }

            // Kiểm tra mã phim có bị trùng không
            string maPhim = txtMaPhim.Text.Trim().ToUpper(); // Loại bỏ khoảng trắng và kiểm tra không phân biệt chữ hoa, chữ thường
            if (!DB.Phims.Any(p => p.MaPhim.Trim().ToUpper() == maPhim))
            {
                MessageBox.Show("Mã phim không tồn tại!");
                return;
            }

            var veMoi = new Ve
            {
                MaVe = txtMaVe.Text,
                SoGhe = txtSoGhe.Text,
                TrangThaiVe = txtTrangThai.Text,
                MaSuatChieu = txtMaSuatChieu.Text,
                MaKhachHang = txtMaKhachHang.Text,
                MaPhim = txtMaPhim.Text
            };

            DB.Ves.Add(veMoi);
            DB.SaveChanges();
            LoadData();
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (dgVe.SelectedItem is Ve selectedVe)
            {
                var ve = DB.Ves.FirstOrDefault(v => v.MaVe == selectedVe.MaVe);
                if (ve != null)
                {
                    // Kiểm tra mã vé có bị trùng không khi sửa
                    if (DB.Ves.Any(v => v.MaVe == txtMaVe.Text && v.MaVe != selectedVe.MaVe))
                    {
                        MessageBox.Show("Mã vé này đã tồn tại trong hệ thống!");
                        return;
                    }

                    // Kiểm tra mã suất chiếu có bị trùng không
                    string maSuatChieu = txtMaSuatChieu.Text.Trim();
                    if (!DB.SuatChieux.Any(s => s.MaSuatChieu.Trim() == maSuatChieu))
                    {
                        MessageBox.Show("Mã suất chiếu không tồn tại!");
                        return;
                    }

                    // Kiểm tra mã phim có bị trùng không
                    string maPhim = txtMaPhim.Text.Trim().ToUpper();
                    if (!DB.Phims.Any(p => p.MaPhim.Trim().ToUpper() == maPhim))
                    {
                        MessageBox.Show("Mã phim không tồn tại!");
                        return;
                    }

                    ve.SoGhe = txtSoGhe.Text;
                    ve.TrangThaiVe = txtTrangThai.Text;
                    ve.MaSuatChieu = txtMaSuatChieu.Text;
                    ve.MaKhachHang = txtMaKhachHang.Text;
                    ve.MaPhim = txtMaPhim.Text;

                    DB.SaveChanges();
                    LoadData();
                }
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (dgVe.SelectedItem is Ve selectedVe)
            {
                var ve = DB.Ves.FirstOrDefault(v => v.MaVe == selectedVe.MaVe);
                if (ve != null)
                {
                    DB.Ves.Remove(ve);
                    DB.SaveChanges();
                    LoadData();
                }
            }
        }

        private void btnLamMoi_Click(object sender, RoutedEventArgs e)
        {
            txtMaVe.Clear();
            txtSoGhe.Clear();
            txtTrangThai.Clear();
            txtMaSuatChieu.Clear();
            txtMaKhachHang.Clear();
            txtMaPhim.Clear();
        }

        private void dgVe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgVe.SelectedItem is Ve selectedVe)
            {
                txtMaVe.Text = selectedVe.MaVe;
                txtSoGhe.Text = selectedVe.SoGhe;
                txtTrangThai.Text = selectedVe.TrangThaiVe;
                txtMaSuatChieu.Text = selectedVe.MaSuatChieu;
                txtMaKhachHang.Text = selectedVe.MaKhachHang;
                txtMaPhim.Text = selectedVe.MaPhim;
            }
        }
    }
}
