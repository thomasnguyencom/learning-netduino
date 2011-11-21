using ShieldStudio.Services.ShieldStudioPresenterServices;

namespace ShieldStudioShell
{
    public class Program
    {
        public static void Main()
        {
            IShieldStudioPresenterServices service = new ShieldStudioPresenterServices();

            while (true)
            {
                service.WriteWord('S', 'h', 'i', 'e', 400);
                service.WriteWord('l', 'd', 'S', 't', 400);
                service.WriteWord('u', 'd', 'i', 'o', 400);
                service.WriteWord('.', 'c', 'o', 'm', 400);
            }
        }

    }
}
