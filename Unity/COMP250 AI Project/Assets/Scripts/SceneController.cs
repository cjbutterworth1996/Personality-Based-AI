using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class <c>SceneController</c> is used for functions that interact with the game level and scene.
/// </summary>
public class SceneController : MonoBehaviour
{
    /// <summary>
    /// Method <c>SceneReset</c> resets the scene.
    /// </summary>
    public void SceneReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
