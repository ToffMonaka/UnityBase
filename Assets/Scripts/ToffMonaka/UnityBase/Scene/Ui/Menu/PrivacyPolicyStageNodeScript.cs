/**
 * @file
 * @brief PrivacyPolicyStageNodeScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui.Menu {
/**
 * @brief PrivacyPolicyStageNodeScriptCreateDescクラス
 */
public class PrivacyPolicyStageNodeScriptCreateDesc : UnityBase.Scene.Ui.Menu.StageNodeScriptCreateDesc
{
}

/**
 * @brief PrivacyPolicyStageNodeScriptクラス
 */
public class PrivacyPolicyStageNodeScript : UnityBase.Scene.Ui.Menu.StageNodeScript
{
    [SerializeField] private ScrollRect _scrollRect = null;
    [SerializeField] private float _scrollBarMinSize = 64.0f;
    [SerializeField] private GameObject _messageNode = null;
    [SerializeField] private TMP_Text _cancelButtonNameText = null;
    [SerializeField] private Image _cancelButtonCoverImage = null;

    public new UnityBase.Scene.Ui.Menu.PrivacyPolicyStageNodeScriptCreateDesc createDesc{get; private set;} = null;

    private Vector2 _scrollBarMinSize2 = Vector2.zero;

    /**
     * @brief コンストラクタ
     */
    public PrivacyPolicyStageNodeScript()
    {
        this._SetStageType(UnityBase.Util.SCENE.MENU_STAGE_TYPE.PRIVACY_POLICY);

        return;
    }

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)UnityBase.Util.SCENE.SCRIPT_INDEX.MENU_PRIVACY_POLICY_STAGE_NODE);
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

        this._scrollBarMinSize2 = new Vector2(1.0f / this._scrollRect.viewport.rect.width * this._scrollBarMinSize, 1.0f / this._scrollRect.viewport.rect.height * this._scrollBarMinSize);
        this._cancelButtonNameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.CANCEL));

        this._messageNode.SetActive(false);

        {// MessageNode Create
            string[] txt_ary;

		    switch (UnityBase.Global.systemConfigFile.data.systemLanguageType) {
		    case UnityBase.Util.LANGUAGE_TYPE.JAPANESE: {
                txt_ary = UnityBase.Scene.Ui.Menu.PrivacyPolicyMessageUtil.JAPANESE_TEXT_ARRAY;

			    break;
		    }
		    default: {
                txt_ary = UnityBase.Scene.Ui.Menu.PrivacyPolicyMessageUtil.ENGLISH_TEXT_ARRAY;

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

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as UnityBase.Scene.Ui.Menu.PrivacyPolicyStageNodeScriptCreateDesc;

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

        this._UpdateScrollBarSize();

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
     * @brief OnScrollRectValueChanged関数
     * @param event_pos (event_position)
     */
    public void OnScrollRectValueChanged(Vector2 event_pos)
    {
        this._UpdateScrollBarSize();

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

        this.GetMenuNodeScript().RunStageCancelButton();

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
     * @brief _UpdateScrollBarSize関数
     */
    private void _UpdateScrollBarSize()
    {
        if (this._scrollRect.vertical) {
            if (this._scrollRect.verticalScrollbar != null) {
                if (this._scrollRect.verticalScrollbar.size < this._scrollBarMinSize2.y) {
                    this._scrollRect.verticalScrollbar.size = this._scrollBarMinSize2.y;
                }
            }
        }

        return;
    }
}
}
}
