namespace Osmosys.Data.ValueRepresentations
{
    public class DicomCodeString : DicomMultiStringElement
    {
        public DicomCodeString(DicomTag tag, string value) : base(tag, value)
        {
        }

        public DicomCodeString(DicomTag tag, string[] values) : base(tag, values)
        {
        }
    }
}