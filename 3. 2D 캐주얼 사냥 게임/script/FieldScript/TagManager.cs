using System;

namespace TagManager
{
    public partial class BaseCamp
    {
        private int BaseCampAnimalCount = 0;

        public int GetCount()
        {
            return BaseCampAnimalCount;
        }
    }

    public partial class Tree01
    {
        private float Tree01DisSizeTop = 0.15f;
        private float Tree01DisSizeBot = 1.7f;

        public float GetTree01DisSizeTop()
        {
            return Tree01DisSizeTop;
        }

        public float GetTree01DisSizeBot()
        {
            return Tree01DisSizeBot;
        }
    }

    public partial class Tree02
    {
        private float Tree02DisSizeTop = 0.15f;
        private float Tree02DisSizeBot = 1.7f;

        public float GetTree02DisSizeTop()
        {
            return Tree02DisSizeTop;
        }

        public float GetTree02DisSizeBot()
        {
            return Tree02DisSizeBot;
        }
    }

    public partial class Bird
    {
        private string CreatePrefab = "Bird01";
        private string CreatePrefab2 = "Bird02";

        private float BirdHP;
        private float BirdAtk;

        private int BirdAnimalCount = 3;

        private float BirdPosY = 0.2f;

        public int GetCount()
        {
            return BirdAnimalCount;
        }

        public float GetPosY()
        {
            return BirdPosY;
        }
    }

    public partial class Buffalo
    {
        private float BuffaloDisSizeTop = 0.1f;
        private float BuffaloDisSizeBot = 1.7f;

        public float GetBuffaloDisSizeTopDisSizeTop()
        {
            return BuffaloDisSizeTop;
        }

        public float GetBuffaloDisSizeTopDisSizeBot()
        {
            return BuffaloDisSizeBot;
        }
    }

    public partial class Gazella
    {
        private float GazellaDisSizeTop = 0.13f;
        private float GazellaDisSizeBot = 1.7f;

        public float GetGazellaDisSizeTopDisSizeTop()
        {
            return GazellaDisSizeTop;
        }

        public float GetGazellaDisSizeTopDisSizeBot()
        {
            return GazellaDisSizeBot;
        }
        public float GetGazellaResponePosY(float size)
        {
            float posY = 0.05f;
            float tmp_size = 0.1f;
            while (tmp_size < size) 
            {
                float sizeGap = tmp_size * tmp_size * 0.015f;
                tmp_size += sizeGap;
                posY += -0.0005f;
            }
            return posY;
        }
    }
}