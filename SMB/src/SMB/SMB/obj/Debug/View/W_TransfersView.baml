   M S B A M L   `   `   `  ����>  :SMB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:SMB.ViewModelSMB.ViewModel  5      #clr-namespace:SMB.ViewSMB.View  5          SMB.View.W_TransfersView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1	viewModelclr-namespace:SMB.ViewModel     5      (localclr-namespace:SMB.View     5      X TFontAwesome.Sharp, Version=6.1.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      
������   � DataContext  5      &    SMB.ViewModel.TransfersViewModel  5   
   .��5      � .+�5   
   �  � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $	��500 �6#   �� 5      $��* �6#   .+�5      � $��1��6    � RowDefinitions 5      �� 5      $��30 �6$   �� 5      $��* �6$   .+�5!      �� $��0��6   $��TRANSFER��6)   
�������$��10(�5#       $��
Montserrat)�5$       $��0��5%       $��Center=�5&       $��Center=�5'   !   $��0,0,0,0q�5(       �� 5)      $��1��6    �� Orientation$ Vertical=�6*   .+�5*      �� $
��IBAN��6    
�������$��12(�5,       $��Medium"�5-       $��
Montserrat)�5.       $��0,35,0,0q�5/       $��Center=�50       $��Center=�51       �� 52      -   5         ��Name$ txtIBAN��52      $��13(�54      $��Medium"�55      $��
Montserrat)�56      
������� �� 
CaretBrush
 �����
�������$��0,0,0,2q�5:      $��28��5;      $��Center=�5<      $
��Left=�5=      $��0,5,0,0q�5>      $��20,0,0,0q�5?      ��53      �� *Iban+ �� UpdateSourceTrigger$ PropertyChanged=�.��5?   1   ��5@      �� 5A       �� ImageSource$ /Imagini/user-icon2.png��6)    j� Stretch$
 None=�5B   )   	 j� 
AlignmentX$
	 Left=�5C   )   .��5D   .   5E      �� 5F      $��Amount��6    
�������$��12(�5H       $��Medium"�5I       $��
Montserrat)�5J       $��0,35,0,0q�5K       $��Center=�5L       $��Center=�5M       �� 5N      -   5        $ 	txtAmount��5N      $��13(�5P      $��Medium"�5Q      $��
Montserrat)�5R      
�������
 �����
�������$��0,0,0,2q�5V      $��28��5W      $��Center=�5X      $
��Left=�5Y      $��0,5,0,0q�5Z      $��20,0,0,0q�5[      ��5O      �� *Amount+$ PropertyChanged=�.��5[   1   ��5\      �� 5]      $ /Imagini/user-icon2.png��6)   $
 None=�5^   )   $
	 Left=�5_   )   .��5`   .   5a      �� 5c      $��Add Description��6    
�������$��12(�5e       $��Medium"�5f       $��
Montserrat)�5g       $��0,35,0,0q�5h       $��Center=�5i       $��Center=�5j       �� 5k      -   5        $ txtDescriere��5k      $��13(�5m      $��Medium"�5n      $��
Montserrat)�5o      
�������
 �����
�������$��0,0,0,2q�5s      $��28��5t      $��Center=�5u      $
��Left=�5v      $��0,5,0,0q�5w      $��20,0,0,0q�5x      ��5l      �� *Description+$ PropertyChanged=�.��5x   1   ��5y      �� 5z      $ /Imagini/user-icon2.png��6)   $
 None=�5{   )   $
	 Left=�5|   )   .��5}   .   5~      �� 5      ���#D7596D$��12(�5�       $��Medium"�5�       $��
Montserrat)�5�       $��0,10,0,0q�5�       $
��Wrap=�5�       ��5       �� *
ErrorMsg+5�       �� 5�      
��� � �$��12(�5�       $��Medium"�5�       $��
Montserrat)�5�       $��0,10,0,0q�5�       $
��Wrap=�5�       ��5�       �� *SuccesMessage+5�       �� 5�      -   5        
 ��Name$
 btn_Send��5�      $��0q�5�      $
��SEND��5�      
�������$��12(�5�      $��
Montserrat)�5�       � Cursor$
 Hand��5�      $��0,30,0,0q�5�      ��5�      �� *SendCommand+��5�      �� 5�       �� 
TargetType" ��6$   .�5�   "   ��  �� Property � �� �� Value �#462AD86?    �� Triggers 5�   "   P� 5�   &    P� Property �@J�IsMouseOver P� Value . . �5�   *   ��  � �� �#28AEED6G   5�   '   5�      ��5�      �� 5�       �� 
TargetType" ��6.   .R�5�   "   �� $	��150��6)   $��40��65    �� CornerRadius$ 20��5�   )   #��z��5�   )   ._�5�   &   �� $��Center=�67   $��Center=�5�   7   5�   #   5�      5�      5�      5�      5�      5�      5�      