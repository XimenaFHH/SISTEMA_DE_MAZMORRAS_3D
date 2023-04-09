using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 10f;

    // Variables para almacenar la posición y rotación del jugador
    private Vector3 playerPosition;
    private Quaternion playerRotation;

    // Agrega un objeto de texto como una variable pública
    public Text textObjectP;  
    public Text textObjectR;

    private void UpdatePlayerInfo()
    {
        playerPosition = transform.position;
        playerRotation = transform.rotation;
    }

    // Start is called before the first frame update
    private void ShowPlayerInfo()
    {
        textObjectP.text = "Posición: " + playerPosition;
        textObjectR.text = "Rotación: " + playerRotation;
    }


    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        UpdatePlayerInfo();
        ShowPlayerInfo();
    }
}
