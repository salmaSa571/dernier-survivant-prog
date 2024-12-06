using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Flèches Gauche/Droite
        float moveVertical = Input.GetAxis("Vertical");     // Flèches Haut/Bas

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}
