/**
 * @file
 * @brief LanguageSelectDialogScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using TMPro;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui {
/**
 * @brief LanguageSelectDialogScriptCreateDescクラス
 */
public class LanguageSelectDialogScriptCreateDesc : UnityBase.Scene.Ui.DialogScriptCreateDesc
{
    public UnityBase.Scene.Ui.MenuOptionStageScript stageScript = null;
}

/**
 * @brief LanguageSelectDialogScriptクラス
 */
public class LanguageSelectDialogScript : UnityBase.Scene.Ui.DialogScript
{
    [SerializeField] private TMP_Text _nameText = null;
    [SerializeField] private GameObject _buttonNode = null;
    [SerializeField] private Image _closeButtonCoverImage = null;

    public new UnityBase.Scene.Ui.LanguageSelectDialogScriptCreateDesc createDesc{get; private set;} = null;

    private UnityBase.Scene.Ui.MenuOptionStageScript _stageScript = null;
    private List<UnityBase.Scene.Ui.LanguageSelectDialogButtonScript> _buttonScriptContainer = new List<UnityBase.Scene.Ui.LanguageSelectDialogButtonScript>();

    /**
     * @brief コンストラクタ
     */
    public LanguageSelectDialogScript()
    {
        this._SetScriptIndex((int)UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.LANGUAGE_SELECT_DIALOG);

        return;
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

        this._stageScript = this.createDesc.stageScript;

        this._nameText.SetText(UnityBase.Global.GetString(UnityBase.Constant.Util.MST_STRING_ID.LANGUAGE));

        this._buttonNode.SetActive(false);

        {// ButtonScript Create
            UnityBase.Constant.Util.LANGUAGE_TYPE[] language_type_ary = {
                UnityBase.Constant.Util.LANGUAGE_TYPE.ENGLISH,
                UnityBase.Constant.Util.LANGUAGE_TYPE.JAPANESE
            };

            foreach (var language_type in language_type_ary) {
                var script = GameObject.Instantiate(this._buttonNode, this._buttonNode.transform.parent).GetComponent<UnityBase.Scene.Ui.LanguageSelectDialogButtonScript>();
                var script_create_desc = new UnityBase.Scene.Ui.LanguageSelectDialogButtonScriptCreateDesc();

                script_create_desc.dialogScript = this;
                script_create_desc.languageType = language_type;

                script.Create(script_create_desc);
                script.Open(0);

                this._buttonScriptContainer.Add(script);
            }
        }

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as UnityBase.Scene.Ui.LanguageSelectDialogScriptCreateDesc;

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

        Lib.Scene.Util.GetSoundManager().PlaySe((int)UnityBase.Constant.Util.SOUND.SE_INDEX.CANCEL);

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
        if (!this.IsControllable()) {
            return;
        }

        this._closeButtonCoverImage.gameObject.SetActive(false);

        return;
    }

    /**
     * @brief RunButton関数
     * @param language_type (language_type)
     */
    public void RunButton(UnityBase.Constant.Util.LANGUAGE_TYPE language_type)
    {
        this._stageScript.SetLanguageType(language_type);

        this.Close(1);

        return;
    }
}
}
}
