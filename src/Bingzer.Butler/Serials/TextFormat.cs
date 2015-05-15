namespace Bingzer.Butler.Serials
{
    public class TextFormat : FormatBase
    {
        public override IFormat NewFormat()
        {
            return new TextFormat();
        }
    }
}
