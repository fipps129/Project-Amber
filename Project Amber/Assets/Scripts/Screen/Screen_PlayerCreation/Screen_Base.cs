using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen_Base : MonoBehaviour {

    [HideInInspector]
    public GameObject g_Object;

	void Awake () {
        g_Object = this.gameObject;
	}

    // Eventually this will trigger animations using iTween
    // But I don't care about animations right now
    virtual public void ShowMenu()
    {
        FadeController.FadeObjectIn(this.gameObject, 0.5f);
    }

    // Eventually this will trigger animations using iTween
    // But I don't care about animations right now
    virtual public void HideMenu()
    {
        FadeController.FadeObjectOut(this.gameObject, 0.5f);
    }

    virtual public void NextScreen()
    {

    }

    virtual public void LoadScreenData()
    {

    }
}
