using ShieldStudio.Views.ShieldStudio;

namespace ShieldStudio.Services.ShieldStudioPresenterServices
{
    public interface IShieldStudioPresenterServices
    {
        DisplayPanel[] ConvertToDisplayPanel(string message);
        DisplayPanel[] ConvertToScrollingDisplayPanel(string message);
    }
}