using PoW.Essentials.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using PoW.Core;

namespace PoW.Launcher.ViewModel
{
  class LauncherViewModel : NotifyBase
  {

    public double StartingPos
    {
      get { return Get<double>(); }
      set { Set(value); }
    }

    public int CurrentControl
    {
      get { return Get<int>(); }
      set { Set(value); }
    }

    public LauncherViewModel()
    {
      CurrentControl = 1;
      StartingPos = 650;
      CreateCommands();
    }


    #region Commands

    //Komplette Dummy-Implementierung der Commands, sodass man es einfach erweitern kann
    private void CreateCommands()
    {
      FocusMainCommand = new RelayCommand(ExecuteFocusMain);

    }

    public ICommand FocusMainCommand { get; private set; }

    //Das ganze Zeug mit den Traits ist noch unnötig wie shit, sollte man mal vereinfachen.
    public void ExecuteFocusMain()
    {
      CurrentControl = 0;

    }



    public bool CanExecute()
    {
      return true; //Hier könnte eine Abfrage, ob das Command ausgeführt werden darf, stehen
    }

    #endregion Commands

  }
}
