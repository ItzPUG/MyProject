   M S B A M L   `   `   `  ����  ProjectQlyRap!    ProjectQlyRap.HoaDonControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      $	��400��5      $	��600��6   .��5      � .+�5	   
   �� 
���   �$��1q�6%     �� CornerRadius$  5��69    �� Padding$ 10q�6J   $��10q�6W   ._�5
      �� .+�5      �� $��
HÓA ĐƠN��6   $��20(�6+   $
��Bold"�69   
����  �$��Center=�6]   $��0,0,0,10q�6z   � 5       � RowDefinitions 5      �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(    � ColumnDefinitions 5      �� 5      $	��150 �6+   �� 5      $��* �6+   .+�5      �� $��Mã Hóa Đơn:��6    $
��Bold"�63   $��Center=�6E   $��0��6`   �� 5      -   5        $��txtMaHoaDon��5      $��1��61   $��5q�6A   $��0��6L   �� 5      $��Mã Khách Hàng:��6    $
��Bold"�66   $��Center=�6H   $��1��6c   �� 5      -   5        $��txtMaKhachHang��5      $��1��64   $��5q�6D   $��1��6O   �� 5!      $��Ngày Bán:��6    $
��Bold"�61   $��Center=�6C   $��2��6^   (  "System.Windows.Controls.DatePicker  5"      -   5        $��	dpNgayBan��5"   !   $��1��62   $��5q�6B   $��2��6M   �� 5$      $��Mã Nhân Viên:��6    $
��Bold"�65   $��Center=�6G   $��3��6b   �� 5%      -   5        $��txtMaNhanVien��5%      $��1��63   $��5q�6C   $��3��6N   �� 5'      $��Mã Thanh Toán:��6    $
��Bold"�66   $��Center=�6H   $��4��6c   �� 5(      -   5        $��txtMaThanhToan��5(      $��1��64   $��5q�6D   $��4��6O   5)      �� 5+       �� Orientation$ 
Horizontal=�6   $��Center=�66   $��10q�6S   .+�5,      �� -   5        $��btnThem��5,      $��Thêm��6,   $��80��6;   $��5q�6F   6Q   �� 5-      -   5        $��btnSua��5-      $��Sửa��6+   $��80��69   $��5q�6D   6O   �� 5.      -   5        $��btnXoa��5.      $
��Xóa��6+   $��80��69   $��5q�6D   6O   �� 5/      -	   5        $��	btnLamMoi��5/      $��
Làm Mới��6.   $��80��6@   $��5q�6K   6V   50      &   System.Windows.Controls.DataGrid  52      -
   5        $��dgHoaDon��52         AutoGenerateColumns .  $	��200��6G   $��5q�6T      Columns 53      0  *System.Windows.Controls.DataGridTextColumn  54      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã Hóa Đơn��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6^   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6A   �� *
MaHoaDon+6^     55      $ Mã Khách Hàng��6-   $	 100 6d   	 6D   �� *MaKhachHang+6d     56      $ 
Ngày Bán��6-   $	 100 6[   	 6?   �� *	NgayBan+6[     57      $ Mã Nhân Viên��6-   $	 100 6b   	 6C   �� *
MaNhanVien+6b     58      $ Mã Thanh Toán��6-   $	 100 6d   	 6D   �� *MaThanhToan+6d   5:      5;      5<      5=      5>      