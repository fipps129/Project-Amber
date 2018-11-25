using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassChartController : MonoBehaviour {

    ClassScreen classScreen;
    Class _class;

    [SerializeField]
    private Text chartTitle;

    [SerializeField]
    private GameObject buttonObj;

    [SerializeField]
    private List<ClassChartRow> rowList = new List<ClassChartRow>();

    private List<GameObject> buttons = new List<GameObject>();

    // Use this for initialization
    void Awake()
    {
        classScreen = this.transform.parent.GetComponent<ClassScreen>();
    }

    public void ShowClassChart()
    {
        foreach (GameObject g in buttons)
            Destroy(g);

        _class = classScreen.GetCurrentClass();

        chartTitle.text = _class.classType.ToString();

        for (int i = 0; i < rowList.Count; i++)
        {
            for (int j = 0; j < _class.classChart[i].specialAbilities.Count; j++)
            {
                rowList[i].level.text = _class.classChart[i].level.ToString();
                rowList[i].bab.text = _class.classChart[i].bab;
                rowList[i].fort.text = "+" + _class.classChart[i].fort.ToString();
                rowList[i].reflex.text = "+" + _class.classChart[i].reflex.ToString();
                rowList[i].will.text = "+" + _class.classChart[i].will.ToString();

                GameObject button = Instantiate(buttonObj, rowList[i].special.transform);

                string delValue = _class.classChart[i].specialAbilities[j].ToString();

                if (j != _class.classChart[i].specialAbilities.Count - 1)
                {
                    button.transform.GetChild(0).GetComponent<Text>().text = delValue + ",";
                }
                else
                {
                    button.transform.GetChild(0).GetComponent<Text>().text = delValue;
                }

                button.GetComponent<Button>().onClick.AddListener(delegate { classScreen.ShowAbilityPopup(delValue); });

                buttons.Add(button);
            }

            FadeController.FadeObjectIn(this.gameObject, 0.5f);
        }
    }

    public void CloseChart()
    {
        FadeController.FadeObjectOut(this.gameObject, 0.5f);
    }

}
