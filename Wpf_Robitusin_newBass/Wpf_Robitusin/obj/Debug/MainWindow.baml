   M S B A M L   `   `   `  ����H  DWpf_Robitusin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Wpf_RobitusinWpf_Robitusin  5   	       Wpf_Robitusin.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Wpf_Robitusin     5   	     � Title$  Sign In��5   	   $	��300��6   $	��400��6&    � WindowStyle$
 None=�5	   	    � 
ResizeMode$ NoResize=�5
   	    � ShowInTaskbar .  � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��1��6!   $��2��61   $��45(�6E   $��0 0 0 10q�6S   $��Center=�6e   $��Light"�6�   	Sign In6�   �� 5   
   $��1��6   $��1��6!   $��1��61   $��20(�6E   $��0q�6S   $��Light"�6^   	Username:5       �� 5!   
   $��2��6   $��1��6!   $��1��61   $��20(�6E   $��0q�6S   $��Light"�6^   	Password:5#      �� 5%   
   -   5         ��Name$ tb_Login_Username��5%      $��1��6-   $��2��6:   $��1��6J   $��20(�6^   $
��Left=�6m   $	��100��6�   $	��100��6�   $��5 0 0 10q�6�   .��6�   5&      �� 5'   
   -   5        $ tb_Login_Password��5'      $��2��6-   $��2��6:   $��1��6J   $��20(�6^   $
��Left=�6m   $	��100��6�   $	��100��6�   $��5 0 0 20q�6�   .��6�   5(      �� 5*   
   -   5         ��Name$ bt_Login_LogOk��5*      $��3��6)   $��1��66   $��1��6F   $��Center=�6Z   $	��100��6w   $��40��6�   $��0 0 5 0q�6�   .��6�   Done5,      �� 5-   
   -   5        $ bt_Login_ToSignUp��5-      $��3��6,   $��2��69   $��1��6I   $��Center=�6]   $	��100��6z   $��40��6�   $��5 0 0 0q�6�   .��6�   	Sign Up5/      �� 51   
   -   5        $ bt_Login_Exit��51      $��0��6(   $��4��65   
���\\��$	��Top=�6\   $��Right=�6t   $��30��6�   $��30��6�   $��0 5 5 0q�6�   $��	ExtraBold"�6�   .��6�   X53      54      55      