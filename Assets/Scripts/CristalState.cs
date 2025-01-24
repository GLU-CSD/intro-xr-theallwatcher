using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristalState : MonoBehaviour
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
                    gameManager.CristalDes();
                    Debug.Log("cristal down");
                    Destroy(gameObject);
                }
            }
            else
            {
                Debug.Log("cristal has no reference to GameManager");
            }

        }
        else
        {
            Debug.Log("cristal has no reference to Health");
        }
    }
}
