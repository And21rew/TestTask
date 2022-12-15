using UnityEngine;
using TMPro;

public class Step : MonoBehaviour
{
    private int stepNumber;
    public int StepNumber { get => stepNumber; }
    private TMP_Text textStepNumber;

    private void Awake()
    {
        stepNumber = int.Parse(gameObject.name.Split("_")[1]) - 1;
        textStepNumber = gameObject.GetComponentInChildren<TMP_Text>();
    }

    private void Start()
    {
        textStepNumber.text = (stepNumber + 1).ToString();
    }
}
