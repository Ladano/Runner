using UnityEngine;
using System.Collections;

namespace Com
{
	public static class GlobalValues
	{
		private const string BestScorePrefsName = "PLAYER_BEST_SCORE";

		public static int BestScore
		{
			get { return PlayerPrefs.GetInt(BestScorePrefsName, 0); }
			set { PlayerPrefs.SetInt(BestScorePrefsName, value); }
		}
	}
}
