using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public CollectableType type;
    public Sprite icon;
    public Rigidbody2D rb2d;
    AudioMange audioMange;
    public void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        audioMange = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioMange>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if(player != null)
        {
            player.inventory.Add(this);
            audioMange.PlaySFX(audioMange.collectoItem);
            Destroy(this.gameObject);
        }    
    }

    public enum CollectableType
    {
        None,Gold,Gem
    }
}
