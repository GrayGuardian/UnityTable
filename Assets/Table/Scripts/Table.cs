using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public GameObject RowTemp;
    public GameObject ItemTemp;
    public RectTransform ContentNode;
    public List<Table_Row> Rows = new List<Table_Row>();
    public List<List<T>> GetDatas<T>()
    {
        List<List<T>> datas = new List<List<T>>();
        for (int i = 0; i < Rows.Count; i++)
        {
            var row = Rows[i];
            datas.Add(new List<T>());
            for (int j = 0; j < row.Items.Count; j++)
            {
                var item = row.Items[j];
                datas[i].Add((T)item.Data);
            }
        }
        return datas;
    }
    public void LoadData(List<List<object>> datas)
    {
        Clear();
        for (int i = 0; i < datas.Count; i++)
        {
            var rowData = datas[i];
            AddRow(rowData);
        }
    }
    public void Clear()
    {

    }
    public int AddRow(List<object> datas = null, int index = -1)
    {
        datas = datas == null ? new List<object>() : datas;
        index = (index < 0 || index > Rows.Count) ? Rows.Count : index;
        Transform node = GameObject.Instantiate(RowTemp).transform;
        node.parent = ContentNode;
        node.SetSiblingIndex(index);
        node.localScale = Vector3.one;
        var comp = node.gameObject.GetComponent<Table_Row>();
        Rows.Insert(index, comp);
        for (int i = 0; i < datas.Count; i++)
        {
            AddItem(datas[i], i, index);
        }
        return index;
    }
    public void AddItem(object data = null, int index = -1, int rowIndex = -1)
    {
        rowIndex = rowIndex == -1 ? Rows.Count - 1 : rowIndex;
        rowIndex = (rowIndex >= Rows.Count) ? AddRow() : rowIndex;
        var row = Rows[rowIndex];
        index = (index < 0 || index > row.Items.Count) ? row.Items.Count : index;
        Transform node = GameObject.Instantiate(ItemTemp).transform;
        node.parent = row.transform;
        node.SetSiblingIndex(index);
        node.localScale = Vector3.one;
        var comp = node.gameObject.GetComponent<Table_Item>();
        row.Items.Insert(index, comp);

        comp.LoadData(data);
    }

}