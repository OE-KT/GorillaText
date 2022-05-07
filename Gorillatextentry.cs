using System;
using System.Collections.Generic;
using System.Text;
using ComputerInterface.Interfaces;
namespace type
{
        class Gorillatextentry : IComputerModEntry
        {
            public string EntryName => "Gorilla text";

            // This is the first view that is going to be shown if the user select you mod
            // The Computer Interface mod will instantiate your view 
            public Type EntryViewType => typeof(CIentryt);
        }
   
}
