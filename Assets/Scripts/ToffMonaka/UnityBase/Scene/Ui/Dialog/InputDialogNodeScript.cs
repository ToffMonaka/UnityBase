/**
 * @file
 * @brief InputDialogNodeScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui.Dialog {
/**
 * @brief InputDialogNodeScriptCreateDescクラス
 */
public class InputDialogNodeScriptCreateDesc : UnityBase.Scene.Ui.Dialog.DialogNodeScriptCreateDesc
{
    public UnityBase.Scene.Ui.Dialog.InputDialogEngine engine = null;
    public System.Action<UnityBase.Scene.Ui.Dialog.InputDialogNodeScript> onClickOkButton = null;

    /**
     * @brief GetPrefabFilePath関数
     * @return prefab_file_path (prefab_file_path)
     */
    public override string GetPrefabFilePath()
    {
        return (UnityBase.Util.FILE_PATH.INPUT_DIALOG_PREFAB);
    }

    /**
     * @brief GetNewScript関数
     * @param prefab_file_path (prefab_file_path)
     * @return script (script)
     */
    public override UnityBase.Scene.Ui.Dialog.DialogNodeScript GetNewScript(string prefab_file_path)
    {
        var node = ToffMonaka.Tml.Scene.SceneUtil.GetPrefabNode(prefab_file_path);

        return (node.GetComponent<UnityBase.Scene.Ui.Dialog.InputDialogNodeScript>());
    }
}

/**
 * @brief InputDialogNodeScriptクラス
 */
public class InputDialogNodeScript : UnityBase.Scene.Ui.Dialog.DialogNodeScript
{
    [SerializeField] private TMP_Text _nameText = null;
    [SerializeField] private TMP_InputField _inputField = null;
    [SerializeField] private Scrollbar _inputFieldScrollbar = null;
    [SerializeField] private TMP_Text _okButtonNameText = null;
    [SerializeField] private TMP_Text _cancelButtonNameText = null;

    public new UnityBase.Scene.Ui.Dialog.InputDialogNodeScriptCreateDesc createDesc{get; private set;} = null;

    private UnityBase.Scene.Ui.Dialog.InputDialogEngine _engine = null;
    private System.Action<UnityBase.Scene.Ui.Dialog.InputDialogNodeScript> _onClickOkButton = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)UnityBase.Util.SCENE.SCRIPT_INDEX.INPUT_DIALOG_NODE);
    }

    /**
     * @brief _OnAwake関数
     */
    protected override void _OnAwake()
    {
        base._OnAwake();

        return;
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
        this._okButtonNameText.transform.parent.gameObject.SetActive((this._onClickOkButton != null));
        this._okButtonNameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.OK));
        this._cancelButtonNameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.CANCEL));

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ToffMonaka.Tml.Scene.ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new UnityBase.Scene.Ui.Dialog.InputDialogNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as UnityBase.Scene.Ui.Dialog.InputDialogNodeScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

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

        this._inputField.textComponent.rectTransform.localPosition = Vector3.zero;
        this._inputField.GetComponentInChildren<TMP_SelectionCaret>().rectTransform.localPosition = Vector3.zero;
        this._inputFieldScrollbar.SetValueWithoutNotify(0.0f);

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
     * @brief OnCloseButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnCloseButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        UnityBase.Global.GetSceneManager().PlaySoundSe((int)UnityBase.Util.SOUND.SE_INDEX.CANCEL);

        this.Close(1);

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

        UnityBase.Global.GetSceneManager().PlaySoundSe((int)UnityBase.Util.SOUND.SE_INDEX.OK2);

        this._onClickOkButton?.Invoke(this);

        this.Close(1);

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

        UnityBase.Global.GetSceneManager().PlaySoundSe((int)UnityBase.Util.SOUND.SE_INDEX.CANCEL);

        this.Close(1);

        return;
    }

    /**
     * @brief GetEngine関数
     * @return engine (engine)
     */
    public UnityBase.Scene.Ui.Dialog.InputDialogEngine GetEngine()
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
