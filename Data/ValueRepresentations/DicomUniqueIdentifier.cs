namespace Osmosys.Data.ValueRepresentations
{
    public class DicomUniqueIdentifier : DicomMultiStringElement
    {
        public DicomUniqueIdentifier(DicomTag tag, string value) : base(tag, value)
        {
        }

        public DicomUniqueIdentifier(DicomTag tag, string[] values) : base(tag, values)
        {
        }
    }
}