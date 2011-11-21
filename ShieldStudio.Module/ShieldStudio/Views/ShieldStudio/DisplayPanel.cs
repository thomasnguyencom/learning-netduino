namespace ShieldStudio.Views.ShieldStudio
{
    public class DisplayPanel
    {
        public char FirstCharacter { get; set; }
        public char SecondCharacter { get; set; }
        public char ThirdCharacter { get; set; }
        public char FourthCharacter { get; set; }

        public DisplayPanel(char char1, char char2, char char3, char char4)
        {
            FirstCharacter = char1;
            SecondCharacter = char2;
            ThirdCharacter = char3;
            FourthCharacter = char4;
        }
    }
}