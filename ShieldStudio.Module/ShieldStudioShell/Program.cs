using ShieldStudio.Views.ShieldStudio;

namespace ShieldStudioShell
{
    public class Program
    {
        public static void Main()
        {
            var view = new ShieldStudioView();

            while (true)
            {
                view.WriteWord('S', 'h', 'i', 'e', 400);
                view.WriteWord('l', 'd', 'S', 't', 400);
                view.WriteWord('u', 'd', 'i', 'o', 400);
                view.WriteWord('.', 'c', 'o', 'm', 400);
            }
        }

    }
}
