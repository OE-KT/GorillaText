using ComputerInterface;
using ComputerInterface.ViewLib;

using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
namespace type
{
    public class CIentryt : ComputerView
    {
 
        const string highlightColor = "58892Cff";
        const string highlightColorAlt = "892C41";
        bool darkmode;
        public override void OnShow(object[] args)
        {
            base.OnShow(args);

            
        }

        public void Updeatscreen()
        {
            SetText(str =>
            {
                str.BeginCenter();
                str.MakeBar('-', SCREEN_WIDTH, 0, "ffffff10");
                str.AppendClr("Gorilla Text", highlightColor).EndColor().AppendLine();
                str.AppendLine("By KT");
                str.MakeBar('-', SCREEN_WIDTH, 0, "ffffff10");
                str.EndAlign().AppendLines(1);
                str.AppendLine($"<color={(darkmode ? string.Format("#{0}>Off", "ffffff") : "000000>On")}</color>");
            });


        }
        public override void OnKeyPressed(EKeyboardKey key)
        {
            
                Updeatscreen();
               
            switch (key)
            {
                case EKeyboardKey.Back:
                    ReturnToMainMenu();
                    break;
                case EKeyboardKey.Enter:
                    darkmode = !darkmode;
                    break;
            }

        }
    }
}
