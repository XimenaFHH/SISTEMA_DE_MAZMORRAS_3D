using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RoomSpawner : MonoBehaviour
{
    public int openSide; // 1 Need Bottom door, 2 Need Top door, 3 Need Left door, 4 Need Right door

    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;

    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke(nameof(Spawn), 0.1f);
    }

    private void Spawn()
    {
        if (spawned) return;

        switch (openSide)
        {
            case 1: // Need Bottom door
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
                break;

            case 2: // Need Top door
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
                break;

            case 3: // Need Left door
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
                break;

            case 4: // Need Right door
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
                break;
        }

        templates.IncrementRoomCount();
        spawned = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("SpawnPoint")) return;

        var otherSpawner = other.GetComponent<RoomSpawner>();
        if (otherSpawner != null && !otherSpawner.spawned && !spawned)
        {
            Instantiate(templates.closedRoom, transform.position, Quaternion.identity); 
            Destroy(gameObject); 
        }

        spawned = true;
    }
}
