   M S B A M L   `   `   `  ����I  ESeriousGameWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:SeriousGameWPF.StaticSeriousGameWPF.Static  5   	   /clr-namespace:SeriousGameWPFSeriousGameWPF  5   	       SeriousGameWPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   1s#clr-namespace:SeriousGameWPF.Static     5   	   *lclr-namespace:SeriousGameWPF     5   	   -   5          �Name$  
mainWindow��5   	   $	��400��5   	   $	��400��6    � Title$ 
MainWindow��5   	   ���	#FF2C2C2C � WindowStyle$ SingleBorderWindow=�6  
 � Tag 5      �� ��5      �� +   %SeriousGameWPF.Static.MainMenuHandler   GameWindowHeight �� Source# Z  �� Mode$ OneWay=���6p   ��    GameWindowWidth# Z $ OneWay=� � 	Resources 5	       
  FadeIn	 �� TargetProperty
 �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  FadeOut  OnMouseLeaveMenu  OnMouseEnter1Menu  OnMouseLeaveMenu2  OnMouseEnter1Menu2  OnMouseLeaveMenu3  OnMouseEnter1Menu3��%j  &	        &	 �     &	 t    &	     &	 �    &	 ?    &	 �    &	 {    �� 5      .��5      U� $	 (UIElement.Opacity)�6&   $
 frame��6V   .\�5   	     $ 0��6   $ 0Q�6*     5   	   $ 0:0:0.5��6   $ 1Q�60   5   	   5      �� 5   
   .��5      U� $	 (UIElement.Opacity)�6,   $
 frame��6\   .\�5        $ 0��6'   $ 1Q�63     5      $ 0:0:0.5��6'   $ 0Q�69   5      5      �� 5   
   .��5      U� $	 (UIElement.Opacity)�6)   $
 menuItem��6Y   .\�5        $ 0:0:0.5��6!   $ 0.495Q�63   5      5      �� 5   
   .��5      U� $	 (UIElement.Opacity)�6)   $
 menuItem��6Y   .\�5        $ 0:0:0.5��6!   $ 1Q�63   5      5       �� 5!   
   .��5"      U� $	 (UIElement.Opacity)�6,   $
 menuItemBack��6\   .\�5#        $ 0:0:0.5��6'   $ 0.495Q�69   5$      5%      �� 5'   
   .��5(      U� $	 (UIElement.Opacity)�6,   $
 menuItemBack��6\   .\�5)        $ 0:0:0.5��6'   $ 1Q�69   5*      5,      �� 5-   
   .��5.      U� $	 (UIElement.Opacity)�6,   $
 menuItemBacktoMode��6\   .\�5/        $ 0:0:0.5��6'   $ 0.495Q�69   50      51      �� 52   
   .��53      U� $	 (UIElement.Opacity)�6,   $
 menuItemBacktoMode��6\   .\�54        $ 0:0:0.5��6'   $ 1Q�69   55      57      59       � Triggers 5:      :� 5?       :� RoutedEvent$ Mouse.MouseEnter��6    :� 
SourceName$ menuItem��60   .[�5@      �� -   5         ��Name$# MenuHighlight_BeginStoryboard��5@      #��[ 6<   5A      :� 5B      $ Mouse.MouseLeave��6   $ menuItem��60   .[�5C      �� -   5        $&  OnMouseLeaveMenu_BeginStoryboard��5C      #��[ 6?   5D      :� 5E   
   $ Mouse.MouseEnter��6   $ menuItemBack��66   .[�5F      �� -   5        $$ MenuHighlight_BeginStoryboard2��5F      #��[ 6F   5G      :� 5H   
   $ Mouse.MouseEnter��6   $ menuItemBacktoMode��66   .[�5I      �� -   5        $$ MenuHighlight_BeginStoryboard3��5I      #��[ 6F   5J      :� 5K   
   $ Mouse.MouseLeave��6   $ menuItemBack��66   .[�5L      �� -   5        $' !OnMouseLeaveMenu_BeginStoryboard2��5L      #��[ 6I   5M      :� 5N   
   $ Mouse.MouseLeave��6   $ menuItemBacktoMode��66   .[�5O      �� -   5        $' !OnMouseLeaveMenu_BeginStoryboard3��5O      #��[ 6I   5P      .��5S      � .+�5T      �� .+�5U      o� -   5         o�Name$
 menu��5U   
    o� 
IsMainMenu .   
MenuStyle1#���  6*   
����������	#FF8D8B8B.@�5V      m� -	   5         m�Name$ menuItem��5V       J� Opacity$	 0.5Q�6   $
��Exit��6/    	 MenuItemStyle1#��� 	 6=   ��6f   Z� 6�   m� 5W      -
   5        $ menuItemBack��5W   )   $	 0.5Q�6   $
��Back��6@   #��� 	 6N   ��6w   Z�  � DataContext 6�   ��  �� RelativeSource �� *FindAncestor+ �� AncestorType" �{�6�   �� *IsBackEnabled+62  m� 5X      -   5        $ menuItemBacktoMode��5X   )   $	 0.5Q�6   $��Mode Selection��6E   #��� 	 6]   ��6�   Z�  6�   ��  �� *FindAncestor+" �{�6�   �� *IsModeBackEnabled+6I  5Y      5Z      �� 5[   
   -   5         ��Name$ ScrollViewerForCanvas��5[      $
��Auto=�66   $
��Auto=�6Y     
 ScrollViewerControlTemplate1#��� 
 6~   $��0,23,0,0q�6�   .��5\       � -   5          �Name$ frame��5\   4     � NavigationUIVisibility$ Hidden=�6    6C   ��  �� *FindAncestor+" �  � Source 6�   ��  �� Path$ DisplayPage� �� UpdateSourceTrigger$ PropertyChanged=�6�   5�      5�      5�      