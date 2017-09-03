using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController_Player : MonoBehaviour {

    [SerializeField]
    private Screen_Base currentMenu;
    private Screen_Base previousMenu;

    [SerializeField]
    private Screen_Base AbilityScreen;
    [SerializeField]
    private Screen_Base RaceScreen;

    [SerializeField]
    private List<Screen_Base> MainList = new List<Screen_Base>();
    private int mainIndex = 0;

    void Start () {
        // This is so I don't have to start from the start screen everytime
        if(Application.isEditor)
        {
            if (SaveManager.manager == null)
            {
                GameObject sm = new GameObject();
                sm.AddComponent<SaveManager>();
                sm.name = "Save Manager";
                if (SaveManager.manager.character == null)
                    SaveManager.manager.CreateNewCharacter();
            }
        }

        //Show Ability Calculator animation
    }
	
    public void NextPage()
    {
        mainIndex++;
        currentMenu.HideMenu();
        MainList[mainIndex].ShowMenu();
        currentMenu = MainList[mainIndex];
        currentMenu.LoadScreenData();
    }

}
