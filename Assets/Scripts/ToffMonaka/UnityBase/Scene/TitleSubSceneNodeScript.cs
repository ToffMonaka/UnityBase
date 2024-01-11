/**
 * @file
 * @brief TitleSubSceneNodeScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using DG.Tweening;


namespace ToffMonaka {
namespace UnityBase.Scene {
/**
 * @brief TitleSubSceneNodeScriptCreateDescクラス
 */
public class TitleSubSceneNodeScriptCreateDesc : Lib.Scene.SubSceneNodeScriptCreateDesc
{
}

/**
 * @brief TitleSubSceneNodeScriptクラス
 */
public class TitleSubSceneNodeScript : Lib.Scene.SubSceneNodeScript
{
    [SerializeField] private TMP_Text _startButtonNameText = null;
    [SerializeField] private TMP_Text _companyNameText = null;
    [SerializeField] private TMP_Text _versionNameText = null;
    [SerializeField] private GameObject _menuNode = null;
    [SerializeField] private Image _openCloseFadeImage = null;

    public new UnityBase.Scene.TitleSubSceneNodeScriptCreateDesc createDesc{get; private set;} = null;

    private UnityBase.Scene.Ui.MenuScript _menuScript = null;

    /**
     * @brief コンストラクタ
     */
    public TitleSubSceneNodeScript() : base((int)UnityBase.Util.SCENE.NODE_SCRIPT_INDEX.TITLE_SUB_SCENE)
    {
        return;
    }

    /**
     * @brief _OnAwake関数
     */
    protected override void _OnAwake()
    {
        return;
    }

    /**
     * @brief _OnDestroy関数
     */
    protected override void _OnDestroy()
    {
        return;
    }

    /**
     * @brief _OnCreate関数
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    protected override int _OnCreate()
    {
        this._companyNameText.SetText(UnityBase.Util.PROJECT.COMPANY_NAME);
        this._versionNameText.SetText("Version " + UnityBase.Util.PROJECT.VERSION_NAME);

        {// MenuScript Create
            var script = this._menuNode.GetComponent<UnityBase.Scene.Ui.MenuScript>();
            var script_create_desc = new UnityBase.Scene.Ui.MenuScriptCreateDesc();

            script_create_desc.subSceneNodeScript = this;

            script.Create(script_create_desc);
            script.Open(0);

            this._menuScript = script;
        }

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.NodeScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as UnityBase.Scene.TitleSubSceneNodeScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
        Lib.Scene.Util.GetSoundManager().PlayBgm((int)UnityBase.Util.SOUND.BGM_INDEX.TITLE);

        this._startButtonNameText.DOFade(0.0f, 1.0f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InQuart).SetDelay(1.0f).SetLink(this._startButtonNameText.gameObject);

        return;
    }

    /**
     * @brief _OnDeactive関数
     */
    protected override void _OnDeactive()
    {
        return;
    }

    /**
     * @brief _OnUpdate関数
     */
    protected override void _OnUpdate()
    {
        return;
    }

    /**
     * @brief _OnOpen関数
     */
    protected override void _OnOpen()
    {
		switch (this.GetOpenType()) {
		case 1: {
            this._openCloseFadeImage.gameObject.SetActive(true);
            this._openCloseFadeImage.color = new Color32(8, 8, 8, 255);

            var open_close_sequence = DOTween.Sequence();

            open_close_sequence.AppendInterval(0.05f);
            open_close_sequence.Append(this._openCloseFadeImage.DOFade(0.0f, 0.2f));
            open_close_sequence.SetLink(this.gameObject);

            this.AddOpenCloseSequence(open_close_sequence);

			break;
		}
		default: {
            this._openCloseFadeImage.gameObject.SetActive(false);

			break;
		}
		}

        return;
    }

    /**
     * @brief _OnUpdateOpen関数
     */
    protected override void _OnUpdateOpen()
    {
        if (!this.IsActiveOpenCloseSequence()) {
            this.CompleteOpen();

            this._openCloseFadeImage.gameObject.SetActive(false);
        }

        return;
    }

    /**
     * @brief _OnClose関数
     */
    protected override void _OnClose()
    {
		switch (this.GetCloseType()) {
		case 1: {
            this._openCloseFadeImage.gameObject.SetActive(true);
            this._openCloseFadeImage.color = new Color32(8, 8, 8, 0);

            var open_close_sequence = DOTween.Sequence();

            open_close_sequence.Append(this._openCloseFadeImage.DOFade(1.0f, 0.2f));
            open_close_sequence.AppendInterval(0.05f);
            open_close_sequence.SetLink(this.gameObject);

            this.AddOpenCloseSequence(open_close_sequence);

			break;
		}
		default: {
            this._openCloseFadeImage.gameObject.SetActive(false);

			break;
		}
		}

        return;
    }

    /**
     * @brief _OnUpdateClose関数
     */
    protected override void _OnUpdateClose()
    {
        if (!this.IsActiveOpenCloseSequence()) {
            this.CompleteClose();

		    switch (this.GetClosedType()) {
            case 1: {
                {// SelectSubSceneNodeScript Create
                    var script = this.GetManager().ChangeSubScene(UnityBase.Util.FILE_PATH.SELECT_SUB_SCENE_PREFAB) as UnityBase.Scene.Select.SubSceneNodeScript;
                    var script_create_desc = new UnityBase.Scene.Select.SubSceneNodeScriptCreateDesc();

                    script.Create(script_create_desc);
                    script.Open(1);
                }

			    break;
		    }
		    }
        }

        return;
    }

    /**
     * @brief OnStartButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnStartButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        Lib.Scene.Util.GetSoundManager().PlaySe((int)UnityBase.Util.SOUND.SE_INDEX.OK);

        this.Close(1, 1);

        return;
    }
}
}
}
