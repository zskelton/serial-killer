   M S B A M L   `   `   `  ����G  CSerialKiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:SerialKillerSerialKiller  5   	   D @AdonisUI, Version=1.16.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:AdonisUI;assembly=AdonisUIAdonisUI 5   	       SerialKiller.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:SerialKiller     5   	   =adonisUi(clr-namespace:AdonisUI;assembly=AdonisUI     5   	   -   5          � Title$  
MainWindow��5	   	   $	��662��6   $
��1054��6)    � WindowStartupLocation$ CenterScreen=�5
   	   ��5      �� 5   
    �� 
TargetType" �6    �� BasedOn# [B�6$   .��5      � .+�5   
   ]� ��.  .+�5      o� $	��Top=�6   .@�5      m� $��_File��6   .@�5      m� -   5         m�Name$ mitem_Connect��5      $��_Connect��66   6H   m� 5      -   5        $ mitem_Upload��5      $��_Upload File��65   6K   �� 5      m� 5      -   5        $ 
mitem_Exit��5      $��_Exit��63   6B   5      m� 5      $��_Edit��6   .@�5      m� -   5        $ mitem_Properties��5      $��_Properties��69   6N   5      m� 5      $��_Help��6   .@�5      m� -   5        $ mitem_About��5      $��_About��64   6D   5      5      �� 5      $��Bottom=�6   $��30��60   .@�5      �� $��30��6    .��5       �� -   5         ��Name$ 	lblStatus��5        5!      5"      �� 5#      -   5         ��Name$ txt_Terminal��5#   -   $��Right=�6   $	��571��6C    �� TextWrapping$
 Wrap=�6P   $	��Top=�6�   $��20q�6�   $	��771��6�    �� AcceptsReturn . "	 �� VerticalScrollBarVisibility$
	 Auto=�6�   $
��Left=�6�   $	��Top=�6  ��6d   �� 
 �� Path$
 terminalText� �� Mode$ TwoWay=�65  � 5$      $��581.04��6   $	��Top=�6#   $	��275��6;    � ShowGridLines .  � ColumnDefinitions 5%      �� 5&      $
��auto �6'    � RowDefinitions 5(      �� 5)      $��1* �6$   �� 5*      $��2* �6$   �� 5+      $��2* �6$   �� 5,      $��1* �6$   .+�5.      �� $��1��6   $��0��6*   $
��Left=�6:   $
��63.2��6U   $	��Top=�6c   $	��275��6{    �� Orientation$ 
Horizontal=�6�   $��
20,-4,20,0q�6�   .+�5/      �� -	   5         ��Name$ lbl_Port��5/      $��Port:��6.   $
��63.2��6>   $��Center=�6L   $��0,0,-112.994,0q�6g   $
��Left=�6   $��75��6�   $��Center=�6�   �� 50      -
   5        $ txt_Port��50      $��34��60   $
 Wrap=�6<   $
��COM3��6P   $��Center=�6\   $��0,14,-195,15q�6w   $	��135��6�   $��Right=�6�   $
��Left=�6�   51      �� 52      $��1��6   $��0��6*   $��115.48��6:   $	��260��6J   $��20,73.2,20,5q�6V   $��Center=�6l   $��Center=�6�   $ 
Horizontal=�6�   .+�53      �� -   5         ��Name$ btn_Connect��53      $��Connect��62   $��25��6D   $	��Top=�6P   $��
0,0,-150,0q�6h   $��Center=�6�   � 54      -   5         �Name$ bar_Connect��54   "   $��25��67   $��Center=�6C   $��0,45,-100,45q�6^    � Value$ 50Q�6t   55      �� 56      -   5        $ btn_Stop��56      $
��Stop��6+   $
��Left=�6:   $��30��6U   $��60,49.48,0,0q�6a   $��2��6w   $	��Top=�6�   $��85��6�   {�.  6�   57      58      59      5:      