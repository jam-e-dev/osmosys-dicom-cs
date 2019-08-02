namespace Osmosys.Data.ValueRepresentations
{
    public class DicomApplicationEntity : DicomMultiStringElement
    {
        public DicomApplicationEntity(DicomTag tag, string value) : base(tag, value)
        {
        }

        public DicomApplicationEntity(DicomTag tag, string[] values) : base(tag, values)
        {
        }
    }
}