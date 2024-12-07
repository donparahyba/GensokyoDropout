using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int health = 100;
    private int MAX_HEALTH = 100;

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Não é possível dano negativo");
        }

        this.health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Não é possível cura negaiva");
        }

        bool WouldBeOverMaxHealth = health + amount > MAX_HEALTH;

        if (WouldBeOverMaxHealth)
        {
            this.health = MAX_HEALTH;
        }
        else
        {
            this.health += amount;
        }
    }

    private void Die()
    {
        Debug.Log("Você Morreu :/");
        Destroy(gameObject);
    }
}