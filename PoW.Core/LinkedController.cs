using PoW.Essentials;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace PoW.Core
{
  public class LinkedController
  {
    private DataSet m_BaseData;

    private Dictionary<DataTable, IList<IEnumerable>> m_BaseTables;

    private DataSet m_UserData;

    private Dictionary<DataTable, IList<IEnumerable>> m_UserTables;

    public LinkedController()
    {

    }

    public void Initialize()
    {
      //alle Tabellen, die man so finden kann in m_BaseData laden
    }

    public void CreateList<T>()
    {
      //Neue Liste aus DataTable anhand des Typs über den Converter bauen
    }

    public void Associate(DataTable tbl, IList list, Dictionary<DataTable, IList<IEnumerable>> dict)
    {

      if (!dict.ContainsKey(tbl))
        dict.Add(tbl, new List<IEnumerable>());

      dict.FirstOrDefault(e => e.Key == tbl).Value.Add(list);

      foreach (ModelBase model in list)
      {
        model.PropertyChanged += UpdateTable;
      }
      tbl.RowChanged += UpdateList;


    }

    public void UpdateTable(object sender, PropertyChangedEventArgs e)
    {
      ModelBase model = sender as ModelBase;
      //model.Row = Values wieder in ein Table-Format umwandeln
    }

    public void UpdateList(object sender, DataRowChangeEventArgs e)
    {

    }

    //Verwalten von DataTables/Listen
  }
}
