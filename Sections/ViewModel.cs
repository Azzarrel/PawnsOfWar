using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using static Sections.SectionItem;

namespace Sections
{
  class ViewModel : INotifyPropertyChanged
  {
    public ObservableCollection<SectionItem> Sections { get; set; }

    public ViewModel()
    {
      this.Sections = new ObservableCollection<SectionItem>
    {
      new NewsSection(Section.News) {Title = "News"},
      new DlcSection(Section.Dlc) {Title = "DLC"},
      new SettingsSection(Section.Settings) {Title = "Settings"}
    };

    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

  }
}
