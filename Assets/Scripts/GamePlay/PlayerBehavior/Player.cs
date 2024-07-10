using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
/*    public void DropLocate(Collectable item)
    {
        Vector2 spawnLocation = transform.position;

        Vector2 spawnOffset = Random.insideUnitCircle * 1.25f;

        Collectable dropItem = Instantiate(item, (spawnLocation + spawnOffset), Quaternion.identity);

        dropItem.rb2d.AddForce(spawnOffset * 0.2f, ForceMode2D.Impulse);
    }*/
}
