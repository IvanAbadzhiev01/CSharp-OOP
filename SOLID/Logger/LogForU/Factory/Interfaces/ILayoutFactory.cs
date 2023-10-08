using LogForU.Core.Layouts.Interfaces;

namespace LogForU.Factory.Interfaces
{
    public interface ILayoutFactory
    {
        ILayout CreateLayout(string layout);
    }
}
