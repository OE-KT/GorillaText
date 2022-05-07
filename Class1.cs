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
        bool cantype;
        float cerenntcooldown;
        float cooldown = 0.5f;
        
        Color color; //color of key rn
        void Start()
        {
            screen = GameObject.Find("textconputer(Clone)/Canvas/Text").gameObject.GetComponent<Text>();
            color = GetComponent<MeshRenderer>().material.color;
        }
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.GetComponentInParent<GorillaTriggerColliderHandIndicator>() != null && cantype)
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

                   
                } else if (gameObject.name == "enter")
                {
                   screen.text = screen.text + "\n";
               
                } else if (gameObject.name == "reload")
                {
                    Plugin.instines.setupconfig();
                   
                } else
                {
                    print(screen.text + this.gameObject.name);
                    screen.text = screen.text + this.gameObject.name;
                }
                GetComponent<MeshRenderer>().material.color = Color.red;
                cantype = false;
                cerenntcooldown = cooldown;
                
            }
        }
       void Update()
        {
            if (cantype == false)
            {
                cerenntcooldown -= Time.deltaTime;
                if(cerenntcooldown <= 0)
                {
                    cerenntcooldown = 0;
                    GetComponent<MeshRenderer>().material.color = color;
                    cantype = true;
                }
            }
            
        }
    }
}
