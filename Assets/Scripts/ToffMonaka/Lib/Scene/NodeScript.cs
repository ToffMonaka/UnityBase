/**
 * @file
 * @brief NodeScriptファイル
 */


using UnityEngine;


namespace ToffMonaka.Lib.Scene {
/**
 * @brief NodeScriptクラス
 */
public abstract class NodeScript : MonoBehaviour
{
    /**
     * @brief OnEnable関数
     */
    private void OnEnable()
    {
        this._OnActivate();
        this._OnActivate2();

        return;
    }

    /**
     * @brief _OnActivate関数
     */
    protected virtual void _OnActivate()
    {
        return;
    }

    /**
     * @brief _OnActivate2関数
     */
    protected virtual void _OnActivate2()
    {
        return;
    }

    /**
     * @brief OnDisable関数
     */
    private void OnDisable()
    {
        this._OnDeactivate();
        this._OnDeactivate2();

        return;
    }

    /**
     * @brief _OnDeactivate関数
     */
    protected virtual void _OnDeactivate()
    {
        return;
    }

    /**
     * @brief _OnDeactivate2関数
     */
    protected virtual void _OnDeactivate2()
    {
        return;
    }

    /**
     * @brief Update関数
     */
    private void Update()
    {
        this._OnUpdate();
        this._OnUpdate2();

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
     * @brief _OnUpdate2関数
     */
    protected virtual void _OnUpdate2()
    {
        return;
    }

    /**
     * @brief GetActivateFlag関数
     * @return activate_flg (activate_flag)
     */
    public bool GetActivateFlag()
    {
        return (this.gameObject.activeSelf);
    }

    /**
     * @brief GetActivateFlagInHierarchy関数
     * @return activate_flg (activate_flag)
     */
    public bool GetActivateFlagInHierarchy()
    {
        return (this.gameObject.activeInHierarchy);
    }

    /**
     * @brief SetActivateFlag関数
     * @param activate_flg (activate_flag)
     */
    public void SetActivateFlag(bool activate_flg)
    {
        this.gameObject.SetActive(activate_flg);

        return;
    }
}
}
