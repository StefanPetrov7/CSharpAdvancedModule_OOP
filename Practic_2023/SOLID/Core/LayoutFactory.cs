using SOLID.Core.Factories;
using SOLID.Layouts;

namespace SOLID.Core
{
    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            ILayout layout;

            switch (type)
            {
                case nameof(JSONlayout):
                    layout = new JSONlayout();
                    break;
                case nameof(SimpleLayout):
                    layout = new SimpleLayout();
                    break;
                case nameof(XmlLayout):
                    layout = new XmlLayout();
                    break;
                default:
                    throw new InvalidDataException();
            }

            return layout;
        }
    }
}

