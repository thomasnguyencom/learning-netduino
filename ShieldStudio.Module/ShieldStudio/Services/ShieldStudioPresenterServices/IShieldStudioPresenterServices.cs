using ShieldStudio.Views.ShieldStudio;

namespace ShieldStudio.Services.ShieldStudioPresenterServices
{
    public interface IShieldStudioPresenterServices
    {
        DisplayPanel[] ConvertToDisplayPanel(string message);

        /// <summary>
        /// Converts the message to a scrolling list
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        DisplayPanel[] ConvertToScrollingDisplayPanel(string message);
    }
}