/**
 * @file
 * @brief ComponentScriptファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace Lib.Scene {
/**
 * @brief ComponentScriptクラス
 */
public abstract class ComponentScript : Lib.Scene.Script
{
    /**
     * @brief コンストラクタ
     */
    public ComponentScript()
    {
        return;
    }

    /**
     * @brief _Awake関数
     */
    protected override void _Awake()
    {
        this._OnAwake();

        return;
    }

    /**
     * @brief _Destroy関数
     */
    protected override void _Destroy()
    {
        this._OnDestroy();

        return;
    }

    /**
     * @brief _Active関数
     */
    protected override void _Active()
    {
        this._OnActive();

        return;
    }

    /**
     * @brief _Deactive関数
     */
    protected override void _Deactive()
    {
        this._OnDeactive();

        return;
    }

    /**
     * @brief _FirstUpdate関数
     */
    protected override void _FirstUpdate()
    {
        this._OnFirstUpdate();

        return;
    }

    /**
     * @brief _Update関数
     */
    protected override void _Update()
    {
        this._OnUpdate();

        return;
    }

    /**
     * @brief _FixedUpdate関数
     */
    protected override void _FixedUpdate()
    {
        this._OnFixedUpdate();

        return;
    }

    /**
     * @brief _LateUpdate関数
     */
    protected override void _LateUpdate()
    {
        this._OnLateUpdate();

        return;
    }
}
}
}
