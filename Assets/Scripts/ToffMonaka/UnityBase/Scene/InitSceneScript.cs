/**
 * @file
 * @brief InitSceneScriptファイル
 */


using UnityEngine;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief InitSceneScriptクラス
 */
public class InitSceneScript : ToffMonaka.Lib.Scene.SceneScript
{
    private int _progressType = 0;
    private float _progressElapsedTime = 0.0f;

    /**
     * @brief コンストラクタ
     */
    public InitSceneScript()
    {
        this.SetScriptType((int)ToffMonaka.UnityBase.Constant.Util.SCRIPT_TYPE.INIT_SCENE);

        return;
    }

    /**
     * @brief _OnActivate関数
     */
    protected override void _OnActivate()
    {
        this.Create(new ToffMonaka.Lib.Scene.ScriptHolder((int)ToffMonaka.UnityBase.Constant.Util.SCRIPT_TYPE_COUNT), "");

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
