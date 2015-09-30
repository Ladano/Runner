using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Com
{
	public class BestScoreGUIView : MonoBehaviour
	{
		private const string BestScoreFormatString = "Best score: {0}";

		[SerializeField] private Text _label;

		private void Start()
		{
			_label.text = string.Format(BestScoreFormatString, GlobalValues.BestScore.ToString());
		}
	}
}
