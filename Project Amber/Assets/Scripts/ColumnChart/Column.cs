using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour {

    public List<ColumnItem> itemList = new List<ColumnItem>();

    public ColumnItem firstItem;

    public int oldItemNum = 1;
}
