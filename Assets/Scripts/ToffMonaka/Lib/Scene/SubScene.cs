/**
 * @file
 * @brief SubSceneファイル
 */


using UnityEngine;


namespace ToffMonaka.Lib.Scene {
/**
 * @brief SubSceneクラス
 */
public abstract class SubScene : MonoBehaviour
{
    private bool _openedFlag = false;

    /**
     * @brief OnEnable関数
     */
    public void OnEnable()
    {
        if (this._openedFlag) {
            return;
        }

        this._OnOpen();

        this._openedFlag = true;

        return;
    }

    /**
     * @brief _OnOpen関数
     */
    protected virtual void _OnOpen()
    {
        return;
    }

    /**
     * @brief OnDisable関数
     */
    public void OnDisable()
    {
        if (!this._openedFlag) {
            return;
        }

        this._OnClose();

        this._openedFlag = false;

        return;
    }

    /**
     * @brief _OnClose関数
     */
    protected virtual void _OnClose()
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

    /**
     * @brief GetOpenedFlag関数
     * @return opened_flg (opened_flag)
     */
    public bool GetOpenedFlag()
    {
        return (this._openedFlag);
    }
}
}
