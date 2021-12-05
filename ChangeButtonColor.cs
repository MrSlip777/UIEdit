/*
 * ボタンの色を指定した色に変更するスクリプト
 *
 * (C)2021 slip
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 * [Twitter]: https://twitter.com/kjmch2s/
 *
 * 利用規約：
 *  作者に無断で改変、再配布が可能で、利用形態（商用、18禁利用等）
 *  についても制限はありません。
 *  このスクリプトはもうあなたのものです。
 * 
 */

using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class ChangeButtonColor : ScriptableWizard
{

    public GameObject target;

    public string colorCode_normal = null;
    public string colorCode_highlight = null;
    public string colorCode_pressed = null;
    public string colorCode_selected = null;
    public string colorCode_disabled = null;


    // Start is called before the first frame update
    public static void CreateWizard(){
        var wiz = ScriptableWizard.DisplayWizard<ChangeButtonColor>(
        "ChangeButtonColor", "change");
            
    }

    void OnWizardCreate()
    {
        Button[] targetButtons = target.GetComponentsInChildren<Button>();
        
        Color cNormal = Color.white;  //通常
        Color cHighLight = Color.white;  //ハイライト
        Color cPressed = Color.white; //押下
        Color cSelected = Color.white;//選択
        Color cDisabled = Color.white;//無効

        //文字列をColorへ変換する
        if(colorCode_normal != ""){
            ColorUtility.TryParseHtmlString("#" + colorCode_normal, out cNormal);
        }

        if(colorCode_highlight != ""){
            ColorUtility.TryParseHtmlString("#" + colorCode_highlight, out cHighLight);
        }

        if(colorCode_pressed != ""){
            ColorUtility.TryParseHtmlString("#" + colorCode_pressed, out cPressed);
        }

        if(colorCode_selected != ""){
            ColorUtility.TryParseHtmlString("#" + colorCode_selected, out cSelected);
        }

        if(colorCode_disabled != ""){
            ColorUtility.TryParseHtmlString("#" + colorCode_disabled, out cDisabled);
        }

        if(targetButtons != null){
            foreach(Button targetButton in targetButtons){
                ColorBlock colorblock = targetButton.colors;

                if(colorCode_normal != ""){
                    colorblock.normalColor = cNormal;
                }

                if(colorCode_highlight != ""){
                    colorblock.highlightedColor = cHighLight;
                }

                if(colorCode_pressed != ""){
                    colorblock.pressedColor = cPressed;
                }

                if(colorCode_selected != ""){
                    colorblock.selectedColor = cSelected;
                }

                if(colorCode_disabled != ""){
                    colorblock.disabledColor = cDisabled;
                }

                targetButton.colors = colorblock;

                //設定反映
                EditorUtility.SetDirty(targetButton);
            }            
        }
    }
}

public static class ChangeButtonColor_Menu
{
    const string ADD_OPTIONOBJECT_KEY = "/UIEdit/ChangeButtonColor";

    [MenuItem(ADD_OPTIONOBJECT_KEY)]
    private static void Menu()
    {
        ChangeButtonColor.CreateWizard();
    }
}

