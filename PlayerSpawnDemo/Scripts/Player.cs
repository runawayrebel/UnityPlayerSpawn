using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Create a singleton for this class to be called in GameSetup
    public static Player instance;

    // These have to be public to be called outside of this script
    public float health = 100f;
    public bool isDead = false;

    private Text t_health;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        // Reduce health until player can respawn
        health -= Time.deltaTime * 25;

        if (isDead)
        {
            // When the player dies, destroy the player
            Destroy(gameObject);

            // Optimization: Instead of deleting model, turn off mesh and collider then respawn

            // Turn off mesh renderer and collider
            //GetComponent<MeshRenderer>().enabled = false;
            //GetComponent<Collider>().enabled = false;
        }
        else
        {
            // When the player in instantiated, find the health text on the canvas
            t_health = GameObject.Find("Canvas/Health").GetComponent<Text>();

            // Display the health to the player
            t_health.text = "Health: " + health.ToString("F0");
        }
    }
}
