using SQLite4Unity3d;
using UnityEngine;
#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif
using System.Collections.Generic;


public class DataBase
{
	public class Prefab{
		public int typeId { get; set; }
		public string typeName { get; set; }
		public int groupId { get; set; }
		public string groupName { get; set; }
		public string name { get; set; }

		public override string ToString(){
			return string.Format("{0}/{1}/{2}", groupName, typeName, name);
		}
	}


    private SQLiteConnection db;

	public IEnumerable<Prefab> GetPrefabs()
	{
		return db.Query<Prefab> (
            "select prefabs.`type` as typeId, types.`name` as typeName, types.`group` as groupId, groups.`name` as groupName, prefabs.`name` from prefabs"+
            " left join types on (prefabs.`type` == types.id)"+
            " left join groups on (types.`group` == groups.id)"+
            " order by groupId, typeId"
			);
	}

    /*
    public IEnumerable<Person> GetPersons()
    {
        return _connection.Table<Person>();
    }

    public IEnumerable<Person> GetPersonsNamedRoberto()
    {
        return _connection.Table<Person>().Where(x => x.Name == "Roberto");
    }

    public Person GetJohnny()
    {
        return _connection.Table<Person>().Where(x => x.Name == "Johnny").FirstOrDefault();
    }

    public Person CreatePerson()
    {
        var p = new Person
        {
            Name = "Johnny",
            Surname = "Mnemonic",
            Age = 21
        };
        _connection.Insert(p);
        return p;
    }

    */

	public DataBase(string DatabaseName)
	{
		
		#if UNITY_EDITOR
		var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
		#else
		// check if file exists in Application.persistentDataPath
		var filepath = string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);
		
		if (!File.Exists(filepath))
		{
			Debug.Log("Database not in Persistent path");
			// if it doesn't ->
			// open StreamingAssets directory and load the db ->
			
			#if UNITY_ANDROID
			var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);  // this is the path to your StreamingAssets in android
			while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
			// then save to Application.persistentDataPath
			File.WriteAllBytes(filepath, loadDb.bytes);
			#elif UNITY_IOS
			var loadDb = Application.dataPath + "/Raw/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
			// then save to Application.persistentDataPath
			File.Copy(loadDb, filepath);
			#elif UNITY_WP8
			var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
			// then save to Application.persistentDataPath
			File.Copy(loadDb, filepath);
			
			#elif UNITY_WINRT
			var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
			// then save to Application.persistentDataPath
			File.Copy(loadDb, filepath);
			#endif
			
			Debug.Log("Database written");
		}
		
		var dbPath = filepath;
		#endif
		//_connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
		db = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadOnly);
		Debug.Log("Database: " + dbPath);
		
	}
}