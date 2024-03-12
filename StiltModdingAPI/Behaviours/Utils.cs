using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace StiltModdingAPI
{
    public static class Utils
    {
        public static GameObject StiltModObject
        {
            get 
            {
                if (_StiltModObject == null)
                {
                    _StiltModObject = new GameObject("StiltModObject");
                    GameObject.DontDestroyOnLoad(_StiltModObject);
                }

                return _StiltModObject; 
            }
        }

        static GameObject _StiltModObject;
    }
}
