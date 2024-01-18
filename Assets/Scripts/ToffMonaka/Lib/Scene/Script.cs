/**
 * @file
 * @brief Scriptファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace Lib.Scene {
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
    public Lib.Scene.ScriptCreateDesc createDesc{get; private set;} = null;

    private Lib.Scene.Manager _manager = null;
    private Lib.Util.SCENE.SCRIPT_TYPE _scriptType = Lib.Util.SCENE.SCRIPT_TYPE.NONE;
    private int _scriptIndex = (int)Lib.Util.SCENE.SCRIPT_INDEX.NONE;

    /**
     * @brief コンストラクタ
     * @param script_type (script_type)
     */
    public Script(Lib.Util.SCENE.SCRIPT_TYPE script_type)
    {
        this._scriptType = script_type;
        this._scriptIndex = this._OnGetScriptIndex();

        return;
    }

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected virtual int _OnGetScriptIndex()
    {
        return ((int)Lib.Util.SCENE.SCRIPT_INDEX.NONE);
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
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    public virtual int Create(Lib.Scene.ScriptCreateDesc desc = null)
    {
        return (0);
    }

    /**
     * @brief _OnCreate関数
     * @return result_val (result_value)<br>
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
    public virtual void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc)
    {
        this.createDesc = create_desc;

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

    /**
     * @brief GetManager関数
     * @return manager (manager)
     */
    public Lib.Scene.Manager GetManager()
    {
        return (this._manager);
    }

    /**
     * @brief SetManager関数
     * @param manager (manager)
     */
    public void SetManager(Lib.Scene.Manager manager)
    {
        this._manager = manager;

        return;
    }

    /**
     * @brief GetScriptType関数
     * @return script_type (script_type)
     */
    public Lib.Util.SCENE.SCRIPT_TYPE GetScriptType()
    {
        return (this._scriptType);
    }

    /**
     * @brief GetScriptIndex関数
     * @return script_index (script_index)
     */
    public int GetScriptIndex()
    {
        return (this._scriptIndex);
    }
}
}
}
