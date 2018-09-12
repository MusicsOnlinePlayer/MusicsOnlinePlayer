namespace Utility.Musics
{
<<<<<<< HEAD
    public interface IElement
    {
        ElementType Type { get; set; }
        string MID { get; set; }
        string Name { get; }
    }
=======
    [Serializable]
    public class Element
    {
        public ElementType Type { get; set; }
        public string MID { get; set; }
    }

    
>>>>>>> Rename IElement to Element (it 's not an interface but a base class)
}
