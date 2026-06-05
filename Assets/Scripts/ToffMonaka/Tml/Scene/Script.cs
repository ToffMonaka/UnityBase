/**
 * @file
 * @brief Scriptファイル
 */

using UnityEngine;

namespace ToffMonaka {
namespace Tml.Scene {
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
    public ScriptCreateDesc createDesc{get; private set;} = null;

    private SceneUtil.SCRIPT_TYPE _scriptType = SceneUtil.SCRIPT_TYPE.NONE;
    private int _scriptIndex = (int)SceneUtil.SCRIPT_INDEX.NONE;
    private bool _activeAutoFlag = true;
    private bool _managerAddedFlag = false;
    private bool _awakedFlag = false;
    private bool _createdFlag = false;
    private bool _controlFlag = false;

    /**
     * @brief _OnGetScriptType関数
     * @return script_type (script_type)
     */
    protected virtual SceneUtil.SCRIPT_TYPE _OnGetScriptType()
    {
        return (SceneUtil.SCRIPT_TYPE.NONE);
    }

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected virtual int _OnGetScriptIndex()
    {
        return ((int)SceneUtil.SCRIPT_INDEX.NONE);
    }

    /**
     * @brief _OnGetActiveAutoFlag関数
     * @return active_auto_flg (active_auto_flag)
     */
    protected virtual bool _OnGetActiveAutoFlag()
    {
        return (true);
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
     * @brief Start関数
     */
    private void Start()
    {
        this._Start();

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
        if (this._awakedFlag) {
            return;
        }

        this._scriptType = this._OnGetScriptType();
        this._scriptIndex = this._OnGetScriptIndex();
        this._activeAutoFlag = this._OnGetActiveAutoFlag();

        this._OnAwake();

        this._awakedFlag = true;

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

        SceneUtil.GetManager()?.RemoveScript(this);

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
     * @brief _Start関数
     */
    protected virtual void _Start()
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
     * @brief Create関数
     * @param desc (desc)
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    public virtual int Create(ScriptCreateDesc desc = null)
    {
        this._Awake();

        this._createdFlag = false;
        this._controlFlag = false;

        if (this._activeAutoFlag) {
            this.gameObject.SetActive(true);
        }

        {// This Create
            this.SetCreateDesc(desc);

            if ((SceneUtil.GetManager() == null)
            || (SceneUtil.GetManager().AddScript(this) < 0)) {
                return (-1);
            }
        }

        int create_result_val = this._OnCreate();

        if (create_result_val < 0) {
            return (create_result_val);
        }

        if (this._activeAutoFlag) {
            this.gameObject.SetActive(false);
        }

        this._createdFlag = true;
        this._controlFlag = true;

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
    public virtual void SetCreateDesc(ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new ScriptCreateDesc());

            return;
        }

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
     * @brief GetScriptType関数
     * @return script_type (script_type)
     */
    public SceneUtil.SCRIPT_TYPE GetScriptType()
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

    /**
     * @brief GetActiveAutoFlag関数
     * @return active_auto_flg (active_auto_flag)
     */
    public bool GetActiveAutoFlag()
    {
        return (this._activeAutoFlag);
    }

    /**
     * @brief GetManagerAddedFlag関数
     * @return manager_added_flg (manager_added_flag)
     */
    public bool GetManagerAddedFlag()
    {
        return (this._managerAddedFlag);
    }

    /**
     * @brief SetManagerAddedFlag関数
     * @param manager_added_flg (manager_added_flag)
     */
    public void SetManagerAddedFlag(bool manager_added_flg)
    {
        this._managerAddedFlag = manager_added_flg;

        return;
    }

    /**
     * @brief GetAwakedFlag関数
     * @return awaked_flg (awaked_flag)
     */
    public bool GetAwakedFlag()
    {
        return (this._awakedFlag);
    }

    /**
     * @brief GetCreatedFlag関数
     * @return created_flg (created_flag)
     */
    public bool GetCreatedFlag()
    {
        return (this._createdFlag);
    }

    /**
     * @brief GetControlFlag関数
     * @return ctrl_flg (control_flag)
     */
    public bool GetControlFlag()
    {
        return (this._controlFlag);
    }

    /**
     * @brief SetControlFlag関数
     * @param ctrl_flg (control_flag)
     */
    public void SetControlFlag(bool ctrl_flg)
    {
        this._controlFlag = ctrl_flg;

        return;
    }

    /**
     * @brief IsControllable関数
     * @return controllable_flg (controllable_flag)<br>
     * false=コントロール不可,true=コントロール可
     */
    public virtual bool IsControllable()
    {
        if (!this._createdFlag) {
            return (false);
        }

        if (!this._controlFlag) {
            return (false);
        }

        if (SceneUtil.GetManager() != null) {
            var main_scene_node_script = SceneUtil.GetManager().GetMainSceneNodeScript();

            if ((main_scene_node_script != null)
            && (!main_scene_node_script.GetOpenedFlag())) {
                return (false);
            }

            var sub_scene_node_script = SceneUtil.GetManager().GetSubSceneNodeScript();

            if ((sub_scene_node_script != null)
            && (!sub_scene_node_script.GetOpenedFlag())) {
                return (false);
            }
        }

        return (true);
    }
}
}
}
