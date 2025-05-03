using System;
using System.Collections.Generic;
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
    /// Interaction logic for TrangChu.xaml
    /// </summary>
    public partial class TrangChu : Window
    {
        public TrangChu()
        {
            InitializeComponent();
        }

        private void btnTHoat_Click(object sender, RoutedEventArgs e)
        {
            //
            DangNhapDangKi login = new DangNhapDangKi();
            login.Show();
            this.Close();
        }

        private void mnDsKhachHang_Click(object sender, RoutedEventArgs e)
        {
            uDanhSachtest ndctDanhSachKH = new uDanhSachtest();
            CC.Content = ndctDanhSachKH;
        }

        private void TrangChu_Click(object sender, RoutedEventArgs e)
        {
            // Đóng cửa sổ hiện tại và mở lại TrangChu.xaml
            TrangChu trangChu = new TrangChu();
            trangChu.Show();
            this.Close();
        }

        private void mnPhim_Click(object sender, RoutedEventArgs e)
        {
            uHoaDon ndctHoaDon = new uHoaDon();
            CC.Content = ndctHoaDon;
        }

        private void mnDsVe_Click(object sender, RoutedEventArgs e)
        {
            uVe ndctVe = new uVe();
            CC.Content = ndctVe;
        }

        private void btnHoaDon_Click(object sender, RoutedEventArgs e)
        {
            HoaDonControl ndctHoaDonControl = new HoaDonControl();
            CC.Content = ndctHoaDonControl;
        }
    }
}
