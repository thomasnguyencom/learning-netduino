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
            view.WritePhrase(services.GetSampleMessage());
            view.WritePhrase(services.ConvertToDisplayPanel(""));
            view.WritePhrase(services.ConvertToDisplayPanel("1"));
            view.WritePhrase(services.ConvertToDisplayPanel("12"));
            view.WritePhrase(services.ConvertToDisplayPanel("123"));
//            view.WritePhrase(services.ConvertToDisplayPanel("1234"));
//            view.WritePhrase(services.ConvertToDisplayPanel("12345"));
//            view.WritePhrase(services.ConvertToDisplayPanel("123456"));
//            view.WritePhrase(services.ConvertToDisplayPanel("1234567"));
//            view.WritePhrase(services.ConvertToDisplayPanel("12345678"));
//            view.WritePhrase(services.ConvertToDisplayPanel("123456789"));
//            view.WritePhrase(services.ConvertToDisplayPanel("1234567890"));
//            view.WritePhrase(services.ConvertToDisplayPanel("12345678901"));
//            view.WritePhrase(services.ConvertToDisplayPanel("123456789012"));
//            view.WritePhrase(services.ConvertToDisplayPanel("1234567890123"));
//            view.WritePhrase(services.ConvertToDisplayPanel("12345678901234"));
//            view.WritePhrase(services.ConvertToDisplayPanel("123456789012345"));
//            view.WritePhrase(services.ConvertToDisplayPanel("1234567890123456"));
//            view.WritePhrase(services.ConvertToDisplayPanel("12345678901234567"));
//            view.WritePhrase(services.ConvertToDisplayPanel("123456789012345678"));
//            view.WritePhrase(services.ConvertToDisplayPanel("1234567890123456789"));
//            view.WritePhrase(services.ConvertToDisplayPanel("12345678901234567890"));

            view.Clear();
        }
    }
}
