using UnityEngine;
using System.Collections;

namespace Com.Game
{
	public class TerrainFragment : MonoBehaviour
	{
		[SerializeField] private Transform _nextTerrainWp;

		public void Init()
		{

		}

		public Transform GetNextTerrainWp()
		{
			return _nextTerrainWp;
		}

		public void ReleaseAllObjects()
		{

		}
	}
}
