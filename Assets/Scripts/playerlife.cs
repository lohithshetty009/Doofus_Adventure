using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerlife : MonoBehaviour
{
    bool dead = false;//Set a variable to check if he is dead and to reload the scene
    private void Update()
    {
        if (transform.position.y < -1f && !dead)
        {
            Die();
        }
    }
    //To call new scene or game when he is dead mention here
    void Die()
    {
        Invoke(nameof(ReloadLevel), 1f);
        dead = true;
    }
    //Function reload level to load new game after player is dead
    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
