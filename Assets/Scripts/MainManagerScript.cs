using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManagerScript : MonoBehaviour
{
	//加不加 static很关键, 测试不加的后果？
	public static MainManagerScript Instance;
	public Color TeamColor;
	void Awake()
	{
		if (Instance!=null)
		{
			Destroy(gameObject);
			return;
		}
		Instance = this;
		DontDestroyOnLoad(gameObject);//全程不销毁当前创建的对象
	}
}
