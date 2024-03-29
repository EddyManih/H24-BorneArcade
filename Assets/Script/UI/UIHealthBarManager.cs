using UnityEngine;
using UnityEngine.UI;

public class UIHealthBarManager : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;

    [SerializeField] PlayerController playerController;

    private void Start()
    {
        ChangeSliderValue(playerController.healthManagerSO.health);
    }

    private void OnEnable()
    {
        playerController.healthManagerSO.damageTakenEvent.AddListener(ChangeSliderValue);
    }

    private void OnDisable()
    {
        playerController.healthManagerSO.damageTakenEvent.RemoveListener(ChangeSliderValue);
    }

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
