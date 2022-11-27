using System.Text;

namespace DataIndexer.Helpers.CharacterFilters
{
    public class CharacterFilter : ICharacterFilter
    {
        public string Filter(string orginalText)
        {
            var sb = new StringBuilder(orginalText.Length);

            foreach (char c in orginalText)
            {
                if (char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c))
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }
    }
}