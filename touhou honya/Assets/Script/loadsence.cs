using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class loadsence : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void bookwindow()
    {
        Debug.Log(1);
        SceneManager.LoadScene(1);
        return;
    } 
}
