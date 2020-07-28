using PoW.Launcher.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PoW.Launcher.View
{
  /// <summary>
  /// Interaction logic for LaunchWindow.xaml
  /// </summary>
  public partial class LauncherWindow : Window
  {
    public LauncherWindow()
    {
      InitializeComponent();
      DataContext = new LauncherViewModel();
    }
  }
}
