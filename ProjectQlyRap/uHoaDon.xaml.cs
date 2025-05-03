using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.IO; // Thêm dòng này
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace ProjectQlyRap
{
    public partial class uHoaDon : UserControl
    {
        QuanLyRapPhimEntities3 DB = new QuanLyRapPhimEntities3();

        public uHoaDon()
        {
            InitializeComponent();
            LoadPhim();
        }

        private void LoadPhim()
        {
            try
            {
                var phimList = DB.Phims.ToList();
                lstPhim.ItemsSource = null;  // Xóa dữ liệu cũ để tránh lỗi hiển thị
                foreach (var phim in phimList)
                {
                    // Đảm bảo rằng hình ảnh sử dụng tên file mà không cần đường dẫn đầy đủ
                    phim.HinhAnh = phim.HinhAnh?.Trim();  // Đảm bảo không có khoảng trắng thừa
                }
                lstPhim.ItemsSource = phimList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách phim: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void lstPhim_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedPhim = lstPhim.SelectedItem as Phim;

            if (selectedPhim != null)
            {
                // Cập nhật thông tin phim vào các trường nhập liệu
                txtInputMaPhim.Text = selectedPhim.MaPhim ?? string.Empty;
                txtInputTenPhim.Text = selectedPhim.TenPhim ?? string.Empty;
                txtInputTheLoai.Text = selectedPhim.TheLoai ?? string.Empty;
                txtInputDaoDien.Text = selectedPhim.DaoDien ?? string.Empty;
                txtInputMoTaPhim.Text = selectedPhim.MoTaPhim ?? string.Empty;
                txtInputTrangThaiPhim.Text = selectedPhim.TrangThaiPhim ?? string.Empty;
                txtInputMaSuatChieu.Text = selectedPhim.MaSuatChieu?.ToString() ?? string.Empty;

                // Xử lý hình ảnh
                string imageFileName = selectedPhim.HinhAnh?.Trim(); // Lấy tên file ảnh từ database

                if (!string.IsNullOrEmpty(imageFileName))
                {
                    // Tạo đường dẫn hình ảnh từ thư mục 'images/'
                    string imagePath = Path.Combine("images", imageFileName);

                    try
                    {
                        // Thử tải hình ảnh từ thư mục images
                        imgPhim.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));

                        // Nếu không tìm thấy hình ảnh, thay thế bằng hình ảnh mặc định
                        if (imgPhim.Source == null)
                        {
                            imgPhim.Source = new BitmapImage(new Uri("pack://application:,,,/Images/default.jpg"));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi tải hình ảnh: {ex.Message}");
                        imgPhim.Source = new BitmapImage(new Uri("pack://application:,,,/Images/default.jpg"));
                    }
                }
                else
                {
                    MessageBox.Show("Tên file ảnh không hợp lệ!");
                    imgPhim.Source = new BitmapImage(new Uri("pack://application:,,,/Images/default.jpg"));
                }
            }
        }

        private void btnChonAnh_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Chọn ảnh",
                Filter = "Tệp hình ảnh|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;

                // Tạo thư mục Images nếu chưa có
                string appImagesFolder = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");

                if (!Directory.Exists(appImagesFolder))
                {
                    Directory.CreateDirectory(appImagesFolder);
                }

                // Lấy tên file ảnh
                string imageFileName = System.IO.Path.GetFileName(selectedFilePath);
                string destFilePath = System.IO.Path.Combine(appImagesFolder, imageFileName);

                try
                {
                    // Sao chép hình ảnh vào thư mục ứng dụng
                    File.Copy(selectedFilePath, destFilePath, true);

                    // Hiển thị hình ảnh lên UI
                    imgPhim.Source = new BitmapImage(new Uri(destFilePath));

                    // Cập nhật đường dẫn ảnh vào TextBox (chỉ lưu tên tệp hình ảnh)
                    txtImagePath.Text = imageFileName; // Chỉ lưu tên file hình ảnh
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"Lỗi khi sao chép file ảnh: {ex.Message}");
                }
            }
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            string imagePath = txtImagePath.Text.Trim();

            if (string.IsNullOrEmpty(imagePath))
            {
                MessageBox.Show("Vui lòng chọn hình ảnh trước khi thêm phim.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Tạo đối tượng Phim mới và lưu vào cơ sở dữ liệu
            Phim newPhim = new Phim
            {
                MaPhim = txtInputMaPhim.Text,
                TenPhim = txtInputTenPhim.Text,
                TheLoai = txtInputTheLoai.Text,
                DaoDien = txtInputDaoDien.Text,
                MoTaPhim = txtInputMoTaPhim.Text,
                TrangThaiPhim = txtInputTrangThaiPhim.Text,
                MaSuatChieu = txtInputMaSuatChieu.Text.Trim(),
                HinhAnh = imagePath  // Chỉ lưu tên tệp hình ảnh
            };

            try
            {
                DB.Phims.Add(newPhim);
                DB.SaveChanges();
                LoadPhim();
                MessageBox.Show("Thêm phim thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm phim: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (lstPhim.SelectedItem is Phim selectedPhim)
            {
                bool isModified = false;

                // Kiểm tra sự thay đổi các thuộc tính
                if (selectedPhim.MaPhim != txtInputMaPhim.Text)
                {
                    selectedPhim.MaPhim = txtInputMaPhim.Text;
                    isModified = true;
                }
                if (selectedPhim.TenPhim != txtInputTenPhim.Text)
                {
                    selectedPhim.TenPhim = txtInputTenPhim.Text;
                    isModified = true;
                }
                if (selectedPhim.TheLoai != txtInputTheLoai.Text)
                {
                    selectedPhim.TheLoai = txtInputTheLoai.Text;
                    isModified = true;
                }
                if (selectedPhim.DaoDien != txtInputDaoDien.Text)
                {
                    selectedPhim.DaoDien = txtInputDaoDien.Text;
                    isModified = true;
                }
                if (selectedPhim.MoTaPhim != txtInputMoTaPhim.Text)
                {
                    selectedPhim.MoTaPhim = txtInputMoTaPhim.Text;
                    isModified = true;
                }
                if (selectedPhim.TrangThaiPhim != txtInputTrangThaiPhim.Text)
                {
                    selectedPhim.TrangThaiPhim = txtInputTrangThaiPhim.Text;
                    isModified = true;
                }
                if (selectedPhim.MaSuatChieu != txtInputMaSuatChieu.Text.Trim())
                {
                    selectedPhim.MaSuatChieu = txtInputMaSuatChieu.Text.Trim();
                    isModified = true;
                }

                // Kiểm tra và cập nhật tên hình ảnh nếu có thay đổi
                string newImageName = Path.GetFileName(txtImagePath.Text.Trim()); // Lấy tên tệp hình ảnh mà không có đường dẫn
                if (selectedPhim.HinhAnh != newImageName)
                {
                    selectedPhim.HinhAnh = newImageName;
                    isModified = true;
                }

                // Lưu thay đổi nếu có
                if (isModified)
                {
                    try
                    {
                        DB.SaveChanges();
                        LoadPhim();
                        MessageBox.Show("Cập nhật phim thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi cập nhật phim: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Không có thay đổi nào để cập nhật!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }


        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            string imagePath = txtImagePath.Text.Trim();

            // Kiểm tra nếu không có hình ảnh thì thông báo
            if (string.IsNullOrEmpty(imagePath))
            {
                MessageBox.Show("Vui lòng chọn hình ảnh trước khi lưu phim.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Kiểm tra các trường thông tin phim
            if (string.IsNullOrEmpty(txtInputMaPhim.Text) || string.IsNullOrEmpty(txtInputTenPhim.Text) || string.IsNullOrEmpty(txtInputTheLoai.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin phim.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Lấy tên tệp hình ảnh từ đường dẫn đã chọn
            string imageFileName = System.IO.Path.GetFileName(imagePath);
            string appImagesFolder = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images");

            if (!Directory.Exists(appImagesFolder))
            {
                Directory.CreateDirectory(appImagesFolder);
            }

            // Tạo đường dẫn mới để lưu hình ảnh vào thư mục Images
            string destFilePath = System.IO.Path.Combine(appImagesFolder, imageFileName);

            // Kiểm tra nếu hình ảnh đã tồn tại
            if (!File.Exists(destFilePath))
            {
                try
                {
                    // Sao chép hình ảnh vào thư mục ứng dụng
                    File.Copy(imagePath, destFilePath, true);
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"Lỗi khi sao chép file ảnh: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            // Đảm bảo rằng đường dẫn hình ảnh không bị lặp lại "images/"
            string imageRelativePath = "images/" + imageFileName;
            if (imageRelativePath.StartsWith("images/"))
            {
                imageRelativePath = imageRelativePath.Substring(7); // Loại bỏ "images/" nếu đã tồn tại
            }

            // Tạo đối tượng Phim mới và lưu vào cơ sở dữ liệu
            Phim newPhim = new Phim
            {
                MaPhim = txtInputMaPhim.Text,
                TenPhim = txtInputTenPhim.Text,
                TheLoai = txtInputTheLoai.Text,
                DaoDien = txtInputDaoDien.Text,
                MoTaPhim = txtInputMoTaPhim.Text,
                TrangThaiPhim = txtInputTrangThaiPhim.Text,
                MaSuatChieu = txtInputMaSuatChieu.Text.Trim(),
                HinhAnh = "images/" + imageRelativePath  // Lưu đường dẫn tương đối của hình ảnh
            };

            try
            {
                DB.Phims.Add(newPhim);
                DB.SaveChanges();
                LoadPhim();
                MessageBox.Show("Lưu phim thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu phim: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (lstPhim.SelectedItem is Phim selectedPhim)
            {
                MessageBoxResult result = MessageBox.Show("Bạn có chắc muốn xóa phim này?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        DB.Phims.Remove(selectedPhim);
                        DB.SaveChanges();
                        LoadPhim();
                        MessageBox.Show("Xóa phim thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa phim: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phim để xóa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}