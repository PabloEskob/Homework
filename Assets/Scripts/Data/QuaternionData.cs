using System;

namespace Data
{
    [Serializable]
    public class QuaternionData
    {
        public float X;
        public float Y;
        public float Z;
        public float W;

        public QuaternionData(float quaternionX, float quaternionY, float quaternionZ, float quaternionW)
        {
            X = quaternionX;
            Y = quaternionY;
            Z = quaternionZ;
            W = quaternionW;
        }

        public QuaternionData()
        {
            
        }
    }
}