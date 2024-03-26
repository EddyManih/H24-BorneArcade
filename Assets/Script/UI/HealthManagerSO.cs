using UnityEngine.Events;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthManagerSO", menuName = "ScriptableObjets/Health Manager")]
public class HealthManagerSO : ScriptableObject
{
    public int health = 100;

    [SerializeField] private int maxHealth = 100;

    [System.NonSerialized] public UnityEvent<int> healthChangeEvent;

    private void OnEnable()
    {
        health = maxHealth;

        if (healthChangeEvent == null)
        {
            healthChangeEvent = new UnityEvent<int>();
        }
    }

    public void DecreaseHealth(int amount)
    {
        if (health - amount < 0)
        {
            health = 0;
            // Player dead event triggered
        } else {
            health -= amount;
        }
        healthChangeEvent.Invoke(health);
    }
}

