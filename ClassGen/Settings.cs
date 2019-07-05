using ClassGen.Model;
using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace ClassGen
{

    public static class Settings
    {
        public static string Username
        {
            get
            {
                var localObjectStorageHelper = new LocalObjectStorageHelper();
                // Read and Save with simple objects
                string keySimpleObject = "username";
                string result = localObjectStorageHelper.Read<string>(keySimpleObject);
                return result;

            }
            set
            {
                var localObjectStorageHelper = new LocalObjectStorageHelper();
                // Read and Save with simple objects
                string keySimpleObject = "username";
                localObjectStorageHelper.Save(keySimpleObject, value);
            }
        }

        public static string Password
        {
            get
            {
                var localObjectStorageHelper = new LocalObjectStorageHelper();
                // Read and Save with simple objects
                string keySimpleObject = "password";
                string result = localObjectStorageHelper.Read<string>(keySimpleObject);
                return result;

            }
            set
            {
                var localObjectStorageHelper = new LocalObjectStorageHelper();
                // Read and Save with simple objects
                string keySimpleObject = "password";
                localObjectStorageHelper.Save(keySimpleObject, value);
            }
        }

        public static Term TheTerm
        {
            get
            {
                var localObjectStorageHelper = new LocalObjectStorageHelper();
                // Read and Save with simple objects
                string keySimpleObject = "term";
                Term result = localObjectStorageHelper.Read<Term>(keySimpleObject);
                return result;

            }
            set
            {
                var localObjectStorageHelper = new LocalObjectStorageHelper();
                // Read and Save with simple objects
                string keySimpleObject = "term";
                localObjectStorageHelper.Save(keySimpleObject, value);
            }
        }

        public static string Year
        {
            get
            {
                var localObjectStorageHelper = new LocalObjectStorageHelper();
                // Read and Save with simple objects
                string keySimpleObject = "year";
                string result = localObjectStorageHelper.Read<string>(keySimpleObject);
                return result;

            }
            set
            {
                var localObjectStorageHelper = new LocalObjectStorageHelper();
                // Read and Save with simple objects
                string keySimpleObject = "year";
                localObjectStorageHelper.Save(keySimpleObject, value);
            }
        }

        public static string BrushType
        {
            get
            {
                var localObjectStorageHelper = new LocalObjectStorageHelper();
                // Read and Save with simple objects
                string keySimpleObject = "BrushType";
                string result = localObjectStorageHelper.Read<string>(keySimpleObject);
                return result;

            }
            set
            {
                var localObjectStorageHelper = new LocalObjectStorageHelper();
                // Read and Save with simple objects
                string keySimpleObject = "BrushType";
                localObjectStorageHelper.Save(keySimpleObject, value);
            }
        }


    }
}
