using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Reflection;
namespace type
{
    public class Class1 : MonoBehaviour
    {
        public Text screen;
        public static string fileLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        void Start()
        {
            screen = GameObject.Find("textconputer(Clone)/Canvas/Text").gameObject.GetComponent<Text>();
        }
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.GetComponentInParent<GorillaTriggerColliderHandIndicator>() != null)
            {
                if(gameObject.name == "Del")
                {
                    screen.text = screen.text.Substring(0, screen.text.Length - 1);
                } else if(gameObject.name == "save")
                {
                    string path = fileLocation + "\\texts\\" + System.DateTime.Now.ToString().Replace("/", ".").Replace(":", ".") + ".txt";
                    if(!File.Exists(path))
                    {
                        File.WriteAllText(path, "Gorrilla text:");
                    }
                    string content = screen.text;

                    File.WriteAllText(path, content);
                } else if (gameObject.name == "clear")
                {
                    screen.text = "";
                } else
                {
                    print(screen.text + this.gameObject.name);
                    screen.text = screen.text + this.gameObject.name;
                }
                

            }
        }
    }
}
