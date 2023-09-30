using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    Character character;
    public Character Character => character;

    void Start()
    {
        instance = this;
        character = GetComponent<Character>();
    }

    //when I click the mouse, move the character to that location
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !TextController.instance.ShowingConversation)
        {
            Vector3 targetDestination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetDestination.z = transform.position.z;
            character.Move(targetDestination);
        }
    }
}
