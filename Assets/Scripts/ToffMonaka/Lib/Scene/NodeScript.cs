/**
 * @file
 * @brief NodeScriptファイル
 */


using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;


namespace ToffMonaka {
namespace Lib.Scene {
/**
 * @brief NodeScriptCreateDescクラス
 */
public class NodeScriptCreateDesc : Lib.Scene.ScriptCreateDesc
{
}

/**
 * @brief NodeScriptクラス
 */
public abstract class NodeScript : Lib.Scene.Script
{
    public new Lib.Scene.NodeScriptCreateDesc createDesc{get; private set;} = null;

    private bool _activeAutoFlag = true;
    private bool _activedFlag = false;
    private int _openType = 0;
    private int _openedType = 0;
    private bool _openFlag = false;
    private bool _openedFlag = false;
    private int _closeType = 0;
    private int _closedType = 0;
    private bool _closeFlag = false;
    private bool _closedFlag = true;
    private List<Sequence> _openCloseSequenceContainer = new List<Sequence>();
    private bool _controlFlag = false;

    /**
     * @brief コンストラクタ
     * @param script_type (script_type)
     * @param active_auto_flg (active_auto_flag)
     */
    public NodeScript(Lib.Util.SCENE.SCRIPT_TYPE script_type, bool active_auto_flg) : base(script_type)
    {
        this._activeAutoFlag = active_auto_flg;

        return;
    }

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)Lib.Util.SCENE.SCRIPT_INDEX.NODE);
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

        if (this.GetManager() != null) {
            this.GetManager().RemoveScript(this);
        }

        return;
    }

    /**
     * @brief _OnSetNode関数
     */
    protected virtual void _OnSetNode()
    {
        return;
    }

    /**
     * @brief Create関数
     * @param desc (desc)
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    public override int Create(Lib.Scene.ScriptCreateDesc desc = null)
    {
        if (this.GetManager() == null) {
            if (this._activeAutoFlag) {
                this.gameObject.SetActive(true);
                this.gameObject.SetActive(false);
            }
        }

        {// This Create
            if (desc != null) {
                this.SetCreateDesc(desc);
            }

            if (Lib.Scene.Util.GetManager() != null) {
                if (Lib.Scene.Util.GetManager().AddScript(this) < 0) {
                    return (-1);
                }
            } else {
                return (-1);
            }

            this._OnSetNode();
        }

        int create_result_val = this._OnCreate();

        if (create_result_val < 0) {
            return (create_result_val);
        }

        this._controlFlag = true;

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as Lib.Scene.NodeScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _Active関数
     */
    protected override void _Active()
    {
        if ((this.GetManager() == null)
        || (this._activedFlag)) {
            return;
        }

        this._OnActive();

        this._activedFlag = true;

        return;
    }

    /**
     * @brief _Deactive関数
     */
    protected override void _Deactive()
    {
        if ((this.GetManager() == null)
        || (!this._activedFlag)) {
            return;
        }

        this._OnDeactive();

        this._activedFlag = false;

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

    /**
     * @brief GetActiveAutoFlag関数
     * @return active_auto_flg (active_auto_flag)
     */
    public bool GetActiveAutoFlag()
    {
        return (this._activeAutoFlag);
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
     * @param opened_type (opened_type)
     */
    public void Open(int open_type = 0, int opened_type = 0)
    {
        if (this._activeAutoFlag) {
            this.gameObject.SetActive(true);
        }

        if (!this.gameObject.activeSelf) {
            return;
        }

        this._openType = open_type;
        this._openedType = opened_type;
        this._openFlag = true;
        this._openedFlag = false;
        this._closeFlag = false;
        this._closedFlag = false;
        this.RemoveOpenCloseSequence();

        this._OnOpen();

        if (this._openFlag) {
            this._OnUpdateOpen();
        }

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
     * @param closed_type (closed_type)
     */
    public void Close(int close_type = 0, int closed_type = 0)
    {
        if (!this.gameObject.activeSelf) {
            return;
        }

        this._closeType = close_type;
        this._closedType = closed_type;
        this._openFlag = false;
        this._openedFlag = false;
        this._closeFlag = true;
        this._closedFlag = false;
        this.RemoveOpenCloseSequence();

        this._OnClose();

        if (this._closeFlag) {
            this._OnUpdateClose();
        }

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
     * @brief GetOpenedType関数
     * @return opened_type (opened_type)
     */
    public int GetOpenedType()
    {
        return (this._openedType);
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
     * @brief GetClosedType関数
     * @return closed_type (closed_type)
     */
    public int GetClosedType()
    {
        return (this._closedType);
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

    /**
     * @brief AddOpenCloseSequence関数
     * @param open_close_sequence (open_close_sequence)
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    public int AddOpenCloseSequence(Sequence open_close_sequence)
    {
        if (open_close_sequence == null) {
            return (-1);
        }

        this._openCloseSequenceContainer.Add(open_close_sequence);

        return (0);
    }

    /**
     * @brief RemoveOpenCloseSequence関数
     */
    public void RemoveOpenCloseSequence()
    {
        foreach (var open_close_sequence in this._openCloseSequenceContainer) {
            if (open_close_sequence.IsActive()) {
                open_close_sequence.Kill();
            }
        }

        this._openCloseSequenceContainer.Clear();

        return;
    }

    /**
     * @brief IsActiveOpenCloseSequence関数
     * @return active_flg (active_flag)<br>
     * false=非アクティブ,true=アクティブ
     */
    public bool IsActiveOpenCloseSequence()
    {
        bool active_flg = false;

        foreach (var open_close_sequence in this._openCloseSequenceContainer) {
            if (open_close_sequence.IsActive()) {
                active_flg = true;

                break;
            }
        }

        return (active_flg);
    }

    /**
     * @brief GetControlFlag関数
     * @return ctrl_flg (control_flg)
     */
    public bool GetControlFlag()
    {
        return (this._controlFlag);
    }

    /**
     * @brief SetControlFlag関数
     * @param ctrl_flg (control_flg)
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
        if (!this._controlFlag) {
            return (false);
        }

        if (this.GetClosedFlag()) {
            return (false);
        }

        if (this.IsActiveOpenCloseSequence()) {
            return (false);
        }

        return (true);
    }
}
}
}
