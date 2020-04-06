using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSetup : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private bool respawned = false;
    [SerializeField] private Text t_respawn;

    private float respawnTime = 0;
    private int spawnIndex = 0;
    private List<GameObject> spawnPoints = new List<GameObject>();

    private void Start()
    {
        // Get all spawn points in this objects children
        foreach (Transform t in transform)
        {
            spawnPoints.Add(t.gameObject);
        }

        // Instantiate the player at the first spawn point in the list
        Instantiate(playerPrefab, spawnPoints[spawnIndex].transform.position, spawnPoints[spawnIndex].transform.rotation);
    }

    private void Update()
    {
        RespawnPlayer();
    }

    void RespawnPlayer()
    {
        if (Player.instance.health <= 0f && Player.instance.isDead == false)
        {
            Player.instance.health = 0f;
            Player.instance.isDead = true;

            // Set the respawn time
            respawnTime = 4;

            // Assign players to the next spawn point (round robin)
            spawnIndex++;
        }

        if (Player.instance.isDead)
        {
            // Start counting down the respawn time
            respawnTime -= Time.deltaTime;

            // Display text to the screen
            t_respawn.text = "Respawn in " + respawnTime.ToString("F0");

            // When the respawn time reaches zero, respawn the player
            if (respawnTime < 0)
            {
                respawned = true;
                Player.instance.isDead = false;

                // Loop spawn list
                if (spawnIndex == spawnPoints.Count)
                    spawnIndex = 0;

                // Instantiate the player at the next spawn point in the list
                Instantiate(playerPrefab, spawnPoints[spawnIndex].transform.position, spawnPoints[spawnIndex].transform.rotation);
            }
        }
        else
        {
            // If the player is not dead, clear the respawn text
            t_respawn.text = "";
        }
    }
}
