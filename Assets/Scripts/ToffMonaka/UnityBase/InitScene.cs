/**
 * @file
 * @brief InitSceneファイル
 */


using UnityEngine;
using UnityEngine.SceneManagement;


namespace ToffMonaka.UnityBase {
/**
 * @brief InitSceneクラス
 */
public class InitScene : MonoBehaviour
{
    /**
     * @brief Start関数
     */
    public void Start()
    {
        this.Invoke(nameof(_changeScene), 3.0f);

        return;
    }

    /**
     * @brief Update関数
     */
    public void Update()
    {
        return;
    }

    /**
     * @brief _changeScene関数
     */
    private void _changeScene()
    {
        SceneManager.LoadScene("PlayScene");

        return;
    }
}
}
