   M S B A M L   `   `   `  ����H  DProjectQlyRap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ProjectQlyRapProjectQlyRap  5          ProjectQlyRap.uHoaDon   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:ProjectQlyRap     5      .��5
      � $��10q�6     � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��3* �6   .+�5   
   �� $��0��6   $��0��6    $��5q�60   ��5      �� 5      $��Danh Sách Phim��6   $��16(�62   
�������
���OO/� �� Padding$ 5q�6n   .��5      �� -   5         ��Name$ lstPhim��5      $	��200��6S   $��5q�6`   
�������$��1q�6�   ��5      �� 5      .R�5      �� $��14(�6=   $ 5q�6K   
���OO/���6$   �� *	TenPhim+6W   5       5"      5#      � 5&   
   $��0��6   $��1��6   $��2��6,   $��5q�6=     5'      �� 5(      $
��Auto �6    �� 5)      $��* �6    .+�5-      �� $��Hình Ảnh Phim��6   $��0��6.   $��Center=�6;   .��5.      �� $��1q�6   
������� �� Padding$ 5q�6@   ._�5/      �� -   5         ��Name$ imgPhim��5/      $	��200��6-   $	��200��69   50      51      52      �� 55   
   $��Nhập Thông Tin Phim��6   $��2��60   $��0��6=   $��2��6M   $��5q�6a   .��56      � $��10q�6    57      �� 58      $��1* �6'   �� 59      $��3* �6'     5<      �� 5=      $
��Auto �6$   �� 5>      $
��Auto �6$   �� 5?      $
��Auto �6$   �� 5@      $
��Auto �6$   �� 5A      $
��Auto �6$   �� 5B      $
��Auto �6$   �� 5C      $
��Auto �6$   �� 5D      $
��Auto �6$   �� 5E      $
��Auto �6$   .+�5H      �� $��0��6   $��0��6)   $��
Tên phim:��69   $��Center=�6J   �� 5I      -   5         ��Name$ txtInputTenPhim��5I      $��0��63   $��1��6@   $	��250��6P   �� 5K      $��1��6   $��0��6)   $��Thể loại:��69   $��Center=�6J   �� 5L      -   5        $ txtInputTheLoai��5L      $��1��63   $��1��6@   $	��250��6P   �� 5N      $��2��6   $��0��6)   $��Đạo diễn:��69   $��Center=�6J   �� 5O      -   5        $ txtInputDaoDien��5O      $��2��63   $��1��6@   $	��250��6P   �� 5Q      $��3��6   $��0��6)   $��Mô tả phim:��69   $��Center=�6L   �� 5R      -   5        $ txtInputMoTaPhim��5R      $��3��64   $��1��6A   $	��250��6Q   �� 5T      $��4��6   $��0��6)   $��Trạng thái phim:��69   $��Center=�6Q   �� 5U      -   5        $ txtInputTrangThaiPhim��5U      $��4��69   $��1��6F   $	��250��6V   �� 5W      $��5��6   $��0��6)   $��Mã suất chiếu:��69   $��Center=�6O   �� 5X      -   5        $ txtInputMaSuatChieu��5X      $��5��67   $��1��6D   $	��250��6T   �� 5Z      $��6��6   $��0��6)   $��	Mã phim:��69   $��Center=�6I   �� 5[      -	   5        $ txtInputMaPhim��5[      $��6��62   $��1��6?   $	��250��6O   �� 5]      $��7��6   $��0��6)   $��Đường dẫn ảnh:��69   $��Center=�6O   �� 5^      $��7��6   $��1��6*    �� Orientation$ 
Horizontal=�6:   $��Center=�6S   .+�5_      �� -
   5        $ txtImagePath��5_      $	��160��64   $��Center=�6@    �� 
IsReadOnly . 6[   �� 5`      -   5        $��Chọn ảnh��5`      $��80��6I   $��5,0,0,0q�6T   $��Center=�6e   5a      5b      5c      �� 5f   
   $��3��6   $��0��6"   $��2��62   $ 
Horizontal=�6F   $��Center=�6_   $��10q�6|   .+�5g      �� -   5        	 ��Name$	 btnThem��5g      $��Thêm��6&   $��90��65   $��5q�6@   6K   �� 5h      -   5        $	 btnSua��5h      $��Sửa��6%   $��90��63   $��5q�6>   6I   �� 5i      -   5        $
��Lưu��5i      $��90��6#   $��5q�6.   69   �� 5j      -   5        $	 btnXoa��5j      $
��Xóa��6%   $��90��63   $��5q�6>   6I   5k      5l      5m      