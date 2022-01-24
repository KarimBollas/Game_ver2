using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitcher : MonoBehaviour
{
    public int escenaNumero;
    public void SceneSwitch()
    {
        SceneManager.LoadScene(1);
    }
}
