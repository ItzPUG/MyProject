   M S B A M L   `   `   `  ����H  DProjectQlyRap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ProjectQlyRapProjectQlyRap  5      !    ProjectQlyRap.uDanhSachtest   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:ProjectQlyRap     5      .��5	      �   � RowDefinitions  5
   
   �� 5      6    � ColumnDefinitions 5   
   �� 5      $��5* �6   6,   �� 5      $��9* �6   6,   .+�5   
   �� $��0��6   $��0��6"   .+�5      �� $
��Phim��6   .��5      �� .+�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� $��Mã Phim��6    $	��100��62   6@   �� 5      -   5        $��cbPhim��5   #   $	��180��61   6j   5      5!      5"      �� 5#      $��Thông tin khách hàng��6   .��5$      �� .+�5%      �� $ 
Horizontal=�6!   .+�5&      �� $��Mã Khách Hàng:��6    $	��100��69   6H   �� 5'      -   5         ��Name$ txtMaKH��5'   "   $�� ��63   $	��180��6;   6I   5(      �� 5)      $ 
Horizontal=�6!   .+�5*      �� $��
Họ Tên:��6    $	��100��62   6@   �� 5+      -   5        $ txtHoTen��5+   "   $�� ��64   $	��180��6<   6J   5,      �� 5-      $ 
Horizontal=�6!   .+�5.      �� $��Ngày Sinh:��6    $	��100��65   6C   (  "System.Windows.Controls.DatePicker  5/      -   5        $��	dNgaySinh��5/   %   $	��170��66   6D   50      �� 51      $ 
Horizontal=�6!   .+�52      �� $��Quê Quán:��6    $	��100��64   6B   �� 53      -   5        $ 
txtQueQuan��53   "   $�� ��66   $	��180��6>   6L   54      �� 55      $ 
Horizontal=�6!   .+�56      �� $��Địa Chỉ:��6    $	��100��63   6A   �� 57      -   5        $ 	txtDiaChi��57   "   $�� ��65   $	��180��6=   6K   58      �� 59      $ 
Horizontal=�6!   .+�5:      �� $��Điện Thoại:��6    $	��100��66   6D   �� 5;      -   5        $ txtDienThoai��5;   "   $�� ��68   $	��180��6@   6N   5<      �� 5=      $ 
Horizontal=�6!   .+�5>      �� $��	Mã Phim:��6    $	��100��63   6A   �� 5?      -   5        $ txtPhim��5?   "   $�� ��63   $	��180��6;   6I   5@      5A      5B      �� 5C      $ 
Horizontal=�6   $��Center=�62   .+�5D      �� -	   5         ��Name$ btnThem��5D      $��50��6*   $��Thêm��65   $��
0, 0, 0, 0q�6Z   6p   �� 5F      -
   5        $ btnXoa��5F      $��50��6)   $
��Xóa��64   $��
0, 0, 5, 0q�6B   6X   �� 5G      -   5        $ btnLuu��5G      $��50��6)   $
��Lưu��64   $��
0, 0, 5, 0q�6W   6m   5I      5J      �� 5K   
   $��0��6   $��1��6"   .+�5L      �� $��DANH SÁCH KHÁCH HÀNG��6   $��	180 0 0 0q�63   $��Arial Black)�6F   6a   &   System.Windows.Controls.DataGrid  5M      -   5          Name$ dgrDanhSachKhachHang��5M         AutoGenerateColumns .     Columns 5N      0  *System.Windows.Controls.DataGridTextColumn  5O      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã khách hàng��6)   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6@   �� 
 �� Path$
 MaKhachHang�6g     5P      $ Họ tên khách hàng��6)   	 6D   �� $
 TenKhachHang�6l     5Q      $ 
Ngày sinh��6)   	 6<   �� $
 NgaySinh�6`     5R      $ 
Quê quán��6)   	 6;   �� $
 QueQuan�6^     5S      $ Địa chỉ liên lạc��6)   	 6C   �� $
 DiaChiLienLac�6l     5T      $ Điện thoại��6)   	 6=   �� $
 SoDienThoai�6d     5U      $ Mã Phim��6)   	 6:   �� $
 MaPhim�6\   5W      5Y      5Z      5[      