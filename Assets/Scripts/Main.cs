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
                datas[i].Add(("我是Item" + j));
            }
        }

        Table.LoadData(datas);
    }

}
