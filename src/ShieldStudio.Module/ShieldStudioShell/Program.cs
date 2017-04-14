using ShieldStudio.Services.ShieldStudioPresenterServices;
using ShieldStudio.Views.ShieldStudio;

namespace ShieldStudioShell
{
    public class Program
    {
        public static void Main()
        {
            var view = new ShieldStudioView();
            view.Clear();

            var services = new ShieldStudioPresenterServices();
            view.WritePhrase(services.ConvertToScrollingDisplayPanel("Hello World."));

            view.Clear();
        }
    }
}
