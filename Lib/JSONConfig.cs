using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using DmShared;

namespace DmShared
{
    public class JSONConfig
    {
        public static string LoadDataFromUrl(string Url)
        {
            WebClient req = new WebClient();

            StreamReader reqstream = new StreamReader(req.OpenRead(Url));

            string res = reqstream.ReadToEnd();

            reqstream.Close();
            req.Dispose();


            return res;
        }

        public static void SaveFile(string FName, string Data)
        {
            StreamWriter F = new StreamWriter(FName);
            F.Write(Data);
            F.Close();
        }

        public static void SaveDataCollectionFile(string FName, DataCollection Src)
        {
            SaveFile(FName, JSON.JsonEncode(Src));
        }

        public  static DataCollection LoadDataCollectionFile(string FName)
        {
            DataCollection res = new DataCollection();
            StreamReader F = new StreamReader(FName);
            res = LoadDataCollectionFromJSON(F.ReadToEnd());
            F.Close();
            return res;
        }

        public static DataCollection LoadDataCollectionFromJSON(string Data)
        {
            object r = JSON.JsonDecode(Data);
            if (r is DataCollection)
                return (DataCollection)r;
            return null;
        }
    }
}
