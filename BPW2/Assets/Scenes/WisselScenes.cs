using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WisselScenes : MonoBehaviour
{
public void Sceneloader(int SceneIndex)
    {

        SceneManager.LoadScene(SceneIndex);

    }
public void afsluiten()
{
        Application.Quit();


    }
}
