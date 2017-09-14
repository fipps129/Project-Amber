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

    [Range(1, 30)]
    public int maxItemNum = 1;
    private int oldItemNum = 1;

    private int totalItems = 0;

    private void ColCountChanged()
    {
        int safeGuard = 0;
        while(oldColNum != colNum)
        {
            safeGuard++;
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
            if(safeGuard >=1000)
            {
                Debug.Log("Safe guard triggered!");
                break;
            }
        }
    }

    private void ItemCountChanged()
    {
        int safeGuard = 0;

        foreach (Column c in columnList)
        {
            while(c.oldItemNum!=maxItemNum)
            {

                safeGuard++;
                if (c.oldItemNum < maxItemNum)
                {
                    GameObject newItem = Instantiate(itemObj, c.transform) as GameObject;
                    c.itemList.Add(newItem.GetComponent<ColumnItem>());
                    c.oldItemNum++;
                }
                else if(c.oldItemNum > maxItemNum)
                {
                    if (c.itemList.Count == 1)
                        return;
                    ColumnItem oldItem = c.itemList[c.itemList.Count - 1];
                    c.itemList.Remove(oldItem);
                    GameObject.DestroyImmediate(oldItem.gameObject);
                    c.oldItemNum--;
                }
                oldItemNum = c.oldItemNum;
                if(safeGuard >-1000)
                    break;
            }
        }

    }

    void Start()
    {
        if (colNum != oldColNum)
        {
            ColCountChanged();
        }
        if (maxItemNum != oldItemNum)
        {
            ItemCountChanged();
        }
    }

	// Update is called once per frame
	void Update () {
        
        if (maxItemNum != oldItemNum)
        {
            ItemCountChanged();
        }
    }

    public void Reset()
    {
        foreach (Column c in columnList)
        {
            foreach(ColumnItem item in c.itemList)
            {
                
                item.Hide();
            }
        }
    }

    private void AdjustChartSize()
    {
        if((colNum * maxItemNum)<totalItems) // Check if the chart is too small
        {
            while((colNum * maxItemNum)<totalItems)
            {
                colNum++;
                GameObject newCol = Instantiate(columnObj, this.transform) as GameObject;
                columnList.Add(newCol.GetComponent<Column>());
                oldColNum ++;
                if (colNum > 10)
                {
                    Debug.LogError("You have too many items in this list");
                    break;
                }
            }
        }
        else // Check if the chart is too big
        {
            for(int i=colNum;i>0;i--)
            {
                if (columnList.Count == 1)
                {
                    if((i * maxItemNum)<totalItems)
                    {
                        colNum = i+1;
                        GameObject newCol = Instantiate(columnObj, this.transform) as GameObject;
                        columnList.Add(newCol.GetComponent<Column>());
                        oldColNum ++;
                    }
                    return;
                }
                colNum--;
                Column oldCol = columnList[columnList.Count - 1];
                columnList.Remove(oldCol);
                GameObject.DestroyImmediate(oldCol.gameObject);
                oldColNum --;
                if((i*maxItemNum)<totalItems)
                {
                    colNum = i+1;
                    GameObject newCol = Instantiate(columnObj, this.transform) as GameObject;
                    columnList.Add(newCol.GetComponent<Column>());
                    oldColNum ++;
                    break;
                }
            }
        }
    }
        
    public void AddItems(List<string> titles)
    {
        totalItems = titles.Count;

        ItemCountChanged();

        //AdjustChartSize();


        int colIndex = 0;
        int itemIndex = 0;

        for(int i=0;i<titles.Count;i++)
        {
            columnList[colIndex].itemList[itemIndex].Initialize(titles[i]);
            if(colIndex == columnList.Count-1)
            {
                colIndex = 0;
                itemIndex++;
            }
            else
            {
                colIndex ++;
            }
        }

        /*
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
        */
    }

    public void AddItems(List<string> titles, List<string> descriptions)
    {

    }

}
