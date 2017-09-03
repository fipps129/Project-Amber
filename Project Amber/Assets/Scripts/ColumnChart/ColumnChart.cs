using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnChart : MonoBehaviour {

    public GameObject itemObj;

    public GameObject columnObj;
    [SerializeField]
    private List<Column> columnList = new List<Column>();

    [Range(1, 10)]
    public int colNum = 1;
    public int oldColNum = 1;

    [Range(1, 10)]
    public int itemNum = 1;
    private int oldItemNum = 1;

    private void ColCountChanged()
    {
        if(oldColNum < colNum)
        {
            GameObject newCol = Instantiate(columnObj, this.transform) as GameObject;
            columnList.Add(newCol.GetComponent<Column>());
            oldColNum ++;
        }
        else if(oldColNum > colNum)
        {
            if (columnList.Count == 1)
                return;
            Column oldCol = columnList[columnList.Count - 1];
            columnList.Remove(oldCol);
            GameObject.DestroyImmediate(oldCol.gameObject);
            oldColNum --;
        }
    }

    private void ItemCountChanged()
    {
        foreach (Column c in columnList)
        {
            if (c.oldItemNum < itemNum)
            {
                GameObject newItem = Instantiate(itemObj, c.transform) as GameObject;
                c.itemList.Add(newItem.GetComponent<ColumnItem>());
                c.oldItemNum++;
            }
            else if(c.oldItemNum > itemNum)
            {
                if (c.itemList.Count == 1)
                    return;
                ColumnItem oldItem = c.itemList[c.itemList.Count - 1];
                c.itemList.Remove(oldItem);
                GameObject.DestroyImmediate(oldItem.gameObject);
                c.oldItemNum--;
            }
            oldItemNum = c.oldItemNum;
        }

    }

	// Update is called once per frame
	void Update () {
        if (colNum != oldColNum)
        {
            ColCountChanged();
        }
        if (itemNum != oldItemNum)
        {
            ItemCountChanged();
        }
    }

    public void AddItems(List<string> titles)
    {
        int totalItems = titles.Count;

        while((colNum * itemNum)<totalItems)
        {
            colNum++;
            if (colNum > 10)
            {
                Debug.LogError("You have too many items in this list");
                break;
            }
        }

        int index = 0;
        for(int i=0;i<columnList.Count; i++)
        {
            for (int j = 0; j < columnList[i].itemList.Count; j++)
            {
                if (index == titles.Count)
                    break;
                columnList[i].itemList[j].Initialize(titles[index]);
                index++;
            }
        }
    }

    public void AddItems(List<string> titles, List<string> descriptions)
    {

    }

}
