using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class mainUI : MonoBehaviour {
    Text shopgoldtext;


    // Use this for initialization
    void Start () {
        shopgoldtext = GameObject.Find("shopgold").GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update () {
        //数据刷新显示
        shopstatic.GlobalData Gamedata = shopstatic.GlobalData.CreateData();
        shopgoldtext.text = "金钱： " + Gamedata.Gold;
    }
}
