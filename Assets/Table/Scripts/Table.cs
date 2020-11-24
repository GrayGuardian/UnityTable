using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public GameObject RowTemp;
    public GameObject ItemTemp;
    public RectTransform ContentNode;

    public List<List<object>> Datas;

    public List<Table_Row> Rows = new List<Table_Row>();
    public void LoadData(List<List<object>> datas)
    {
        Datas = datas;
        Refresh();
    }
    public void Refresh()
    {
        Clear();
        for (int i = 0; i < Datas.Count; i++)
        {
            var rowData = Datas[i];
            AddRow(rowData);
        }
    }
    public void Clear()
    {

    }
    public void AddRow(List<object> datas = null, int index = -1)
    {
        datas = datas == null ? new List<object>() : datas;
        index = index == -1 ? Rows.Count : index;
        Transform node = GameObject.Instantiate(RowTemp).transform;
        node.parent = ContentNode;
        node.localScale = Vector3.one;
        var comp = node.gameObject.GetComponent<Table_Row>();
        Rows.Add(comp);
        for (int i = 0; i < datas.Count; i++)
        {
            AddItem(datas[i], index, i);
        }


    }
    public void AddItem(object data = null, int rowIndex = -1, int index = -1)
    {

        var row = Rows[rowIndex];
        Transform node = GameObject.Instantiate(ItemTemp).transform;
        node.parent = row.transform;
        node.localScale = Vector3.one;

    }

}