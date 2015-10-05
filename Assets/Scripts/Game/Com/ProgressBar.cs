using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Com.Game
{
	public class ProgressBar : MonoBehaviour
	{
		[SerializeField] private Transform _progressLine;

		public void SetProgress(float progress)
		{
			_progressLine.localScale = new Vector3(1.0f, progress, 1.0f);
		}
	}
}
