   M S B A M L   `   `   `  ����I  ESeriousGameWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:SeriousGameWPF.StaticSeriousGameWPF.Static  5      /clr-namespace:SeriousGameWPFSeriousGameWPF  5          SeriousGameWPF.MainMenu   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1s#clr-namespace:SeriousGameWPF.Static     5      *lclr-namespace:SeriousGameWPF     5        N� Title$  MainMenu��5
       � 	Resources 5         DataTemplateNoImage  MainMenuViewBoxStyle1  MainMenuBorderStyle1  MainMenuGridStyle1 �� TextAlignment  MainMenuTextBlockStyle1+   %SeriousGameWPF.Static.MainMenuHandler   GameMenuFontSize �� Source �� Mode ��Name J� Opacity � ToolTip	 � Triggers
 :� RoutedEvent �� 
TargetName �� TargetProperty	 W� To g� Duration  DataTemplateBasic��%�  &	        &	 P    �� 5      .R�5      (� -   5        $	��200��5      $	��400��6   $��Center=�6&   $��Center=�6C   #���  6x   ��6^   �� *Margin+.��5      �� $
��Left=�6   $	��200��6(   $	��400��65   #���  6A   ._�5      � #���  6   .+�5      �� $ Center=�6z   $��Center=�6�   $��Center=�6�   $��10q�6�   #���  6�   $
��Auto��6  $
��Auto��6+  ��6$   �� # Z $ OneWay=���6�   �� *Name+6+  �� 5      $ myimg��6   -   5        $y�Hidden=�5      $	��200��61   $	��200��6>   $
��Left=�6J   $��Uniform=�6�   $
 0.75Q�6�   ��6e   �� *
ImageUri+ 6�   �� *Name+	 5   	   :� 5   
   $
 UIElement.MouseEnter��6   .[�5      �� .��5      �� .��5      W� $ myimg��6    $ Opacity�5      $	 1.0X�5      $ 0:0:1D�6   5      5      5      :� 5   
   $
 UIElement.MouseLeave��6   .[�5      �� .��5       �� .��5!      W� $ myimg��6    $ Opacity�5"      $
 0.75X�5#      $ 0:0:1D�6   5%      5&      5'      5)   	   5*      5+      5,      5-      �� 5.      .R�50      (� -   5        $	��200��50      $	��400��6   $��Center=�6&   $��Center=�6C   #���  6x   ��6^   �� *Margin+.��51      �� $
��Left=�6   $	��200��6(   $	��400��65   #���  6A   ._�52      � #���  6   .+�53      �� $ Center=�6   $��Center=�6)   $��Center=�6D   $��205,10,10,10q�6w   #���  6�   $	��181��6�   $
��Auto��6�   ��6a   �� *Name+6�   �� 54      $ myimg��6   -   5        $	��200��54      $	��200��6+   $
��Left=�67   $��Uniform=�6�   $
 0.75Q�6�   ��6R   �� *
ImageUri+ 6n   �� *Name+	 55   	   :� 56   
   $
 UIElement.MouseEnter��6   .[�57      �� .��58      �� .��59      W� $ myimg��6    $ Opacity�5:      $	 1.0X�5;      $ 0:0:1D�6   5=      5>      5?      :� 5@   
   $
 UIElement.MouseLeave��6   .[�5A      �� .��5B      �� .��5C      W� $ myimg��6    $ Opacity�5D      $
 0.75X�5E      $ 0:0:1D�6   5G      5H      5I      5K   	   5L      5M      5N      5O      5P      .��5S      � .+�5V      �� -   5         ��Name$ Canvas1��5V      $	��Top=�6&   $
��Left=�6>   ��6Z   ��  �� Path$ CanvasHeight���6   �� $ CanvasWidth�.+�5Y      �� -   5         ��Name$ ItemControl0��5Y      $��0��6�   #���   6�   ��65   ��    	GamesList# Z $ OneWay=���5Z      �� 5[      .R�5\      �� 5]      5_      5�      5�      5�      