   M S B A M L   `   `   `  ����>  :SMB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:SMB.ViewModelSMB.ViewModel  5      #clr-namespace:SMB.ViewSMB.View  5          SMB.View.W_OverviewView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1	viewModelclr-namespace:SMB.ViewModel     5      (localclr-namespace:SMB.View     5      X TFontAwesome.Sharp, Version=6.1.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  63   
������   � DataContext  5      !   SMB.ViewModel.MainViewModel  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��350 �6   �� 5      $��* �6   .+�5   
   �  � RowDefinitions 5      �� 5      $��35 �6    �� 5      $��* �6    �� 5      $	��135 �6    .+�5      ��  �� Orientation$ 
Horizontal=�6   $��15,0,0,0q�62   .+�5      !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.1.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$
 List=�6   $��16��6+   $
��Left=�67   $��Center=�6R   $��0,8,0,0q�6m      
Foreground �#D5CFF56~   �� 5      $��	ACCOUNTS:��6   ���#D5CFF5$��20(�5!      $(��"Bahnschrift SemiBold SemiCondensed)�5"      $
��Bold"�6L   $��5,10,0,0q�5#      5$      �� 5'      
������ 
������ $��0q�6J   $��1��6^   .@�5(      �� $��
10,10,50,0q�6   $	��125��63   $	��245��6@   ���#1F1B24 � Cursor$ Arrow��6a   {�.  $	��0.5q�6�   
���   �.��5)      �  5*      �� 5+      $��40 �6,   �� 5,      $��25 �6,   �� 5-      $��* �6,   .+�5/      � $��0��6    50      �� 51   "   $	��175 �63   .+�53      �� $��Current Account��6(   ���#D5CFF5$��18(�55   $   $(��"Bahnschrift SemiBold SemiCondensed)�56   $   $
��Bold"�6T   $��0,15,0,0q�57   $   58      � 59      $��1��6    5:      �� 5;   "   $��50 �63   �� 5<   "   $	��80* �63   �� 5=   "   $��30 �63   .+�5?      �� $��0��6)   .+�5@   "   �� $��Balance:��6,   ���#D5CFF5$��15(�5B   (   $(��"Bahnschrift SemiBold SemiCondensed)�5C   (   $
��Bold"�6X   $��0,5,0,0q�5D   (   5E      �� 5F      $��1��6)   .+�5H   "   �� ���	#FFFF005D$��25(�5J   (   $(��"Bahnschrift SemiBold SemiCondensed)�5K   (   $
��Bold"�6X   $��3,-4,0,0q�5L   (   ��5H   ,   �� *.,CurrentUserAccount.STRCurrentAccount_Balance+5L   (   5M      �� 5N      $��2��6)   .+�5P   "   �� ���#D5CFF5$��14(�5R   (   $(��"Bahnschrift SemiBold SemiCondensed)�5S   (   $
��Bold"�6X   $��0,5,0,0q�5T   (   ��5P   ,   �� *,*CurrentUserAccount.CurrentAccount_Currency+5T   (   5U      5V      � 5W      $��2��6    5X      �� 5Y   "   $��35 �63   �� 5Z   "   $��* �63   .+�5\      �� $��0��6)   .+�5]   "   �� $��IBAN:��6,   ���#D5CFF5$��15(�5_   $   $(��"Bahnschrift SemiBold SemiCondensed)�5`   $   $
��Bold"�6T   $��0,-3,0,0q�5a   $   5b      �� 5c      $��1��6)   .+�5e   "   �� ���#D5CFF5$��15(�5g   $   $(��"Bahnschrift SemiBold SemiCondensed)�5h   $   $
��Bold"�6T   $��0,-3,0,0q�5i   $   ��5e   ,   �� *(&CurrentUserAccount.CurrentAccount_IBAN+5i   $   5j      5k      5l      5m      �� 5n      $��
10,10,50,0q�6   $	��125��63   $	��245��6@   ���#1F1B24$ Arrow��6a   {�.  $��1q�6�   
���  ��.��5o      �  5p      �� 5q      $��40 �6,   �� 5r      $��25 �6,   �� 5s      $��* �6,   .+�5u      � $��0��6    5v      �� 5w   "   $��55 �63   �� 5x   "   $��* �63   .+�5z      �� $��0��6)   .+�5{   "   �� $��Deposit��6,   ���#D5CFF5$��18(�5}   $   $(��"Bahnschrift SemiBold SemiCondensed)�5~   $   $
��Bold"�6T   $��0,15,0,0q�5   $   5�      �� 5�      $��1��6)   $��40��69   $	��Top=�6E   .+�5�   "     $
 Lock=�6/   $��15��6;   
 �  ��$��5,17,0,0q�6X   $
��Left=�6j   5�      5�      � 5�      $��1��6    5�      �� 5�   "   $��50 �63   �� 5�   "   $	��80* �63   �� 5�   "   $��30 �63   .+�5�      �� $��0��6)   .+�5�   "   �� $��Balance:��6,   ���#D5CFF5$��15(�5�   (   $(��"Bahnschrift SemiBold SemiCondensed)�5�   (   $
��Bold"�6X   $��0,5,0,0q�5�   (   5�      �� 5�      $��1��6)   .+�5�   "   �� $��77777.00��6,   ���	#FFFF005D$��25(�5�   (   $(��"Bahnschrift SemiBold SemiCondensed)�5�   (   $
��Bold"�6X   $��3,-4,0,0q�5�   (   5�      �� 5�      $��2��6)   .+�5�   "   �� $	��RON��6,   ���#D5CFF5$��14(�5�   (   $(��"Bahnschrift SemiBold SemiCondensed)�5�   (   $
��Bold"�6X   $��0,5,0,0q�5�   (   5�      5�      � 5�      $��2��6    5�      �� 5�   "   $��35 �63   �� 5�   "   $��* �63   .+�5�      �� $��0��6)   .+�5�   "   �� $��IBAN:��6,   ���#D5CFF5$��15(�5�   $   $(��"Bahnschrift SemiBold SemiCondensed)�5�   $   $
��Bold"�6T   $��0,-3,0,0q�5�   $   5�      �� 5�      $��1��6)   .+�5�   "   �� $#��RO49 UGBI 0000 6089 4444 0RON��6,   ���#D5CFF5$��15(�5�   $   $(��"Bahnschrift SemiBold SemiCondensed)�5�   $   $
��Bold"�6T   $��0,-3,0,0q�5�   $   5�      5�      5�      5�      5�      5�      � 5�   
   $��1��6    5�      �� 5�      $��35 �6    �� 5�      $��* �6    �� 5�      $	��250 �6    .+�5�      �� $��0��6   $ 
Horizontal=�5�      $��LeftToRight=�5�      
������ $��10,0,0,0q�5�      .+�5�        $ MoneyBillTransfer=�6   $��25��68    �	#FFD5CFF5$��0,5,0,0q�6[   �� 5�      $��RECENT TRANSACTIONS :��6   ���#D5CFF5$��20(�5�      $(��"Bahnschrift SemiBold SemiCondensed)�5�      $
��Bold"�6L   $��5,10,0,0q�5�      5�      � 5�      $��1��6   .+�5�      �� -   5         ��Name$ 	listView1��5�   �   $��Disabled=�6   ��.  $��Hidden=�6u   
������ 
������ $��0q�6,  $	��646��6k  $	��280��6w  $��LeftToRight=�6�  ��6�   �� *%#CurrentUserAccount.Lista_tranzactii+��5�      �� 5�      .R�5�      �� 
���   �$	��0.6q�6;   ���#1F1B24 �� CornerRadius$ 10��6f   ._�5�   "   � $��50��6'    5�   &   �� 5�   *   $��20 �6;   �� 5�   *   $	��200 �6;   �� 5�   *   $	��200 �6;   �� 5�   *   $	��100 �6;   �� 5�   *   $	��115 �6;   .+�5�   &   �� $��Center=�6N   $��Center=�6i   ���#D5CFF5$��0,3,0,0q�6�   $(��"Bahnschrift SemiBold SemiCondensed)�6�   $
��Bold"�6�   $��10(�6�   ��61   �� *IDFereastra+6�   �� 5�   &   $��1��61   $��Center=�6_   $��Center=�6z   ���#D5CFF5$(��"Bahnschrift SemiBold SemiCondensed)�6�   $
��Bold"�6�   ��6A   �� *StrTranDate+6�   �� 5�   &   $��2��61   $��Center=�6\   $
��Left=�6w   ���#D5CFF5$(��"Bahnschrift SemiBold SemiCondensed)�6�   $
��Bold"�6�   ��6A   �� *	NumeSursa+6�   �� 5�   &   $��3��61   $ 
Horizontal=�6A   .+�5�   *     $
 play=�67   $��10��6C    �#D5CFF5$��-100,0,30,0q�6c   �� 5�   *   $��Center=�6V   $
��Left=�6q   ���#D5CFF5$(��"Bahnschrift SemiBold SemiCondensed)�6�   $
��Bold"�6�   ��66   �� *NumeDestinatie+6�   5�   '   �� 5�   &   $��4��61   $ 
Horizontal=�6A   .+�5�   *   �� $��Center=�6J   $
��Left=�6e   ���	#FFFF005D$(��"Bahnschrift SemiBold SemiCondensed)�6�   $
��Bold"�6�   ��64   �� *Semn+6�   �� 5�   *   $��Center=�6M   $
��Left=�6h   ���	#FFFF005D$(��"Bahnschrift SemiBold SemiCondensed)�6�   $
��Bold"�6�   ��65   �� *amount+6�   �� 5�   *   $�� ��65   �� 5�   *   $��Center=�6S   $
��Left=�6n   ���	#FFFF005D$(��"Bahnschrift SemiBold SemiCondensed)�6�   $
��Bold"�6�   ��65   �� *TextCurrency+6�   5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      