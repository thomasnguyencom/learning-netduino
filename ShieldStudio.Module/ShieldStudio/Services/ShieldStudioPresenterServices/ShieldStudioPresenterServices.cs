using ShieldStudio.Views.ShieldStudio;

namespace ShieldStudio.Services.ShieldStudioPresenterServices
{
    public class ShieldStudioPresenterServices : IShieldStudioPresenterServices
    {
        public DisplayPanel[] ConvertToScrollingDisplayPanel(string message)
        {
            DisplayPanel[] displayPanel;
            if (message.Length >= 4)
            {
                displayPanel = new DisplayPanel[message.Length + 2];

                var position = 0;
                displayPanel[position++] = new DisplayPanel(' ', ' ', ' ', message[0]);
                displayPanel[position++] = new DisplayPanel(' ', ' ', message[0], message[1]);
                displayPanel[position++] = new DisplayPanel(' ', message[0], message[1], message[2]);

                for (int i = 0; i < message.Length - 4; i++)
                {
                    displayPanel[position++] = new DisplayPanel(message[i], message[i + 1], message[i + 2], message[i + 3]);
                }

                displayPanel[position++] = new DisplayPanel(message[message.Length - 3], message[message.Length - 2], message[message.Length - 1], ' ');
                displayPanel[position++] = new DisplayPanel(message[message.Length - 2], message[message.Length - 1], ' ', ' ');
                displayPanel[position++] = new DisplayPanel(message[message.Length - 1], ' ', ' ', ' ');
            }
            else if (message.Length == 3)
            {
                displayPanel = new DisplayPanel[message.Length + 3];

                var position = 0;
                displayPanel[position++] = new DisplayPanel(' ', ' ', ' ', message[0]);
                displayPanel[position++] = new DisplayPanel(' ', ' ', message[0], message[1]);
                displayPanel[position++] = new DisplayPanel(' ', message[0], message[1], message[2]);
                displayPanel[position++] = new DisplayPanel(message[0], message[1], message[2], ' ');
                displayPanel[position++] = new DisplayPanel(message[1], message[2], ' ', ' ');
                displayPanel[position++] = new DisplayPanel(message[2], ' ', ' ', ' ');
            }
            else if (message.Length == 2)
            {
                displayPanel = new DisplayPanel[message.Length + 3];

                var position = 0;
                displayPanel[position++] = new DisplayPanel(' ', ' ', ' ', message[0]);
                displayPanel[position++] = new DisplayPanel(' ', ' ', message[0], message[1]);
                displayPanel[position++] = new DisplayPanel(' ', message[0], message[1], ' ');
                displayPanel[position++] = new DisplayPanel(message[0], message[1], ' ', ' ');
                displayPanel[position++] = new DisplayPanel(message[1], ' ', ' ', ' ');
            }
            else if (message.Length == 1)
            {
                displayPanel = new DisplayPanel[message.Length + 3];

                var position = 0;
                displayPanel[position++] = new DisplayPanel(' ', ' ', ' ', message[0]);
                displayPanel[position++] = new DisplayPanel(' ', ' ', message[0], ' ');
                displayPanel[position++] = new DisplayPanel(' ', message[0], ' ', ' ');
                displayPanel[position++] = new DisplayPanel(message[0], ' ', ' ', ' ');
            }
            else
            {
                displayPanel = new DisplayPanel[0];
            }

            return displayPanel;
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
                    displayPanel[displayPanel.Length - 1] = asdf(message, pointer, length);
                }
                else
                {
                    for (var i = 0; i < displayPanel.Length - 1; i++)
                    {
                        displayPanel[i] = new DisplayPanel(message[pointer++],
                                                           message[pointer++], 
                                                           message[pointer++],
                                                           message[pointer++]);
                    }

                    displayPanel[displayPanel.Length - 1] = asdf(message, pointer, length);
                }
            }
            else
            {
                displayPanel = new DisplayPanel[] { DisplayPanel.Empty() };
            }

            return displayPanel;
        }

        private DisplayPanel asdf(string message, int pointer, int length)
        {
            DisplayPanel panel;

            if (length % 4 == 1)
            {
                panel = new DisplayPanel(message[pointer++],
                                         ' ',
                                         ' ',
                                         ' ');
            }
            else if (length % 4 == 2)
            {
                panel = new DisplayPanel(message[pointer++],
                                         message[pointer++],
                                         ' ',
                                         ' ');
            }
            else if (length%4 == 3)
            {
                panel = new DisplayPanel(message[pointer++],
                                         message[pointer++],
                                         message[pointer++],
                                         ' ');
            }
            else
            {
                panel = new DisplayPanel(message[pointer++],
                                         message[pointer++],
                                         message[pointer++],
                                         message[pointer++]);
            }

            return panel;
        }
    }
}