using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectQlyRap
{
    /// <summary>
    /// Interaction logic for uDanhSachtest.xaml
    /// </summary>
    public partial class uDanhSachtest : UserControl
    {
        QuanLyRapPhimEntities3 DB = new QuanLyRapPhimEntities3();
        int thaotac = 0;
        public uDanhSachtest()
        {
            InitializeComponent();
            //Khi load một đối tượng user ds khách hàng thì đồng thời load  dskh từ csdl và đổ vào datagrid khách hàng
            //->Gọi hàm load all khách hàng
            LoadAllKhachHang();
            LoadPhim();
        }

        public void LoadAllKhachHang()
        {
            var dskh = DB.Database.SqlQuery<KhachHang>("SELECT * FROM KhachHang;").ToList();
            //Gắn nguồn dữ liệu vào dgr
            dgrDanhSachKhachHang.ItemsSource = dskh;
        }

        public void LoadPhim()
        {
            // Lấy danh sách khách hàng từ cơ sở dữ liệu
            var dskh = DB.KhachHangs.ToList();

            // Gắn danh sách khách hàng vào ComboBox
            cbPhim.ItemsSource = dskh;
            cbPhim.DisplayMemberPath = "MaKhachHang"; // Hiển thị Mã khách hàng trong ComboBox
            cbPhim.SelectedValuePath = "MaKhachHang"; // Giá trị trả về là Mã khách hàng
            if (cbPhim.Items.Count > 0)
            {
                cbPhim.SelectedIndex = 0; // Chọn mục đầu tiên theo mặc định
            }
        }




        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Lấy thông tin từ giao diện
                var maKhachHang = txtMaKH.Text;
                var hoTen = txtHoTen.Text;
                var ngaySinh = dNgaySinh.SelectedDate;
                var queQuan = txtQueQuan.Text;
                var diaChi = txtDiaChi.Text;
                var soDienThoai = txtDienThoai.Text;
                var maPhim = txtPhim.Text;

                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrWhiteSpace(maKhachHang) ||
                    string.IsNullOrWhiteSpace(hoTen) ||
                    ngaySinh == null ||
                    string.IsNullOrWhiteSpace(queQuan) ||
                    string.IsNullOrWhiteSpace(diaChi) ||
                    string.IsNullOrWhiteSpace(soDienThoai) ||
                    string.IsNullOrWhiteSpace(maPhim))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                // Kiểm tra mã khách hàng có trùng không
                var khachHangTonTai = DB.KhachHangs.FirstOrDefault(kh => kh.MaKhachHang == maKhachHang);
                if (khachHangTonTai != null)
                {
                    MessageBox.Show("Mã khách hàng đã tồn tại, vui lòng nhập mã khác!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                // Tạo đối tượng KhachHang mới
                var khachHangMoi = new KhachHang
                {
                    MaKhachHang = maKhachHang,
                    TenKhachHang = hoTen,
                    NgaySinh = ngaySinh.Value,
                    QueQuan = queQuan,
                    DiaChiLienLac = diaChi,
                    SoDienThoai = soDienThoai,
                    MaPhim = maPhim
                };

                // Thêm vào cơ sở dữ liệu
                DB.KhachHangs.Add(khachHangMoi);
                DB.SaveChanges();

                // Cập nhật danh sách khách hàng hiển thị
                LoadAllKhachHang();

                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                Reset(); // Xóa trắng các ô nhập liệu
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Reset()
        {
            txtMaKH.Text = string.Empty;
            txtHoTen.Text = string.Empty;
            dNgaySinh.SelectedDate = null;
            txtQueQuan.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtDienThoai.Text = string.Empty;
            txtPhim.Text = string.Empty;
        }


        private void cbPhim_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbPhim.SelectedValue != null)
            {
                // Lấy mã khách hàng được chọn
                var selectedMaKH = cbPhim.SelectedValue.ToString();

                try
                {
                    // Lọc danh sách khách hàng theo mã khách hàng
                    var filteredKhachHang = DB.KhachHangs
                        .Where(kh => kh.MaKhachHang == selectedMaKH)
                        .ToList();

                    // Gắn danh sách vào DataGrid
                    dgrDanhSachKhachHang.ItemsSource = filteredKhachHang;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void dgrDanhSachKhachHang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCustomer = dgrDanhSachKhachHang.SelectedItem as KhachHang; // Giả sử Customer là lớp dữ liệu của bạn

            if (selectedCustomer != null)
            {
                txtMaKH.Text = selectedCustomer.MaKhachHang.ToString();
                txtHoTen.Text = selectedCustomer.TenKhachHang;
                dNgaySinh.SelectedDate = selectedCustomer.NgaySinh;
                txtQueQuan.Text = selectedCustomer.QueQuan;
                txtDiaChi.Text = selectedCustomer.DiaChiLienLac;
                txtDienThoai.Text = selectedCustomer.SoDienThoai;
                txtPhim.Text = selectedCustomer.MaPhim.ToString();
            }
        }
        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (dgrDanhSachKhachHang.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để xóa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var selectedKhachHang = (KhachHang)dgrDanhSachKhachHang.SelectedItem;

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa khách hàng {selectedKhachHang.TenKhachHang}?",
                                "Xác nhận xóa",
                                MessageBoxButton.YesNo,
                                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    using (var context = new QuanLyRapPhimEntities3())
                    {
                        var khachHangToDelete = context.KhachHangs.FirstOrDefault(kh => kh.MaKhachHang == selectedKhachHang.MaKhachHang);
                        if (khachHangToDelete != null)
                        {
                            context.KhachHangs.Remove(khachHangToDelete);
                            context.SaveChanges();
                            MessageBox.Show("Xóa khách hàng thành công.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                            RefreshKhachHangData();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi xóa khách hàng: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void RefreshKhachHangData()
        {
            using (var context = new QuanLyRapPhimEntities3())
            {
                dgrDanhSachKhachHang.ItemsSource = context.KhachHangs.ToList();
            }
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            var selectedCustomer = dgrDanhSachKhachHang.SelectedItem as KhachHang;
            if (selectedCustomer != null)
            {
                // Kiểm tra và chuyển đổi mã khách hàng và mã phim thành chuỗi
                selectedCustomer.MaKhachHang = txtMaKH.Text;  // MaKhachHang là chuỗi, không cần chuyển kiểu
                selectedCustomer.TenKhachHang = txtHoTen.Text;
                selectedCustomer.NgaySinh = dNgaySinh.SelectedDate ?? DateTime.Now;
                selectedCustomer.QueQuan = txtQueQuan.Text;
                selectedCustomer.DiaChiLienLac = txtDiaChi.Text;
                selectedCustomer.SoDienThoai = txtDienThoai.Text;
                selectedCustomer.MaPhim = txtPhim.Text;  // MaPhim là chuỗi, không cần chuyển kiểu

                // Cập nhật vào cơ sở dữ liệu
                UpdateCustomerInDatabase(selectedCustomer);

                // Cập nhật lại DataGrid
                dgrDanhSachKhachHang.Items.Refresh();
            }
        }

    private void UpdateCustomerInDatabase(KhachHang khachHang)
        {
            // Sử dụng đúng context là QuanLyRapPhimEntities1
            var existingCustomer = DB.KhachHangs.FirstOrDefault(c => c.MaKhachHang == khachHang.MaKhachHang);
            if (existingCustomer != null)
            {
                existingCustomer.TenKhachHang = khachHang.TenKhachHang;
                existingCustomer.NgaySinh = khachHang.NgaySinh;
                existingCustomer.QueQuan = khachHang.QueQuan;
                existingCustomer.DiaChiLienLac = khachHang.DiaChiLienLac;
                existingCustomer.SoDienThoai = khachHang.SoDienThoai;
                existingCustomer.MaPhim = khachHang.MaPhim;

                DB.SaveChanges();
            }
        }



        //private void btnLuu_Click(object sender, RoutedEventArgs e)
        //{
        //    if(thaotac==0) 
        //    {
        //        //Xử lý thêm
        //        var makh = txtMaKH.Text;
        //        var hotenkh = txtHoTen.Text;
        //        var diachi = txtDiaChi.Text;
        //        var ngaysinh = dNgaySinh.SelectedDate;
        //        var quequan = txtQueQuan.Text;
        //        var dienthoai = txtDienThoai.Text;
        //        //hotenkh.TrimStart;
        //        //hotenkh.TrimEnd;

        //        //String[] hoten = hotenkh.Split(',');
        //        //string ho = hoten[0];
        //        //string ten = hotenkh.Substring(hotenkh.LastIndexOf(' ') + 1);
        //        //string tenlot = hotenkh.TrimStart();
        //        //tenlot.TrimEnd();
        //        //tenlot.Replace(ho, "");
        //        //tenlot.Replace(ten, "");
        //        KhachHang newkh = new KhachHang();
        //        newkh.MaKhachHang = makh;
        //        newkh.TenKhachHang = hotenkh;
        //        newkh.NgaySinh = (DateTime)ngaysinh;
        //        newkh.DiaChiLienLac = diachi;
        //        newkh.QueQuan = quequan;
        //        newkh.SoDienThoai = dienthoai;
        //    } 
        //    else if(thaotac==1) 
        //    {
        //        //Xử lý Cập Nhật
        //    }
        //    else
        //    {
        //        //Thao tác xóa
        //    }
        //}
    }
}
