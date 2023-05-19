/**
 * @file
 * @brief Scriptファイル
 */


using UnityEngine;


namespace ToffMonaka.Lib.Scene {
/**
 * @brief ScriptCreateDescクラス
 */
public class ScriptCreateDesc
{
}

/**
 * @brief Scriptクラス
 */
public abstract class Script : MonoBehaviour
{
    public ToffMonaka.Lib.Scene.ScriptCreateDesc createDesc{get; private set;} = null;
    private ToffMonaka.Lib.Scene.Manager _manager = null;
    private int _scriptType = 0;
    private int _scriptIndex = 0;

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
     * @brief _Destroy関数
     */
    protected virtual void _Destroy()
    {
        this._OnDestroy();

        if (this._manager != null) {
            this._manager.RemoveScript(this);

            this._manager = null;
        }

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
     * @brief DestroyByManager関数
     */
    public void DestroyByManager()
    {
        this._Destroy();

        return;
    }

    /**
     * @brief Create関数
     * @param desc (desc)
     * @return result (result)<br>
     * 0未満=失敗
     */
    public int Create(ToffMonaka.Lib.Scene.ScriptCreateDesc desc = null)
    {
        if (desc != null) {
            this.SetCreateDesc(desc);
        }

        {// This Create
            if (ToffMonaka.Lib.Scene.Util.GetManager() != null) {
                if (ToffMonaka.Lib.Scene.Util.GetManager().AddScript(this) < 0) {
                    return (-1);
                }
            } else {
                return (-1);
            }
        }

        int create_res = this._OnCreate();

        if (create_res < 0) {
            return (create_res);
        }

        this.gameObject.SetActive(true);

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
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public virtual void SetCreateDesc(ToffMonaka.Lib.Scene.ScriptCreateDesc create_desc)
    {
        this.createDesc = create_desc;

        return;
    }

    /**
     * @brief _Active関数
     */
    protected virtual void _Active()
    {
        if (this._manager == null) {
            return;
        }

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
     * @brief _Deactive関数
     */
    protected virtual void _Deactive()
    {
        if (this._manager == null) {
            return;
        }

        this._OnDeactive();

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
     * @brief _Update関数
     */
    protected virtual void _Update()
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
     * @brief _FixedUpdate関数
     */
    protected virtual void _FixedUpdate()
    {
        this._OnFixedUpdate();

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
        this._OnLateUpdate();

        return;
    }

    /**
     * @brief _OnLateUpdate関数
     */
    protected virtual void _OnLateUpdate()
    {
        return;
    }

    /**
     * @brief GetManager関数
     * @return manager (manager)
     */
    public ToffMonaka.Lib.Scene.Manager GetManager()
    {
        return (this._manager);
    }

    /**
     * @brief SetManager関数
     * @param manager (manager)
     */
    public void SetManager(ToffMonaka.Lib.Scene.Manager manager)
    {
        this._manager = manager;

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
}
}
