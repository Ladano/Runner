using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Com
{
	public static class ListExtensions
	{
		public static T GetRandomItem<T>(this List<T> list)
		{
			if(list.Count>0)
			{
				return list[Random.Range(0, list.Count)];
			}
			return default(T);
		}

		public static T RemoveRandomItem<T>(this List<T> list)
		{
			if(list.Count>0)
			{
				T value = list[Random.Range(0, list.Count)];
				list.Remove(value);
				return value;
			}
			return default(T);
		}
	}
}
