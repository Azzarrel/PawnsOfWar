using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace PoW.Essentials.Base
{
  public abstract class ControlBase : UserControl, INotifyPropertyChanged
  {

    private readonly Dictionary<string, object> propertyValues;

    protected ControlBase()
    {
      propertyValues = new Dictionary<string, object>();
    }

    protected void Set<T>(T value, [CallerMemberName] string propertyName = null)
    {
      if (propertyValues.ContainsKey(propertyName))
      {
        //Nur ändern, wenn es auch tatsächlich eine Änderung gab, bei null sollte der Wert danach immer von einer Value überschrieben werden
        if (propertyValues[propertyName] == null || !propertyValues[propertyName].Equals(value))
        {
          propertyValues[propertyName] = value;
        }
      }
      else
      {
        propertyValues.Add(propertyName, value);
      }
      OnPropertyChanged(propertyName);
    }

    protected T Get<T>([CallerMemberName] string propertyName = null)
    {
      if (propertyValues.ContainsKey(propertyName))
      {
        return (T)propertyValues[propertyName];
      }
      return default;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChangedEventHandler handler = PropertyChanged;
      if (handler != null)
      {
        handler(this, new PropertyChangedEventArgs(propertyName));
      }
    }
  }
}