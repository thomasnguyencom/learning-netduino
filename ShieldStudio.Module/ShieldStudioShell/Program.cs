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
                view.WriteWord(new DisplayPanel('S', 'h', 'i', 'e'), 400);
                view.WriteWord(new DisplayPanel('l', 'd', 'S', 't'), 400);
                view.WriteWord(new DisplayPanel('u', 'd', 'i', 'o'), 400);
                view.WriteWord(new DisplayPanel('.', 'c', 'o', 'm'), 400);
            }
        }

    }
}
