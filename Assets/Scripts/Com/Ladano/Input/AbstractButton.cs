using UnityEngine;
using System.Collections;

namespace Com
{
	public abstract class AbstractButton : MonoBehaviour
	{
		public void ButtonClick()
		{
			ButtonAction();
		}

		protected abstract void ButtonAction();
	}
}
