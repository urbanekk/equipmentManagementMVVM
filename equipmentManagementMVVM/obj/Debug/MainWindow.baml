   M S B A M L   `   `   `  ����B  >ED_MVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ED_MVVMED_MVVM  5   	   7 clr-namespace:ED_MVVM.ViewModelsED_MVVM.ViewModels  5   	       ED_MVVM.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:ED_MVVM     5   	   /vm clr-namespace:ED_MVVM.ViewModels     5   	     � Title$  Equipment Management��5	   	   $	��500��6&   $	��800��63   $	��500��5
   	   $	��800��5   	    � 	Resources 5      %   ED_MVVM.ViewModels.MainWindowVM   mainWindowVM-   'ED_MVVM.ViewModels.ManageReservationsVM  manageReservationsVM"   ED_MVVM.ViewModels.AddUserVM  	addUserVM'   !ED_MVVM.ViewModels.AddEquipmentVM  addEquipmentVM��%t   &	        &	      &	 &     &	 9       5   
   6     5   
   6"     5   
   6     5   
   6   5      .��5      � .+�5   
   �� -   5         ��Name$ 
tabControl��5      $��Stretch=�6)   $��Stretch=�6G   $��0,0,0,40q�6c   .@�5      �� $��Reservations��6   .��5      �  � DataContext# [ 6   ���	#FFE5E5E5$��Stretch=�6b   $��Stretch=�6�   $��0,0,0,0q�6�   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ reservationsDataGrid��5      $��Stretch=�6=   $��Stretch=�6[   $��10,10,10,10q�6w   ��6�   ��  �� Path$ Reservations� �� SelectedItem 6�   �� $ Reservation�5      5      �� 5      $��Manage Accounts��6   # [  6/   y�6[   �� *AccountTabVisibility+ �� Mode$ OneWay=�.��5      � # [ 6   ���	#FFE5E5E5$��0,0,0,0q�6W    � ColumnDefinitions 5      �� 5      $
��100* �6+   �� 5      $
��400* �6+   .+�5!      �� -   5        	 ��Name$	 firstNameLabel��5!      $��First name:��64   $��Right=�6J   $��	19,66,0,0q�6f   $	��Top=�6y   $��0��6�   �� 5"      -   5        $	 lastNameLabel��5"      $��
Last name:��63   $��Right=�6H   $��
17,107,0,0q�6d   $	��Top=�6x   $��0��6�   �� 5#      -   5        $	 fullNameLabel��5#      $��
Full name:��63   $��Right=�6H   $��
19,149,0,0q�6d   $	��Top=�6x   $��0��6�   �� 5$      -   5        $	 
loginLabel��5$      $��Login:��60   $��Right=�6A   $��
41,192,0,0q�6]   $	��Top=�6q   $��0��6�   �� 5%      -   5        $	 passwordLabel��5%      $��	Password:��63   $��Right=�6G   $��
20,238,0,0q�6c   $	��Top=�6w   $��0��6�   �� 5&      -   5        
 ��Name$
 firstNameTextBox��5&      $
��Left=�68   $��22��6S   $��1,70,0,0q�6_    �� TextWrapping$
 Wrap=�6q   $	��Top=�6�   $	��120��6�   $��1��6�   ��6�   �� *	FirstName+$ OneWayToSource=�6�   �� 5'      -	   5        $
 surnameTextBox��5'      $
��Left=�66   $��24��6Q   $��	1,109,0,0q�6]   $
 Wrap=�6p   $	��Top=�6�   $	��120��6�   $��1��6�   ��6�   �� *
LastName+$ OneWayToSource=�6�   �� 5(      -
   5        $
 fullNameTextBox��5(      $
��Left=�67   $��22��6R   $��	1,153,0,0q�6^   $
 Wrap=�6q   $	��Top=�6�   $	��120��6�   $��1��6�   ��6�   �� *
FullName+$ OneWay=�6�   �� 5)      -   5        $
 loginTextBox��5)      $
��Left=�64   $��22��6O   $��	1,196,0,0q�6[   $
 Wrap=�6n   $	��Top=�6�   $	��120��6�   $��1��6�   ��6�   �� *Login+$ OneWayToSource=�6�   �� 5*      -   5        $
 passwordTextBox��5*      $
��Left=�67   $��22��6R   $��	1,238,0,0q�6^   $
 Wrap=�6q   $	��Top=�6�   $	��120��6�   $��1��6�   ��6�   �� *
Password+$ OneWayToSource=�6�   �� 5+      -   5         ��Name$ addUserButton��5+      $��Add user��64   $
��Left=�6G   $��	1,301,0,0q�6b   $	��Top=�6u   $	��120��6�   $��28��6�   $��1��6�   ��6�   �� *AddUserCommand+6�   5,      5-      �� 5.      $��Manage Equipments��6   # [  61   y�6]   �� *EquipmentTabVisibility+$ OneWay=�.��5/      � # [ 6   ���	#FFE5E5E5$��0,0,0,0q�6\    50      �� 51      $
��100* �6+   �� 52      $
��400* �6+   .+�54      �� -   5        $	 equipmentNameLabel��54      $��Equipment name:��68   $��Right=�6R   $��	42,66,0,0q�6n   $	��Top=�6�   $��0��6�   �� 55      -   5        $	 ownerFullNameLabel��55      $��Owner name:��68   $��Right=�6N   $��
40,107,0,0q�6j   $	��Top=�6~   $��0��6�   �� 56      -   5        $	 eidLabel��56      $
��EID:��6.   $��Right=�6=   $��
42,149,0,0q�6Y   $	��Top=�6m   $��0��6�   �� 57      -   5        $
 equipmentNameTextbox��57      $
��Left=�6<   $��22��6W   $��	12,70,0,0q�6c   $
 Wrap=�6v   $	��Top=�6�   $	��155��6�   $��1��6�   ��6�   �� *Name+$ OneWayToSource=�6�   �� 58      -   5         ��Name$ ownerNameCombobox��58      $
��Left=�6:   $��
12,107,0,0q�6U   $	��Top=�6i   $	��155��6�   $��1��6�   ��6�   �� $ Users� 6�   �� $ Owner�6�   �� 59      -   5        $
 
eidTextbox��59      $
��Left=�62   $��22��6M   $��
12,153,0,0q�6Y   $
 Wrap=�6m   $	��Top=�6�   $	��155��6�   $��1��6�   ��6�   �� *EID+$ OneWayToSource=�6�   �� 5:      -   5        $ addEquipmentButton��5:      $��Add equipment��69   $
��Left=�6Q   $��
12,213,0,0q�6l   $	��Top=�6�   $	��155��6�   $��28��6�   $��1��6�   ��6�   �� *AddEquipmentCommand+6�   5;      5<      5=      �� 5>   
   $��User: ��6   $
��Left=�6!   $��Bottom=�6<   $��10,10,10,10q�6W   �� 5?   
   -   5        $	 	userLabel��5?   =   # [  6   $
��Left=�6P   $��Bottom=�6k   $��50,10,10,10q�6�   ��6�   �� *UserFullname+$ OneTime=�5@      5A      