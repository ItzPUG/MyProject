using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjectQlyRap
{
    /// <summary>
    /// Interaction logic for DangNhapDangKi.xaml
    /// </summary>
    public partial class DangNhapDangKi : Window
    {
        QuanLyRapPhimEntities3 DB = new QuanLyRapPhimEntities3();
        public DangNhapDangKi()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, RoutedEventArgs e)
        {
            // Lấy thông tin từ người dùng nhập
            var tk = txtEmail.Text?.Trim();
            var mk = txtPassword.Password?.Trim();

            // Kiểm tra xem thông tin nhập đã đầy đủ chưa
            if (string.IsNullOrEmpty(tk) || string.IsNullOrEmpty(mk))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ email và mật khẩu.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Tạo mảng các tham số trong câu lệnh SQL cần thực hiện
            SqlParameter[] param = { new SqlParameter("@tk", tk), new SqlParameter("@mk", mk) };

            var kq = DB.Database.SqlQuery<TaiKhoan>("Select * from TaiKhoan where username=@tk and matkhau=@mk", param).ToList();

            // Nếu có tài khoản thì chuyển trang chủ
            if (kq != null && kq.Count > 0)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                TrangChu gdc = new TrangChu();
                gdc.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên người dùng hoặc mật khẩu không đúng.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void btnDangKi_Click(object sender, RoutedEventArgs e)
        {
            // Lấy thông tin từ ô nhập liệu
            var email = txtRegisterEmail.Text?.Trim();
            var password = txtRegisterPassword.Password?.Trim();
            var confirmPassword = txtConfirmPassword.Password?.Trim();

            // Kiểm tra nhập đầy đủ thông tin
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Kiểm tra xác nhận mật khẩu
            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Kiểm tra tài khoản đã tồn tại hay chưa
            var existingUser = DB.TaiKhoans.FirstOrDefault(t => t.username == email);
            if (existingUser != null)
            {
                MessageBox.Show("Email đã tồn tại. Vui lòng chọn email khác.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                // Thêm tài khoản mới vào database
                TaiKhoan newUser = new TaiKhoan
                {
                    username = email,
                    matkhau = password,
                    quyen = "user"  // Mặc định role là user
                };

                DB.TaiKhoans.Add(newUser);
                DB.SaveChanges();  // Lưu vào database

                MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                TrangChu gdc = new TrangChu();
                gdc.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đăng ký: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
