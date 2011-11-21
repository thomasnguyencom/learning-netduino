using ShieldStudio.Services.ShieldStudioPresenterServices;
using ShieldStudio.Views.ShieldStudio;

namespace ShieldStudioShell
{
    public class Program
    {
        public static void Main()
        {
            var view = new ShieldStudioView();
            view.WritePhrase(new ShieldStudioPresenterServices().GetSampleMessage());
        }

    }
}
