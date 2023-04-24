/**
 * @file
 * @brief Layerファイル
 */


using UnityEngine;


namespace ToffMonaka.Lib.Scene {
/**
 * @brief Layerクラス
 */
public abstract class Layer : MonoBehaviour
{
    /**
     * @brief Start関数
     */
    public void Start()
    {
        this._OnStart();

        return;
    }

    /**
     * @brief _OnStart関数
     */
    protected virtual void _OnStart()
    {
        return;
    }

    /**
     * @brief Update関数
     */
    public void Update()
    {
        this._OnUpdate();

        return;
    }

    /**
     * @brief _OnUpdate関数
     */
    protected virtual void _OnUpdate()
    {
        return;
    }
}
}
