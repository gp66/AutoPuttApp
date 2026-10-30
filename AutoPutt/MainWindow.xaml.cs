using System;
using System.Windows;

namespace AutoPutt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly AutoPuttLevelE[] SkillLevels =
        {
            AutoPuttLevelE.TourPro,
            AutoPuttLevelE.ScratchGolfer,
            AutoPuttLevelE.FiveHandicap,
            AutoPuttLevelE.TenHandicap,
            AutoPuttLevelE.FifteenHandicap,
            AutoPuttLevelE.TwentyHandicap
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AutoPuttButton_Click(object sender, RoutedEventArgs e)
        {
            int distanceInFeet;
            if (!int.TryParse(PuttDistanceTextBox.Text, out distanceInFeet) || distanceInFeet < 1)
            {
                MessageBox.Show(this, "Enter a whole-number putt distance of at least 1 foot.",
                    "Invalid Putt Distance", MessageBoxButton.OK, MessageBoxImage.Warning);
                PuttDistanceTextBox.Focus();
                PuttDistanceTextBox.SelectAll();
                return;
            }

            int selectedIndex = SkillLevelComboBox.SelectedIndex;
            if (selectedIndex < 0 || selectedIndex >= SkillLevels.Length)
            {
                MessageBox.Show(this, "Select a golfer skill level.",
                    "Skill Level Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Run each skill level exactly once, so the selected result
            // and its entry in the comparison always match.
            int[] puttResults = new int[SkillLevels.Length];
            for (int i = 0; i < SkillLevels.Length; i++)
            {
                ProbabilityMgr.AutoPuttLevelEnum = SkillLevels[i];
                puttResults[i] = DoAutoPutt(distanceInFeet);
            }

            // Restore the skill level selected by the user.
            ProbabilityMgr.AutoPuttLevelEnum = SkillLevels[selectedIndex];

            SelectedSkillTextBlock.Text = GetSkillLevelName(SkillLevels[selectedIndex]);
            SelectedResultTextBlock.Text =
                distanceInFeet + " ft putt  |  " + FormatPutts(puttResults[selectedIndex]);

            TourProResultTextBlock.Text = FormatPutts(puttResults[0]);
            ScratchResultTextBlock.Text = FormatPutts(puttResults[1]);
            FiveHandicapResultTextBlock.Text = FormatPutts(puttResults[2]);
            TenHandicapResultTextBlock.Text = FormatPutts(puttResults[3]);
            FifteenHandicapResultTextBlock.Text = FormatPutts(puttResults[4]);
            TwentyHandicapResultTextBlock.Text = FormatPutts(puttResults[5]);
        }

        private static string GetSkillLevelName(AutoPuttLevelE level)
        {
            switch (level)
            {
                case AutoPuttLevelE.TourPro: return "Tour Pro";
                case AutoPuttLevelE.ScratchGolfer: return "Scratch Golfer";
                case AutoPuttLevelE.FiveHandicap: return "Five Handicap";
                case AutoPuttLevelE.TenHandicap: return "Ten Handicap";
                case AutoPuttLevelE.FifteenHandicap: return "Fifteen Handicap";
                case AutoPuttLevelE.TwentyHandicap: return "Twenty Handicap";
                default: return "Unknown";
            }
        }

        private static string FormatPutts(int numberOfPutts)
        {
            return numberOfPutts + (numberOfPutts == 1 ? " Putt" : " Putts");
        }

        private static int DoAutoPutt(int targetDistanceInFeet)
        {
            // Preserve the original probability calculation:
            // First roll for a one-putt, then (if needed) roll for a three-putt.
            int numOfPutts = 2;
            int rand = GetRandomNumber(1, 100);
            int puttProbability = ProbabilityMgr.Get1PuttProbability(targetDistanceInFeet);

            if (rand <= puttProbability)
            {
                numOfPutts = 1;
            }
            else if (targetDistanceInFeet > 5) // No three-putts at 5 feet or less.
            {
                rand = GetRandomNumber(1, 100);
                puttProbability = ProbabilityMgr.Get3PuttProbability(targetDistanceInFeet);
                if (rand <= puttProbability)
                    numOfPutts = 3;
            }

            return numOfPutts;
        }

        private static int GetRandomNumber(int min, int max)
        {
            return Random.Shared.Next(min, max + 1);
        }
    }
}
