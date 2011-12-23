using ShieldStudio.Views.ShieldStudio;

namespace ShieldStudio.Services.ShieldStudioPresenterServices
{
    public class ShieldStudioPresenterServices : IShieldStudioPresenterServices
    {
        public DisplayPanel[] GetSampleMessage()
        {
            return new DisplayPanel[] {
                    new DisplayPanel('1', '2', '3', '4'),
                    new DisplayPanel('2', '3', '4', '1'),
                    new DisplayPanel('3', '4', '1', '2'),
                    new DisplayPanel('4', '1', '2', '3')
                };
        }

        public DisplayPanel[] ConvertToDisplayPanel(string message)
        {
            DisplayPanel[] displayPanel;
            if (!message.Equals(string.Empty))
            {
                var length = message.Length;
                if (length%4 == 0)
                {
                    displayPanel = new DisplayPanel[length/4];
                }
                else
                {
                    displayPanel = new DisplayPanel[length/4 + 1];
                }

                var pointer = 0;

                if (displayPanel.Length == 1)
                {

                    if (length%4 == 1)
                    {
                        displayPanel[displayPanel.Length - 1] = new DisplayPanel(message[pointer++], ' ', ' ', ' ');
                    }
                    else if (length%4 == 2)
                    {
                        displayPanel[displayPanel.Length - 1] = new DisplayPanel(message[pointer++], message[pointer++],
                                                                                 ' ',
                                                                                 ' ');
                    }
                    else if (length%4 == 3)
                    {
                        displayPanel[displayPanel.Length - 1] = new DisplayPanel(message[pointer++], message[pointer++],
                                                                                 message[pointer++], ' ');
                    }
                    else
                    {
                        displayPanel[displayPanel.Length - 1] = new DisplayPanel(message[pointer++], message[pointer++],
                                                                                 message[pointer++],
                                                                                 message[pointer++]);
                    }
                }
                else
                {
                    for (var i = 0; i < displayPanel.Length - 1; i++)
                    {
                        displayPanel[i] = new DisplayPanel(message[pointer++], message[pointer++], message[pointer++],
                                                           message[pointer++]);
                    }

                    if (length%4 == 1)
                    {
                        displayPanel[displayPanel.Length - 1] = new DisplayPanel(message[pointer++], ' ', ' ', ' ');
                    }
                    else if (length%4 == 2)
                    {
                        displayPanel[displayPanel.Length - 1] = new DisplayPanel(message[pointer++], message[pointer++],
                                                                                 ' ',
                                                                                 ' ');
                    }
                    else if (length%4 == 3)
                    {
                        displayPanel[displayPanel.Length - 1] = new DisplayPanel(message[pointer++], message[pointer++],
                                                                                 message[pointer++], ' ');
                    }
                    else
                    {
                        displayPanel[displayPanel.Length - 1] = new DisplayPanel(message[pointer++], message[pointer++],
                                                                                 message[pointer++],
                                                                                 message[pointer++]);
                    }
                }
            }
            else
            {
                displayPanel = new DisplayPanel[] {new DisplayPanel(' ', ' ', ' ', ' ')};
            }

            return displayPanel;
        }
    }
}