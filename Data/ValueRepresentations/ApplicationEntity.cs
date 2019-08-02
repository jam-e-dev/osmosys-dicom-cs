namespace Osmosys.Data.ValueRepresentations
{
    public class ApplicationEntity : MultiStringElement
    {
        public ApplicationEntity(DicomTag tag, string value) : base(tag, value)
        {
        }

        public ApplicationEntity(DicomTag tag, string[] values) : base(tag, values)
        {
        }
    }
}