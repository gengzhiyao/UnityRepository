using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

/*
 * this指向当前类的一个实例对象
 * 当脚本挂载到游戏物体身上时，就自动创建了一个对象，相当于 new
 * 也就是说，当脚本挂载到游戏物体上时，就是为这个脚本new了一个实例，这个实例就是脚本作为组件的存在
 * this指向的就是这个 Script 组件
 * Debug.Log(this)是尝试将this作为字符串输出，但因为只有Object类中有ToString方法，所以调用的是Object基类中的方法
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
			Destroy(this.gameObject);
			return;
		}

		Instance = this;    //this = this.gameObject.GetComponent<MainManagerScript>();
		//Debug.Log(this==this.gameObject.GetComponent<MainManagerScript>());
		//Debug.Log(this.gameObject.GetComponent<Transform>().name);
		//Debug.Log(this.ToString());
		DontDestroyOnLoad(this.gameObject);//全程不销毁当前创建的对象
	}
}
