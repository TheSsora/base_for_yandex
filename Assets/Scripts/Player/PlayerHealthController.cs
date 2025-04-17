using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField] private float health;

    public void TakeDamage(float damage)
    {
        if ((health -= damage) <= 0)
        {
            Death();
        }
    }
    private void Death()
    {
        Time.timeScale = 0;
    }
}
