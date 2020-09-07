using PoW.Essentials;
using System.Collections.ObjectModel;

namespace PoW.Launcher.Model
{
	public class HistoryGroupModel : NotifyBase
	{
		public HistoryGroupModel()
		{
			this.Entrys = new ObservableCollection<HistoryCharacterModel>();
		}

		public string Title
		{
			get { return Get<string>(); }
			set { Set(value); }
		}

		public ObservableCollection<HistoryCharacterModel> Entrys
		{
			get { return Get<ObservableCollection<HistoryCharacterModel>>(); }
			set { Set(value); }
		}
	}
}
