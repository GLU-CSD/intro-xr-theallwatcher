using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGrenade : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject towerPrefab;

    void OnCollisionEnter(Collision collision)
    {
        // Controleer of de grenade het terrein raakt
        if (collision.gameObject.CompareTag("Terrain"))
        {
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
