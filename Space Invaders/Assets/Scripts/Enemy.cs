using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    public System.Action death;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
      
        else
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            this.death.Invoke();

        }


    }
}
