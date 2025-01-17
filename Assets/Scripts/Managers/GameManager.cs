using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            player.ResetPlayer();
        }
    }
}
