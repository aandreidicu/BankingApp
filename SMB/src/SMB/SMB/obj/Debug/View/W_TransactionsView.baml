   M S B A M L   `   `   `  ����>  :SMB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:SMB.ViewModelSMB.ViewModel  5      #clr-namespace:SMB.ViewSMB.View  5      !    SMB.View.W_TransactionsView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1	viewModelclr-namespace:SMB.ViewModel     5      (localclr-namespace:SMB.View     5      X TFontAwesome.Sharp, Version=6.1.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      
������   � DataContext  5      !   SMB.ViewModel.MainViewModel  5   
   .��5      � .+�5   
   ��  �� Orientation$ Vertical=�6   .+�5      �� $ 
Horizontal=�6   .+�5      �� $��50��6   $��7,0,0,0q�6'   $��ID��68    �� TextAlignment$ Center=�6B   $��Center=�6Y   $��Stretch=�6t   ���#D5CFF5$(��"Bahnschrift SemiBold SemiCondensed)�6�   $
��Bold"�6�   $��15(�6�   �� 5      $	��300��6   $��0,0,0,0q�6(   $��TRANSACTION DATE��69   $ Center=�6Q   $��Center=�6h   $��Stretch=�6�   ���#D5CFF5$(��"Bahnschrift SemiBold SemiCondensed)�6�   $
��Bold"�6�   $��15(�6�   �� 5      $	��100��6   $��	-25,0,0,0q�6(   $��SOURCE��6;   $ Center=�6I   $��Center=�6`   $��Stretch=�6{   ���#D5CFF5$(��"Bahnschrift SemiBold SemiCondensed)�6�   $
��Bold"�6�   $��15(�6�   �� 5      $	��100��6   $��12,0,0,0q�6(   $��DESTINATION��6:   $ Center=�6M   $��Center=�6d   $��Stretch=�6   ���#D5CFF5$(��"Bahnschrift SemiBold SemiCondensed)�6�   $
��Bold"�6�   $��15(�6�   �� 5      $	��200��6   $��	-20,0,0,0q�6(   $��AMOUNT��6;   $ Center=�6I   $��Center=�6`   $��Stretch=�6{   ���#D5CFF5$(��"Bahnschrift SemiBold SemiCondensed)�6�   $
��Bold"�6�   $��15(�6�   �� 5      $	��230��6   $��15,0,0,0q�6(   $��DESCRIPTION��6:   $ Center=�6M   $��Center=�6d   $��Stretch=�6   ���#D5CFF5$(��"Bahnschrift SemiBold SemiCondensed)�6�   $
��Bold"�6�   $��15(�6�   5      �� 5   
   -   5         ��Name$ 	listView1��5   �   $��Hidden=�6   
������ 
������ $��0q�6�   ��6G   �� *%#CurrentUserAccount.Lista_tranzactii+��5      �� 5      .R�5      �� 
���   �$	��0.6q�61   ���#1F1B24 �� CornerRadius$ 10��6\   ._�5       � $��60��6    � ColumnDefinitions 5!      �� 5"   "   $��50 �63   �� 5#   "   $	��300 �63   �� 5$   "   $	��100 �63   �� 5%   "   $	��100 �63   �� 5&   "   $	��200 �63   �� 5'   "   $	��230 �63   .+�5+      �� $��Center=�6G   $��Center=�6b   ���#D5CFF5$��0,3,0,0q�6�   $(��"Bahnschrift SemiBold SemiCondensed)�6�   $
��Bold"�6�   $��15(�6�   ��6)   �� *IDFereastra+6�   �� 5-      $��1��6)   $��Center=�6T   $��Center=�6o   ���#D5CFF5$(��"Bahnschrift SemiBold SemiCondensed)�6�   $
��Bold"�6�   $��15(�6�   ��69   �� *
tranDate+6�   �� 5/      $��2��6)   $��Center=�6T   $
��Left=�6o   ���#D5CFF5$(��"Bahnschrift SemiBold SemiCondensed)�6�   $
��Bold"�6�   $��15(�6�   ��69   �� *	NumeSursa+6�   �� 51      $��3��6)   $ 
Horizontal=�69   .+�53   "   !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.1.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$
 play=�6/   $��10��6;      
Foreground �#D5CFF5$��
-20,0,15,0q�6[   �� 55   "   $��Center=�6N   $
��Left=�6i   ���#D5CFF5$(��"Bahnschrift SemiBold SemiCondensed)�6�   $
��Bold"�6�   $��15(�6�   ��6.   �� *NumeDestinatie+6�   56      �� 58      $��4��6)   $ 
Horizontal=�69   .+�59   "   �� $��Center=�6B   $
��Left=�6]   ���	#FFFF005D$(��"Bahnschrift SemiBold SemiCondensed)�6�   $
��Bold"�6�   $��15(�6�   ��6,   �� *Semn+6�   �� 5:   "   $��Center=�6E   $
��Left=�6`   ���	#FFFF005D$(��"Bahnschrift SemiBold SemiCondensed)�6�   $
��Bold"�6�   $��15(�6�   ��6-   �� *amount+6�   �� 5;   "   $�� ��6-   �� 5<   "   $��Center=�6K   $
��Left=�6f   ���	#FFFF005D$(��"Bahnschrift SemiBold SemiCondensed)�6�   $
��Bold"�6�   $��15(�6�   ��6-   �� *TextCurrency+6�   5=      �� 5>      $��5��6(   $��Center=�6V   $
��Left=�6q   ���	#FF9BEF3A$(��"Bahnschrift SemiBold SemiCondensed)�6�   $
��Bold"�6�   $��15(�6�   ��68   �� *tDescription+6�   5@      5A      5B      5E      5F      5I      5J      