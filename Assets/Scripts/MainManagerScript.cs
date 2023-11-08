using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using System.IO;

/*
 * this指向当前类的一个实例对象
 * 当脚本挂载到游戏物体身上时，就自动创建了一个对象，相当于 new
 * 也就是说，当脚本挂载到游戏物体上时，就是为这个脚本 new了一个实例，这个实例就是脚本作为组件的存在
 * this指向的就是这个 Script 组件
 * Debug.Log(this)是尝试将this作为字符串输出，但因为只有Object类中有ToString方法，所以调用的是Object基类中的方法
 */

/*
  var allComponents = GetComponents<Component>();
  foreach (Component item in allComponents)
  {
	  Debug.Log(item.GetType());
  }
*/

public class MainManagerScript : MonoBehaviour
{
	//加不加 static很关键, 测试不加的后果？
	public static MainManagerScript Instance;
	
	public Color TeamColor;
	void Awake()
	{
		if (Instance!=null)
		{
			Destroy(this.gameObject);//点击返回按钮后，展开 Menu场景菜单会发现，在其中会有原来的 MainManager，这里Destroy就是删除原场景中的物体
									 //因为原场景中的物体不会被带到新的场景中，所以每次切换回原场景只会有一个 MainManager
			return;
		}
		Instance = this;    //this = this.gameObject.GetComponent<MainManagerScript>();
							//Debug.Log(this==this.gameObject.GetComponent<MainManagerScript>());
							//Debug.Log(this.gameObject.GetComponent<Transform>().name);
							//Debug.Log(this.ToString());
		DontDestroyOnLoad(this.gameObject);//全程不销毁当前创建的对象
		Debug.Log(Application.persistentDataPath);
		
		LoadColor();
		
	}
	
	[System.Serializable]		//仅对 class,struct,enum,delegate有效,JsonUtility允许你获取可序列化的类并将其转换为Json形式
	class SaveData
	{
		public Color TeamColor;
	}
	
	public void SaveColor()
	{
		SaveData data = new SaveData();
		data.TeamColor = TeamColor;

		string json = JsonUtility.ToJson(data);
		
		File.WriteAllText(Application.persistentDataPath+"savefile.json",json);
	}

	public void LoadColor()
	{
		string path = Application.persistentDataPath+"savefile.json";
		if (File.Exists(path))
		{
			string json = File.ReadAllText(path);
			SaveData data = JsonUtility.FromJson<SaveData>(json);

			TeamColor = data.TeamColor;
		}
	}
}



	



