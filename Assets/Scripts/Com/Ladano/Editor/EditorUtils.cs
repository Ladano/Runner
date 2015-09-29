using UnityEditor;
using UnityEngine;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Com;

namespace MyEditor
{
	public class CustomMenu : MonoBehaviour
    { 
		#region work with transform
		/// <summary>
		/// Roundings the transform coordinates.
		/// </summary>
		[MenuItem("Utils/Transform/Rounding coordinates #&q")]
		private static void RoundingTransformCoordinates()
		{
			Vector3 coords = Selection.activeTransform.localPosition;
			Selection.activeTransform.localPosition = new Vector3((float)System.Math.Round(coords.x, 2), (float)System.Math.Round(coords.y, 2), (float)System.Math.Round(coords.z, 2));
		}
		/// <summary>
		/// Zeros the transform local coordinates.
		/// </summary>
		[MenuItem("Utils/Transform/Set zore local pos #&w")]
		private static void ZeroTransformCoordinates()
		{
			Selection.activeTransform.localPosition = Vector3.zero;
		}
		#endregion

		#region work with sprites
		/// <summary>
		/// Sets tk2dBaseSprite/SpriteRenderer alpha 0.0f.
		/// </summary>
		[MenuItem("Utils/Sprites/Set alpha 0.0f #&z")]
		private static void SetSpriteAlphaZero()
		{
			/*if(Selection.activeTransform.GetComponent<tk2dSprite>()!=null)
			{
				SetSpiteAlpha(Selection.activeTransform.GetComponent<tk2dBaseSprite>(), 0.0f);
			}

			if(Selection.activeTransform.GetComponent<SpriteRenderer>()!=null)
			{
				SetSpiteAlpha(Selection.activeTransform.GetComponent<SpriteRenderer>(), 0.0f);
			}*/
		}

		/// <summary>
		/// Sets tk2dBaseSprite/SpriteRenderer alpha 0.3f.
		/// </summary>
		[MenuItem("Utils/Sprites/Set alpha 0.3f #&x")]
		private static void SetSpriteAlphaHalf()
		{
			/*if(Selection.activeTransform.GetComponent<tk2dSprite>()!=null)
			{
				SetSpiteAlpha(Selection.activeTransform.GetComponent<tk2dSprite>(), 0.3f);
			}*/
			
			if(Selection.activeTransform.GetComponent<SpriteRenderer>()!=null)
			{
				SetSpiteAlpha(Selection.activeTransform.GetComponent<SpriteRenderer>(), 0.3f);
			}
		}

		/// <summary>
		/// Sets tk2dBaseSprite/SpriteRenderer alpha 1.0f.
		/// </summary>
		[MenuItem("Utils/Sprites/Set alpha 1.0f #&c")]
		private static void SetSpriteAlphaOne()
		{
			/*if(Selection.activeTransform.GetComponent<tk2dSprite>()!=null)
			{
				SetSpiteAlpha(Selection.activeTransform.GetComponent<tk2dSprite>(), 1.0f);
			}*/
			
			if(Selection.activeTransform.GetComponent<SpriteRenderer>()!=null)
			{
				SetSpiteAlpha(Selection.activeTransform.GetComponent<SpriteRenderer>(), 1.0f);
			}
		}

		/*private static void SetSpiteAlpha(tk2dBaseSprite sprite, float alpha)
		{
			sprite.SetAlpha(alpha);
		}*/

		private static void SetSpiteAlpha(SpriteRenderer sprite, float alpha)
		{
			sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, alpha);
		}
		#endregion

		#region scriptable objects
		/// <summary>
		/// Creates the scriptable object.
		/// </summary>
		[MenuItem("Utils/Scriptable Objects/Create")]
		private static void CreateScriptableObject()
		{
			//CreateScriptableObjectAsset<InventoryPanelPartsStorage>();
		}

		/// <summary>
		/// Creates scriptable object of generic type.
		/// </summary>
		/// <typeparam name="T">Required class type.</typeparam>
		private static void CreateScriptableObjectAsset<T> () where T : ScriptableObject
		{
			T asset = ScriptableObject.CreateInstance<T> ();
			
			string path = AssetDatabase.GetAssetPath (Selection.activeObject);
			if (path == "") 
			{
				path = "Assets";
			} 
			else if (Path.GetExtension (path) != "") 
			{
				path = path.Replace (Path.GetFileName (AssetDatabase.GetAssetPath (Selection.activeObject)), "");
			}
			
			string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath (path + "/New " + typeof(T).ToString() + ".asset");
			
			AssetDatabase.CreateAsset (asset, assetPathAndName);
			
			AssetDatabase.SaveAssets ();
			AssetDatabase.Refresh();
			EditorUtility.FocusProjectWindow ();
			Selection.activeObject = asset;
		}
		#endregion

		#region other
		/// <summary>
		/// Kills the player prefs.
		/// </summary>
		[MenuItem("Utils/Other/Kill prefs")]
		private static void KillPrefs()
		{
			PlayerPrefs.DeleteAll();
			SoundSwitcher();
		}

		/// <summary>
		/// Switche sound state.
		/// </summary>
		[MenuItem("Utils/Other/Sound switcher")]
		private static void SoundSwitcher()
		{
			//GlobalValues.SoundState = !GlobalValues.SoundState;
		}

		/// <summary>
		/// Drops the component in all childrens in choosen object.
		/// </summary>
		[MenuItem("Utils/Other/Drop component in childrens")]
		private static void DropComponentInChildrens()
		{
			/*List<tk2dUITweenItem> _items = Selection.activeTransform.GetComponentsInChildren<tk2dUITweenItem>().ToList();
			for(int i = 0; i<_items.Count; i++)
			{
				DestroyImmediate(_items[i]);
			}*/
		}

		/// <summary>
		/// Moves render to required sortingLayer and sortingOrder.
		/// </summary>
		[MenuItem("Utils/Other/Move renderer to layer")]
		private static void MoveToLayer()
		{
			Renderer workObject = Selection.activeTransform.GetComponent<Renderer>();
			if(workObject!=null)
			{
				workObject.sortingLayerName = "Default";
				workObject.sortingOrder = 0;
			}
		}
		#endregion
   }
}