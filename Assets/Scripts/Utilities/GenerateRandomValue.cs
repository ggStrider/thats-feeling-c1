using UnityEngine;

namespace Utilities
{
    public static class GenerateRandomValue
    {
        public static int GenerateRandomInt(int min, int max)
        {
            return Random.Range(min, max);
        }

        public static float GenerateRandomFloat(float min, float max)
        {
            return Random.Range(min, max);
        }

        public static bool GenerateRandomBool()
        {
            var randomBool = Random.Range(0, 1);
            return randomBool > 0;
        }

        public static Vector3 GenerateRandomVector3(Vector3 min, Vector3 max)
        {
            var x = Random.Range(min.x, min.y);
            var y = Random.Range(min.y, max.y);
            var z = Random.Range(min.z, max.z);

            return new Vector3(x, y, z);
        }
    }
}