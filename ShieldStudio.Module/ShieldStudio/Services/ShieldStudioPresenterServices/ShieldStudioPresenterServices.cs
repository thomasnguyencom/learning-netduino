using ShieldStudio.Views.ShieldStudio;

namespace ShieldStudio.Services.ShieldStudioPresenterServices
{
    public class ShieldStudioPresenterServices : IShieldStudioPresenterServices
    {

        public DisplayPanel[] GetSampleMessage()
        {
            return new DisplayPanel[] {
                    new DisplayPanel('S', 'h', 'i', 'e'),
                    new DisplayPanel('l', 'd', 'S', 't'),
                    new DisplayPanel('u', 'd', 'i', 'o'),
                    new DisplayPanel('.', 'c', 'o', 'm')
                };
        }
    }
}