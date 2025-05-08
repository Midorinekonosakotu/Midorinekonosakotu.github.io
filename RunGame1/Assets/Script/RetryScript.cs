using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RetryScript : MonoBehaviour
{

    public void OnClickStartButton()
    {
        FadeManager.Instance.LoadScene("MainGame", 3.0f);
    }
}
