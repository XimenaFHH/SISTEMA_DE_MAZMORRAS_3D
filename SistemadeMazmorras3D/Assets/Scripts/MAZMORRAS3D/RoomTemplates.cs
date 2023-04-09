using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] rightRooms;
    public GameObject[] leftRooms;

    public GameObject closedRoom;

    public List<GameObject> rooms;

    public GameObject boss;
    public GameObject coins;

    System.Random rnd = new System.Random();

    private int roomCount = 0;
    public Text roomCountText;

    private int gemCount = 0; // variable para contar las gemas generadas
    public TMP_Text gemCountText;


    private void Start()
    {
        Invoke("SpawnEnemies", 10f);
        
    }

    void SpawnEnemies()
    {
        Instantiate(boss, rooms[rooms.Count - 1].transform.position + new Vector3(0, 2, 0), Quaternion.identity);

        for (int i = 0; i < rooms.Count; i++)
        {
            int randomIndex = rnd.Next(rooms.Count);

            //Instanciar el objeto en la posición de la habitación correspondiente
            Instantiate(coins, rooms[randomIndex].transform.position + new Vector3(0, 1.5f, 0), Quaternion.identity);

            gemCount++;
        }
        gemCountText.text = "Gemas generadas: " + gemCount.ToString();
    }

    public void IncrementRoomCount()
    {
        roomCount++;
        UpdateRoomCount();
    }

    private void UpdateRoomCount() 
    {
        roomCountText.text = "Cuartos Generados: " + roomCount.ToString();
    }
}
   



