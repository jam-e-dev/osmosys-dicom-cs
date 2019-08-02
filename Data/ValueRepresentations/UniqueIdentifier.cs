namespace Osmosys.Data.ValueRepresentations
{
    public class UniqueIdentifier : MultiStringElement
    {
        public UniqueIdentifier(DicomTag tag, string value) : base(tag, value)
        {
        }

        public UniqueIdentifier(DicomTag tag, string[] values) : base(tag, values)
        {
        }
    }
}