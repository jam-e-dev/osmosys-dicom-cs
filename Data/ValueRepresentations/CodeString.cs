namespace Osmosys.Data.ValueRepresentations
{
    public class CodeString : MultiStringElement
    {
        public CodeString(DicomTag tag, string value) : base(tag, value)
        {
        }

        public CodeString(DicomTag tag, string[] values) : base(tag, values)
        {
        }
    }
}