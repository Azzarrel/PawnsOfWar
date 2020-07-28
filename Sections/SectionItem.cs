using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Sections
{

  public enum Section
  {
    None = 0,
    Dlc,
    Settings,
    News
  }
  public abstract class SectionItem : INotifyPropertyChanged
  {

    public SectionItem(Section id)
    {
      this.id = id;
    }

    private Section id;
    public Section Id
    {
      get => this.id;
      set
      {
        this.id = value;
        OnPropertyChanged();
      }
    }

    private string title;
    public string Title
    {
      get => this.title;
      set
      {
        this.title = value;
        OnPropertyChanged();
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }

  class DlcSection : SectionItem
  {
    public DlcSection(Section id) : base(id)
    {
    }
  }

  class SettingsSection : SectionItem
  {
    public SettingsSection(Section id) : base(id)
    {
    }
  }

  class NewsSection : SectionItem
  {
    public NewsSection(Section id) : base(id)
    {
    }
  }

}
