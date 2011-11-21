namespace ShieldStudio.Services.ShieldStudioPresenterServices
{
    public interface IShieldStudioPresenterServices
    {

        /// <summary>
        /// Display character on the digit specified
        /// </summary>
        /// <param name="character"></param>
        /// <param name="digit"></param>
        void WriteCharacter(char character, ShieldStudioPresenterBase.Digits digit);

        /// <summary>
        /// Display a word with a pause 
        /// </summary>
        /// <param name="char1"></param>
        /// <param name="char2"></param>
        /// <param name="char3"></param>
        /// <param name="char4"></param>
        /// <param name="pause">milliseconds</param>
        void WriteWord(char char1, char char2, char char3, char char4, int pause);
    }
}