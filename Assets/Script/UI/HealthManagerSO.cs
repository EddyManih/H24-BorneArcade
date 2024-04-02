using UnityEngine.Events;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthManagerSO", menuName = "ScriptableObjets/Health Manager")]
public class HealthManagerSO : ScriptableObject
{
    public int health;
    private bool alive;

    [SerializeField] private int maxHealth = 100;

    [System.NonSerialized] public UnityEvent<int> damageTakenEvent;
    [System.NonSerialized] public UnityEvent DiedEvent;

    private void OnEnable()
    {
        health = maxHealth;
        alive = true;

        if (damageTakenEvent == null)
        {
            damageTakenEvent = new UnityEvent<int>();
        }

        if (DiedEvent == null)
        {
            DiedEvent = new UnityEvent();
        }
    }

    public void DamageTaken(int amount)
    {
        if (health - amount < 0 && alive)
        {
            health = 0;
            alive = false;
            DiedEvent.Invoke();
        } else {
            health -= amount;
        }
        damageTakenEvent.Invoke(health);
    }
}

