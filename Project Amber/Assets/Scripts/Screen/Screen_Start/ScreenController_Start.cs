using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenController_Start : MonoBehaviour {

    [SerializeField]
    private Screen_Base currentMenu;
    private Screen_Base previousMenu;


    [SerializeField]
    private Screen_Base StartScreen;
    [SerializeField]
    private Screen_Base Player_LoadScreen;

    public void ShowPlayerOptions()
    {
        StartScreen.HideMenu();
        Player_LoadScreen.ShowMenu();
    }

    public void ShowGMOptions()
    {
        // This will transition to a page that will show the options
        // to load a game or create a new one :: UNDER CONSTRUCTION ::
    }

    public void LoadPlayerCreation()
    {
        SaveManager.manager.CreateNewCharacter();
        SceneManager.LoadScene("PlayerCreation");
    }

    public void LoadGameMaster()
    {
        Debug.Log("Under Construction");
    }


}
