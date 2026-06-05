/**
 * @file
 * @brief NodeScriptファイル
 */

using System.Collections.Generic;
using DG.Tweening;

namespace ToffMonaka {
namespace Tml.Scene {
/**
 * @brief NodeScriptCreateDescクラス
 */
public class NodeScriptCreateDesc : ScriptCreateDesc
{
}

/**
 * @brief NodeScriptクラス
 */
public abstract class NodeScript : Script
{
    public new NodeScriptCreateDesc createDesc{get; private set;} = null;

    private int _openType = 0;
    private bool _openFlag = false;
    private bool _openedFlag = false;
    private int _closeType = 0;
    private bool _closeFlag = false;
    private bool _closedFlag = true;
    private List<Sequence> _openCloseSequenceContainer = new();
    private List<System.Func<NodeScript, bool>> _openCloseCheckerContainer = new();
    private System.Action<NodeScript> _onOpened = null;
    private System.Action<NodeScript> _onClosed = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)SceneUtil.SCRIPT_INDEX.NODE);
    }

    /**
     * @brief _Awake関数
     */
    protected override void _Awake()
    {
        base._Awake();

        return;
    }

    /**
     * @brief _Destroy関数
     */
    protected override void _Destroy()
    {
        base._Destroy();

        return;
    }

    /**
     * @brief _Start関数
     */
    protected override void _Start()
    {
        base._Start();

        return;
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new NodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as NodeScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _Active関数
     */
    protected override void _Active()
    {
        if (!this.GetCreatedFlag()) {
            return;
        }

        this._OnActive();

        return;
    }

    /**
     * @brief _Deactive関数
     */
    protected override void _Deactive()
    {
        if (!this.GetCreatedFlag()) {
            return;
        }

        this._OnDeactive();

        return;
    }

    /**
     * @brief _Update関数
     */
    protected override void _Update()
    {
        if (!this.GetCreatedFlag()) {
            return;
        }

        this._UpdateOpen();
        this._UpdateClose();

        this._OnUpdate();

        return;
    }

    /**
     * @brief _FixedUpdate関数
     */
    protected override void _FixedUpdate()
    {
        if (!this.GetCreatedFlag()) {
            return;
        }

        this._OnFixedUpdate();

        return;
    }

    /**
     * @brief _LateUpdate関数
     */
    protected override void _LateUpdate()
    {
        if (!this.GetCreatedFlag()) {
            return;
        }

        this._OnLateUpdate();

        return;
    }

    /**
     * @brief IsControllable関数
     * @return controllable_flg (controllable_flag)<br>
     * false=コントロール不可,true=コントロール可
     */
    public override bool IsControllable()
    {
        if (!base.IsControllable()) {
            return (false);
        }

        if (!this._openedFlag) {
            return (false);
        }

        return (true);
    }

    /**
     * @brief Open関数
     * @param open_type (open_type)
     * @param on_opened (on_opened)
     */
    public void Open(int open_type = 0, System.Action<NodeScript> on_opened = null)
    {
        if (!this.GetCreatedFlag()) {
            return;
        }

        if (this.GetActiveAutoFlag()) {
            this.gameObject.SetActive(true);
        }

        this._openType = open_type;
        this._openFlag = true;
        this._openedFlag = false;
        this._closeFlag = false;
        this._closedFlag = false;
        this._onOpened = on_opened;
        this.RemoveOpenCloseSequence();
        this.RemoveOpenCloseChecker();

        this._OnOpen();

        this._UpdateOpen();

        return;
    }

    /**
     * @brief _UpdateOpen関数
     */
    private void _UpdateOpen()
    {
        if (!this._openFlag) {
            return;
        }

        if (this.IsOpenClose()) {
            return;
        }

        this._openFlag = false;
        this._openedFlag = true;

        this._OnOpened();
        this._onOpened?.Invoke(this);

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
     * @brief _OnOpened関数
     */
    protected virtual void _OnOpened()
    {
        return;
    }

    /**
     * @brief Close関数
     * @param close_type (close_type)
     * @param on_closed (on_closed)
     */
    public void Close(int close_type = 0, System.Action<NodeScript> on_closed = null)
    {
        if (!this.GetCreatedFlag()) {
            return;
        }

        this._closeType = close_type;
        this._openFlag = false;
        this._openedFlag = false;
        this._closeFlag = true;
        this._closedFlag = false;
        this._onClosed = on_closed;
        this.RemoveOpenCloseSequence();
        this.RemoveOpenCloseChecker();

        this._OnClose();

        this._UpdateClose();

        return;
    }

    /**
     * @brief _UpdateClose関数
     */
    private void _UpdateClose()
    {
        if (!this._closeFlag) {
            return;
        }

        if (this.IsOpenClose()) {
            return;
        }

        this._closeFlag = false;
        this._closedFlag = true;

        this._OnClosed();
        this._onClosed?.Invoke(this);

        if (this.GetActiveAutoFlag()) {
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
     * @brief _OnClosed関数
     */
    protected virtual void _OnClosed()
    {
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

    /**
     * @brief IsOpenClose関数
     * @return active_flg (active_flag)<br>
     * false=非アクティブ,true=アクティブ
     */
    public bool IsOpenClose()
    {
        bool active_flg = false;

        foreach (var open_close_sequence in this._openCloseSequenceContainer) {
            if (open_close_sequence.IsActive()) {
                active_flg = true;

                break;
            }
        }

        foreach (var open_close_checker in this._openCloseCheckerContainer) {
            if (open_close_checker(this)) {
                active_flg = true;

                break;
            }
        }

        return (active_flg);
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
     * @brief AddOpenCloseChecker関数
     * @param open_close_checker (open_close_checker)
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    public int AddOpenCloseChecker(System.Func<NodeScript, bool> open_close_checker)
    {
        if (open_close_checker == null) {
            return (-1);
        }

        this._openCloseCheckerContainer.Add(open_close_checker);

        return (0);
    }

    /**
     * @brief RemoveOpenCloseChecker関数
     */
    public void RemoveOpenCloseChecker()
    {
        this._openCloseCheckerContainer.Clear();

        return;
    }
}
}
}
