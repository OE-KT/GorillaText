using System;
using System.Collections.Generic;
using System.Text;
using BepInEx;
using Zenject;
using ComputerInterface.Interfaces;
namespace type.ConputerInface
{
    public class maininstalller : Installer
    {
        public override void InstallBindings()
        {
            base.Container.Bind<IComputerModEntry>().To<Gorillatextentry>().AsSingle();
        }
    }
}
