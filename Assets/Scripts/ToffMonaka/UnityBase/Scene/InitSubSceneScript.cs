/**
 * @file
 * @brief InitSubSceneScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief InitSubSceneScriptクラス
 */
public class InitSubSceneScript : ToffMonaka.Lib.Scene.SubSceneScript
{
    [SerializeField] private TextMeshProUGUI _waitMessageText = null;
    [SerializeField] private Image _openCloseFadeImage = null;

    private Sequence _openCloseFadeSequence = null;
    private int _progressType = 0;
    private float _progressElapsedTime = 0.0f;

    /**
     * @brief コンストラクタ
     */
    public InitSubSceneScript()
    {
        this._SetScriptIndex((int)ToffMonaka.UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.INIT_SUB_SCENE);

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

        this._waitMessageText.SetText("ちょっと待ってね。");

        return (0);
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
        this._progressType = 1;
        this._progressElapsedTime = 0.0f;

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
		switch (this._progressType) {
		case 1: {
            this._progressElapsedTime += Time.deltaTime;

            if (this._progressElapsedTime >= 3.0f) {
                this.Close();

                this._progressType = 2;
                this._progressElapsedTime = 0.0f;
            }

			break;
		}
		case 2: {
			break;
		}
		}

        return;
    }

    /**
     * @brief _OnOpen関数
     */
    protected override void _OnOpen()
    {
        this._openCloseFadeImage.gameObject.SetActive(false);

        return;
    }

    /**
     * @brief _OnUpdateOpen関数
     */
    protected override void _OnUpdateOpen()
    {
        this.CompleteOpen();

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

            this.GetHolder().GetSceneScript().ChangeSubScene(ToffMonaka.UnityBase.Constant.Util.FILE_PATH.TITLE_SUB_SCENE_PREFAB);

            var sub_scene_script = this.GetHolder().GetSubSceneScript() as ToffMonaka.UnityBase.Scene.TitleSubSceneScript;

            sub_scene_script.Open();
        }

        return;
    }
}
}
