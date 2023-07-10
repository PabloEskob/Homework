﻿using System;

namespace Data
{
    [Serializable]
    public class Vector3Data
    {
        public float X;
        public float Y;
        public float Z;
        public float W;

        public Vector3Data(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3Data()
        {
           
        }
    }
}