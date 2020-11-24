using UnityEngine;
using UnityEngine.UI;
public class Table_Item : MonoBehaviour
{
    public object Data;
    private InputField _inputField;
    private void Awake()
    {
        _inputField = transform.GetComponentInChildren<InputField>();
    }
    public void LoadData(object data)
    {
        Data = data;
        _inputField.text = data.ToString();
    }
}