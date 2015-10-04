using UnityEngine;
using System.Collections;

namespace Com.Game
{
	public class PauseButton : AbstractButton
	{
		public static event System.Action OnPauseButtonAction;

		protected override void ButtonAction()
		{
			if(OnPauseButtonAction!=null)
			{
				OnPauseButtonAction();
			}
		}
	}
}
