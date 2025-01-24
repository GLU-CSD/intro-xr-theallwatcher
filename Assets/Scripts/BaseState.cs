using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private health health;

    private void Update()
    {
        
        if (health != null)
        {
            if (gameManager != null)
            {
                if (health.currentHealth <= 0)
                {
                    gameManager.GameOver();
                    Debug.Log("base dead");
                    Destroy(gameObject);
                }
            }
            else
            {
                Debug.Log("Base has no reference to GameManager");
            }

        }
        else
        {
            Debug.Log("Base has no reference to Health");
        }
    }
}
