﻿/**
 * @file
 * @brief SelectSubSceneScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief SelectSubSceneScriptクラス
 */
public class SelectSubSceneScript : ToffMonaka.Lib.Scene.SubSceneScript
{
    [SerializeField] private Image _fadeImage = null;

    private Sequence _fadeImageSequence = null;
    private bool _test2DFlag = false;
    private bool _test3DFlag = false;

    /**
     * @brief コンストラクタ
     */
    public SelectSubSceneScript()
    {
        this._SetScriptIndex((int)ToffMonaka.UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.SELECT_SUB_SCENE);

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

        return (0);
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
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
        this._fadeImage.gameObject.SetActive(true);
        this._fadeImage.color = new Color32(8, 8, 8, 255);
        this._fadeImageSequence = DOTween.Sequence();
        this._fadeImageSequence.Append(this._fadeImage.DOFade(0.0f, 0.2f));

        return;
    }

    /**
     * @brief _OnUpdateOpen関数
     */
    protected override void _OnUpdateOpen()
    {
        if (!this._fadeImageSequence.IsActive()) {
            this.CompleteOpen();

            this._fadeImage.gameObject.SetActive(false);
        }

        return;
    }

    /**
     * @brief _OnClose関数
     */
    protected override void _OnClose()
    {
        this._fadeImage.gameObject.SetActive(true);
        this._fadeImage.color = new Color32(8, 8, 8, 0);
        this._fadeImageSequence = DOTween.Sequence();
        this._fadeImageSequence.Append(this._fadeImage.DOFade(1.0f, 0.2f));
        this._fadeImageSequence.AppendInterval(0.05f);

        return;
    }

    /**
     * @brief _OnUpdateClose関数
     */
    protected override void _OnUpdateClose()
    {
        if (!this._fadeImageSequence.IsActive()) {
            this.CompleteClose();

            if (this._test2DFlag) {
                this.GetHolder().GetSceneScript().ChangeSubScene(ToffMonaka.UnityBase.Constant.Util.FILE_PATH.TEST_2D_SUB_SCENE_PREFAB);

                var sub_scene_script = this.GetHolder().GetSubSceneScript() as ToffMonaka.UnityBase.Scene.Test2DSubSceneScript;

                sub_scene_script.Open();
            }

            if (this._test3DFlag) {
                this.GetHolder().GetSceneScript().ChangeSubScene(ToffMonaka.UnityBase.Constant.Util.FILE_PATH.TEST_3D_SUB_SCENE_PREFAB);

                var sub_scene_script = this.GetHolder().GetSubSceneScript() as ToffMonaka.UnityBase.Scene.Test3DSubSceneScript;

                sub_scene_script.Open();
            }
        }

        return;
    }

    /**
     * @brief OnTest2DButtonPointerClickEvent関数
     */
    public void OnTest2DButtonPointerClickEvent()
    {
        this.Close();

        this._test2DFlag = true;

        return;
    }

    /**
     * @brief OnTest3DButtonPointerClickEvent関数
     */
    public void OnTest3DButtonPointerClickEvent()
    {
        this.Close();

        this._test3DFlag = true;

        return;
    }
}
}
