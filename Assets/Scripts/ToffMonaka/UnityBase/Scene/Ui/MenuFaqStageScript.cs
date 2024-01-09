/**
 * @file
 * @brief MenuFaqStageScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui {
/**
 * @brief MenuFaqStageScriptCreateDescクラス
 */
public class MenuFaqStageScriptCreateDesc : UnityBase.Scene.Ui.MenuStageScriptCreateDesc
{
}

/**
 * @brief MenuFaqStageScriptクラス
 */
public class MenuFaqStageScript : UnityBase.Scene.Ui.MenuStageScript
{
    [SerializeField] private ScrollRect _messageScrollRect = null;
    [SerializeField] private GameObject _messageNode = null;
    [SerializeField] private TMP_Text _cancelButtonNameText = null;
    [SerializeField] private Image _cancelButtonCoverImage = null;

    public new UnityBase.Scene.Ui.MenuFaqStageScriptCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief コンストラクタ
     */
    public MenuFaqStageScript() : base((int)UnityBase.Util.SCENE.NODE_SCRIPT_INDEX.MENU_FAQ_STAGE)
    {
        this._SetStageType(UnityBase.Util.SCENE.MENU_STAGE_TYPE.FAQ);

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

        this._messageNode.SetActive(false);

        {// MessageNode Create
            var en_txt_ary = new string[]{
                "Q, What is the application to do?\n" +
                "A, It is a Unity base application."
            };
            var jp_txt_ary = new string[]{
                "Q, 何をするアプリなんですか？\n" +
                "A, Unityのベースアプリです。"
            };
            string[] txt_ary;

		    switch (UnityBase.Global.systemConfigFile.data.systemLanguageType) {
		    case UnityBase.Util.LANGUAGE_TYPE.JAPANESE: {
                txt_ary = jp_txt_ary;

			    break;
		    }
		    default: {
                txt_ary = en_txt_ary;

			    break;
		    }
		    }

            for (int txt_i = 0; txt_i < txt_ary.Length; ++txt_i) {
                var txt = (txt_i <= 0) ? txt_ary[txt_i] : "\n" + txt_ary[txt_i];

                var node = GameObject.Instantiate(this._messageNode, this._messageNode.transform.parent);

                node.GetComponent<TMP_Text>().SetText(txt);

                node.SetActive(true);
            }
        }

        this._cancelButtonNameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.CANCEL));

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.NodeScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as UnityBase.Scene.Ui.MenuFaqStageScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
        base._OnActive();

        this._messageScrollRect.verticalNormalizedPosition = 1.0f;
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
     * @brief OnCancelButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnCancelButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        Lib.Scene.Util.GetSoundManager().PlaySe((int)UnityBase.Util.SOUND.SE_INDEX.CANCEL);

        this.GetMenuScript().RunStageCancelButton();

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
