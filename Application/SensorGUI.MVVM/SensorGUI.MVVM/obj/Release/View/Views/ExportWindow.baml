   M S B A M L   `   `   `  ���� I  ESensorGUI.MVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:SensorGUI.MVVM.ViewsSensorGUI.MVVM.Views  '    !SensorGUI.MVVM.Views.ExportWindow   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     4local"clr-namespace:SensorGUI.MVVM.Views       � 
ResizeMode$  NoResize=� � Title$ Exportieren...��$	��300��$	��400�� � Icon$  /View/Images/Export-96.png�� � DataContext ��    Locator �� Source# [   �� Path$ ExportWindow�.���  � RowDefinitions �� $��* ��� $
��Auto �.+��� .+��� $0��*Zu exportierende Messvorgänge auswählen:��$
��Left=�$��	10,10,0,5q�$��Medium"��� $��
10,5,10,10q�$	��150�� �� # [  $ 
MainWindow����� *MeasurementSeries+���� .R��� $��5,3,0,2q����� *Name+ d� 	IsChecked �� *ExportChecked+�� $��1�� �� Orientation$ 
Horizontal=�$��Right=�.+��� $��	0,0,10,10q�$
��35,5q�	 �� 	IsDefault	 . ���� *	OkCommand+.��OK�� $��	0,0,10,10q�$
��30,5q�
 �� IsCancel
 . .��	Abbrechen