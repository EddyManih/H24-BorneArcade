using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIHealthBarManager : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;

    [SerializeField] HealthManagerSO healthManagerSO;

    private void Start()
    {
        ChangeSliderValue(healthManagerSO.health);
    }

    private void OnEnable()
    {
        healthManagerSO.healthChangeEvent.AddListener(ChangeSliderValue);
    }

    private void OnDisable()
    {
        healthManagerSO.healthChangeEvent.RemoveListener(ChangeSliderValue);
    }

    // TO BE REMOVED
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            healthManagerSO.DecreaseHealth(10);
        }
    }
    //

    private float ConvertIntToFloatDecimal(int amount)
    {
        return (float)amount / 100;
    }

    public void ChangeSliderValue(int amount)
    {
        float convertedAmount  = ConvertIntToFloatDecimal(amount);
        fill.color = gradient.Evaluate(convertedAmount);
        slider.value = convertedAmount;
    }
}
