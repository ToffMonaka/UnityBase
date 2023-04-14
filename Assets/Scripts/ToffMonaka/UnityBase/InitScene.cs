/**
 * @file
 * @brief InitSceneファイル
 */


namespace ToffMonaka.UnityBase {
/**
 * @brief InitSceneクラス
 */
public class InitScene : UnityEngine.MonoBehaviour
{
    /**
     * @brief Start関数
     */
    void Start()
    {
        this.Invoke(nameof(ChangeScene), 3.0f);

        return;
    }

    /**
     * @brief Update関数
     */
    void Update()
    {
        return;
    }

    /**
     * @brief ChangeScene関数
     */
    void ChangeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("PlayScene");

        return;
    }
}
}
