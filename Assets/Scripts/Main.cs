using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public Table Table;
    void Start()
    {
        List<List<object>> datas = new List<List<object>>();
        for (int i = 0; i < 3; i++)
        {
            datas.Add(new List<object>());
            for (int j = 0; j < 4; j++)
            {
                datas[i].Add(string.Format("我是Item({0},{1})", i, j));
            }
        }

        Table.LoadData(datas);
        Table.AddRow(new List<object>() { "我是插入的行" }, 1);
        Table.AddRow(new List<object>() { "", "", "", "" }, 1);
        Table.AddItem("我是插入的项", 0, 0);

        List<List<string>> arr = Table.GetDatas<string>();
        foreach (var row in arr)
        {
            foreach (var item in row)
            {
                Debug.Log(item);
            }
        }

    }

}
