using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health;

    public void DamagePlayer(int damageAmount)
    {
        health -= damageAmount;
        if(health <= 0)
        {
            GameManager.Instance.ProcessGameOver();
            AudioManager.Instance.PlayDeadClip();
        }
    }
}
