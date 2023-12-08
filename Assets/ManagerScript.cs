using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if (UNITY_EDITOR)
            UnityEditor.EditorApplication.isPlaying = false;
#elif (UNITY_STANDALONE)
                Application.Quit();
#elif (UNITY_WEBGL)
                // Doesn't actually fix the problem... and apparently closing the 
                // tab in code was eliminated due to security issues.
                Application.OpenURL("about:blank");
#endif
        }
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("OutdoorsScene");
    }
}
