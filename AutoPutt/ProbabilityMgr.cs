using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace AutoPutt
{
    public static class ProbabilityMgr
    {
        public static AutoPuttLevelE AutoPuttLevelEnum { get; set; } = AutoPuttLevelE.TenHandicapAutoPutts;

        public static int Get1PuttProbability(int distanceInFeet)
        {
            if (AutoPuttLevelEnum == AutoPuttLevelE.TourProAutoPutts)
            {
                return PGATour1PuttProbability(distanceInFeet);
            }
            else if (AutoPuttLevelEnum == AutoPuttLevelE.ScratchGolferAutoPutts)
            {
                return ScratchGolfer1PuttProbability(distanceInFeet);
            }
            else if (AutoPuttLevelEnum == AutoPuttLevelE.TenHandicapAutoPutts)
            {
                return TenHandicap1PuttProbability(distanceInFeet);
            }
            else if (AutoPuttLevelEnum == AutoPuttLevelE.TwentyHandicapAutoPutts)
            {
                return TwentyHandicap1PuttProbability(distanceInFeet);
            }

            return -1;
        }

        public static int Get3PuttProbability(int distanceInFeet)
        {
            if (AutoPuttLevelEnum == AutoPuttLevelE.TourProAutoPutts)
            {
                return PGATour3PuttProbability(distanceInFeet);
            }
            else if (AutoPuttLevelEnum == AutoPuttLevelE.ScratchGolferAutoPutts)
            {
                return ScratchGolfer3PuttProbability(distanceInFeet);
            }
            else if (AutoPuttLevelEnum == AutoPuttLevelE.TenHandicapAutoPutts)
            {
                return TenHandicap3PuttProbability(distanceInFeet);
            }
            else if (AutoPuttLevelEnum == AutoPuttLevelE.TwentyHandicapAutoPutts)
            {
                return TwentyHandicap3PuttProbability(distanceInFeet);
            }

            return -1;
        }

        private static int PGATour1PuttProbability(int distanceInFeet)
        {
            if (distanceInFeet <= 2) return 99;
            if (distanceInFeet <= 3) return 96;
            if (distanceInFeet <= 4) return 88;
            if (distanceInFeet <= 5) return 77;
            if (distanceInFeet <= 6) return 66;
            if (distanceInFeet <= 7) return 58;
            if (distanceInFeet <= 8) return 50;
            if (distanceInFeet <= 9) return 45;
            if (distanceInFeet <= 10) return 40;
            if (distanceInFeet <= 15) return 23;
            if (distanceInFeet <= 20) return 15;
            if (distanceInFeet <= 30) return 7;
            if (distanceInFeet <= 40) return 4;
            if (distanceInFeet <= 50) return 3;
            if (distanceInFeet > 50) return 2;
            return 2;
        }

        private static int PGATour3PuttProbability(int distanceInFeet)
        {
            if (distanceInFeet <= 2) return 0;
            if (distanceInFeet <= 3) return 0;
            if (distanceInFeet <= 4) return 0;
            if (distanceInFeet <= 5) return 0;
            if (distanceInFeet <= 6) return 0;
            if (distanceInFeet <= 7) return 1;
            if (distanceInFeet <= 8) return 1;
            if (distanceInFeet <= 9) return 1;
            if (distanceInFeet <= 10) return 1;
            if (distanceInFeet <= 15) return 1;
            if (distanceInFeet <= 20) return 2;
            if (distanceInFeet <= 30) return 5;
            if (distanceInFeet <= 40) return 10;
            if (distanceInFeet <= 50) return 17;
            if (distanceInFeet > 50) return 23;
            return 23;
        }

        private static int ScratchGolfer1PuttProbability(int distanceInFeet)
        {
            if (distanceInFeet <= 2) return 99;
            if (distanceInFeet <= 3) return 93;
            if (distanceInFeet <= 4) return 80;
            if (distanceInFeet <= 5) return 66;
            if (distanceInFeet <= 6) return 55;
            if (distanceInFeet <= 7) return 47;
            if (distanceInFeet <= 8) return 41;
            if (distanceInFeet <= 9) return 36;
            if (distanceInFeet <= 10) return 33;
            if (distanceInFeet <= 15) return 21;
            if (distanceInFeet <= 20) return 14;
            if (distanceInFeet <= 30) return 6;
            if (distanceInFeet <= 40) return 2;
            if (distanceInFeet <= 50) return 1;
            if (distanceInFeet > 50) return 1;
            return 1;
        }

        private static int ScratchGolfer3PuttProbability(int distanceInFeet)
        {
            if (distanceInFeet <= 2) return 0;
            if (distanceInFeet <= 3) return 0;
            if (distanceInFeet <= 4) return 0;
            if (distanceInFeet <= 5) return 0;
            if (distanceInFeet <= 6) return 0;
            if (distanceInFeet <= 7) return 1;
            if (distanceInFeet <= 8) return 1;
            if (distanceInFeet <= 9) return 1;
            if (distanceInFeet <= 10) return 1;
            if (distanceInFeet <= 15) return 2;
            if (distanceInFeet <= 20) return 4;
            if (distanceInFeet <= 30) return 9;
            if (distanceInFeet <= 40) return 15;
            if (distanceInFeet <= 50) return 23;
            if (distanceInFeet > 50) return 30;
            return 30;
        }

        private static int TenHandicap1PuttProbability(int distanceInFeet)
        {
            if (distanceInFeet <= 2) return 97;
            if (distanceInFeet <= 3) return 88;
            if (distanceInFeet <= 4) return 72;
            if (distanceInFeet <= 5) return 58;
            if (distanceInFeet <= 6) return 47;
            if (distanceInFeet <= 7) return 39;
            if (distanceInFeet <= 8) return 34;
            if (distanceInFeet <= 9) return 29;
            if (distanceInFeet <= 10) return 26;
            if (distanceInFeet <= 15) return 16;
            if (distanceInFeet <= 20) return 10;
            if (distanceInFeet <= 30) return 4;
            if (distanceInFeet <= 40) return 1;
            if (distanceInFeet <= 50) return 1;
            if (distanceInFeet > 50) return 1;
            return 1;
        }

        private static int TenHandicap3PuttProbability(int distanceInFeet)
        {
            if (distanceInFeet <= 2) return 0;
            if (distanceInFeet <= 3) return 0;
            if (distanceInFeet <= 4) return 0;
            if (distanceInFeet <= 5) return 0;
            if (distanceInFeet <= 6) return 1;
            if (distanceInFeet <= 7) return 1;
            if (distanceInFeet <= 8) return 1;
            if (distanceInFeet <= 9) return 1;
            if (distanceInFeet <= 10) return 2;
            if (distanceInFeet <= 15) return 3;
            if (distanceInFeet <= 20) return 6;
            if (distanceInFeet <= 30) return 17;
            if (distanceInFeet <= 40) return 22;
            if (distanceInFeet <= 50) return 32;
            if (distanceInFeet > 50) return 40;
            return 40;
        }

        private static int TwentyHandicap1PuttProbability(int distanceInFeet)
        {
            if (distanceInFeet <= 2) return 95;
            if (distanceInFeet <= 3) return 84;
            if (distanceInFeet <= 4) return 65;
            if (distanceInFeet <= 5) return 50;
            if (distanceInFeet <= 6) return 39;
            if (distanceInFeet <= 7) return 32;
            if (distanceInFeet <= 8) return 27;
            if (distanceInFeet <= 9) return 23;
            if (distanceInFeet <= 10) return 20;
            if (distanceInFeet <= 15) return 11;
            if (distanceInFeet <= 20) return 6;
            if (distanceInFeet <= 30) return 2;
            if (distanceInFeet <= 40) return 1;
            if (distanceInFeet <= 50) return 1;
            if (distanceInFeet > 50) return 1;
            return 1;
        }

        private static int TwentyHandicap3PuttProbability(int distanceInFeet)
        {
            if (distanceInFeet <= 2) return 0;
            if (distanceInFeet <= 3) return 0;
            if (distanceInFeet <= 4) return 0;
            if (distanceInFeet <= 5) return 0;
            if (distanceInFeet <= 6) return 1;
            if (distanceInFeet <= 7) return 1;
            if (distanceInFeet <= 8) return 2;
            if (distanceInFeet <= 9) return 2;
            if (distanceInFeet <= 10) return 2;
            if (distanceInFeet <= 15) return 5;
            if (distanceInFeet <= 20) return 8;
            if (distanceInFeet <= 30) return 18;
            if (distanceInFeet <= 40) return 30;
            if (distanceInFeet <= 50) return 41;
            if (distanceInFeet > 50) return 51;
            return 51;
        }
    }
}
