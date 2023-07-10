using System;
using System.IO;
using UnityEngine;

namespace Data
{
    public static class DataExtensions
    {
        public static Vector3Data AsVectorData(this Vector3 vector) =>
            new Vector3Data(vector.x, vector.y, vector.z);

        public static QuaternionData AsQuaternionData(this Quaternion quaternion) =>
            new QuaternionData(quaternion.x, quaternion.y, quaternion.z, quaternion.w);
        
        public static Vector3 AsUnityVector(this Vector3Data vector3Data) =>
            new Vector3(vector3Data.X, vector3Data.Y, vector3Data.Z);
        public static Quaternion AsUnityQuaternion(this QuaternionData vector3Data) =>
            new Quaternion(vector3Data.X, vector3Data.Y, vector3Data.Z,vector3Data.W);

        public static string ToJson(this object obj) =>
            JsonUtility.ToJson(obj, true);

        public static T ToDeserialized<T>(string path) =>
            JsonUtility.FromJson<T>(File.ReadAllText(path));
    }
}