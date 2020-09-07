using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using PoW.Core;
using PoW.Essentials;
using PoW.Launcher.Model;
using PoW.Utility;

namespace PoW.Launcher.ViewModel
{
  public class LauncherViewModel : NotifyBase
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

    public ObservableCollection<HistoryGroupModel> HistoryGroups
    {
      get { return Get<ObservableCollection<HistoryGroupModel>>(); }
      set { Set(value); }
    }

    public LauncherViewModel()
    {
      CurrentControl = 1;
      StartingPos = 650;

      HistoryGroups = new ObservableCollection<HistoryGroupModel>();
      HistoryGroups.Add(new HistoryGroupModel() { Title = "Heute"});
      HistoryGroups.Add(new HistoryGroupModel() { Title = "Gestern", Entrys = new ObservableCollection<HistoryCharacterModel>() { new HistoryCharacterModel() { Title = "Title 1" } } });

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
