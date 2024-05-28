/**
 * @file
 * @brief EndStageNodeScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui.Menu {
/**
 * @brief EndStageNodeScriptCreateDescクラス
 */
public class EndStageNodeScriptCreateDesc : UnityBase.Scene.Ui.Menu.StageNodeScriptCreateDesc
{
}

/**
 * @brief EndStageNodeScriptクラス
 */
public class EndStageNodeScript : UnityBase.Scene.Ui.Menu.StageNodeScript
{
    [SerializeField] private ScrollRect _scrollRect = null;
    [SerializeField] private TMP_Text _restartNameText = null;
    [SerializeField] private Toggle _restartToggle = null;
    [SerializeField] private TMP_Text _endNameText = null;
    [SerializeField] private Toggle _endToggle = null;
    [SerializeField] private TMP_Text _okButtonNameText = null;
    [SerializeField] private Image _okButtonCoverImage = null;
    [SerializeField] private TMP_Text _cancelButtonNameText = null;
    [SerializeField] private Image _cancelButtonCoverImage = null;

    public new UnityBase.Scene.Ui.Menu.EndStageNodeScriptCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief コンストラクタ
     */
    public EndStageNodeScript() : base(UnityBase.Util.SCENE.MENU_STAGE_TYPE.END)
    {
        return;
    }
    
    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)UnityBase.Util.SCENE.SCRIPT_INDEX.MENU_END_STAGE_NODE);
    }

    /**
     * @brief _OnDestroy関数
     */
    protected override void _OnDestroy()
    {
        base._OnDestroy();

        return;
    }

    /**
     * @brief _OnCreate関数
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    protected override int _OnCreate()
    {
        if (base._OnCreate() < 0) {
            return (-1);
        }

        this._restartNameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.RESTART));
        this._endNameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.EXIT));
        this._okButtonNameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.OK));
        this._cancelButtonNameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.CANCEL));

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as UnityBase.Scene.Ui.Menu.EndStageNodeScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
        base._OnActive();

        this._scrollRect.verticalNormalizedPosition = 1.0f;
        this._restartToggle.SetIsOnWithoutNotify(false);
        this._endToggle.SetIsOnWithoutNotify(false);
        this._okButtonCoverImage.gameObject.SetActive(false);
        this._cancelButtonCoverImage.gameObject.SetActive(false);

        return;
    }

    /**
     * @brief _OnDeactive関数
     */
    protected override void _OnDeactive()
    {
        base._OnDeactive();

        return;
    }

    /**
     * @brief _OnUpdate関数
     */
    protected override void _OnUpdate()
    {
        base._OnUpdate();

        return;
    }

    /**
     * @brief _OnOpen関数
     */
    protected override void _OnOpen()
    {
        base._OnOpen();

        return;
    }

    /**
     * @brief _OnOpened関数
     */
    protected override void _OnOpened()
    {
        base._OnOpened();

        return;
    }

    /**
     * @brief _OnClose関数
     */
    protected override void _OnClose()
    {
        base._OnClose();

        return;
    }

    /**
     * @brief _OnClosed関数
     */
    protected override void _OnClosed()
    {
        base._OnClosed();

        return;
    }

    /**
     * @brief OnRestartToggleValueChanged関数
     * @param event_val (event_value)
     */
    public void OnRestartToggleValueChanged(bool event_val)
    {
        if (this._restartToggle.isOn) {
            this._endToggle.SetIsOnWithoutNotify(false);
        }

        if (!this.IsControllable()) {
            return;
        }

        if (this._restartToggle.isOn) {
            Lib.Scene.Util.GetSoundManager().PlaySe((int)UnityBase.Util.SOUND.SE_INDEX.OK2);
        } else {
            Lib.Scene.Util.GetSoundManager().PlaySe((int)UnityBase.Util.SOUND.SE_INDEX.CANCEL);
        }

        return;
    }

    /**
     * @brief OnEndToggleValueChanged関数
     * @param event_val (event_value)
     */
    public void OnEndToggleValueChanged(bool event_val)
    {
        if (this._endToggle.isOn) {
            this._restartToggle.SetIsOnWithoutNotify(false);
        }

        if (!this.IsControllable()) {
            return;
        }

        if (this._endToggle.isOn) {
            Lib.Scene.Util.GetSoundManager().PlaySe((int)UnityBase.Util.SOUND.SE_INDEX.OK2);
        } else {
            Lib.Scene.Util.GetSoundManager().PlaySe((int)UnityBase.Util.SOUND.SE_INDEX.CANCEL);
        }

        return;
    }

    /**
     * @brief OnOkButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnOkButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        Lib.Scene.Util.GetSoundManager().PlaySe((int)UnityBase.Util.SOUND.SE_INDEX.OK2);

        if (this._restartToggle.isOn) {
            Lib.Scene.Util.GetManager().StartApplication();
        } else if (this._endToggle.isOn) {
            Lib.Scene.Util.GetManager().EndApplication();
        }

        this.GetMenuNodeScript().ChangeStage(UnityBase.Util.SCENE.MENU_STAGE_TYPE.NONE);

        return;
    }

    /**
     * @brief OnOkButtonPointerEnter関数
     * @param event_dat (event_data)
     */
    public void OnOkButtonPointerEnter(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        this._okButtonCoverImage.gameObject.SetActive(true);

        return;
    }

    /**
     * @brief OnOkButtonPointerExit関数
     * @param event_dat (event_data)
     */
    public void OnOkButtonPointerExit(PointerEventData event_dat)
    {
        this._okButtonCoverImage.gameObject.SetActive(false);

        return;
    }

    /**
     * @brief OnCancelButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnCancelButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        Lib.Scene.Util.GetSoundManager().PlaySe((int)UnityBase.Util.SOUND.SE_INDEX.CANCEL);

        this.GetMenuNodeScript().ChangeStage(UnityBase.Util.SCENE.MENU_STAGE_TYPE.NONE);

        return;
    }

    /**
     * @brief OnCancelButtonPointerEnter関数
     * @param event_dat (event_data)
     */
    public void OnCancelButtonPointerEnter(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        this._cancelButtonCoverImage.gameObject.SetActive(true);

        return;
    }

    /**
     * @brief OnCancelButtonPointerExit関数
     * @param event_dat (event_data)
     */
    public void OnCancelButtonPointerExit(PointerEventData event_dat)
    {
        this._cancelButtonCoverImage.gameObject.SetActive(false);

        return;
    }
}
}
}
