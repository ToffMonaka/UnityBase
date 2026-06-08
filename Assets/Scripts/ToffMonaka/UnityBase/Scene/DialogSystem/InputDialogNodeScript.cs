/**
 * @file
 * @brief InputDialogNodeScriptファイル
 */

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using ToffMonaka.UnityBase.Data;
using ToffMonaka.UnityBase.Sound;

namespace ToffMonaka {
namespace UnityBase.Scene.DialogSystem {
/**
 * @brief InputDialogNodeScriptCreateDescクラス
 */
public class InputDialogNodeScriptCreateDesc : DialogNodeScriptCreateDesc
{
    public InputDialogExtension extension = null;
    public System.Action<InputDialogNodeScript> onClickOkButton = null;

    /**
     * @brief GetPrefabFilePath関数
     * @return prefab_file_path (prefab_file_path)
     */
    public override string GetPrefabFilePath()
    {
        return (Util.FILE_PATH.INPUT_DIALOG_PREFAB);
    }

    /**
     * @brief GetNewScript関数
     * @param prefab_file_path (prefab_file_path)
     * @return script (script)
     */
    public override DialogNodeScript GetNewScript(string prefab_file_path)
    {
        var node = ToffMonaka.Tml.Scene.SceneUtil.GetPrefabNode(prefab_file_path);

        return (node.GetComponent<InputDialogNodeScript>());
    }
}

/**
 * @brief InputDialogNodeScriptクラス
 */
public class InputDialogNodeScript : DialogNodeScript
{
    [SerializeField] private TMP_Text _nameText = null;
    [SerializeField] private TMP_InputField _inputField = null;
    [SerializeField] private Scrollbar _inputFieldScrollbar = null;
    [SerializeField] private TMP_Text _okButtonNameText = null;
    [SerializeField] private TMP_Text _cancelButtonNameText = null;

    public new InputDialogNodeScriptCreateDesc createDesc{get; private set;} = null;

    private InputDialogExtension _extension = null;
    private System.Action<InputDialogNodeScript> _onClickOkButton = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)SceneUtil.SCRIPT_INDEX.INPUT_DIALOG_NODE);
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

        if (this.createDesc.extension == null) {
            return (-1);
        }

        this._extension = this.createDesc.extension;
        this._onClickOkButton = this.createDesc.onClickOkButton;

        this._nameText.SetText(this._extension.OnGetName());
        this._okButtonNameText.transform.parent.gameObject.SetActive((this._onClickOkButton != null));
        this._okButtonNameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.OK));
        this._cancelButtonNameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.CANCEL));

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ToffMonaka.Tml.Scene.ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new InputDialogNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as InputDialogNodeScriptCreateDesc;

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

        SceneUtil.GetManager().PlaySoundSe((int)SoundUtil.SE_SOUND_INDEX.CANCEL);

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

        SceneUtil.GetManager().PlaySoundSe((int)SoundUtil.SE_SOUND_INDEX.OK2);

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

        SceneUtil.GetManager().PlaySoundSe((int)SoundUtil.SE_SOUND_INDEX.CANCEL);

        this.Close(1);

        return;
    }

    /**
     * @brief GetExtension関数
     * @return ext (extension)
     */
    public InputDialogExtension GetExtension()
    {
        return (this._extension);
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
