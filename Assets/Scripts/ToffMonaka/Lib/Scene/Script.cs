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
    private ToffMonaka.Lib.Constant.Util.SCENE.SCRIPT_TYPE _scriptType = ToffMonaka.Lib.Constant.Util.SCENE.SCRIPT_TYPE.NONE;
    private int _scriptIndex = 0;
    private bool _activeAutoFlag = true;
    private bool _activedFlag = false;
    private int _openType = 0;
    private bool _openFlag = false;
    private bool _openedFlag = false;
    private int _closeType = 0;
    private bool _closeFlag = false;
    private bool _closedFlag = true;

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
        if (this._manager == null) {
            if (this._activeAutoFlag) {
                this.gameObject.SetActive(true);
                this.gameObject.SetActive(false);
            }
        }

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
        if ((this._manager == null)
        || (this._activedFlag)) {
            //return;
        }

        this._OnActive();

        this._activedFlag = true;

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
        if ((this._manager == null)
        || (!this._activedFlag)) {
            return;
        }

        this._OnDeactive();

        this._activedFlag = false;

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
        if (this._openFlag) {
            this._OnUpdateOpen();
        }

        if (this._closeFlag) {
            this._OnUpdateClose();
        }


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
    public ToffMonaka.Lib.Constant.Util.SCENE.SCRIPT_TYPE GetScriptType()
    {
        return (this._scriptType);
    }

    /**
     * @brief _SetScriptType関数
     * @param script_type (script_type)
     */
    protected void _SetScriptType(ToffMonaka.Lib.Constant.Util.SCENE.SCRIPT_TYPE script_type)
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
     * @brief GetActiveAutoFlag関数
     * @return active_auto_flg (active_auto_flag)
     */
    public bool GetActiveAutoFlag()
    {
        return (this._activeAutoFlag);
    }

    /**
     * @brief _SetActiveAutoFlag関数
     * @param active_auto_flg (active_auto_flag)
     */
    protected void _SetActiveAutoFlag(bool active_auto_flg)
    {
        this._activeAutoFlag = active_auto_flg;

        return;
    }

    /**
     * @brief GetActivedFlag関数
     * @return actived_flg (actived_flag)
     */
    public bool GetActivedFlag()
    {
        return (this._activedFlag);
    }

    /**
     * @brief Open関数
     * @param open_type (open_type)
     */
    public void Open(int open_type)
    {
        if (this._activeAutoFlag) {
            this.gameObject.SetActive(true);
        }

        if (!this.gameObject.activeSelf) {
            return;
        }

        this._openType = open_type;
        this._openFlag = true;
        this._openedFlag = false;
        this._closeFlag = false;
        this._closedFlag = true;

        this._OnOpen();

        return;
    }

    /**
     * @brief CompleteOpen関数
     */
    protected void CompleteOpen()
    {
        if (!this._openFlag) {
            return;
        }

        this._openFlag = false;
        this._openedFlag = true;

        return;
    }

    /**
     * @brief _OnOpen関数
     */
    protected virtual void _OnOpen()
    {
        this.CompleteOpen();

        return;
    }

    /**
     * @brief _OnUpdateOpen関数
     */
    protected virtual void _OnUpdateOpen()
    {
        this.CompleteOpen();

        return;
    }

    /**
     * @brief Close関数
     * @param close_type (close_type)
     */
    public void Close(int close_type)
    {
        this._closeType = close_type;
        this._openFlag = false;
        this._openedFlag = true;
        this._closeFlag = true;
        this._closedFlag = false;

        this._OnClose();

        return;
    }

    /**
     * @brief CompleteClose関数
     */
    protected void CompleteClose()
    {
        if (!this._closeFlag) {
            return;
        }

        this._closeFlag = false;
        this._closedFlag = true;

        if (this._activeAutoFlag) {
            this.gameObject.SetActive(false);
        }

        return;
    }

    /**
     * @brief _OnClose関数
     */
    protected virtual void _OnClose()
    {
        this.CompleteClose();

        return;
    }

    /**
     * @brief _OnUpdateClose関数
     */
    protected virtual void _OnUpdateClose()
    {
        this.CompleteClose();

        return;
    }

    /**
     * @brief GetOpenType関数
     * @return open_type (open_type)
     */
    public int GetOpenType()
    {
        return (this._openType);
    }

    /**
     * @brief GetOpenFlag関数
     * @return open_flg (open_flag)
     */
    public bool GetOpenFlag()
    {
        return (this._openFlag);
    }

    /**
     * @brief GetOpenedFlag関数
     * @return opened_flg (opened_flag)
     */
    public bool GetOpenedFlag()
    {
        return (this._openedFlag);
    }

    /**
     * @brief GetCloseType関数
     * @return close_type (close_type)
     */
    public int GetCloseType()
    {
        return (this._closeType);
    }

    /**
     * @brief GetCloseFlag関数
     * @return close_flg (close_flag)
     */
    public bool GetCloseFlag()
    {
        return (this._closeFlag);
    }

    /**
     * @brief GetClosedFlag関数
     * @return closed_flg (closed_flag)
     */
    public bool GetClosedFlag()
    {
        return (this._closedFlag);
    }
}
}
