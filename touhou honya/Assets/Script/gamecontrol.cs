using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class gamecontrol : MonoBehaviour
{
    public GameObject booklist;
    public GameObject bookview;
    int booknum = 0;
    bool firstload = true;

    // Use this for initialization
    void Start()
    {
        shopstatic.GlobalData Gamedata = shopstatic.GlobalData.CreateData();
        if (firstload == true)
        {
            while (booknum < Gamedata.bookdata.Count)
            {
                GameObject tempbook = GameObject.Instantiate(booklist) as GameObject;
                tempbook.name = booknum.ToString();
                string target = tempbook.name + "/bookname";
                GameObject tempbookname = GameObject.Find(target);
                Component text= tempbookname.GetComponent("Text");
                tempbookname.GetComponent<Text>().text = Gamedata.bookdata[booknum].tittle;
                Debug.Log(Gamedata.bookdata[booknum].tittle);
                booknum++;
                tempbook.transform.SetParent(bookview.transform);
            }
            firstload = false;

        }
    }

    // Update is called once per frame
    void Update() {
    }
}
