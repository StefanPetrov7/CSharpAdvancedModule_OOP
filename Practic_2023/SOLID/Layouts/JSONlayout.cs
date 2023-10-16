namespace SOLID.Layouts
{
    public class JSONlayout : ILayout
    {
        public string Template
        {
            get
            {
                return $"log:\n  date: {1},\n level: {2},\n message: {3}";
            }
        }
    }
}

