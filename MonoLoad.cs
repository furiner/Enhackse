using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Enhackse
{
    public  class MonoLoad
    {
        public static void Init()
        {
            MonoLoad.Load = new GameObject();
            MonoLoad.Load.AddComponent<Client>();

            UnityEngine.Object.DontDestroyOnLoad(MonoLoad.Load);
        }

        private static GameObject Load;
    }
}
