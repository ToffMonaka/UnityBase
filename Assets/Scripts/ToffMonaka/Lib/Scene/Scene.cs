/**
 * @file
 * @brief Sceneファイル
 */


using UnityEngine;


namespace ToffMonaka.Lib.Scene {
/**
 * @brief Sceneクラス
 */
public abstract class Scene : MonoBehaviour
{
    /**
     * @brief Start関数
     */
    public void Start()
    {
        this.OnStart();

        return;
    }

    /**
     * @brief OnStart関数
     */
    protected virtual void OnStart()
    {
        return;
    }

    /**
     * @brief Update関数
     */
    public void Update()
    {
        this.OnUpdate();

        return;
    }

    /**
     * @brief OnUpdate関数
     */
    protected virtual void OnUpdate()
    {
        return;
    }
}
}
