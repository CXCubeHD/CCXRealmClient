   M S B A M L   `   `   `  ���� I  ECCXRealmClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:CCXRealmClientCCXRealmClient      CCXRealmClient.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:CCXRealmClient     -     � Title$  CCXRealmClient��$	��600��$	��350��
���   � � AllowsTransparency .  � WindowStyle$
 None=����	#00000000 � Icon$ 
ICON64.ico�� � Topmost . .��� -    �Name$ Window��$	��350��$	��600��.+�� -   $ Content��.+�� -   $ Window_Background��.+��� ���	#E5000000 �� RadiusX$ 20�� �� RadiusY$ 20��� -   $ Window_2��.+�� -   $ WindowTopBorder��$��30��$	��Top=����	#00000000.+��� -    ��Name$ StackPanel_ControlButtons��$��Right=�	 �� Orientation$	 
Horizontal=�.+��� -   
 ��Name$
 MinimizeRect��
�������$��16��$��16��$ 10��$ 10��$��0,0,5,0q��� -	   $
 	CloseRect�����	#FF9600FF$��16��$��16��$ 10��$ 10��$��0,0,15,0q��� -
   $ Stackpanel_Titelbar��$
��Left=�$��0q�$��30��$	 
Horizontal=�.+��� $��REALM Client��
�������$��10,0,0,0q�$
��Bold"���Z� �� $��v0.1.1 BETA��
�������$��-5,0,0,0q�$
��Bold"���Z� �� $��by CXCubeHD��
�������$��-5,0,0,0q�$
��Bold"���Z� � -   $ UI��$��	-1,30,0,0q�.+�� .+��� $��50��$	 
Horizontal=�$	��Top=�$��10,0,-241,0q�.+��� ���	#FF9600FF$��Game Status:��$��0q���Z� �� -    ��Name$ label_gamestatus��
���  ��$��5,0,0,0q� J� RenderTransformOrigin$ 0.833,0.743&�$��	Not Found����Z� �� $��50��$	��Top=�$	 
Horizontal=�$��
10,25,10,0q�.+��� ���	#FF9600FF$��0q�$ 0.833,0.743&�$��50��$
��Bold"�$��Position (X,Y,Z)����Z� �� -   $ label_positionX�����	#FF0096FF$��0q�$ 0.833,0.743&�$��X��$
��Bold"�$��80��$
��Left=���Z� �� -   $ label_positionY�����	#FF0096FF$��0q�$ 0.833,0.743&�$��X��$
��Bold"�$��70��$
��Left=���Z� �� -   $ label_positionZ�����	#FF0096FF$��0q�$ 0.833,0.743&�$��X��$
��Bold"�$��80��$
��Left=���Z� � -   $ module_shower��$��	0,60,0,10q�.+��� $��
10,0,10,10q���Z� ��Z� ��Z�  � 	Resources  �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� Triggers P� Property P� Value �� 
TargetName��%&  '��       �� " ��.���  � �� �� " ��.R�� $ Panel��.+��� $ ContentSite��$��Center=�$��Center=�$��Header��$
��10,2q� P�  �@��
IsSelected . . ��� $ Panel�� � �� �	#33FFFFFFP�  �@��
IsSelected .  . ��� $ Panel�� Z�  � ��.@��� $
��Move��
���������Z� .��� .+��� $	��Top=�$��
10,10,10,0q�.+��� -    ��Name$% checkbox_trigger_module_airjump��$��Airjump��$	��Top=�
�������
����������	#FF9600FF$��20(�$��0q��� -   $# checkbox_trigger_module_speed��$��Speed��$	��Top=�
�������
����������	#FF9600FF$��20(�$��0,10,0,0q��� -    ��Name$" slider_valueset_module_speed�� � Maximum$	 100Q�
�������
�������$��0,5,0,0q�$��30�� � SmallChange$ 5Q� � LargeChange$ 10Q� �� TickFrequency$ 5Q� �� TickPlacement$ BottomRight=� �� IsSnapToTickEnabled . ��Z� �� -   $ label_value_module_speed��$��Speed��
��������� $��Walk: 0.1  Run: 0.13��
�������$��	0,-26,0,0q�$��Right=��� ���	#7FFFFFFF$��2q� �� CornerRadius$ 10���� $��Combat��
���������Z� .��� .+��� $	��Top=�$��
10,10,10,0q�.+��� -   $&  checkbox_trigger_module_rapidhit��$��RapidHIT��$	��Top=�
�������
����������	#FF9600FF$��20(�$��0,0,20,0q��� ���	#7FFFFFFF$��2q�$ 10���� $��Player��
���������Z� .��� .+��� $	��Top=�$��
10,10,10,0q�.+��� -   $$ checkbox_trigger_module_nofall��$��Nofall��$	��Top=�
�������
����������	#FF9600FF$��20(�$��0q�� -   $+ %button_trigger_module_selfdestruction��$��30��$
��0,10q�.+��� -   ���	#FF9600FF$��30��
���   �$	��Top=�$��0q�$ 10��$ 10���� -   $��Self Destruction��$	��Top=�$��0q�$��14(�$
��Bold"�$��Center=�
�������$��30����Z� �� ���	#7FFFFFFF$��2q�$ 10���� $
��Game��
���������Z� .��� .+��� ���	#7FFFFFFF$��2q�$ 10���� $��TP��
�������$��30����Z� .��� .+��� ���	#7FFFFFFF$��2q�$ 10���� $:��4X, Y, Z         use ~ to mark youre relativ position��$	��Top=�$��20,10q�$��30��
�������$
��Bold"�$��Center=���Z� �� $��50��$	��Top=�$��
10,35,10,0q�$	 
Horizontal=�.+��� $��40��  �� TextWrapping$
  Wrap=�$	��Top=����	#FF9600FF
�������$	��100��$��2,5,0,5q�$��20(�! �� 
CaretBrush
! �  ��" �� 	UndoLimit$" 10��# �� 	MaxLength$# 11����Z� �� $��40��$
  Wrap=�$	��Top=����	#FF9600FF
�������$	��100��$��1,5,0,0q�$��20(�
! �  ��$" 10��$# 5����Z� �� $��40��$
  Wrap=�$	��Top=����	#FF9600FF
�������$	��100��$��1,5,2,0q�$��20(�
! �  ��$" 10��$# 11����Z� �� -   $
 button_trigger_module_tp�����	#FF9600FF$��30��
���   �$	��Top=�$��40,100,40,0q�$ 10��$ 10���� -   $$ label_button_trigger_module_tp��$��Teleport��$	��Top=�$��40,100,40,0q�$��14(�$
��Bold"�$��Center=�
���������Z� �� $
��More��
���������Z� .��� .+��� ���	#7FFFFFFF$��2q�$ 10���� $��2q����	#7F9600FF$ 20��