using LoggerTask.Models.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerTask.Models.Factories
{
    public class LayoutFactory
    {
        public ILayout CreateLayout(string layoutType)
        {
            ILayout layout = null;

            switch (layoutType)
            {
                case "SimpleLayout":
                    layout = new SimpleLayout();
                    break;

                case "XmlLayout":
                    layout = new XmlLayout();
                    break;

                default:
                    throw new ArgumentException("Invalid Layout type!");
            }

            return layout;
        }
    }
}
