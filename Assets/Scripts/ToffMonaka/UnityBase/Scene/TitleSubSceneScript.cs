/**
 * @file
 * @brief TitleSubSceneScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief TitleSubSceneScriptクラス
 */
public class TitleSubSceneScript : ToffMonaka.Lib.Scene.SubSceneScript
{
    [SerializeField] private TextMeshProUGUI _startButtonText = null;
    [SerializeField] private AudioSource _startButtonAudioSource = null;
    [SerializeField] private TextMeshProUGUI _companyNameText = null;
    [SerializeField] private TextMeshProUGUI _versionNameText = null;
    [SerializeField] private Image _openCloseFadeImage = null;

    private Sequence _openCloseFadeSequence = null;

    /**
     * @brief コンストラクタ
     */
    public TitleSubSceneScript()
    {
        this._SetScriptIndex((int)ToffMonaka.UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.TITLE_SUB_SCENE);

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
     * @brief _OnRelease関数
     */
    protected override void _OnRelease()
    {
        return;
    }

    /**
     * @brief _OnCreate関数
     * @return result (result)<br>
     * 0未満=失敗
     */
    protected override int _OnCreate()
    {
        var canvas_node = this.GetCoreNode().transform.Find("Canvas").gameObject;

        canvas_node.GetComponent<Canvas>().worldCamera = this.GetHolder().GetSceneScript().GetMainCamera();

        this._companyNameText.SetText(ToffMonaka.UnityBase.Constant.Util.COMPANY_NAME);
        this._versionNameText.SetText("Version " + ToffMonaka.UnityBase.Constant.Util.VERSION_NAME);

        return (0);
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
        this._startButtonText.DOFade(0.0f, 1.0f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InQuart).SetDelay(1.0f).SetLink(this._startButtonText.gameObject);

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
        this._openCloseFadeImage.gameObject.SetActive(true);
        this._openCloseFadeImage.color = new Color32(8, 8, 8, 255);

        this._openCloseFadeSequence = DOTween.Sequence();
        this._openCloseFadeSequence.AppendInterval(0.05f);
        this._openCloseFadeSequence.Append(this._openCloseFadeImage.DOFade(0.0f, 0.2f));

        return;
    }

    /**
     * @brief _OnUpdateOpen関数
     */
    protected override void _OnUpdateOpen()
    {
        if (!this._openCloseFadeSequence.IsActive()) {
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
        this._openCloseFadeImage.gameObject.SetActive(true);
        this._openCloseFadeImage.color = new Color32(8, 8, 8, 0);

        this._openCloseFadeSequence = DOTween.Sequence();
        this._openCloseFadeSequence.Append(this._openCloseFadeImage.DOFade(1.0f, 0.2f));
        this._openCloseFadeSequence.AppendInterval(0.05f);

        return;
    }

    /**
     * @brief _OnUpdateClose関数
     */
    protected override void _OnUpdateClose()
    {
        if (!this._openCloseFadeSequence.IsActive()) {
            this.CompleteClose();

            this.GetHolder().GetSceneScript().ChangeSubScene(ToffMonaka.UnityBase.Constant.Util.FILE_PATH.SELECT_SUB_SCENE_PREFAB);

            var sub_scene_script = this.GetHolder().GetSubSceneScript() as ToffMonaka.UnityBase.Scene.SelectSubSceneScript;

            sub_scene_script.Open();
        }

        return;
    }

    /**
     * @brief OnStartButtonPointerClickEvent関数
     */
    public void OnStartButtonPointerClickEvent()
    {
        AudioSource.PlayClipAtPoint(this._startButtonAudioSource.clip, this.GetHolder().GetSceneScript().GetMainCamera().gameObject.transform.position);

        this.Close();

        return;
    }
}
}
