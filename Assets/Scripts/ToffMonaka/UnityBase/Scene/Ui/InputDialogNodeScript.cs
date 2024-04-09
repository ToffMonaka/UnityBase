/**
 * @file
 * @brief InputDialogNodeScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui {
/**
 * @brief InputDialogNodeScriptCreateDescクラス
 */
public class InputDialogNodeScriptCreateDesc : UnityBase.Scene.Ui.DialogNodeScriptCreateDesc
{
    public UnityBase.Scene.Ui.InputDialogEngine engine = null;
    public System.Action<UnityBase.Scene.Ui.InputDialogNodeScript> onClickOkButton = null;
}

/**
 * @brief InputDialogNodeScriptクラス
 */
public class InputDialogNodeScript : UnityBase.Scene.Ui.DialogNodeScript
{
    [SerializeField] private TMP_Text _nameText = null;
    [SerializeField] private Image _closeButtonCoverImage = null;
    [SerializeField] private TMP_InputField _inputField = null;
    [SerializeField] private Scrollbar _inputFieldScrollbar = null;
    [SerializeField] private TMP_Text _okButtonNameText = null;
    [SerializeField] private Image _okButtonCoverImage = null;
    [SerializeField] private TMP_Text _cancelButtonNameText = null;
    [SerializeField] private Image _cancelButtonCoverImage = null;

    public new UnityBase.Scene.Ui.InputDialogNodeScriptCreateDesc createDesc{get; private set;} = null;

    private UnityBase.Scene.Ui.InputDialogEngine _engine = null;
    private System.Action<UnityBase.Scene.Ui.InputDialogNodeScript> _onClickOkButton = null;

    /**
     * @brief コンストラクタ
     */
    public InputDialogNodeScript()
    {
        return;
    }
    
    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)UnityBase.Util.SCENE.SCRIPT_INDEX.INPUT_DIALOG_NODE);
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

        if (this.createDesc.engine == null) {
            return (-1);
        }

        this._engine = this.createDesc.engine;
        this._onClickOkButton = this.createDesc.onClickOkButton;

        this._nameText.SetText(this._engine.OnGetName());
        this._okButtonNameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.OK));
        this._cancelButtonNameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.CANCEL));

        if (this._onClickOkButton != null) {
            this._okButtonNameText.transform.parent.gameObject.SetActive(true);
        } else {
            this._okButtonNameText.transform.parent.gameObject.SetActive(false);
        }

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as UnityBase.Scene.Ui.InputDialogNodeScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
        base._OnActive();

        this._closeButtonCoverImage.gameObject.SetActive(false);
        this._inputField.textComponent.rectTransform.localPosition = Vector3.zero;
        this._inputField.GetComponentInChildren<TMP_SelectionCaret>().rectTransform.localPosition = Vector3.zero;
        this._inputFieldScrollbar.SetValueWithoutNotify(0.0f);
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
     * @brief _OnUpdateOpen関数
     */
    protected override void _OnUpdateOpen()
    {
        base._OnUpdateOpen();

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
     * @brief _OnUpdateClose関数
     */
    protected override void _OnUpdateClose()
    {
        base._OnUpdateClose();

        return;
    }

    /**
     * @brief OnCloseButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnCloseButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        Lib.Scene.Util.GetSoundManager().PlaySe((int)UnityBase.Util.SOUND.SE_INDEX.CANCEL);

        this.Close(1);

        return;
    }

    /**
     * @brief OnCloseButtonPointerEnter関数
     * @param event_dat (event_data)
     */
    public void OnCloseButtonPointerEnter(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        this._closeButtonCoverImage.gameObject.SetActive(true);

        return;
    }

    /**
     * @brief OnCloseButtonPointerExit関数
     * @param event_dat (event_data)
     */
    public void OnCloseButtonPointerExit(PointerEventData event_dat)
    {
        this._closeButtonCoverImage.gameObject.SetActive(false);

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

        this._onClickOkButton?.Invoke(this);

        this.Close(1);

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

        this.Close(1);

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

    /**
     * @brief GetEngine関数
     * @return engine (engine)
     */
    public UnityBase.Scene.Ui.InputDialogEngine GetEngine()
    {
        return (this._engine);
    }

    /**
     * @brief GetText関数
     * @return txt (text)
     */
    public string GetText()
    {
        return (this._inputField.text);
    }

    /**
     * @brief SetText関数
     * @param txt (text)
     */
    public void SetText(string txt)
    {
        this._inputField.SetTextWithoutNotify(txt);

        return;
    }
}
}
}
