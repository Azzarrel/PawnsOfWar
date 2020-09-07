using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PoW.Essentials
{
  public abstract class ModelBase : NotifyBase
  {
    public string ObjId
    {
      get { return Get<string>(); }
      set { Set(value); }
    }
    public string Name
    {
      get { return Get<string>(); }
      set { Set(value); }
    }
    public DataRow Row
    {
      get { return Get<DataRow>(); }
      set { Set(value); }
    }
  }
}
