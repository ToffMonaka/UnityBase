/**
 * @file
 * @brief Scriptファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace Lib.Scene {
/**
 * @brief Scriptクラス
 */
public abstract class Script : MonoBehaviour
{
    /**
     * @brief コンストラクタ
     */
    public Script()
    {
        return;
    }

    /**
     * @brief Awake関数
     */
    private void Awake()
    {
        this._Awake();

        return;
    }

    /**
     * @brief OnDestroy関数
     */
    private void OnDestroy()
    {
        this._Destroy();

        return;
    }

    /**
     * @brief OnEnable関数
     */
    private void OnEnable()
    {
        this._Active();

        return;
    }

    /**
     * @brief OnDisable関数
     */
    private void OnDisable()
    {
        this._Deactive();

        return;
    }

    /**
     * @brief Start関数
     */
    private void Start()
    {
        this._FirstUpdate();

        return;
    }

    /**
     * @brief Update関数
     */
    private void Update()
    {
        this._Update();

        return;
    }

    /**
     * @brief FixedUpdate関数
     */
    private void FixedUpdate()
    {
        this._FixedUpdate();

        return;
    }

    /**
     * @brief LateUpdate関数
     */
    private void LateUpdate()
    {
        this._LateUpdate();

        return;
    }

    /**
     * @brief _Awake関数
     */
    protected virtual void _Awake()
    {
        return;
    }

    /**
     * @brief _OnAwake関数
     */
    protected virtual void _OnAwake()
    {
        return;
    }

    /**
     * @brief _Destroy関数
     */
    protected virtual void _Destroy()
    {
        return;
    }

    /**
     * @brief _OnDestroy関数
     */
    protected virtual void _OnDestroy()
    {
        return;
    }

    /**
     * @brief _Active関数
     */
    protected virtual void _Active()
    {
        return;
    }

    /**
     * @brief _OnActive関数
     */
    protected virtual void _OnActive()
    {
        return;
    }

    /**
     * @brief _Deactive関数
     */
    protected virtual void _Deactive()
    {
        return;
    }

    /**
     * @brief _OnDeactive関数
     */
    protected virtual void _OnDeactive()
    {
        return;
    }

    /**
     * @brief _FirstUpdate関数
     */
    protected virtual void _FirstUpdate()
    {
        return;
    }

    /**
     * @brief _OnFirstUpdate関数
     */
    protected virtual void _OnFirstUpdate()
    {
        return;
    }

    /**
     * @brief _Update関数
     */
    protected virtual void _Update()
    {
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
     * @brief _FixedUpdate関数
     */
    protected virtual void _FixedUpdate()
    {
        return;
    }

    /**
     * @brief _OnFixedUpdate関数
     */
    protected virtual void _OnFixedUpdate()
    {
        return;
    }

    /**
     * @brief _LateUpdate関数
     */
    protected virtual void _LateUpdate()
    {
        return;
    }

    /**
     * @brief _OnLateUpdate関数
     */
    protected virtual void _OnLateUpdate()
    {
        return;
    }
}
}
}
