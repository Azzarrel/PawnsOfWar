using PoW.Essentials.Base;

namespace PoW.Launcher.Model
{
	class HistoryCharacterModel : NotifyBase
	{

		public string Title
		{
			get { return Get<string>(); }
			set { Set(value); }
		}

		public string Date
		{
			get { return Get<string>(); }
			set { Set(value); }
		}

		public string Path
		{
			get { return Get<string>(); }
			set { Set(value); }
		}

	}
}
