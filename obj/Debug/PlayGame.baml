   M S B A M L   `   `   `  ����a  ]PresentationFramework.Aero, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes  5      I ESeriousGameWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:SeriousGameWPF.StaticSeriousGameWPF.Static 5         SeriousGameWPF.PlayGame   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ]ThemesJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero     5      1s#clr-namespace:SeriousGameWPF.Static     5      -   5          N� Title$  PlayGame��5
       � 	Resources 5         DataTemplate1+  %SeriousGameWPF.Static.MainMenuHandler   	DebugMode �� Source �� Mode �� Left
 �� Top  ItemsPanelTemplate1 K� IsItemsHost  ButtonFocusVisual �� Property	 �� Value
 �� StrokeDashArray J� SnapsToDevicePixels  ButtonNormalBackground �� EndPoint �� 
StartPoint � Color � Offset  ButtonNormalBorder �� Color  ButtonStyle1 �� 
TargetType �� 
TargetType � 	Resources  Key �� TargetProperty �� 
TargetName O� KeyTime O� Value9  3System.Windows.Media.Animation.EasingDoubleKeyFrame+   %Microsoft.Windows.Themes.ButtonChrome  Name J� Opacity   BorderBrush   RenderPressed �� IsDefaulted   RenderDefaulted   
Background �� Triggers  :� RoutedEvent! :� 
SourceName  OnMouseLeave1" ��Name  OnMousEnter1# P� Property$ P� Value% �� 
TargetName��%�  &	        &	 C    &	 w    &	 !    &	     &	 8    7  7  7  7  �� 5      .R�5      (� -   5        ��5      �� *ViewboxHeight+��68   �� *ViewboxWidth+��6W   �� *Margin+.��5      �� 
���   ���6-   �� # Z $ OneWay=�._�5      �� ��6   �� *ViewboxHeight+��6>   �� *ViewboxWidth+��6]   �� *
Background+.+�5      �� ��6    �� *
ImageUri+��6<   �� *ViewboxHeight+��6]   �� *ViewboxWidth+�� 5      ��6$   �� *TextFontSize+��6F   �� *TextContent+ 6c   �� *
TextLeft+ 6�   �� *	TextTop+5      5      5      5      �� 5      .R�5      ��  . 6   5      �� 5      .�5      ��  � ��	 5      �� 5      .R�5      �� $	
 1 2R�6   $��1��6(   #��� ��6<    . $��2q�6�   5       5"      5#      �� 5$      $	 0,1&�67   $	 0,0&�6F   .��5%      � $ #F3F3F3��6   $ 0Q�6"   � 5&      $ #EBEBEB��6   $	 0.5Q�6"   � 5'      $ #DDDDDD��6   $	 0.5Q�6"   � 5(      $ #CDCDCD��6   $ 1Q�6"   5)      �� 5*      $ 	#FF707070��6/   �� 5+      " ��6   .�5,      ��  � ��8	   6"   �� 5-       � ��8	  6#   �� 5.       � ��$	 1q�6'   �� 5/       � ��#	 � ��6"   �� 50       � ��$	 Center=�62   �� 51       � ��$	 Center=�60   �� 52       � ��$	 1q�6   �� 53       � ��	 54      �� 55      " ��6    56      ���� 57   	   OnMouseLeave1 .��58   
   U� $ (UIElement.Opacity)�6(   $ Chrome��6X   .\�59      �� $ 0:0:0.5��6    $
 0.65Q�62   5:      5;   
   �� 5<   	   OnMousEnter1 .��5=   
   U� $ (UIElement.Opacity)�6(   $ Chrome��6X   .\�5>        $ 0:0:0.5��6    $ 1Q�62   5?      5@   
   5A   	   .R�5B        $ Chrome��6+   $
 0.65Q�6    �	#FF1760A8# z��6S   # z 6    .  5C   	   �� 5D   
   $	 0,1&�6   $	 0,0&�6-   .��5E      � $ 	#FF88A0F1��6   $ 0.004Q�6*   � 5F      $ 	#FF8194F3��6   $	 0.5Q�6*   � 5G      $ 	#FF859FF7��6   $ 0.263Q�6*   � 5H      $ 	#FF3D68F5��6   $ 1Q�6*   � 5I      $ 	#FF8295F1��6   $ 0.759Q�6*   5J      ._�5L   	   �� #��z��6   #��z��6]   ��. # z 6�   #��z��6�   5M   	    5N      :� 5O   	   $  Mouse.MouseLeave��6   $! Chrome��65   .[�5P   
   �� 8�� 6   5Q   
   :� 5R   	   $  Mouse.MouseEnter��6   $! Chrome��65   .[�5S   
   �� $"" OnMousEnter1_BeginStoryboard��6   8�� 6@   5T   
   P� 5U   	   # �@J�IsKeyboardFocused$ . . �5V   
   �� $% Chrome��6,    �@ RenderDefaulted	 . 6@   5W   
   P� 5X   	   # �@d�	IsChecked$
$ trueY�63   . �5Y   
   �� $% Chrome��6*    �@ RenderPressed	 . 6>   5Z   
   P� 5[   	   # � {�$ .  . �5\   
   ��  � ��	 �#ADADAD6'   5]   
   5_      5a      5b      5c      .��5d      (� .��5e      �� -   5        & ��Name$& PlayArea��5e      $	��800��6?   $	��600��6K   ��6   �� *
Background+.+�5f      �� #���   68   #���  6g   ��6   �� *ActiveContent+6g   �� 5g      -   5        ' ��Name$' 	BigButton��5g      $��Ellenőrzés��6   $��62��64   $	 291��6@   $	 528��6R   $	��229��6c   #���  6o   $��Arial)�6�   $
��Bold"�6�   $��Italic$�6�   $��16(�6�   ��5h      �� 5i      $ 0.5,1&�6   $ 0.5,0&�6,   .��5j      � $ White��6   $ 0Q�6#   � 5k      $ 	#FFFBFBFB��6   $ 1Q�6'   5l      5n      5o      5p      5r      