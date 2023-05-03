/**
 * @file
 * @brief Scriptファイル
 */


using UnityEngine;


namespace ToffMonaka.Lib.Scene {
/**
 * @brief Scriptクラス
 */
public abstract class Script : MonoBehaviour
{
    private int _scriptType = 0;
    private int _scriptIndex = 0;
    private ToffMonaka.Lib.Scene.ScriptHolder _holder = null;

    /**
     * @brief Awake関数
     */
    private void Awake()
    {
        this._OnAwake2();
        this._OnAwake();

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
     * @brief _OnAwake2関数
     */
    protected virtual void _OnAwake2()
    {
        return;
    }

    /**
     * @brief OnEnable関数
     */
    private void OnEnable()
    {
        this._OnActive2();
        this._OnActive();

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
     * @brief _OnActive2関数
     */
    protected virtual void _OnActive2()
    {
        return;
    }

    /**
     * @brief OnDisable関数
     */
    private void OnDisable()
    {
        this._OnDeactive();
        this._OnDeactive2();

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
     * @brief _OnDeactive2関数
     */
    protected virtual void _OnDeactive2()
    {
        return;
    }

    /**
     * @brief Start関数
     */
    private void Start()
    {
        this._OnFirstUpdate2();
        this._OnFirstUpdate();

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
     * @brief _OnFirstUpdate2関数
     */
    protected virtual void _OnFirstUpdate2()
    {
        return;
    }

    /**
     * @brief Update関数
     */
    private void Update()
    {
        this._OnUpdate2();
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
     * @brief _OnUpdate2関数
     */
    protected virtual void _OnUpdate2()
    {
        return;
    }

    /**
     * @brief OnDestroy関数
     */
    private void OnDestroy()
    {
        this.Delete();

        return;
    }

    /**
     * @brief Create関数
     * @param holder (holder)
     * @return result (result)<br>
     * 0未満=失敗
     */
    public int Create(ToffMonaka.Lib.Scene.ScriptHolder holder)
    {
        this._SetHolder(holder);

        int create2_res = this._OnCreate2();

        if (create2_res < 0) {
            return (create2_res);
        }

        int create_res = this._OnCreate();

        if (create_res < 0) {
            return (create_res);
        }

        this.SetActiveFlag(true);

        return (0);
    }

    /**
     * @brief _OnCreate関数
     * @return result (result)<br>
     * 0未満=失敗
     */
    protected virtual int _OnCreate()
    {
        return (0);
    }

    /**
     * @brief _OnCreate2関数
     * @return result (result)<br>
     * 0未満=失敗
     */
    protected virtual int _OnCreate2()
    {
        return (0);
    }

    /**
     * @brief Delete関数
     */
    public void Delete()
    {
        this._OnDelete();
        this._OnDelete2();

        this._SetHolder(null);

        return;
    }

    /**
     * @brief _OnDelete関数
     */
    protected virtual void _OnDelete()
    {
        return;
    }

    /**
     * @brief _OnDelete2関数
     */
    protected virtual void _OnDelete2()
    {
        return;
    }

    /**
     * @brief GetActiveFlag関数
     * @return active_flg (active_flag)
     */
    public bool GetActiveFlag()
    {
        return (this.gameObject.activeSelf);
    }

    /**
     * @brief GetActiveFlagInHierarchy関数
     * @return active_flg (active_flag)
     */
    public bool GetActiveFlagInHierarchy()
    {
        return (this.gameObject.activeInHierarchy);
    }

    /**
     * @brief SetActiveFlag関数
     * @param active_flg (active_flag)
     */
    public void SetActiveFlag(bool active_flg)
    {
        this.gameObject.SetActive(active_flg);

        return;
    }

    /**
     * @brief GetScriptType関数
     * @return script_type (script_type)
     */
    public int GetScriptType()
    {
        return (this._scriptType);
    }

    /**
     * @brief _SetScriptType関数
     * @param script_type (script_type)
     */
    protected void _SetScriptType(int script_type)
    {
        this._scriptType = script_type;

        return;
    }

    /**
     * @brief GetScriptIndex関数
     * @return script_index (script_index)
     */
    public int GetScriptIndex()
    {
        return (this._scriptIndex);
    }

    /**
     * @brief _SetScriptIndex関数
     * @param script_index (script_index)
     */
    protected void _SetScriptIndex(int script_index)
    {
        this._scriptIndex = script_index;

        return;
    }

    /**
     * @brief GetHolder関数
     * @return holder (holder)
     */
    public ToffMonaka.Lib.Scene.ScriptHolder GetHolder()
    {
        return (this._holder);
    }

    /**
     * @brief _SetHolder関数
     * @param holder (holder)
     */
    protected void _SetHolder(ToffMonaka.Lib.Scene.ScriptHolder holder)
    {
        if (this._holder != null) {
            this._holder.Remove(this);
        }

        this._holder = holder;

        if (this._holder != null) {
            this._holder.Add(this);
        }

        return;
    }
}
}
