using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventCollision : Collidable
{
    public string escena;

    protected override void OnCollide(Collider2D col)
    {
        if(col.tag == "Player")
        {
            SceneManager.LoadScene(escena);
        }
    }
}
