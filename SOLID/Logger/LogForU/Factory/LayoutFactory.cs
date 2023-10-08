using LogForU.Core.Layouts;
using LogForU.Core.Layouts.Interfaces;
using LogForU.CustomLayout;
using LogForU.Exceptions;
using LogForU.Factory.Interfaces;

namespace LogForU.Factory
{
    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string layout)
        {
            switch (layout)
            {
                case "SimpleLayout":
                    return new SimpleLayout();
                case "XmlLayout":
                    return new XmlLayout();
                default:
                    throw new InvalidLayout();
            }
        }
    }
}
