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

//            view.WritePhrase(services.ConvertToScrollingDisplayPanel(""));
//            view.WritePhrase(services.ConvertToScrollingDisplayPanel("1"));
//            view.WritePhrase(services.ConvertToScrollingDisplayPanel("AB"));
//            view.WritePhrase(services.ConvertToScrollingDisplayPanel("5Ef"));
//            view.WritePhrase(services.ConvertToScrollingDisplayPanel("3faD"));
//            view.WritePhrase(services.ConvertToScrollingDisplayPanel("Hello World."));
            
//            view.WritePhrase(services.GetSampleMessage());
//            view.WritePhrase(services.ConvertToDisplayPanel(""));
//            view.WritePhrase(services.ConvertToDisplayPanel("_"));
//            view.WritePhrase(services.ConvertToDisplayPanel("_2"));
//            view.WritePhrase(services.ConvertToDisplayPanel("_33"));
//            view.WritePhrase(services.ConvertToDisplayPanel("_444"));
//            view.WritePhrase(services.ConvertToDisplayPanel("_555*"));
//            view.WritePhrase(services.ConvertToDisplayPanel("_666*6"));
//            view.WritePhrase(services.ConvertToDisplayPanel("_777*77"));
//            view.WritePhrase(services.ConvertToDisplayPanel("_888*888"));
//            view.WritePhrase(services.ConvertToDisplayPanel("_999*999%"));
//            view.WritePhrase(services.ConvertToDisplayPanel("_AAA*AAA%A"));
//            view.WritePhrase(services.ConvertToDisplayPanel("_BBB*BBB%BB"));
//            view.WritePhrase(services.ConvertToDisplayPanel("_CCC*CCC%CCC"));
//            view.WritePhrase(services.ConvertToDisplayPanel("_DDD*DDD%DDD^"));
//            view.WritePhrase(services.ConvertToDisplayPanel("_EEE*EEE%EEE^E"));
//            view.WritePhrase(services.ConvertToDisplayPanel("_FFF*FFF%FFF^FF"));
//            view.WritePhrase(services.ConvertToDisplayPanel("_GGG*GGG%GGG^GGG"));
//            view.WritePhrase(services.ConvertToDisplayPanel("_HHH*HHH%HHH^HHH#"));
//            view.WritePhrase(services.ConvertToDisplayPanel("_III*III%III^III#I"));
//            view.WritePhrase(services.ConvertToDisplayPanel("_JJJ*JJJ%JJJ^JJJ#JJ"));
//            view.WritePhrase(services.ConvertToDisplayPanel("_KKK*KKK%KKK^KKK#KKK"));
//            view.WritePhrase(services.ConvertToDisplayPanel("_LLL*LLL%LLL^LLL#LLL!"));

            view.Clear();
        }
    }
}
