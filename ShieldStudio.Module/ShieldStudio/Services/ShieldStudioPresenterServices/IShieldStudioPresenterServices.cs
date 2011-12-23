using ShieldStudio.Views.ShieldStudio;

namespace ShieldStudio.Services.ShieldStudioPresenterServices
{
    public interface IShieldStudioPresenterServices
    {
        DisplayPanel[] GetSampleMessage();

        DisplayPanel[] ConvertToDisplayPanel(string message);
    }
}