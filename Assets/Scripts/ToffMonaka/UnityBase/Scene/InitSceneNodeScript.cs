/**
 * @file
 * @brief InitSceneNodeScriptファイル
 */


using UnityEngine;
using UnityEngine.SceneManagement;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief InitSceneNodeScriptクラス
 */
public class InitSceneNodeScript : ToffMonaka.Lib.Scene.SceneNodeScript
{
    private int _progressType = 0;
    private float _progressElapsedTime = 0.0f;

    /**
     * @brief _OnActivate関数
     */
    protected override void _OnActivate()
    {
        this.ChangeSubScene("");

        this._progressType = 1;
        this._progressElapsedTime = 0.0f;

        return;
    }

    /**
     * @brief _OnDeactivate関数
     */
    protected override void _OnDeactivate()
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
                this.ChangeScene("PlayScene");

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
}
}
