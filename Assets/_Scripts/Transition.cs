using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{ 
    public void LoadScene()
    {
        SceneManager.LoadScene("Map1");
    }
}
