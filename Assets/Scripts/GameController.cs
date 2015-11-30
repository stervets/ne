using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SQLite4Unity3d;

public static class Resource{
	public static Dictionary<string, List<GameObject>> BotPart = new Dictionary<string, List<GameObject>>();
}

public class GameController : MonoBehaviour
{
	private DataBase db = new DataBase("game.db");
	
	void Awake ()
	{
		var prefabs = db.GetPrefabs();

		List<GameObject> botParts;
		GameObject botPart;


		foreach(var prefab in prefabs){
			//Debug.Log(prefab.ToString());
			//Resource.BotPart.Add(string.Format("{0}/{1}",prefab.typeName, prefab.name), Resources.Load(prefab.ToString()) as GameObject);
			if (!Resource.BotPart.TryGetValue(prefab.typeName, out botParts)){
				botParts = new List<GameObject>();
				Resource.BotPart.Add(prefab.typeName, botParts);
			}

			botPart = Resources.Load(prefab.ToString()) as GameObject;

			if (botPart==null){
				Debug.LogWarning("Can't load resource: "+prefab);
			}else{
				botParts.Add(botPart);
			}

		}
	}
	
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{

	}
}