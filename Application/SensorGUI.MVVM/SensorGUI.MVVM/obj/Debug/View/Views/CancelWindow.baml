   M S B A M L   `   `   `  ����I  ESensorGUI.MVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:SensorGUI.MVVM.ViewsSensorGUI.MVVM.Views  5   	   '    !SensorGUI.MVVM.Views.CancelWindow   5   	   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:SensorGUI.MVVM.Views     5   	     � Title$  Messvorgang abbrechen��5   	   $	��180��6'   $	��300��64    � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterOwner=�5
   	    � Icon$ /View/Images/Error-96.png��5   	    � DataContext 5   	   ��    Locator �� Source# [   �� Path$ CancelWindow�.��5      �  � RowDefinitions 5   
   �� 5      $��* �6   6)   �� 5      $
��Auto �6   6,   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��/View/Images/Error-96.png��6   $��45��67   $��Center=�6C   $��20,0,5,0q�6^   6r   �� 5      $#��Messwerte wirklich verwerfen?��6   $��Center=�6<   6Y   5      �� 5   
   $��1��6   $ 
Horizontal=�6"   $��Right=�6;   .+�5      �� $��	0,0,10,10q�6   $
��35,5q�6(   ��67   �� *	OkCommand+.��6U   OK6Y   �� 5      $��	0,0,10,10q�6   $
��30,5q�6(   	 �� IsCancel	 . 
 �� 	IsDefault
 . .��6X   	Abbrechen6c   5      5      5      