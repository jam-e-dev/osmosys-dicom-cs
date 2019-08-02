namespace Osmosys.Data
{
    public class DicomTag
    {
        public int Group { get; }
        public int Element { get; }

        public DicomTag(int group, int element)
        {
            Group = group;
            Element = element;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((DicomTag) obj);
        }

        private bool Equals(DicomTag other)
        {
            return Group == other.Group && Element == other.Element;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Group * 397) ^ Element;
            }
        }

        public static bool operator ==(DicomTag left, DicomTag right) => Equals(left, right);

        public static bool operator !=(DicomTag left, DicomTag right) => !Equals(left, right);
    }
}