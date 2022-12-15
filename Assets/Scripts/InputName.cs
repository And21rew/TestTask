using UnityEngine;
using UnityEngine.UI;

public class InputName : MonoBehaviour
{
    public string NameText { get; private set; }

    private void Start()
    {
        transform.GetComponent<InputField>().onValueChanged.AddListener(ChangedValue);
    }
    private void ChangedValue(string value)
    {
        NameText = value;
    }
}
