using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerScript : MonoBehaviour
{
    bool _gameOver = false;
    [SerializeField] CinemachineVirtualCamera _endCamera;

    [SerializeField] private TMP_Text _gameOverText;
    [SerializeField] private GameObject _replayButton;

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

        if (_gameOver && Input.GetKeyDown(KeyCode.R)) {
            LoadGameScene("SpaceIntro");
        }
    }

    public void LoadGameScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void GameOver()
    {
        _gameOver = true;
        _gameOverText.enabled = true;
        _replayButton.SetActive(true);
    }

    public void ReplayTimeline (PlayableDirector _director)
    {
        _replayButton.SetActive(false);
        _director.Stop();
        _director.Play();
    }
}
